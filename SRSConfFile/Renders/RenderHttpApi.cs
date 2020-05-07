using System.Collections.Generic;
using SRSConfFile.SRSConfClass;

namespace SRSConfFile.Renders
{
    public static class RenderHttpApi
    {
        public static void Render_RawApi(SectionBody scbin, SrsSystemConfClass sccout, string instanceName = "")
        {
            if (sccout.Http_api?.Raw_Api == null)
                if (sccout.Http_api != null)
                    sccout.Http_api.Raw_Api = new RawApi();
            if (sccout.Http_api != null)
            {
                if (sccout.Http_api.Raw_Api != null)
                {
                    sccout.Http_api.Raw_Api.SectionsName = "raw_api";
                    if (scbin.BodyList != null)
                        foreach (string s in scbin.BodyList)
                        {
                            if (!s.Trim().EndsWith(";")) continue;
                            KeyValuePair<string, string> tmpkv = Common.GetKV(s);
                            if (string.IsNullOrEmpty(tmpkv.Key)) continue;

                            string cmd = tmpkv.Key.Trim().ToLower();
                            switch (cmd)
                            {
                                case "enabled":
                                    sccout.Http_api.Raw_Api.Enabled = Common.str2bool(tmpkv.Value);
                                    break;
                                case "allow_reload":
                                    sccout.Http_api.Raw_Api.Allow_reload = Common.str2bool(tmpkv.Value);
                                    break;
                                case "allow_query":
                                    sccout.Http_api.Raw_Api.Allow_query = Common.str2bool(tmpkv.Value);
                                    break;
                                case "allow_update":
                                    sccout.Http_api.Raw_Api.Allow_update = Common.str2bool(tmpkv.Value);
                                    break;
                            }
                        }
                }
            }
        }

        public static void Render(SectionBody scbin, SrsSystemConfClass sccout, string instanceName = "")
        {
            if (sccout.Http_api == null) sccout.Http_api = new SrsHttpApiConfClass();
            sccout.Http_api.SectionsName = "http_api";
            if (scbin.BodyList != null)
                foreach (string s in scbin.BodyList)
                {
                    if (!s.Trim().EndsWith(";")) continue;
                    KeyValuePair<string, string> tmpkv = Common.GetKV(s);
                    if (string.IsNullOrEmpty(tmpkv.Key)) continue;

                    string cmd = tmpkv.Key.Trim().ToLower();
                    switch (cmd)
                    {
                        case "enabled":
                            sccout.Http_api.Enabled = Common.str2bool(tmpkv.Value);
                            break;
                        case "listen":
                            sccout.Http_api.Listen = Common.str2ushort(tmpkv.Value);
                            break;
                        case "crossdomain":
                            sccout.Http_api.Crossdomain = Common.str2bool(tmpkv.Value);
                            break;
                        case "device_id":
                            break;
                    }
                }

            if (scbin.SubSections != null && scbin.SubSections.Count > 0)
            {
                foreach (SectionBody scb in scbin.SubSections)
                {
                    Render_RawApi(scb, sccout);
                }
            }
        }
    }
}