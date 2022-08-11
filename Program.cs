using System.IO;
using System.Text.Json.Serialization;
using System.Net;
using System.Text.Json;
namespace ConsumoApi
{
    class Program
    {
        static void Main(string[] args){
            GetCivis();
        }

        public static void GetCivis(){
            var url=$"https://age-of-empires-2-api.herokuapp.com/api/v1/civilizations";
            var request=(HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
             try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            ListadeCivilizaciones Civilizaciones;
                            Civilizaciones = JsonSerializer.Deserialize<ListadeCivilizaciones>(responseBody);
                        
                            foreach ( Civilization Civilizacion in Civilizaciones.Civilizations)
                            {
                              Console.WriteLine("Nombre: " + Civilizacion.Name); 
                              Console.WriteLine("Expansion2: " + Civilizacion.Expansion);       
                            }
                            

                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("Problemas de acceso a la API");
            }
        }
    }
    
}
