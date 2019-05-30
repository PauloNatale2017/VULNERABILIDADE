using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Microsoft.Office.Interop.Word;

using System.IO;

using System.Web;
using System.Web.Mvc;

using System.Web.UI;
using System.Web.UI.WebControls;


using System.Data;
using System.Data.SqlClient;



using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;

using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;

using System.Threading;
using System.Collections;

using System.Drawing.Imaging;

using Excel = Microsoft.Office.Interop.Excel;
using ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat;

using Word = Microsoft.Office.Interop.Word;

using OfficeOpenXml;
using OfficeOpenXml.Style;

using System.ComponentModel;
using SpreadsheetLight;
using DocumentFormat.OpenXml.Spreadsheet;





namespace DEKRA.VULNERABILIDADE.WEB.Controllers
{
    public class DiretoriosController : ApiController
    {

        public string Get()
        {

            return "value";
        }


        // GET api/values/5
        public string Get(string Url)
        {
            TesteDeVulnerabilidade(Url);
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        public void TesteDeVulnerabilidade(string Url)
        {
        }
     


       
    }
}
