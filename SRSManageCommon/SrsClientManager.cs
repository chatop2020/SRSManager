using System;
using System.Collections.Generic;
using System.Threading;
using SRSManageCommon;
using SRSManageCommon.Structs;

namespace SRSManageCommon
{
    public class SrsClientManager
    {
        private List<Channels> GetGB28181Channels(string httpUri)
        {
            string act = "/api/v1/gb28181?action=query_channel";
            string url = httpUri + act;
            try
            {
                string tmpStr = SRSManageCommon.NetHelper.Get(url);
                var ret = JsonHelper.FromJson<SrsT28181QueryChannelModule>(tmpStr);
                if (ret.Code == 0 && ret.Data != null)
                {
                    return ret.Data.Channels;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private void Run()
        {
            while (true)
            {
                #region 补28181 monitorip 地址
                var ret = GetGB28181Channels("");
                if (ret != null)
                {
                    foreach (var r in ret)
                    {
                        if (!string.IsNullOrEmpty(r.Rtp_Peer_Ip) && !string.IsNullOrEmpty(r.Stream))
                        {
                            var reti = OrmService.Db.Update<Client>().Set(x => x.MonitorIp, r.Rtp_Peer_Ip)
                                .Where(x => x.Stream.Equals(r.Stream)).ExecuteAffrows();
                        }
                    }
                }

                #endregion


                Thread.Sleep(1000);
            }
        }

        public SrsClientManager()
        {
            new Thread(new ThreadStart(delegate
            {
                try
                {
                    Run();
                }
                catch (Exception ex)
                {
                    // ignored
                    Console.WriteLine(ex.Message);
                }
            })).Start();
        }
    }
}