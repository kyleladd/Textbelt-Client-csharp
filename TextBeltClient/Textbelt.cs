using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextbeltClient
{
    //public class TextBelt
    //{
    //    public string number { get; set; }
    //    public string message { get; set; }

    //    public TextBelt(string number,string message) {
    //        this.number = number;
    //        this.message = message;
    //    }
    //    public bool sendMessage(){
            
    //        return false;
    //    }
    //}
    public class Textbelt
    {
        public static bool sendMessage(string number, string message)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            var obj = new { number = number, message = message };
            byte[] data = encoder.GetBytes(JsonConvert.SerializeObject(obj));
            HttpWebRequest request = WebRequest.Create("http://textbelt.com/text") as HttpWebRequest;
            request.ContentType = "application/json";
            request.Method = "POST";
            request.ContentLength = data.Length;
            try
            {
                request.GetRequestStream().Write(data, 0, data.Length);
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    var rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    dynamic jsonResponse = JObject.Parse(rawJson);
                    return Convert.ToBoolean(jsonResponse.success);
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }
    }
}
