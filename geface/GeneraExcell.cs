using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using PGENL0001;


namespace Portal_GEFACE.geface
{
    public class GeneraExcell
    {
        StreamWriter w;        
        DataTable series;        
         public int DoExcell(string ruta,string titulo, DataTable datos)
         {
             FileStream fs = new FileStream(ruta, FileMode.Create, FileAccess.ReadWrite);
             w = new StreamWriter(fs);
             EscribeCabecera(titulo);

             foreach (DataRow dr in datos.Rows)
             {
                 EscribeLinea(dr, datos.Columns.Count);
             }
             EscribePiePagina();
             w.Close();
             return 0;                     
         }
         public MemoryStream DoExcell(string titulo, DataTable datos)
         {
             MemoryStream tmp = new MemoryStream();
             w = new StreamWriter(tmp);
             EscribeCabecera(titulo);
             foreach (DataRow dr in datos.Rows)
             {
                 EscribeLinea(dr, datos.Columns.Count);
             }
             EscribePiePagina();
             w.Close();
             return tmp;
         }

  
  public void EscribeCabecera(string pMes)
  {
   StringBuilder html = new StringBuilder(); 
   html.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
   html.Append("<html>");
   html.Append("  <head>");
   html.Append("<title>COFAL DIVISION INFORMATICA</title>");
   html.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />");
   html.Append("  </head>");
   html.Append("<body>");
   html.Append("<p>");
   html.Append("<table>");   
   html.Append("<tr >");
   //html.Append(String.Format("<td></td> <td bgcolor=\"Blue\" colspan=\"12\"><center>REPORTE {0}</center></td>", pMes));
   html.Append(String.Format("<td></td> <td colspan=\"12\" style=\"border-width: 1px;border: solid; border-color: black;\"><center>{0}</center></td>", pMes));
   html.Append("</tr>");

   html.Append("<tr >");
   html.Append("<td ></td> <td colspan=\"6\" style=\"border-width: 1px;border: solid; border-color: black;\"><center>EFACE</center></td>");
   html.Append("<td colspan=\"6\" style=\"border-width: 1px;border: solid; border-color: black;\"><center>COFAL</center></td>");
   html.Append("</tr>");

   html.Append("<tr >");
   html.Append("<td></td>");
   html.Append("<td style=\"border-width: 1px;border: solid; border-color: black;\"><center>DIA</center></td>");
   html.Append("<td style=\"border-width: 1px;border: solid; border-color: black;\"><center>SUCURSAL</center></td>");
   html.Append("<td style=\"border-width: 1px;border: solid; border-color: black;\"><center>DOCUMENTO</center></td>");
   html.Append("<td style=\"border-width: 1px;border: solid; border-color: black;\"><center>IVA</center></td>");
   html.Append("<td style=\"border-width: 1px;border: solid; border-color: black;\"><center>TOTAL</center></td>");
   html.Append("<td style=\"border-width: 1px;border: solid; border-color: black;\"><center>ESTADO</center></td>");
   html.Append("<td style=\"border-width: 1px;border: solid; border-color: black;\"><center>DIA</center></td>");
   html.Append("<td style=\"border-width: 1px;border: solid; border-color: black;\"><center>SUCURSAL</center></td>");
   html.Append("<td style=\"border-width: 1px;border: solid; border-color: black;\"><center>DOCUMENTO</center></td>");
   html.Append("<td style=\"border-width: 1px;border: solid; border-color: black;\"><center>IVA</center></td>");
   html.Append("<td style=\"border-width: 1px;border: solid; border-color: black;\"><center>TOTAL</center></td>");
   html.Append("<td style=\"border-width: 1px;border: solid; border-color: black;\"><center>ESTADO</center></td>");
    html.Append("</tr>");
    html.Append("</center>");  
   w.Write(html.ToString());   
  }
  
