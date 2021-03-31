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
            Offer_Job p = new Offer_Job();
            p.Id_Usuario = 41;
            p.Id_Categoria = 3;
            p.Posicion = "Tecnologo de redes";
            p.Requisitos = "1 año de experiencia en linux";
            p.Fecha = DateTime.Now;
            p.Descripcion = "Los administradores de red son básicamente el " +
                "equivalente de red de los administradores de sistemas: mantienen el " +
                "hardware y software de la red";

            p.Ciudad = "Bahoruco";
            p.Compañia = "Tecnologica Cervantes";
            p.Tipo = "Full-time";
            p.Logo = "logo.jpg";
            ServicioWeb(p);

            Console.WriteLine("Hasta aquí el programa");
            Console.ReadLine();
        }

        public static async void ServicioWeb(Offer_Job usuario)
        {
            //Serializas tu objeto persona con la libreria Newtonsoft y la clase static JsonConvert, y el metodo Serialize lo hace automaticamente pasandole por parametro tu objeto Persona
            var json = JsonConvert.SerializeObject(usuario);

            //Asi quedaria serializado tu objeto
            //{"Documento":1234,"Nombre":"MiNombre","Apellido":"MiApellido"}

            //Esta clase te permite hacer una conexion.
            HttpClient httpClient = new HttpClient();
            //Creas el contenido que enviaras a traves de esa clase, le pasas tu json, le das un formato y por ultimo decis que sera del tipo json
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            //Usas el metodo post para enviar el contenido que creaste y le pasas la url del servicio al que queres comunicarte y le pasas
            //el resultado a la variable response para saber si el resultado fue ok o no.
            var response = await httpClient.PostAsync("https://webapi-prog3.azurewebsites.net/api/Usuario1", content);
                
            if (response.StatusCode == HttpStatusCode.OK)
            {
                //tu servicio respondio bien y puedes hacer alguna accion si necesitas saber la respuesta
                Console.WriteLine("El Nuevo usuario fue añadido mediante codigo..........");
            }
            
            //Para desearlizar algun json, lo mas facil siempre es contar con el modelo del objeto como la clase persona
            //Le indicas el tipo de objeto al que tiene que deserializar y le pasas el json por parametro y en la variable j vas
            // a tener el resultado de tu objeto creado.
           
        }
    }
}