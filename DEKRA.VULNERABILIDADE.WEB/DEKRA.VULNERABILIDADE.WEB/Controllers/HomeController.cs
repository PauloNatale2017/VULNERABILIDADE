using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

using System.Net;

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

using Newtonsoft.Json;



namespace DEKRA.VULNERABILIDADE.WEB.Controllers
{
    public class HomeController : Controller
    {
        IWebDriver driver;   
        public ActionResult ChartCreate()
        {
            //var model = new DEKRA.VULNERABILIDADE.DOMAIN.ENTIITES.MODELS.ENTITYMODEL.TesteAutomatizadoChartLine();
            return View();
        }

        public class UrlsSelen
        {
            public int Id { get; set; }
            public string TypeArquivo { get; set; }
            public string Caminho { get; set; }
            public string Evidencia { get; set; }
            public string UrlRetorno { get; set; }
            public string Resultado { get; set; }
        }
        public class Itens
        {
            //public string Arquivo { get; set; }
            public string id { get; set; }
            public string Ano { get; set; }
            public string Descricao { get; set; }
        }
        public class ModelDirc
        {
            public string id { get; set; }
            public string Ano { get; set; }
            public string Descricao { get; set; }
            public string RelatId { get; set; }
            public string NivelId { get; set; }
            public string treeLevel { get; set; }
            public List<Itens> Itens { get; set; }
        }

        public int count = 1;

        List<UrlsSelen> listas = new List<UrlsSelen>();
      


        //[HttpGet]
        //public JsonResult Vulnerabilidade(string data)
        //{
        //    AutomatizacaoTeste.TestePadrao initial = new AutomatizacaoTeste.TestePadrao();
        //    initial.Initial(data);
        //    return Json("", JsonRequestBehavior.AllowGet);
        //}

      
        public ActionResult Vulnerabilidade()
        {
            return View();
        }

        [HttpGet]
        public JsonResult VulnerabilidadeDiretorios(string model)
        {  
            TesteDeVulnerabilidade(model);
            return Json("", JsonRequestBehavior.AllowGet);
        }



        public void TakeScreensHot(string filaName)
        {
            ITakesScreenshot screenhotHandler = driver as ITakesScreenshot;
            Screenshot screenshot = screenhotHandler.GetScreenshot();
            screenshot.SaveAsFile(filaName);
        }

        public void ArquivosDiretorio(string item)
        {

            System.IO.DirectoryInfo info = new DirectoryInfo(item);
            foreach (System.IO.FileInfo f in info.GetFiles())
            {
                switch (f.Extension.ToLower())
                {
                    case ".asp":
                        listas.Add(new UrlsSelen { TypeArquivo = ".asp", Caminho = f.FullName.ToString().Replace("\\\\toyota\\Sites", "").Replace("\\Views", "") });

                        break;
                    case ".aspx":
                        listas.Add(new UrlsSelen { TypeArquivo = ".aspx", Caminho = f.FullName.ToString() });

                        break;
                    case ".htm":
                        listas.Add(new UrlsSelen { TypeArquivo = ".htm", Caminho = f.FullName.ToString() });

                        break;
                    case ".html":
                        listas.Add(new UrlsSelen { TypeArquivo = ".html", Caminho = f.FullName.ToString() });

                        break;
                    case ".cshtml":
                        listas.Add(new UrlsSelen
                        {
                            Id = count,
                            TypeArquivo = ".asp",
                            Caminho = f.FullName.ToString().Replace("\\\\toyota\\Sites\\", "").Replace("\\Views", "").Replace(".cshtml", "")
                        });
                        break;
                    default:
                        //listas.Add(new UrlsSelen { TypeArquivo = "path", Caminho = f.FullName.ToString() });
                        break;
                }
                count++;
            }
        }

        public class Direc
        {
            public string Identifica { get; set; }
            public string name { get; set; }
            public int  Nivel { get; set; }
            public string TipoArquivo { get; set; }
            public int TotalPorTipo { get; set; }
        }

