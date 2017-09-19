﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContractStatementManagementSystem;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Text;

namespace WebApplication4.Controllers
{
    public class SummationController : Controller
    {
        // GET: Summation
        public ActionResult Summation()
        {
            if (Session["cc"] != null)
            {
                ViewBag.Message = Session["cc"];
            }
            string s = ViewBag.Message;
            Guid ID = new Guid(s);
            ObservableCollection<Productioner> opr=SqlQuery.ProductionerQuery(ID);
            ObservableCollection<Warehouse> ow=SqlQuery.WarehouseQuery(ID);
            ObservableCollection<Project_data> opj = SqlQuery.Project_dataQuery(ID);
            ObservableCollection<Sales> osl =SqlQuery.SalesQuery(ID);
            ObservableCollection<Accountant> oac = SqlQuery.AccountantQuery(ID);
            oac=Orderby.AccountantPaixuByService(oac);
            opj = Orderby.Project_dataPaixu(opj);
            ObservableCollection < ContractNameT > oct = SqlQuery.ContractVQuery(ID);
            ObservableCollection<Invoicing> oin = SqlQuery.Invoicing(ID);
            ViewBag.ProductionerJson = JsonTools.ObjectToJson(opr);
            ViewBag.WarehouseJson = JsonTools.ObjectToJson(ow);
            ViewBag.ProjectJson = JsonTools.ObjectToJson(opj);
            ViewBag.SalesJson = JsonTools.ObjectToJson(osl);
            ViewBag.AccountantJson = JsonTools.ObjectToJson(oac);
            ViewBag.ContractNameTJson = JsonTools.ObjectToJson(oct);
            ViewBag.InvoicingJson = JsonTools.ObjectToJson(oin);
            ViewBag.Contract_Date=oct[0].Contract_Date.ToShortDateString();
            return View();
        }
    }
}