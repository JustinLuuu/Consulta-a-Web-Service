using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Net.Http;

namespace ConsoleApp1
{
    public class Offer_Job
    {
        public int Id { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Categoria { get; set; }
        public string Tipo { get; set; }
        public string Logo { get; set; }
        public string Posicion { get; set; }
        public string Ciudad { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public string Requisitos { get; set; }
        public string Compañia { get; set; }
    }


    class Program
    {
        

        static void Main(string[] args)
        {
            Offer_Job p = new Offer_Job(){
                Id_Usuario = 41,
                Id_Categoria = 3,
                Requisitos = "Requisito dificil",
                Fecha = DateTime.Now,
                Descripcion = "Descripcion asombrosa",
                Ciudad = "Springfield",
                Compañia = "JJJ",
                Tipo = "Full-time",
                Logo = "logo.jpg"              
            };
           
            ServicioWeb(p);

            Console.WriteLine("Listo");
            Console.ReadLine();
        }

        public static async void ServicioWeb(Offer_Job usuario)
        {
            //Serializas tu objeto persona con la libreria Newtonsoft y la clase static JsonConvert, y el metodo Serialize lo hace automaticamente pasandole por parametro tu objeto Persona
            var json = JsonConvert.SerializeObject(usuario);

            //Asi quedaria serializado el objeto
            //{"Documento":1234,"Nombre":"MiNombre","Apellido":"MiApellido"}

            //Esta clase permite hacer conexiones
            HttpClient httpClient = new HttpClient();
            //Creas el contenido que enviaras a traves de esa clase, le pasas tu json, le das un formato y por ultimo decis que sera del tipo json
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            //Utilizar el metodo post para enviar el contenido que creado y asimismo pasandole la url del servicio al que quieres comunicar reteniendo el
            //resultado sobre la variable response para saber si la respuesta fue OK o rejected.
            var response = await httpClient.PostAsync("https://webapi-prog3.azurewebsites.net/api/Usuario1", content);
                
            if (response.StatusCode == HttpStatusCode.OK)
            {
                //el webservice ha respondido sin problemas
                Console.WriteLine(HttpStatusCode.ToString());
            }
            
        }
    }
}