        [HttpGet]
        public JsonResult VulnerabilidadeDiretoriosList(string Url)
        {
            List<Direc> listArquivos = new List<Direc>();
            string[] diretoriosRaiz = Directory.GetDirectories(Url);
            foreach (var item in diretoriosRaiz) {               
                listArquivos.Add(new Direc { 
                    name = item,
                    Nivel = 0,
                    Identifica = item,
                });
            }
            return Json(listArquivos, JsonRequestBehavior.AllowGet); 
        }

        [HttpGet]
        public JsonResult VulnerabilidadeDiretoriosParan(string Url)
        {
            List<Direc> listArquivos = new List<Direc>();
            List<Direc> listArquivos2 = new List<Direc>();
            DirectoryInfo pasta = new DirectoryInfo(Url);
            DirectoryInfo[] subPastas = pasta.GetDirectories();
            FileInfo[] arquivos = pasta.GetFiles();

            string[] arquivoscshtml = Directory.GetFiles(Url, "*.cshtml", SearchOption.AllDirectories);
            int count = 0;
            foreach (var item in arquivoscshtml)
            {
                listArquivos.Add(new Direc
                {
                    name = item,
                    Nivel = 0,
                    Identifica = item,
                    TipoArquivo = "cshtml",
                    TotalPorTipo = (count++),
                });
            }
            

            string[] arquivoshtml = Directory.GetFiles(Url, "*.html", SearchOption.AllDirectories);
            count = 0;
            foreach (var item in arquivoshtml)
            {
                listArquivos.Add(new Direc
                {
                    name = item,
                    Nivel = 0,
                    Identifica = item,
                    TipoArquivo = "html",
                    TotalPorTipo = (count++),
                });
            }
            string[] arquivosasp = Directory.GetFiles(Url, "*.asp", SearchOption.AllDirectories);
            count = 0;
            foreach (var item in arquivosasp)
            {
                listArquivos.Add(new Direc
                {
                    name = item,
                    Nivel = 0,
                    Identifica = item,
                    TipoArquivo = "asp",
                    TotalPorTipo = (count++),
                });
            }
            string[] arquivosaspx = Directory.GetFiles(Url, "*.aspx", SearchOption.AllDirectories);
            count = 0;
            foreach (var item in arquivosaspx)
            {
                listArquivos.Add(new Direc
                {
                    name = item,
                    Nivel = 0,
                    Identifica = item,
                    TipoArquivo = "aspx",
                    TotalPorTipo = (count++),
                });
            }
            string[] arquivoshtm = Directory.GetFiles(Url, "*.htm", SearchOption.AllDirectories);
            count = 0;
            foreach (var item in arquivoshtm)
            {
                listArquivos.Add(new Direc
                {
                    name = item,
                    Nivel = 0,
                    Identifica = item,
                    TipoArquivo = "htm",
                    TotalPorTipo = (count++),
                });
            }
            
           
        
            //string[] diretoriosRaiz = Directory.GetDirectories(Url);
            //foreach (var item in diretoriosRaiz)
            //{
            //    listArquivos.Add(new Direc
            //    {
            //        name = item,
            //        Nivel = 0,
            //        Identifica = item,
            //    });
            //}
            //diretoriosRaiz = null;
            //foreach (var item1 in listArquivos)
            //{
            //    diretoriosRaiz = Directory.GetDirectories(item1.name);
            //    foreach (var item2 in diretoriosRaiz)
            //    {
            //        listArquivos2.Add(new Direc
            //        {
            //            name = item2,
            //            Nivel = 1,
            //            Identifica = item1.name,
            //        });
            //    }
            //    diretoriosRaiz = null;
            //}

            //foreach (var item in listArquivos2)
            //{
            //    listArquivos.Add(new Direc
            //    {
            //        name = item.name,
            //        Nivel = item.Nivel,
            //        Identifica = item.Identifica,
            //    });
            //}
                      

            return Json(listArquivos, JsonRequestBehavior.AllowGet); ;
        }

        public class ArraySelects {
            public string ID { get; set; }
            public string LINHA { get; set; }
        }

