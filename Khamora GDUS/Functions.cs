using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Khamora_GDUS.osint
{
    public class Functions
    {
        public string GetPageSource(string url)
        {
            string str = string.Empty;
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Timeout = 5000;
                httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
                str = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream()).ReadToEnd();
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception exception = ex;
                Console.WriteLine(url + ": " + exception.Message);
                ProjectData.ClearProjectError();
            }
            return str;
        }

        public object GetMatches(string toSearch, string regexPattern)
        {
            return (object)Regex.Matches(toSearch, regexPattern, RegexOptions.Multiline);
        }

        public bool IsUri(string source)
        {
            return !string.IsNullOrEmpty(source) && Uri.IsWellFormedUriString(source, UriKind.RelativeOrAbsolute) && Uri.TryCreate(source, UriKind.RelativeOrAbsolute, out Uri _);
        }

        public void SearchGoogle(string query, ref ListBox g)
        {
            string pageSource = this.GetPageSource("http://www.google.com/search?num=100&q=\"" + query + "\"");
            IEnumerator enumerator;
            try
            {
                enumerator = new Regex("url\\?q=(.*?)&").Matches(pageSource).GetEnumerator();
                while (enumerator.MoveNext())
                {
                    string str = Conversions.ToString(NewLateBinding.LateGet(NewLateBinding.LateGet(RuntimeHelpers.GetObjectValue(enumerator.Current), (System.Type)null, "groups", new object[1]
                    {
            (object) 1
                    }, (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Value", new object[0], (string[])null, (System.Type[])null, (bool[])null));
                    if (!g.Items.Contains((object)str) && !str.Contains("googleusercontent") && !str.Contains("/settings/ads"))
                    {
                        g.Items.Add((object)("Possible Connection: " + WebUtility.HtmlDecode(str)));
                        Console.WriteLine(str);
                    }
                }
            }
            finally
            {

            }
        }
    }
}