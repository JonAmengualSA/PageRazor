using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebInter.Modelo;
using Newtonsoft.Json;
using RestSharp;

namespace WebInter.Pages
{
    public class PnaderiaModel : PageModel
    {
        public List<Panaderia> panaderias { get; set; }
            public int ID { get; set; }
            public string TipoPan { get; set; }
            public double UnitPrice { get; set; }
            public string Foto { get; set; }

        public void OnGet()
        {
            var client = new RestClient("https://localhost:44385/api/Panaderias");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            IRestResponse response = client.Execute(request);

            panaderias = JsonConvert.DeserializeObject<List<Panaderia>>(response.Content);
            
        }
        public void OnPostInsert(int ID,string TipoPan,Double UnitPrice,string Foto)
        {

            var pan = new RestClient("https://localhost:44385/api/Panaderias");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded"); // imprescindible para enlazar formulario valores con objeto de web api

            // agregamos parameters de formulario
            request.AddParameter("ID", ID);
            request.AddParameter("TipoPan", TipoPan);
            request.AddParameter("UnitPrice", UnitPrice);
            request.AddParameter("Foto", Foto);
            IRestResponse response = pan.Post(request);

            OnGet();

        }

        public void OnPostDelete(int ID)
        {
            
            var pan = new RestClient("https://localhost:44385/api/Panaderias");
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded"); // imprescindible para enlazar formulario valores con objeto de web api

            // agregamos parameters de formulario
            request.AddParameter("ID", ID);
            IRestResponse response = pan.Delete(request);

            OnGet();
        }

        public void OnPostEdit(int ID,string TipoPan, Double UnitPrice, string Foto)
        {

            var pan = new RestClient("https://localhost:44385/api/Panaderias");
            var request = new RestRequest(Method.PUT);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded"); // imprescindible para enlazar formulario valores con objeto de web api

            // agregamos parameters de formulario
            request.AddParameter("ID", ID);
            request.AddParameter("TipoPan", TipoPan);
            request.AddParameter("UnitPrice", UnitPrice);
            request.AddParameter("Foto", Foto);
            IRestResponse response = pan.Put(request);

            OnGet();
        }

    }
}