        [HttpPost]
        public JsonResult TesteDeVulnerabilidadeII(string Model)
        {          
                List<ArraySelects> deserializedProduct = JsonConvert.DeserializeObject<List<ArraySelects>>(Model);
                
                string dir1 = DateTime.Now.ToLongTimeString().Replace(":", "-");
                string dir2 = DateTime.Now.ToLongDateString().Replace("/", "-");
                string diretorio = "Vulnerabilidade_" + dir1 + dir2;
                string caminho = @"C:\" + diretorio;
                string Resultado = "";
                string UrlRetorno = "";
                string Evidencia = "";
                
                if (!Directory.Exists(caminho)){
                    DirectoryInfo di = Directory.CreateDirectory(caminho);
                }          
           
                driver = new ChromeDriver(@"c:\users\paulo.natale\documents\visual studio 2013\Projects\CheckAuto.WebTest\CheckAuto.WebTest\Drivers\Chrome\");
                
                foreach (var item in deserializedProduct)
                {
                    string ajuste = "http://" + item.LINHA.Replace("\\", "/");
                    string UrlChrome = ajuste.Substring(0, 7) + "" + ajuste.Substring(23);
                 
                    System.Threading.Thread.Sleep(500);

                    try
                    {
                        HttpStatusCode results = default(HttpStatusCode);
                        var request = HttpWebRequest.Create(UrlChrome);
                        request.Method = "HEAD";
                        using (var response = request.GetResponse() as HttpWebResponse)
                        {
                            if (response != null)
                            {
                                results = response.StatusCode;
                                response.Close();
                            }
                        }
                    }
                    catch (Exception error)
                    {
                        if (error.ToString().Contains("404")){
                            driver.Url = UrlChrome;
                            System.Threading.Thread.Sleep(1000);
                            string url = driver.Url.ToString();
                            Resultado = "ERROR";
                            UrlRetorno = url;
                        } else if (error.ToString().Contains("500")) {
                            driver.Url = UrlChrome;
                            System.Threading.Thread.Sleep(1000);
                            string url = driver.Url.ToString();
                            Resultado = "ERROR";
                            UrlRetorno = url;
                        }
                    }
                  
                    if (Resultado != "OK")
                    {
                        //driver.Navigate().GoToUrl(UrlChrome);
                        string url = driver.Url.ToString();
                        driver.Url = UrlChrome;
                        UrlRetorno = url;
                      
                        if (!url.Contains("Login")) {
                            Resultado = "Falha";
                            Evidencia = caminho + "\\" + item.ID.ToString() + ".png";
                            TakeScreensHot(Evidencia);
                            System.Threading.Thread.Sleep(1000);
                        }
                        else {
                            Resultado = "OK";
                        }
                    } else {
                        Resultado = "OK";
                        Evidencia = "OK" + ".png";
                    }                    

               //
                              
            }
            driver.Close();
            return Json(caminho, JsonRequestBehavior.AllowGet);
        }
      

        
        public void TesteDeVulnerabilidade(string Url)
        {
            string dir1 = DateTime.Now.ToLongTimeString().Replace(":","-");
            string dir2 = DateTime.Now.ToLongDateString().Replace("/","-");
            string diretorio = "Vulnerabilidade_" + dir1 + dir2;
            string caminho =  @"C:\"+diretorio;
            if (!Directory.Exists(caminho)) {
                 DirectoryInfo di = Directory.CreateDirectory(caminho);
            }
            
            List<UrlsSelen> listArquivos = new List<UrlsSelen>();
            string[] diretoriosRaiz = Directory.GetDirectories(Url);
            List<ModelDirc> List = new List<ModelDirc>();
 
            foreach (var item in diretoriosRaiz)
            {              
                string[] diretoriosFilho = Directory.GetDirectories(item);

                if (diretoriosFilho.Length > 1)
                {
                    foreach (var item2 in diretoriosFilho)
                    {
                        string[] diretoriosFilho2 = Directory.GetDirectories(item2);
                        if (diretoriosFilho2.Length > 1)
                        {
                            foreach (var item3 in diretoriosFilho2)
                            {
                                string[] diretoriosFilho3 = Directory.GetDirectories(item3);
                                if (diretoriosFilho3.Length > 1)
                                {
                                    foreach (var item4 in diretoriosFilho3)
                                    {
                                        string[] diretoriosFilho4 = Directory.GetDirectories(item4);
                                        if (diretoriosFilho4.Length > 1)
                                        {
                                            foreach (var item5 in diretoriosFilho4)
                                            {
                                                string[] diretoriosFilho5 = Directory.GetDirectories(item5);
                                                if (diretoriosFilho5.Length > 1)
                                                {
                                                    foreach (var item6 in diretoriosFilho5)
                                                    {
                                                        string[] diretoriosFilho6 = Directory.GetDirectories(item6);
                                                    }

                                                }
                                                else { ArquivosDiretorio(item); }
                                            }

                                        }
                                        else { ArquivosDiretorio(item); }
                                    }
                                }
                                else { ArquivosDiretorio(item); }
                            }
                        }
                        else { ArquivosDiretorio(item); }
                    }
                }
                else { ArquivosDiretorio(item); }

            }

            driver = new ChromeDriver(@"c:\users\paulo.natale\documents\visual studio 2013\Projects\CheckAuto.WebTest\CheckAuto.WebTest\Drivers\Chrome\");

            foreach (var item in listas)
            {
                string a = "http://" + item.Caminho.Replace("\\", "/");
                System.Threading.Thread.Sleep(500);

                try
                {
                    HttpStatusCode results = default(HttpStatusCode);
                    var request = HttpWebRequest.Create(a);
                    request.Method = "HEAD";
                    using (var response = request.GetResponse() as HttpWebResponse)
                    {
                        if (response != null)
                        {
                            results = response.StatusCode;
                            response.Close();
                        }
                    }
                }
                catch (Exception error)
                {
                    if (error.ToString().Contains("404"))
                    {
                        string url = driver.Url.ToString();
                        item.Resultado = "OK";
                        item.UrlRetorno = url;
                    }
                    else if (error.ToString().Contains("500"))
                    {
                        string url = driver.Url.ToString();
                        item.Resultado = "OK";
                        item.UrlRetorno = url;
                    }

                }

                if (item.Resultado != "OK")
                {
                    driver.Navigate().GoToUrl(a);
                    string url = driver.Url.ToString();
                    item.UrlRetorno = url;

                    if (!url.Contains("Login"))
                    {
                        item.Resultado = "Falha";
                        item.Evidencia = caminho +"\\"+ item.Id.ToString() + ".png";
                        TakeScreensHot(item.Evidencia);
                    }
                    else
                    {
                        item.Resultado = "OK";
                    }
                }
                else
                {
                    item.Resultado = "OK";
                    item.Evidencia = "OK" + ".png";                   
                }
            }

            driver.Close();

            string[] colunas = new string[6];
            colunas[0] = "Id";
            colunas[1] = "TypeArquivo";
            colunas[2] = "Caminho";
            colunas[3] = "Evidencia";
            colunas[4] = "UrlRetorno";
            colunas[5] = "Resultado";

            IDictionary<string, object> result = new Dictionary<string, object>();

            using (SLDocument sl = new SLDocument())
            {

                SLStyle style = sl.CreateStyle();
                style.Border.LeftBorder.BorderStyle = BorderStyleValues.Thick;
                style.Border.LeftBorder.Color = System.Drawing.Color.Black;
                style.Border.RightBorder.BorderStyle = BorderStyleValues.Thick;
                style.Border.RightBorder.Color = System.Drawing.Color.Black;
                style.Border.TopBorder.BorderStyle = BorderStyleValues.Thick;
                style.Border.TopBorder.Color = System.Drawing.Color.Black;
                style.Border.BottomBorder.BorderStyle = BorderStyleValues.Thick;
                style.Border.BottomBorder.Color = System.Drawing.Color.Black;
                style.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.Gray, System.Drawing.Color.Gray);
                sl.AutoFitColumn(1, 6);

                SLStyle headerStyle = new SLStyle();
                SLStyle rowStyle = new SLStyle();

                headerStyle.Font.Bold = true;
                headerStyle.SetFontBold(true);

                headerStyle.SetLeftBorder(BorderStyleValues.Thick, SLThemeColorIndexValues.Dark1Color);
                headerStyle.SetRightBorder(BorderStyleValues.Thick, SLThemeColorIndexValues.Dark1Color);
                headerStyle.SetBottomBorder(BorderStyleValues.Thick, SLThemeColorIndexValues.Dark1Color);
                headerStyle.SetTopBorder(BorderStyleValues.Thick, SLThemeColorIndexValues.Dark1Color);

                rowStyle.SetLeftBorder(BorderStyleValues.Medium, SLThemeColorIndexValues.Dark1Color);
                rowStyle.SetRightBorder(BorderStyleValues.Medium, SLThemeColorIndexValues.Dark1Color);
                rowStyle.SetBottomBorder(BorderStyleValues.Medium, SLThemeColorIndexValues.Dark1Color);
                rowStyle.SetTopBorder(BorderStyleValues.Medium, SLThemeColorIndexValues.Dark1Color);

                for (int i = 0; i < colunas.Length; i++)
                {
                    sl.SetCellValue(1, i + 1, colunas[i]);
                    sl.SetColumnWidth(i + 1, 24.0);
                    sl.SetCellStyle(1, i + 1, style);
                }
                int linha = 2;

                foreach (var item in listas)
                {
                    var properties = TypeDescriptor.GetProperties(item);
                    foreach (PropertyDescriptor property in properties)
                    {
                        result.Add(property.Name, property.GetValue(item));
                    }
                    var ArrayDados = result.Values.ToArray();
                    for (int i = 0; i < 1; i++)
                    {
                        try
                        {
                            sl.SetCellStyle(linha, 1, headerStyle);
                            sl.SetCellValue(linha, 1, ArrayDados[0].ToString());
                            sl.SetCellStyle(linha, 2, headerStyle);
                            sl.SetCellValue(linha, 2, ArrayDados[1].ToString());
                            sl.SetCellStyle(linha, 3, headerStyle);
                            sl.SetCellValue(linha, 3, ArrayDados[2].ToString());
                            sl.SetCellStyle(linha, 4, headerStyle);
                            sl.SetCellValue(linha, 4, ArrayDados[3].ToString());
                            sl.SetCellStyle(linha, 5, headerStyle);
                            sl.SetCellValue(linha, 5, ArrayDados[4].ToString());
                            sl.SetCellStyle(linha, 6, headerStyle);
                            sl.SetCellValue(linha, 6, ArrayDados[5].ToString());


                        }
                        catch (Exception ex)
                        {
                            ex.Message.ToString();
                        }

                        linha++;
                    }
                    properties = null;
                    result.Clear();

                }

                try
                {
                    //sl.SaveAs(caminho +"\\"+"Vulnerabilidade_" + "RoboAutomatizado" + ".xlsx");

                    using (var memoryStream = new MemoryStream())
                    {
                        sl.SaveAs(memoryStream);
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment;  filename=" + "Vulnerabilidade_" + "RoboAutomatizado" + ".xlsx");
                        memoryStream.WriteTo(Response.OutputStream); // Response.OutputStream
                        File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Report.xlsx");
                        Response.Flush();
                        Response.End();
                      
                    };
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }

            }
        }



        //[HttpPost]
        //public ActionResult ChartCreate(DEKRA.VULNERABILIDADE.DOMAIN.ENTIITES.MODELS.ENTITYMODEL.TesteAutomatizadoChartLine retornodados)
        //{
        //    DEKRA.VULNERABILIDADE.DOMAIN.CORE.Repository.TesteAutomatizadoChartLineRepository _repository = new DEKRA.VULNERABILIDADE.DOMAIN.CORE.Repository.TesteAutomatizadoChartLineRepository();
        //    _repository.Add(retornodados);          
        //    return View();
        //}
      
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }
        
