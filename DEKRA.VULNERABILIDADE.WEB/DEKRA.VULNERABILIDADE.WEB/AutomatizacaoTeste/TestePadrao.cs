using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace DEKRA.VULNERABILIDADE.WEB.AutomatizacaoTeste
{

  

    public class TestePadrao
    {
        IWebDriver driver;

        //DEKRA.VULNERABILIDADE.DOMAIN.CORE.Repository.TesteAutomatizadoChartLineRepository _repository = new DEKRA.VULNERABILIDADE.DOMAIN.CORE.Repository.TesteAutomatizadoChartLineRepository();
        
        //public List<DEKRA.VULNERABILIDADE.DOMAIN.Entiites.Models.ExternalEntities.RecallForm> lists =  new List<DEKRA.VULNERABILIDADE.DOMAIN.Entiites.Models.ExternalEntities.RecallForm>();
       
        string[] LoginQA = new string[12];

        public void Initial(string url)
        {
            //List<DEKRA.VULNERABILIDADE.DOMAIN.ENTIITES.MODELS.ENTITYMODEL.TesteAutomatizadoChartLine> Listitens = new List<DEKRA.VULNERABILIDADE.DOMAIN.ENTIITES.MODELS.ENTITYMODEL.TesteAutomatizadoChartLine>();

            //var ad = _repository.GetAll().ToList<DEKRA.VULNERABILIDADE.DOMAIN.ENTIITES.MODELS.ENTITYMODEL.TesteAutomatizadoChartLine>();
            //var dados = new DEKRA.VULNERABILIDADE.DOMAIN.ENTIITES.MODELS.ENTITYMODEL.TesteAutomatizadoChartLine
            //{
            //    ChartType = 1,
            //    label = "Login",
            //    value = "10",
            //    vLine = "true",
            //    showLabel = "1",
            //    showValue = "1",
            //    color = "#ff0000",
            //    labelFontColor = "#ff0000",
            //    anchorBorderColor = "#ff0000",
            //    anchorBgColor = "#ff0000",
            //    link = "Home/Index",
            //    valuePosition = "ABOVE",
            //    anchorAlpha = "50",
            //    dashed = "1",
            //    toolText = "Action Login",
            //    labelFontSize = "35"
            //    //DataCreate = DateTime.Now,
            //    //DataUpdate = DateTime.Now
            //};

            //_repository.Add(dados);

            Random id = new Random();
            AutomatizacaoTeste.Excel excel = new AutomatizacaoTeste.Excel();
            AutomatizacaoTeste.WordTes word = new AutomatizacaoTeste.WordTes();
            AutomatizacaoTeste.Arquivo arquivos = new AutomatizacaoTeste.Arquivo();


            string Directory = @"C:\Users\paulo.natale\Desktop\Chrome\EvidenciasTeste\";
            string DiretoryTeste = Directory + "" + DateTime.Now.ToLongDateString() + "" + id.Next(0, 9999999).ToString(); 
            string Arquivo   = "Login.png";

            string Diretorio = "";
                   Diretorio = arquivos.CreateDirectory(DiretoryTeste);

            //try
            //{

                string Login = "laraujo";
                string Senha = "lpa1215";

                LoginQA[0] = "Login=" + Login + "&Password" + Senha + "&div.btnLoginEntra" + "&Time=" + DateTime.Now.ToShortTimeString();

                //lists = excel.ImportExcel(@"C:\Users\paulo.natale\Desktop\Chrome\CadastroWebDriver.xlsx");
                //List<DEKRA.VULNERABILIDADE.DOMAIN.Entiites.Models.ExternalEntities.RecallForm> listD = lists;

                driver = new ChromeDriver(@"c:\users\paulo.natale\documents\visual studio 2013\Projects\CheckAuto.WebTest\CheckAuto.WebTest\Drivers\Chrome\");
                driver.Navigate().GoToUrl(url);
                driver.Manage().Window.Maximize();

                //----------------------- Login Users ------------------------------//
                driver.FindElement(By.Id("Login")).Clear();
                driver.FindElement(By.Id("Senha")).Clear();
                ////Assert.AreEqual("laraujo", Login);
                driver.FindElement(By.Id("Login")).SendKeys(Login);

                
               
               

                ////Assert.AreEqual("lpa1215", Senha);
                driver.FindElement(By.Id("Senha")).SendKeys(Senha);

                TakeScreensHot(DiretoryTeste + @"\Login.png");
                driver.FindElement(By.CssSelector("div.btnLoginEntrar")).Click();

                //------------------------------------------------------------------//

                //foreach (var item in lists)
                //{
                //    Thread.Sleep(5000);
                //     driver.FindElement(By.XPath("//button[@ng-click='FuncNovo()']")).Click();
                //     TakeScreensHot(DiretoryTeste + @"\Cadastro.png");
                //    Thread.Sleep(5000);

                //    //string dates = DateTime.Now.ToShortDateString();
                //    string date = System.DateTime.Today.ToString("dd/MM/yy");
                //    IJavaScriptExecutor javascript = driver as IJavaScriptExecutor;
                //    //IJavaScriptExecutor js = IJavaScriptExecutor();
                //    //js.ExecuteScript("document.getElementById('rbSingleFuture').click();");  
                //    //js.executeJavascript("document.getElementsByName('input')[0].value = '2018-08-14'");

                //    //WebElement firstName = driver.findElement(By.xpath("//input[@name='firstName']"));
                //    //string value = firstName.getText();

                //    javascript.ExecuteScript("document.getElementsByTagName('input')[10].value='2018-08-15'");

                //    //driver.FindElement(By.CssSelector("[ng-model='Cadastro.DataInicialConvocacao']")).SendKeys(item.ConvocacaoInicial);
                //    driver.FindElement(By.CssSelector("[ng-model='Cadastro.Institucional']")).SendKeys(item.Descricao);
                //    //driver.FindElement(By.CssSelector("[ng-model='Cadastro.Fabricante']")).SendKeys(item.Fabricante);
                //    //driver.FindElement(By.CssSelector("[ng-model='Cadastro.Modelo']")).SendKeys(item.Modelo);
                //    driver.FindElement(By.CssSelector("[ng-model='Cadastro.ChassiInicial']")).SendKeys(item.ChassiInicial);
                //    driver.FindElement(By.CssSelector("[ng-model='Cadastro.ChassiFinal']")).SendKeys(item.ChassiFinal);
                //    //driver.FindElement(By.CssSelector("[ng-model='Cadastro.AnoFabricacaoInicial']")).SendKeys(item.AnoInicial);
                //    //driver.FindElement(By.CssSelector("[ng-model='Cadastro.AnoFabricacaoFinal']")).SendKeys(item.AnoFinal);
                //    driver.FindElement(By.CssSelector("[ng-model='Cadastro.Problema']")).SendKeys(item.Problema);
                //    driver.FindElement(By.CssSelector("[ng-model='Cadastro.Instrucao']")).SendKeys(item.Instrucao);
                //    driver.FindElement(By.CssSelector("[ng-model='Cadastro.Telefone']")).SendKeys(item.Telefone);
                //    driver.FindElement(By.CssSelector("[ng-model='Cadastro.OrigemInformacao']")).SendKeys(item.OrigemInformacao);
                //    driver.FindElement(By.CssSelector("[ng-model='Cadastro.Observacao']")).SendKeys(item.Observacao);

                //    TakeScreensHot(DiretoryTeste +@"\DadosPreenchidos.png");

                //    Thread.Sleep(5000);
                //    driver.FindElement(By.XPath("//button[@ng-click='FuncGravarRecall()']")).Click();


                //    Thread.Sleep(7000);
                //    TakeScreensHot(DiretoryTeste + @"\CadastroEfetuado.png");
                //    driver.FindElement(By.XPath("//button[@class='btn btn-sm btn-success']")).Click();
                //    Thread.Sleep(7000);

                //    word.CreateIconInWordDoc(@"C:\Users\paulo.natale\Desktop\Words\Controle de Documento.docx", DiretoryTeste);

                //    driver.Close();
                //}
            
        }

        public void TakeScreensHot(string filaName)
        {
            ITakesScreenshot screenhotHandler = driver as ITakesScreenshot;
            Screenshot screenshot = screenhotHandler.GetScreenshot();
            screenshot.SaveAsFile(filaName);
        }

    }
}