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
    public class Excel
    {
        #region IMPORTAR EXCEL

        //public List<DEKRA.VULNERABILIDADE.DOMAIN.Entiites.Models.ExternalEntities.RecallForm> ImportExcel(string arquivo)
        //{

        //    List<DEKRA.VULNERABILIDADE.DOMAIN.Entiites.Models.ExternalEntities.RecallForm> lists = new List<DEKRA.VULNERABILIDADE.DOMAIN.Entiites.Models.ExternalEntities.RecallForm>();

        //    string ext = string.Empty;
        //    string aspas = "\"";
        //    string Conexao = string.Empty;

        //    System.Data.DataTable DadosExcelInput = new System.Data.DataTable();

        //    ext = ".xlsx";

        //    if (ext == ".xls")
        //    {
        //        Conexao = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + arquivo + ";" + "Extended Properties=" + aspas + "Excel 8.0;HDR=YES" + aspas;
        //    } if (ext == ".xlsx")
        //    {
        //        Conexao = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + arquivo + ";" + "Extended Properties=" + aspas + "Excel 12.0;HDR=YES" + aspas;
        //    }

        //    System.Data.OleDb.OleDbConnection Cn = new System.Data.OleDb.OleDbConnection();
        //    Cn.ConnectionString = Conexao;
        //    Cn.Open();
        //    object[] Restricoes = { null, null, null, "TABLE" };

        //    System.Data.DataTable DTSchema = Cn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, Restricoes);

        //    if (DTSchema.Rows.Count > 0)
        //    {
        //        string Sheet = DTSchema.Rows[0]["TABLE_NAME"].ToString();
        //        System.Data.OleDb.OleDbCommand Comando = new System.Data.OleDb.OleDbCommand("SELECT * FROM [" + Sheet + "]", Cn);
        //        System.Data.DataTable Dados = new System.Data.DataTable();
        //        System.Data.OleDb.OleDbDataAdapter DA = new System.Data.OleDb.OleDbDataAdapter(Comando);
        //        DA.Fill(Dados);
        //        Cn.Close();
        //        DadosExcelInput = Dados;

        //    }

        //    int a = DadosExcelInput.Columns.Count;

        //    foreach (DataRow row in DadosExcelInput.Rows)
        //    {
        //        var Models = new DEKRA.VULNERABILIDADE.DOMAIN.Entiites.Models.ExternalEntities.RecallForm
        //        {
        //            ConvocacaoInicial = row.ItemArray[0].ToString(),
        //            Fabricante = row.ItemArray[1].ToString(),
        //            Modelo = row.ItemArray[2].ToString(),
        //            ChassiInicial = row.ItemArray[3].ToString(),
        //            ChassiFinal = row.ItemArray[4].ToString(),
        //            AnoInicial = row.ItemArray[5].ToString(),
        //            AnoFinal = row.ItemArray[6].ToString(),
        //            Descricao = row.ItemArray[7].ToString(),
        //            Origem = row.ItemArray[8].ToString(),
        //            Problema = row.ItemArray[9].ToString(),
        //            Instrucao = row.ItemArray[10].ToString(),
        //            Telefone = row.ItemArray[11].ToString(),
        //            OrigemInformacao = row.ItemArray[12].ToString(),
        //            Observacao = row.ItemArray[13].ToString()
        //        };
        //        lists.Add(Models);
        //    }
        //    return lists;
        //}

        #endregion
    }
}