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
    public class WordTes
    {

        public void CreateIconInWordDoc(string Layout,string DestinoSave)
        {
                #region CREATE WORD


            Object oMissing = System.Reflection.Missing.Value;
            Word.Application oWord = new Word.Application();
            Word.Document oWordDoc = new Word.Document();
            oWord.Visible = false;

            Object oTemplatePath = Layout;
            oWordDoc = oWord.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);

            string NomeArquivo = "CONTROLEDEDOCUMENTOS_" + DateTime.Now.ToString().Replace(":","");
            string ArquivoSave = DestinoSave + "\\" + NomeArquivo.Replace("/", "") + ".docx";

            string[] diretorios = Directory.GetDirectories(@"C:\\");
            string[] arquivos = Directory.GetFiles(@"C:\\");
            string[] arquivos2 = Directory.GetFiles(DestinoSave, "*.png", SearchOption.AllDirectories);
            // C#
    
            try
            {

                foreach (Word.Field myMergeField in oWordDoc.Fields)
                {
                    Word.Range rngFieldCode = myMergeField.Code;
                    String fieldText = rngFieldCode.Text;

                    if (fieldText.StartsWith(" MERGEFIELD"))
                    {
                        Int32 endMerge = fieldText.IndexOf("\\");
                        Int32 fieldNameLength = fieldText.Length - endMerge;
                        String fieldName = fieldText.Substring(11, endMerge - 11);
                        fieldName = fieldName.Trim();

                        if (fieldName == "descricaoTitulo")
                        {
                            myMergeField.Select();
                            oWord.Selection.TypeText("ROBO DE AUTOMATIZAÇÂO DE TESTE");
                            continue;
                        }
                        else if (fieldName == "NomeArquivo")
                        {
                            myMergeField.Select();
                            oWord.Selection.TypeText(NomeArquivo);
                            continue;
                        }
                        else if (fieldName == "NomeAutor")
                        {
                            myMergeField.Select();
                            oWord.Selection.TypeText("PAULO NATALE");
                            continue;
                        }
                        else if (fieldName == "Modulo")
                        {
                            myMergeField.Select();
                            oWord.Selection.TypeText("CheckAuto");
                            continue;
                        }
                        else if (fieldName == "DescricaoAcao1")
                        {
                            myMergeField.Select();
                            oWord.Selection.TypeText("Se logar. na aplicação Selecionar o menu Relatórios Varejo ");
                            continue;
                        }
                        else if (fieldName == "DescricaoRetorno1")
                        {
                            myMergeField.Select();
                            oWord.Selection.TypeText("Devera exibir a opções dentre elas escola Relatório Varejo > Produção.");
                            continue;
                        }
                        else if (fieldName == "DescricaoAcao2")
                        {
                            myMergeField.Select();
                            oWord.Selection.TypeText("Abrira uma tela de pesquisa com vários filtros selecione os filtros necessários");
                            continue;
                        }
                        else if (fieldName == "DescricaoRetorno2")
                        {
                            myMergeField.Select();
                            oWord.Selection.TypeText("Selecionar o tipo de relatório ‘Sintético‘");
                            continue;
                        }
                        else if (fieldName == "DescricaoAcao3")
                        {
                            myMergeField.Select();
                            oWord.Selection.TypeText("Após a inserção dos filtros click em Gerar Relatórios.");
                            continue;
                        }
                        else if (fieldName == "DescricaoRetorno3")
                        {
                            myMergeField.Select();
                            oWord.Selection.TypeText("O resultado devera conter os novos produtos em seu corpo:Novo Garantido/Dekra Check");
                            continue;
                        }
                        else if (fieldName == "DescricaoAcao4")
                        {
                            myMergeField.Select();
                            oWord.Selection.TypeText("Na impressão do laudo verifique a Capa Modulo Estrutura");
                            continue;
                        }
                        else if (fieldName == "DescricaoRetorno4")
                        {
                            myMergeField.Select();
                            oWord.Selection.TypeText("O conforme do ícone referente ao estado de conservação deve estar coerente com regras selecionadas");
                            continue;
                        }
                        else if (fieldName == "DescricaoAcao5")
                        {
                            myMergeField.Select();
                            oWord.Selection.TypeText("Na impressão do laudo verifique a Capa Modulo Estrutura ícone Pintura");
                            continue;
                        }
                        else if (fieldName == "DescricaoRetorno5")
                        {
                            myMergeField.Select();
                            oWord.Selection.TypeText("Os totalizadores devem esta coerente com os totais inseridos anteriormente o modulo deve esta com pintura em amarela apenas quando mais do que 50% das peças estiverem sido preenchidas com vermelho ou amarelo excluindo as colunas ");
                            continue;
                        }
                        else if (fieldName == "DescricaoAcao6")
                        {
                            myMergeField.Select();
                            oWord.Selection.TypeText("Na impressão do laudo verifique a Capa Modulo Estado de Conservação ícone Pneus");
                            continue;
                        }
                        else if (fieldName == "DescricaoRetorno6")
                        {
                            myMergeField.Select();
                            oWord.Selection.TypeText("Os totalizadores devem esta coerente com os totais inseridos anteriormente o modulo deve esta com o ícone de Pneus com a cor respeitando as regras e junção das respostas escolhidas ");
                            continue;
                        }
                        else if (fieldName == "DescricaoAcao7")
                        {
                            myMergeField.Select();
                            oWord.Selection.TypeText("Na impressão do laudo verifique a Capa o titulo devera Conter o nome do Parceiro ");
                            continue;
                        }
                        else if (fieldName == "DescricaoRetorno7")
                        {
                            myMergeField.Select();
                            oWord.Selection.TypeText("A impressão devera exibir exclusivo concatenado com o nome do Parceiro se ele pertencer as finalidades (Seguradora/Financeira)");
                            continue;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                    ex.Message.ToString();
            }

            var paragrafo5 = oWordDoc.Paragraphs.Add();
            for (int i = 0; i < arquivos2.Length; i++)
            {
                string caminhoCompleto = arquivos2[i].Split('\\')[0] + "\\" + arquivos2[i].Split('\\')[1] + "\\" + arquivos2[i].Split('\\')[2] + "\\" + arquivos2[i].Split('\\')[3] + "\\" + arquivos2[i].Split('\\')[4] + "\\" + arquivos2[i].Split('\\')[5] +"\\"+ arquivos2[i].Split('\\')[6];
                string Foto = arquivos2[i].Split('\\')[7];
                paragrafo5.Range.InlineShapes.AddPicture(System.IO.Path.Combine(caminhoCompleto, Foto));
            }

            oWordDoc.SaveAs2(ArquivoSave);
            oWordDoc.Close();
           }

              #endregion
        }

    }
