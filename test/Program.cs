using System;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace test
{
    class Program
    {

        private static readonly HttpClient client = new HttpClient();
        private static String apiurl = "http://api.arrow.com/itemservice/v3/en/search/list";
        private static String apilogin = "supremecomponents";
        private static String apikey = "07b23129ead7328ca4f14a9c08fa89f333e30d08042a5ec4d211e7b66851825d";

        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            client.DefaultRequestHeaders.Add("Content-Typec", "text/plain");

            var clientip = "127.0.0.1";
            var parts = "[{\"partNum\":\"24AA256-I/MS\",\"mfr\":\"MICRO CHIP\"},{\"partNum\":\"LT1805CS%23PBF\",\"mfr\":\"Arrow\'s\"},{\"partNum\":\"MAX32,32CAE\",\"mfr\":\"MAXIM\"},{\"partNum\":\"MIC5319-3.3YD5-.TR\"},{\"partNum\":\"SSL1523P/N2112\",\"mfr\":\"NXP\"}]";
            // var parts = "[{\"partNum\":\"24AA256-I/MS\",\"mfr\":\"MICRO CHIP\"}]";
            var url = apiurl + "?req={\"request\":{\"login\":\"" + apilogin + "\",\"apikey\":\"" + apikey + "\",\"remoteIp\":\"" + clientip + "\",\"useExact\":true,\"parts\":" + parts + "}}";

            Console.Write(url);

            // var url1 = "http://api.arrow.com/itemservice/v3/en/search/list?req={\"request\":{\"login\":\"supremecomponents\",\"apikey\":\"07b23129ead7328ca4f14a9c08fa89f333e30d08042a5ec4d211e7b66851825d\",\"remoteIp\":\"127.0.0.1\",\"useExact\":true,\"parts\":[{\"partNum\":\"24AA256-I/MS\",\"mfr\":\"MICRO CHIP\"}]}}";

            var stringTask = client.GetStringAsync(url);

            var msg = await stringTask;
            Console.Write(msg);


        }

    }
}
