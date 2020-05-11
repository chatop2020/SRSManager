using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNetCore.Mvc;

namespace SRSWebApi
{
    public class Session
    {
        private string allowKey;
        private string sessionCode;
        private string refreshCode;
        private long expires; //过期时间

        public string AllowKey
        {
            get => allowKey;
            set => allowKey = value;
        }

        public string RefreshCode
        {
            get => refreshCode;
            set => refreshCode = value;
        }

        public string SessionCode
        {
            get => sessionCode;
            set => sessionCode = value;
        }

        public long Expires
        {
            get => expires;
            set => expires = value;
        }
    }

    public class SessionManager
    {
        private List<Session> sessionList = new List<Session>();

        private byte addMin = 50;

        public List<Session> SessionList
        {
            get => sessionList;
            set => sessionList = value;
        }

        private void clearExpires()
        {
            while (true)
            {
                lock (this)
                {
                    foreach (var session in sessionList)
                    {
                        if (session.Expires <= Program.common.GetTimeStampMilliseconds())
                        {
                            sessionList.Remove(session);
                        }
                    }
                }

                Thread.Sleep(5000);
            }
        }

        public SessionManager()
        {
            new Thread(new ThreadStart(delegate
            {
                try
                {
                    clearExpires();
                }
                catch (Exception ex)
                {
                    //
                }
            })).Start();
        }

        /// <summary>
        /// 刷新Session
        /// </summary>
        /// <param name="session">旧的session</param>
        /// <returns></returns>

        public Session RefreshSession(Session session)
        {
            bool found = false;
            int i = 0;
            lock (this)
            {
                for (i = 0; i <= sessionList.Count - 1; i++)
                {
                    if (sessionList[i].AllowKey.Trim().ToLower().Equals(session.AllowKey.Trim().ToLower()) &&
                        sessionList[i].RefreshCode.Trim().ToLower().Equals(session.RefreshCode.Trim().ToLower())
                    )
                    {
                        sessionList[i].SessionCode = Program.common.CreateUUID();
                        sessionList[i].RefreshCode = Program.common.CreateUUID();
                        sessionList[i].Expires = Program.common.GetTimeStampMilliseconds() + (addMin * 1000 * 60);
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    return sessionList[i];
                }
                else
                {
                    return null;
                }
            }
        }

        public Session NewSession(string allowKey)
        {
            Session session = new Session()
            {
                AllowKey = allowKey,
                SessionCode = Program.common.CreateUUID(),
                RefreshCode = Program.common.CreateUUID(),
                Expires = Program.common.GetTimeStampMilliseconds() + (addMin * 1000 * 60),
            };
            lock (this)
            {
                sessionList.Add(session);
            }

            return session;
        }
    }
}