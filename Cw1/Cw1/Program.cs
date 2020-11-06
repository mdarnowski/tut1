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

            try
            {
                if (args.Length > 0)
                {
                    var httpClient = new HttpClient();

                    HttpResponseMessage response;
                    
                    response = await httpClient.GetAsync(args[0]);
                    try
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            var res2 = await response.Content.ReadAsStringAsync();
                            var regex = new Regex("[a-zA-Z0-9]+@[a-z]+[.][a-z]+");

                            var mailDiscovered = false;

                            MatchCollection matches = regex.Matches(res2);
                            foreach (var m in matches)
                            {
                                Console.WriteLine(m);
                                mailDiscovered = true;
                            }

                            if (!mailDiscovered)
                                Console.WriteLine("No email addresses found");
                        }


                    }
                    catch
                    {
                        Console.WriteLine("err while downloading the page");
                      
                    }


                    httpClient.Dispose();

                }
                else
                    throw new ArgumentException("args");

            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}