using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Easy.Public;
using Easy.Public.MyLog;
using Easy.Rpc.directory;
using Easy.Rpc.Monitor;
using Microsoft.Owin.Hosting;
using System.Configuration;
using System.IO;

namespace study.Menu.Api
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = IpHelper.LoopbackIp();
            int port = GetPort(ip);
            var isRegsiterToRegiserCenter = StringHelper.ToInt32(ConfigurationManager.AppSettings["isRegsiterToRegiserCenter"], 1);
            if (isRegsiterToRegiserCenter == 1)
            {
                string registerUrl = ConfigurationManager.AppSettings["registerUrl"];
                string redisUrl = ConfigurationManager.AppSettings["redisUrl"];
                //int databaseIndex = int.Parse(ConfigurationManager.AppSettings["databaseIndex"]);
                var builder = new RedisDirectoryBuilder(registerUrl, redisUrl);
                builder.Build(new MySelfInfo() {
                    Description = "菜品服务",
                    Directory = "StudyMenu",
                    Status = 1,
                    Weight = 10,
                    Url = string.Format("http://{0}:{1}/api/", ip, port),
                    Ip = ip + ":" + port
                },new string[0],new string[] {
                    "Category/Add",
                    "Category/Select"
                });

                //// todo:注册到监控中心
            }

            //string baseUrl = ConfigurationManager.AppSettings["ServiceAddress"];
            string baseUrl = string.Format("http://{0}:{1}/", ip, port);
            Console.WriteLine(baseUrl);
            using (WebApp.Start<Startup>(new StartOptions(baseUrl)))
            {
                System.Console.WriteLine("服务启动中...");
                while (true)
                {
                    Thread.Sleep(80000012);
                }
            }
        }

        private static int GetPort(string ip)
        {
            string portfile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "port.txt");

            if (File.Exists(portfile))
            {
                return int.Parse(File.ReadAllText(portfile));
            }

            int port = Easy.Public.IpHelper.GetAvailablePort(ip, 8000, 9999);

            File.WriteAllText(portfile, port.ToString());
            return port;
        }
    }
}
