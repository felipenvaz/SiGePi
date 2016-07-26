using CamadaDeNegocios;
using CamadaDeNegocios.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace SiGePiWEB.Controllers
{
    public class ClientesController : Controller
    {
        //
        // GET: /Clientes/

        public ActionResult Index()
        {
            List<Cliente> clientes = new ServicesProvider().GetClientes(EClienteDetail.Geral | EClienteDetail.Telefones);

            StringBuilder str = new StringBuilder();

            str.Append("<tr><th>Nome</th><th>Telefone</th><th>E-mail</th></tr>");

            foreach (var c in clientes)
                str.Append("<tr class='cliente'><td id='" + c.Id + "' class ='nome'>" + c.Nome + "</td><td>" + 
                    (string.IsNullOrEmpty(c.Telefone1)?"Não Informado":(c.Telefone1 + 
                        (string.IsNullOrEmpty(c.Telefone2)? "" :("/" + c.Telefone2))) 
                    )
                    + "</td><td>" + (string.IsNullOrEmpty(c.Email) ? "Não Informado" : c.Email) + "</td></tr>");

            ViewBag.Clientes = str.ToString();

            return View();
        }

        //[HttpPost]
        public JsonResult GetDadosCliente(int idCliente)
        {

            List<Cliente> clientes = new ServicesProvider().GetClientes(idCliente, EClienteDetail.Geral | EClienteDetail.Aulas | EClienteDetail.Pagamentos | EClienteDetail.Telefones);
            Cliente cliente = null;
            if (!clientes.IsNullOrEmpty())
                cliente = clientes[0];


            return Json(new ClienteWeb() { Id = cliente.Id, Nome = cliente.Nome });
        }
    }
}
