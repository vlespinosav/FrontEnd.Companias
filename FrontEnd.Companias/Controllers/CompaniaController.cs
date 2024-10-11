using FrontEnd.Companias.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FrontEnd.Companias.Controllers
{
    public class CompaniaController : Controller
    {
        private readonly IConfiguration configuration;

        public CompaniaController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult> ObtenerCompania()
        {
            List<Compania> listaCompania = new List<Compania>();
            string UrlBusqueda = configuration["UrlApiBusqueda"];
            try
            {
                // Se onsume Api para obtener compañias
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(UrlBusqueda);
                listaCompania = JsonConvert.DeserializeObject<List<Compania>>(json);
            }
            catch (Exception ex)
            {

                throw;
            }
            
            return View(listaCompania);
        }

        public ActionResult GuardarCompania()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> GuardarCompania(Compania compania)
        {
            HttpResponseMessage result = new HttpResponseMessage();
            string UrlGuardar = configuration["UrlApiGuardar"];
            try
            {
                //Validamos que los campos no esten vacios
                if (ModelState.IsValid)
                {
                    //Se consume Api para Guardar Registro Compania
                    var httpClient = new HttpClient();
                     result = await httpClient.PostAsJsonAsync<Compania>(UrlGuardar, compania);
                    ViewBag.IsSuccessStatusCode = result.IsSuccessStatusCode.ToString();
                }
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.NombreCompañia = compania.NombreCompania;
                    ViewBag.NombreContacto = compania.NombreContacto;
                    ViewBag.CorreoElectronico = compania.CorreoElectronico;
                    ViewBag.Telefono = compania.Telefono;                    
                }
                else
                {
                    ViewBag.Mensaje = "No se pudo guardar el registro";
                }


            }
            catch (Exception ex)
            {

                return View(ex.Message.ToString());
            }
            

            return View();
        }
    }
}