  public void EscribeLinea( DataRow dr, int columnas)
  {   
   string bgColor = "", fontColor = "";
   //if (i % 2 == 0)      
   {
       //bgColor = " bgcolor=\"LightBlue\" ";
       //fontColor = " style=\"font-size: 10px;color: white;\" ";
   }
   w.Write("<tr ><td ></td>");
   for (int k = 0; k < columnas; k++)
       w.Write(String.Format("<td {1} {2} style=\"border-width: 1px;border: solid; border-color: black;\"><center>{0}</center></td>", dr[k], bgColor, fontColor));
   w.Write("</tr>");
//   w.Write(@"<tr ><td ></td><td {2} {3}>Titulo de la celda:{0} 
//             </td><td {2} {3}>Valor de la celda: {1}</td></tr>" ,i.ToString(),i.ToString(), bgColor, fontColor);
  }
  
  public void EscribePiePagina()
  {
   StringBuilder html = new StringBuilder();       
   html.Append("  </table>");
   html.Append("</p>");
   html.Append(" </body>");
   html.Append("</html>");
   w.Write(html.ToString());
  }
        /// <summary>
        /// quita los registros que cuadran
        /// </summary>
        /// <param name="dtEface">Datos de Eface</param>
        /// <param name="dtVentas">Datos de Ventas</param>
  public void depurarDatos(ref DataTable dtEface,ref DataTable dtVentas)
  {
      try
      {
          #region variables de bloque
          int filasEface = dtEface.Rows.Count;
          int filasVentas = dtVentas.Rows.Count;           
          string docEface = "";
          string ivaEface = "";
          string totalEface = "";
          string serieEface = "";
          string estadoEface = "";
          string documentoEface = "";
          string documentoVentas = "";
          string serieVentas = "";
          string estadoVentas = "";
          string docVentas = "";
          string ivaVentas = "";
          string totalVentas = "";
          bool borradoEface = false;
          this.series=getDataSQLSvr(querys.Series);
          #endregion
          for (int fEface = 0; fEface < filasEface; )
          {                
              int fVentas = 0;
              while (fVentas < filasVentas)
              {                  
                  #region extraccion de datos
                  docEface = dtEface.Rows[fEface]["documento"].ToString().Trim();
                  ivaEface = dtEface.Rows[fEface]["iva"].ToString();
                  totalEface = dtEface.Rows[fEface]["total"].ToString();
                  estadoEface = (string.IsNullOrEmpty(dtEface.Rows[fEface]["EstadoDocumento"].ToString())) ? "" : dtEface.Rows[fEface]["EstadoDocumento"].ToString();                                                          
                  docVentas = dtVentas.Rows[fVentas]["documento"].ToString().Trim();
                  if (docVentas.Trim().Equals("O8M001391"))
                      docVentas = "08M001391";
                  if (docVentas.Contains('|'))
                    docVentas = docVentas.Replace('|','0');
                  if (docVentas.Contains('.'))
                      docVentas = docVentas.Replace('.',' ');
                  ivaVentas = dtVentas.Rows[fVentas]["iva"].ToString();
                  totalVentas = dtVentas.Rows[fVentas]["total"].ToString();
                  estadoVentas = (string.IsNullOrEmpty(dtVentas.Rows[fVentas]["estado"].ToString())) ? "" : dtVentas.Rows[fVentas]["estado"].ToString();
                  serieEface = obtieneNumFact(docEface, "S").Trim();
                  serieVentas = obtieneNumFact(docVentas, "S").Trim();
                  documentoEface = int.Parse(obtieneNumFact(docEface, "N").Trim()).ToString();                  
                  string aux = obtieneNumFact(docVentas, "N").Trim();
                  

                  documentoVentas = string.IsNullOrEmpty(aux) ? docVentas : UInt64.Parse(aux).ToString();
                  //documentoVentas = int.Parse(string.IsNullOrEmpty(aux)?docVentas:aux).ToString();
                  #endregion
                  if (serieEface.Equals(serieVentas) && documentoEface.Equals(documentoVentas) && double.Parse(ivaEface).Equals(double.Parse(ivaVentas)) && double.Parse(totalEface).Equals(double.Parse(totalVentas)) && estadoEface.Equals(estadoVentas))
                      {                        
                          dtEface.Rows.RemoveAt(fEface);
                          dtVentas.Rows.RemoveAt(fVentas);                                                                                     
                          borradoEface = true;
                          fVentas = filasVentas;
                      }
                      else
                      {
                          fVentas++;
                      }
              }
              if (borradoEface)
              {
                  borradoEface = false;
                  filasEface--;
                  filasVentas--;                 
              }
              else
              {
                  fEface++;
              }
          }
      }
      catch (Exception err)
      {
          throw new Exception(err.Message);
      }
  }