        public ActionResult LogIn2()
        {
            return View();
        }
              

        public ActionResult Log()
        {
            return View();
        }

        public ActionResult CreateGmuds()
        {

            try
            {

                //Word.Application wordApp = new Application();
                //Document wordDoc = wordApp.Documents.Add();
                //Range docRange = wordDoc.Range();

                //string imagePath = @"C:\Users\paulo.natale\Documents\Visual Studio 2013\Projects\DEKRA.VULNERABILIDADE.WEB\DEKRA.VULNERABILIDADE.WEB\images\logomarcas\dekra-logo.png";

                //// Create an InlineShape in the InlineShapes collection where the picture should be added later
                //// It is used to get automatically scaled sizes.
                //InlineShape autoScaledInlineShape = docRange.InlineShapes.AddPicture(imagePath);
                //float scaledWidth = 150; //autoScaledInlineShape.Width;
                //float scaledHeight = 35;//autoScaledInlineShape.Height;
                //autoScaledInlineShape.Delete();

                //// Create a new Shape and fill it with the picture
                //Shape newShape = wordDoc.Shapes.AddShape(10, 0, 0, scaledWidth, scaledHeight);
                //newShape.Fill.UserPicture(imagePath);

                //// Convert the Shape to an InlineShape and optional disable Border
                ////InlineShape finalInlineShape = newShape.ConvertToInlineShape();
                ////finalInlineShape.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;

                //// Cut the range of the InlineShape to clipboard
                ////finalInlineShape.Range.Cut();

                //// And paste it to the target Range
                //docRange.Paste();

                //wordDoc.SaveAs2(@"C:\Users\paulo.natale\Desktop\MicrosofVirtualAcademy\temp1.docx");
                //wordApp.Quit();

                //Application wordApp = new Application();
                //Document wordDoc = wordApp.Documents.Add();
                //Range docRange = wordDoc.Range();

                //string imageName = @"c:\temp\win10.jpg";
                //InlineShape pictureShape = docRange.InlineShapes.AddPicture(imageName);

                //wordDoc.SaveAs2(@"C:\Users\paulo.natale\Desktop\MicrosofVirtualAcademy\temp1.docx");
                //wordApp.Quit();

               // //Create an instance for word app
               // Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();

               // //Set animation status for word application
               // //winword.ShowAnimation = false;

               // //Set status for word application is to be visible or not.
               //// winword.Visible = false;

               // //Create a missing variable for missing value
               // object missing = System.Reflection.Missing.Value;

               // //Create a new document
               // Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

               

               // //Add header into the document
               // foreach (Microsoft.Office.Interop.Word.Section section in document.Sections)
               // {
               //     //Get the header range and add the header details.
               //     Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
               //     headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
               //     headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
               //     headerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlue;
               //     headerRange.Font.Size = 10;
               //     //headerRange.Application.Selection.InlineShapes.AddPicture(@"C:\Users\paulo.natale\Documents\Visual Studio 2013\Projects\DEKRA.VULNERABILIDADE.WEB\DEKRA.VULNERABILIDADE.WEB\images\logomarcas\dekra-logo.png");
               //     //headerRange.Text = "Header text goes here";
               // }

               // //Add the footers into the document
               // foreach (Microsoft.Office.Interop.Word.Section wordSection in document.Sections)
               // {
               //     //Get the footer range and add the footer details.
               //     Microsoft.Office.Interop.Word.Range footerRange = wordSection.Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
               //     footerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdDarkRed;
               //     footerRange.Font.Size = 10;
               //     footerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
               //     footerRange.Text = "Footer text goes here";
               // }

               // //adding text to document
               // document.Content.SetRange(0, 0);
               // document.Content.Text = "This is test document " + Environment.NewLine;

               // //Add paragraph with Heading 1 style
               // Microsoft.Office.Interop.Word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
               // object styleHeading1 = "Heading 1";
               //// para1.Range.set_Style(styleHeading1);
               // para1.Range.Text = "Para 1 text";
               // para1.Range.InsertParagraphAfter();

               // //Add paragraph with Heading 2 style
               // Microsoft.Office.Interop.Word.Paragraph para2 = document.Content.Paragraphs.Add(ref missing);
               // object styleHeading2 = "Heading 2";
               //// para2.Range.set_Style(styleHeading2);
               // para2.Range.Text = "Para 2 text";
               // para2.Range.InsertParagraphAfter();

               // //Create a 5X5 table and insert some dummy record
               // Word.Table firstTable = document.Tables.Add(para1.Range, 5, 5, ref missing, ref missing);

               // firstTable.Borders.Enable = 1;
               // foreach (Word.Row row in firstTable.Rows)
               // {
               //     foreach (Word.Cell cell in row.Cells)
               //     {
               //         //Header row
               //         if (cell.RowIndex == 1)
               //         {
               //             cell.Range.Text = "Column " + cell.ColumnIndex.ToString();
               //             cell.Range.Font.Bold = 1;
               //             //other format properties goes here
               //             cell.Range.Font.Name = "verdana";
               //             cell.Range.Font.Size = 10;
               //             //cell.Range.Font.ColorIndex = WdColorIndex.wdGray25;                            
               //             cell.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
               //             //Center alignment for the Header cells
               //             cell.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
               //             cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

               //         }
               //         //Data row
               //         else
               //         {
               //             cell.Range.Text = (cell.RowIndex - 2 + cell.ColumnIndex).ToString();
               //         }
               //     }
               // }

               // Range docRange = wordDoc.Range();
               // string imageName = @"C:\Users\paulo.natale\Documents\Visual Studio 2013\Projects\DEKRA.VULNERABILIDADE.WEB\DEKRA.VULNERABILIDADE.WEB\images\logomarcas\dekra-logo.png";
               // InlineShape pictureShape = docRange.InlineShapes.AddPicture(imageName);

               // //Save the document
               // object filename = @"C:\Users\paulo.natale\Desktop\MicrosofVirtualAcademy\temp1.docx";
               // document.SaveAs2(filename);
               // document.Close(missing,missing,missing);
               // document = null;
               // winword.Quit(missing,missing,missing);
               // winword = null;
              
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            return View();
        }
        

        [HttpGet]
        public JsonResult Diretorios()
        {
            string[] diretorios = Directory.GetDirectories(@"G:\TI\Documentação\GMUD\2018");
           
            List<ModelDirc> List = new List<ModelDirc>();

            //object fileName = @"C:\arquivo.doc";
            //object readOnly = false;
            //object isVisible = true;
            //object oldChars = "#NOMECLIENTE#";
            //object newChars = "Alcenir Moretto";
            //object oTrue = true;
            //object oMissing = System.Reflection.Missing.Value;
            //object oMicrosoftReplace = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;
            //Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            //Microsoft.Office.Interop.Word.Document doc = word.Documents.Open(ref fileName, ref oMissing, ref readOnly, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref isVisible, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            //bool result = word.Selection.Find.Execute(ref oldChars, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oTrue, ref oMissing, ref oTrue, ref newChars, ref oMicrosoftReplace, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            //doc.Save();  

            int count = 0;

            foreach (var item in diretorios)
	        {
                string Items = item.ToString().Split('\\')[4];
                string Itemas =  item.ToString().Split('\\')[5].Split('-')[0];
                string Itemss = item.ToString().Split('\\')[5].Split('-')[1];

                List<Itens> listArquivos = new List<Itens>();

                string[] ArquivosNaPasta = Directory.GetFiles(diretorios[count]);

                count++;

                foreach (var item1 in ArquivosNaPasta)
                {
                    var arquivos = new Itens
                    {
                        id = "",
                        Ano = "",
                        Descricao = item1
                    };
                    listArquivos.Add(arquivos);

                }

                var model = new ModelDirc
                {
                    id = item.ToString().Split('\\')[5].Split('-')[0],
                    Ano = item.ToString().Split('\\')[4],
                    Descricao = item.ToString().Split('\\')[5].Split('-')[1],
                    Itens = listArquivos
                   
                };
                List.Add(model);
	        }
            return Json(List, JsonRequestBehavior.AllowGet);
        }
               
        public ActionResult GridUI()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GridUIDados()
        {
            string[] diretorios = Directory.GetDirectories(@"G:\TI\Documentação\GMUD\2018");         
            return Json(diretorios, JsonRequestBehavior.AllowGet);
        }

        public class Teste
        {
             public string Url { get; set; } 
             public string Banco { get; set; } 
             public string Funcao { get; set; }          
        }

        [HttpGet]
        public JsonResult Testes(string data)
        {
           AutomatizacaoTeste.TestePadrao initial = new AutomatizacaoTeste.TestePadrao();
           initial.Initial(data);
           return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}
