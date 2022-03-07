using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AppRecibos.Repositories;
using AppRecibos.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace AppRecibos.Controllers
{
    public class RecibosController : Controller
    {
        HttpClient client;
        Uri address = new Uri("http://localhost:5000/api");

        public RecibosController()
        {
            client = new HttpClient();
            client.BaseAddress = address;
        }

        public IActionResult Index()
        {
            RecibosRepository repository = new RecibosRepository();
            return View(repository.GetRecibos());
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Recibo recibo)
        {
            if (ModelState.IsValid)
            {
                var data = JsonConvert.SerializeObject(recibo);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/Recibos", content).Result;

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            return View(recibo);
        }

        public IActionResult Editar(int id)
        {
            RecibosRepository repository = new RecibosRepository();
            return View(repository.UpdateRecibo(id));
        }

        [HttpPost]
        public IActionResult Editar(Recibo recibo)
        {
            if (ModelState.IsValid)
            {
                var data = JsonConvert.SerializeObject(recibo);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/Recibos/" + recibo.Id, content).Result;

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            return View(recibo);
        }

        public IActionResult Eliminar(int id)
        {
            RecibosRepository repository = new RecibosRepository();
            return View(repository.DeleteRecibo(id));
        }

        [HttpPost]
        public IActionResult Eliminar(Recibo recibo)
        {
            var data = JsonConvert.SerializeObject(recibo);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Recibos/" + recibo.Id).Result;

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(recibo);
        }
    }
}
