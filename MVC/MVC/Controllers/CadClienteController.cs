using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System;
using MVC.Models;
using System.Net;
using PagedList;

namespace MVC.Controllers
{
    public class CadClienteController : Controller
    {
        public ActionResult Index(int? pagina)
        {
            int paginaTamanho = 4;
            int paginaNumero = (pagina ?? 1);

            IEnumerable<CadCliente> clientes = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7267/api");

                //HTTP GET
                var responseTask = client.GetAsync("Api/cadCliente");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CadCliente>>();
                    readTask.Wait();
                    clientes = readTask.Result;
                }
                else
                {
                    clientes = Enumerable.Empty<CadCliente>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(clientes.ToPagedList(paginaNumero, paginaTamanho));
            }
        }
        [HttpGet]
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(CadCliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest();
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7267/api");
                //HTTP POST
                var postTask = client.PostAsJsonAsync<CadCliente>("api/cadCliente", cliente);
                postTask.Wait();
                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Erro no Servidor. Contacte o Administrador.");
            return View(cliente);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            CadCliente cliente = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7267/api/CadCliente/");

                //HTTP GET
                var responseTask = client.GetAsync(id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CadCliente>();
                    readTask.Wait();
                    cliente = readTask.Result;
                }
            }
            return View(cliente);
        }
        [HttpPost]
        public ActionResult Edit(CadCliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest();
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7267/api/");
                //HTTP PUT
                var putTask = client.PutAsJsonAsync<CadCliente>("cadCliente/", cliente);
                putTask.Wait();
                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(cliente);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            CadCliente cliente = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7267/api");
                //HTTP DELETE
                var deleteTask = client.DeleteAsync("api/cadCliente/?id=" + id.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(cliente);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            CadCliente contato = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7267/api/CadCliente/");

                //HTTP GET
                var responseTask = client.GetAsync(id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CadCliente>();
                    readTask.Wait();
                    contato = readTask.Result;
                }
            }
            return View(contato);
        }
        public ActionResult Search(string nome)
        {
            IEnumerable<CadCliente> cliente = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7267/api/CadCliente/");
                //HTTP GET
                var responseTask = client.GetAsync("Api/"+nome);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CadCliente>>();
                    readTask.Wait();
                    cliente = readTask.Result;
                }
                else
                {
                    cliente = Enumerable.Empty<CadCliente>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(cliente);
            }
        }
    }
}