  public void depurarDatos2(ref DataTable dtEface, ref DataTable dtVentas)
  {
      try
      {
          #region variables de bloque
          int filasEface = dtEface.Rows.Count;
          int filasVentas = dtVentas.Rows.Count;
          string docEface = "";
          string serieEface = "";
          string documentoEface = "";
          string documentoVentas = "";
          string serieVentas = "";
          string docVentas = "";
          bool borradoEface = false;
          this.series = getDataSQLSvr(querys.Series);
          #endregion
          for (int fEface = 0; fEface < filasEface; )
          {
              int fVentas = 0;
              while (fVentas < filasVentas)
              {
                  #region extraccion de datos
                  docEface = dtEface.Rows[fEface]["documento"].ToString().Trim();                                    
                  docVentas = dtVentas.Rows[fVentas]["documento"].ToString().Trim();
                  if (docVentas.Trim().Equals("O8M001391"))
                      docVentas = "08M001391";
                  if (docVentas.Contains('|'))
                      docVentas = docVentas.Replace('|', '0');                  
                  serieEface = obtieneNumFact(docEface, "S").Trim();
                  serieVentas = obtieneNumFact(docVentas, "S").Trim();
                  documentoEface = int.Parse(obtieneNumFact(docEface, "N").Trim()).ToString();
                  string aux = obtieneNumFact(docVentas, "N").Trim();
                  documentoVentas = string.IsNullOrEmpty(aux) ? docVentas : UInt64.Parse(aux).ToString();                  
                  #endregion
                  if (serieEface.Equals(serieVentas) && documentoEface.Equals(documentoVentas) )
                  {
                      dtEface.Rows.RemoveAt(fEface);
                      dtVentas.Rows.RemoveAt(fVentas);
                      borradoEface = true;
                      fVentas = filasVentas;
                  }
                  else
                  {
                      fVentas++;
                  }
              }
              if (borradoEface)
              {
                  borradoEface = false;
                  filasEface--;
                  filasVentas--;
              }
              else
              {
                  fEface++;
              }
          }
      }
      catch (Exception err)
      {
          throw new Exception(err.Message);
      }
  }

