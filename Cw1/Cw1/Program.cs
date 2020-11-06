using Microsoft.VisualBasic;
using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {

        public static async Task Main(string[] args)
        {

            var httpClient = new HttpClient();

            HttpResponseMessage response;

            response = await httpClient.GetAsync(args[0]);


            if (response.IsSuccessStatusCode)
            {
                var res2 = await response.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:[.][a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?[.])+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");



                MatchCollection matches = regex.Matches(res2);
                foreach (var m in matches)
                {
                    Console.WriteLine(m);
                }

            }

        }
    }
}

