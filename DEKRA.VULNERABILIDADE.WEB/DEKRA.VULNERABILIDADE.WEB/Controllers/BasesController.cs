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


using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;

using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;

using System.Threading;
using System.Collections;
using System.Data;

using System.Drawing.Imaging;

//using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace DEKRA.VULNERABILIDADE.WEB.Controllers
{
    public class BasesController : ApiController
    {
               
        //private readonly DEKRA.VULNERABILIDADE.DOMAIN.CORE.Repository.SistemasRepository _repository;

        //private readonly DEKRA.VULNERABILIDADE.DOMAIN.CORE.Repository.BasesRepository _repository = new DEKRA.VULNERABILIDADE.DOMAIN.CORE.Repository.BasesRepository();

        // GET api/values
        //public List<DEKRA.VULNERABILIDADE.DOMAIN.ENTIITES.MODELS.ENTITYMODEL.Bases> Get()
        //{
        //    List<DEKRA.VULNERABILIDADE.DOMAIN.ENTIITES.MODELS.ENTITYMODEL.Bases> list = new List<DEKRA.VULNERABILIDADE.DOMAIN.ENTIITES.MODELS.ENTITYMODEL.Bases>();
        //    return _repository.GetAll().ToList();
        //}


        // GET api/values/5
        public string Get(int id)
        {
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
    }
}
