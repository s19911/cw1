using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cw1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";
            var client = new HttpClient();
            var result = await client.GetAsync(url);

            if (result.IsSuccessStatusCode) 
            {
                var html = await result.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+",
                    RegexOptions.IgnoreCase);
                var matches = regex.Matches(html);

                foreach (var m in matches)
                {
                    Console.WriteLine(m.ToString());
                }

            }
        }
    }
}
