using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpCalcServer
{
    class HttpServer
    {
        HttpListener listener;

        public HttpServer(string uri)
        {
            listener = new HttpListener();
            listener.Prefixes.Add(uri);
        }

        public void Start()
        {
            listener.Start();
            Console.WriteLine("Listening...");

            while(true)
            {
                try
                {
                    HttpListenerContext context = listener.GetContext();
                    Console.WriteLine("Join To Server");
                    Receiver(context);
                }
                catch
                {

                }
            }
        }

        public void Receiver(HttpListenerContext context)
        {
            string a = "";
            string b = "";
            string op = "";

            if(context.Request.HttpMethod == "POST")
            {
                string[] param = new StreamReader(context.Request.InputStream).ReadToEnd().Split('=', '&');
                a = param[1];
                b = param[3];
                op = param[5];
            }
            else
            {
                a = context.Request.QueryString["a"];
                b = context.Request.QueryString["b"];
                op = context.Request.QueryString["op"];
            }

            string data = Calculate.Calc(a, b, op).ToString();

            context.Response.ContentType = "text/plain";
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            context.Response.ContentLength64 = data.Length;
            context.Response.OutputStream.Write(Encoding.ASCII.GetBytes(data), 0, data.Length);
            //context.Response.OutputStream.Close();
        }
    }
}
