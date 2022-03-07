using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;
using AppRecibos.Models;
using Newtonsoft.Json;
using System.Text;

namespace AppRecibos.Repositories
{
    public class RecibosRepository
    {
        HttpClient client;
        Uri address = new Uri("http://localhost:5000/api");

        public RecibosRepository()
        {
            client = new HttpClient();
            client.BaseAddress = address;
        }

        // GET
        public List<Recibo> GetRecibos()
        {
            List<Recibo> ListaRecibos = new List<Recibo>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Recibos").Result;

            if(response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                ListaRecibos = JsonConvert.DeserializeObject<List<Recibo>>(data);
            }
            return ListaRecibos;
        }

        // UPDATE
        public Recibo UpdateRecibo(int id)
        {
            Recibo Recibo = new Recibo();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Recibos/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                Recibo = JsonConvert.DeserializeObject<Recibo>(data);
            }
            return Recibo;
        }

        // DELETE
        public Recibo DeleteRecibo(int id)
        {
            Recibo Recibo = new Recibo();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Recibos/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                Recibo = JsonConvert.DeserializeObject<Recibo>(data);
            }
            return Recibo;
        }
    }
}
