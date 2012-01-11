using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using System.Text;
using System.Text.RegularExpressions;

namespace TiviK2Plus_WebServiceApp.Core
{
    public static class Extractor
    {
        public static string ExtractSchedule(DateTime ngay, string linkNguon, string moTaRutTrich)
        {
            linkNguon = linkNguon.Replace(@"{dd}", ngay.Day.ToString("00"));
            linkNguon = linkNguon.Replace(@"{mm}", ngay.Month.ToString("00"));
            linkNguon = linkNguon.Replace(@"{yyyy}", ngay.Year.ToString());
            linkNguon = linkNguon.Replace(@"{d}", ngay.Day.ToString("##"));
            linkNguon = linkNguon.Replace(@"{m}", ngay.Month.ToString("##"));
            linkNguon = linkNguon.Replace(@"{yy}", (ngay.Year % 100).ToString());

            HttpWebRequest request = WebRequest.Create(linkNguon) as HttpWebRequest;
            request.Method = "GET";

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream respStrm = response.GetResponseStream();
                
                if (moTaRutTrich == "")
                {
                    StreamReader sr = new StreamReader(respStrm);
                    string result = sr.ReadToEnd();
                    sr.Close();

                    return result;
                }
                else
                {
                    HtmlDocument hdoc = new HtmlDocument();
                    hdoc.Load(respStrm, Encoding.UTF8);
                    respStrm.Close();

                    if (moTaRutTrich.StartsWith("regex "))
                    {
                        moTaRutTrich = moTaRutTrich.Remove(0, "regex ".Length);
                        Match match = new Regex(moTaRutTrich).Match(hdoc.DocumentNode.OuterHtml);
                        return match.Value;
                    }
                    else if (moTaRutTrich.StartsWith("xpath "))
                    { 
                        moTaRutTrich = moTaRutTrich.Remove(0, "xpath ".Length);
                        HtmlNode target = hdoc.DocumentNode.SelectSingleNode(moTaRutTrich);
                        if (target != null)
                        {
                            return target.OuterHtml;
                        }                    
                    }
                }
            }

            return "Schedule Not Found";
        }
    }
}