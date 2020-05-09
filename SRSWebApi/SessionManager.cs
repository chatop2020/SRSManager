using System;
using System.Collections.Generic;
using System.Threading;

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
        private List<Session> sessionList= new List<Session>();

        private byte addMin = 5;
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
                    if (session.Expires >= Environment.TickCount64)
                    {
                        sessionList.Remove(session);
                    }
                }
            }
            Thread.Sleep(5000);
            }
        }
        public SessionManager(){
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

        public Session NewSession(string allowKey)
        {
            Session session = new Session()
            {
                AllowKey = allowKey,
                SessionCode = Program.common.CreateUUID(),
                RefreshCode = Program.common.CreateUUID(),
                Expires = Environment.TickCount64 + (addMin * 1000 * 50),
            };
            lock (this)
            {
               sessionList.Add(session); 
            }

            return session;
        }
    }
}