        public DataTable UneTablas2(DataTable dtEface, DataTable dtVentas)
        {
            //tabla resultante
            DataTable table = new DataTable();
            DataTable dtVentasCopy = new DataTable();
            dtVentasCopy = dtVentas.Clone();    
            #region crea las nuevas columnas
            DataColumn[] newcolumns = new DataColumn[dtEface.Columns.Count];
            DataColumn[] newcolumns2 = new DataColumn[dtVentas.Columns.Count];            
            for (int i = 0; i < dtEface.Columns.Count; i++)
            {
                newcolumns[i] = new DataColumn(dtEface.Columns[i].ColumnName, dtEface.Columns[i].DataType);
            }
            for (int i = 0; i < dtVentas.Columns.Count; i++)
            {
                newcolumns2[i] = new DataColumn(dtVentas.Columns[i].ColumnName, dtVentas.Columns[i].DataType);                
            }
            #endregion
            //agregar las columnas vacias (esquema o estructura) a la tabla resultante
            table.Columns.AddRange(newcolumns);
            table.Columns.AddRange(newcolumns2);
            table.BeginLoadData(); 
            //carga datos eface
            foreach (DataRow row in dtEface.Rows)
            {
                table.LoadDataRow(row.ItemArray, true);
            }
            //ubica datos Ventas
            bool encontrado = false;
            int posicionExtraccion = -1;
            foreach (DataRow rowVentas in dtVentas.Rows)
            {
                encontrado = false;
                posicionExtraccion++;
                for (int r = 0; r < dtEface.Rows.Count; r++)
                {
                    var docEface = "";
                    var documentoEface = "";
                    var docVentas = "";
                    var documentoVentas = "";
                    var serieEface = "";
                    var serieVentas = "";
                    docVentas = rowVentas["documento"].ToString().Trim();
                    docEface = dtEface.Rows[r]["documento"].ToString().Trim();
                    serieEface = obtieneNumFact(docEface, "S").Trim();
                    serieVentas = obtieneNumFact(docVentas, "S").Trim();
                    documentoEface = int.Parse(obtieneNumFact(docEface, "N").Trim()).ToString();
                    string aux = obtieneNumFact(docVentas, "N").Trim();
                    documentoVentas = string.IsNullOrEmpty(aux) ? docVentas : UInt64.Parse(aux).ToString();
                    //documentoVentas = int.Parse(string.IsNullOrEmpty(aux) ? docVentas : aux).ToString();
                    if (documentoEface.Equals(documentoVentas) && serieEface.Equals(serieVentas))
                    {
                        for (int c = 0; c < dtVentas.Columns.Count; c++)
                        {
                            string cn = dtVentas.Columns[c].ColumnName.ToString();
                            table.Rows[r][cn] = dtVentas.Rows[posicionExtraccion][cn];
                        }
                        encontrado = true;                        
                    }                    
                }
                if (!encontrado)
                {
                    DataRow dr = dtVentasCopy.NewRow();
                    for (int c = 0; c < dtVentas.Columns.Count; c++)
                    {
                        string cn = dtVentas.Columns[c].ColumnName.ToString();
                        dr[cn] = dtVentas.Rows[posicionExtraccion][cn];
                    }
                    dtVentasCopy.Rows.Add(dr);
                }
            }
            int controlNuevoRegistro = -1;
            foreach (DataRow dr in dtVentasCopy.Rows)
            {
                //controlNuevoRegistro++;
                controlNuevoRegistro++;
                DataRow drAux = table.NewRow();
                for (int c = 0; c < dtVentasCopy.Columns.Count; c++)
                {
                    string cn = dtVentasCopy.Columns[c].ColumnName.ToString();
                    drAux[cn] = dtVentasCopy.Rows[controlNuevoRegistro][cn];
                }
                table.Rows.Add(drAux);
            }
            return table;      
        }
  public DataTable UneTablas(DataTable First, DataTable Second)
  {
      //tabla resultante
      DataTable table = new DataTable("Union");
        #region crear las nuevas columnas
      DataColumn[] newcolumns = new DataColumn[First.Columns.Count];
      DataColumn[] newcolumns2 = new DataColumn[Second.Columns.Count];
      for (int i = 0; i < First.Columns.Count; i++)
      {
          newcolumns[i] = new DataColumn(First.Columns[i].ColumnName, First.Columns[i].DataType);
      }
      for (int i = 0; i < Second.Columns.Count; i++)
      {
          newcolumns2[i] = new DataColumn(Second.Columns[i].ColumnName, Second.Columns[i].DataType);
      }
        #endregion
      //agregar las columnas vacias (esquema o estructura) a la tabla resultante
      table.Columns.AddRange(newcolumns);
      table.Columns.AddRange(newcolumns2);
      table.BeginLoadData();      
      //cargar los datos desde la primera tabla
      foreach (DataRow row in First.Rows)
      {
          table.LoadDataRow(row.ItemArray, true);
      }
      if (First.Rows.Count < Second.Rows.Count)
      {
          for (int k = 0; k < Math.Abs(First.Rows.Count - Second.Rows.Count); k++)
          {
              DataRow dr = First.NewRow();
              table.LoadDataRow(dr.ItemArray, true);
          }
      }
      if (First.Rows.Count > Second.Rows.Count)
      {
          for (int k = 0; k < Math.Abs(First.Rows.Count - Second.Rows.Count); k++)
          {
              DataRow dr = Second.NewRow();
              table.LoadDataRow(dr.ItemArray, true);
          }
      }

      //cargar los datos desde la segunda tabla
      for (int r = 0; r < Second.Rows.Count; r++)
      {
          for (int c = 0; c < Second.Columns.Count; c++)
          {
              string cn = Second.Columns[c].ColumnName.ToString();
              table.Rows[r][cn] = Second.Rows[r][cn];
          }
      }
      table.EndLoadData();
      return table;
  }
  private string obtieneNumFact(String gnufac, string Numero_Serie)
  {   
      try
      {
          string nuevoValor = "";          
          //DataTable series = getDataSQLSvr(querys.Series);
          if (series.Rows.Count > 0)
          {
              for (int i = 0; i < series.Rows.Count; i++)
              {
                  if (gnufac.Trim().StartsWith(series.Rows[i]["SERIE"].ToString().Trim()) && !String.IsNullOrEmpty(series.Rows[i]["SERIE"].ToString()))
                  {
                      if (Numero_Serie.Equals("S"))
                      {
                          nuevoValor = series.Rows[i]["SERIE"].ToString();
                          break;
                      }
                      if (Numero_Serie.Equals("N"))
                      {
                          nuevoValor = gnufac.Substring(series.Rows[i]["SERIE"].ToString().Length);
                          break;
                      }
                  }
              }
          }
          return nuevoValor;
      }
      catch (Exception err)
      {
          throw new Exception(" Error al obtener numero de documento xNUFACT " + err.Message);
      }
  }
  private DataTable getDataSQLSvr(String pQuery)
  {
      DataTable retorno = new DataTable();
      SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLEXPRESS"].ConnectionString);
      try
      {
          myConnection.Open();
          string qry = pQuery;
          SqlDataAdapter da = new SqlDataAdapter(qry, myConnection);
          da.Fill(retorno);
      }

      catch (Exception err)
      {
          myConnection.Close();
          throw new Exception(err.Message); ;
      }
      finally
      {
          myConnection.Close();
      }
      return retorno;
  }
  private DataTable JoinDataTables(DataTable t1, DataTable t2, params Func<DataRow, DataRow, bool>[] joinOn)
  {
      DataTable result = new DataTable();
      foreach (DataColumn col in t1.Columns)
      {
          if (result.Columns[col.ColumnName] == null)
              result.Columns.Add(col.ColumnName, col.DataType);
      }
      foreach (DataColumn col in t2.Columns)
      {
          if (result.Columns[col.ColumnName] == null)
              result.Columns.Add(col.ColumnName, col.DataType);
      }
      foreach (DataRow row1 in t1.Rows)
      {
          var joinRows = t2.AsEnumerable().Where(row2 =>
          {
              foreach (var parameter in joinOn)
              {
                  if (!parameter(row1, row2)) return false;
              }
              return true;
          });
          foreach (DataRow fromRow in joinRows)
          {
              DataRow insertRow = result.NewRow();
              foreach (DataColumn col1 in t1.Columns)
              {
                  insertRow[col1.ColumnName] = row1[col1.ColumnName];
              }
              foreach (DataColumn col2 in t2.Columns)
              {
                  insertRow[col2.ColumnName] = fromRow[col2.ColumnName];
              }
              result.Rows.Add(insertRow);
          }
      }
      return result;
  }
    }
}
