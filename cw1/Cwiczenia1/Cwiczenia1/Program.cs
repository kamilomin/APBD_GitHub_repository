using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cwiczenia1
{
    public class Program
    {
       public static async Task Main(string[] args)
        {
            var client = new HttpClient(); //zamiast var moze byc HttpClient
            HttpResponseMessage result =await client.GetAsync("https://www.pja.edu.pl");
            //getAsync to metody asynchroniczne ktore zwracaja taska
            //ThreadPool jest taka pula wątków chyba lepsza od New Thread 
            //JS -> promise async/await
            //Java -> Future<T>
            //C# Task<T> - async/await
           /* button.serOnClickHandler(new
            {

            });*/
            if (result.IsSuccessStatusCode) //2xx // tu nie ma nawiasów () ponieważ w c# uznano ze jest ot strasznie redenudant i dlatego zrobiono propertis i dlatego mozna wygenerowac ekwiwalent gettera settera np var s = st. getImie() robi to samo co var s = st.Imie
            {
                string html = await result.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+",RegexOptions.IgnoreCase);
                MatchCollection matches = regex.Matches(html);
                foreach(var m in matches){
                    Console.WriteLine(m.ToString());
                }
            }

            Console.WriteLine("Koniec");
        }
    }
}
