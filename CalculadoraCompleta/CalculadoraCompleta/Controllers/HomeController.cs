using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalculadoraCompleta.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //inicializa valor a zero
            ViewBag.Visor = "0";
            return View();
        }
        // POST: Home
        [HttpPost]
        public ActionResult Index(string bt,string visor)
        {
            switch (bt)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    //Determinar se o visor só existe um zero
                    if (visor.Equals("0")) visor = bt;
                    else visor += bt; //visor = visor + bt
                    break;
                case ",":
                    if (!visor.Contains(",")) visor += ",";
                        break;
                case "-/+":
                    visor = Convert.ToDouble(visor) * -1 + "";//Aspas para converter para string
                        break;
                case "C":
                    visor = "0";
                    Session["PrimeiroOperador"] = true;
                    break;
                case "+":
                    if((bool)Session["PrimeiroOperador"])
                    {
                    //guardar valor do visor
                    Session["operando"]=visor;
                    //limpa o visor
                    visor = "0";
                    //guardar o operador
                    Session["operador"] = bt;
                    //marcar que o primeiro operador foi registado
                    Session["PrimeiroOperador"] = false;
                    }
                    else
                    {
                        //se não é a primeira vez que se clica num operador 
                        //vou utilizar os valores anteriores 
                        switch((string)Session["operador"])
                        {
                           // recuperar o codigo da primeira calculadora
                        }
                    //guardar os novos valores 
                    }
                    break;
            }
            //entregar os valores á VIEW
            ViewBag.Visor = visor;
            return View();
        }
    }
}