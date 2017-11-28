using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using notelohell.Models;

namespace notelohell.Services
{
    public class OwAPI
    {
        public OwAPI() { }
        public string SoBusca(string tag)
        {
            if (tag.IndexOf("#") > 0)
                tag = tag.Replace("#", "-");
            string data = string.Empty;
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("Accept-Language", " en-US");
                wc.Headers.Add("Accept", " text/html, application/xhtml+xml, */*");
                wc.Headers.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)");
                string url = "http://owapi.net/api/v3/u/" + tag + "/blob";
                data = wc.DownloadString(url);
            }      

            return data;
        }
        public string Buscar(string tag, UsersModel usuario)
        {
            if (tag.IndexOf("#") > 0)
                tag = tag.Replace("#", "-");
            string data = string.Empty;
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("Accept-Language", " en-US");
                wc.Headers.Add("Accept", " text/html, application/xhtml+xml, */*");
                wc.Headers.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)");
                string url = "http://owapi.net/api/v3/u/" + tag + "/blob";
                data = wc.DownloadString(url);
            }
            if(usuario != null)
            {
                if(usuario.GameTag.Replace("#","-") == tag)
                SalvarDados(data, usuario);
            }
               
            return data;
        }

        private void SalvarDados(string data,UsersModel usuario)
        {
            usuario.SalvarDados(data);
        }
    }
}