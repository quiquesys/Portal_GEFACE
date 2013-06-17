using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using PGENL0001;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Portal_GEFACE.geface
{
    public class Informacion
    {
        string _usuario;

        public string Usuario
        {
          get { return _usuario; }
          set { _usuario = value; }
        }        
        /// <summary>
        /// Llena el DropDownList con las compañias a las que tiene autorización
        /// </summary>
        /// <param name="ddlCompanias">DropDownList de compañias a llenar</param>
        public void mCargaCompanias(ref DropDownList ddlCompanias)
        {
            AccesoDatos acd = new AccesoDatos();
            string qry = String.Format(querys.Companias_EFACE_AS400, Usuario);
            DataTable empresas = acd.RealizaConsulta(qry);
            DataTable temp = empresas.Clone();
            temp.Columns["NOMBRE"].MaxLength = 100;
            temp.Rows.Add("-1", "Seleccione Compañia...");
            if (empresas.Rows.Count > 0)
            {
                foreach (DataRow r in empresas.Rows)
                {
                    temp.Rows.Add(r[0].ToString(), r[1].ToString());
                }
            }
            ddlCompanias.DataSource = temp;
            ddlCompanias.DataValueField = "CODIGO";
            ddlCompanias.DataTextField = "NOMBRE";
            ddlCompanias.DataBind();
            
        }
        public void mCargaTipoDocumento(ref DropDownList ddlTypeDoc)
        {
            DataTable TipoDoc = getDataSQLSvr(querys.TipoDoc_PDF);
            DataTable temp = TipoDoc.Clone();
            temp.Columns["NOMBRE"].MaxLength = 300;
            temp.Rows.Add("-1", "Seleccione Tipo...");
            if (TipoDoc.Rows.Count > 0)
            {
                foreach (DataRow r in TipoDoc.Rows)
                {
                    temp.Rows.Add(r[0].ToString(), r[1].ToString());
                }
            }
            ddlTypeDoc.DataSource = temp;
            ddlTypeDoc.DataValueField = "TIPO";
            ddlTypeDoc.DataTextField = "NOMBRE";
            ddlTypeDoc.DataBind();
        }
        public void ListMonths(ref DropDownList ddlMonth)
        {
            ddlMonth.Items.Clear();            
            DataTable meses = new DataTable();
            meses.Columns.Add("ID");
            meses.Columns.Add("MES");
            meses.Rows.Add("0", "Seleccione Mes...");
            meses.Rows.Add("1", "ENERO");
            meses.Rows.Add("2", "FEBRERO");
            meses.Rows.Add("3", "MARZO");
            meses.Rows.Add("4", "ABRIL");
            meses.Rows.Add("5", "MAYO");
            meses.Rows.Add("6", "JUNIO");
            meses.Rows.Add("7", "JULIO");
            meses.Rows.Add("8", "AGOSTO");
            meses.Rows.Add("9", "SEPTIEMBRE");
            meses.Rows.Add("10", "OCTUBRE");
            meses.Rows.Add("11", "NOVIEMBRE");
            meses.Rows.Add("12", "DICIEMBRE");
            ddlMonth.DataSource = meses;
            ddlMonth.DataValueField = "ID";
            ddlMonth.DataTextField = "MES";
            ddlMonth.DataBind();                    
        }
        public void ListYears(ref DropDownList ddlYear, int initiation, int final)
        {
            ddlYear.Items.Clear();            
            DataTable anio = new DataTable();
            anio.Columns.Add("ID");
            anio.Columns.Add("ANIO");
            anio.Rows.Add("-1", "Seleccione Año...");
            for (int i = initiation; i < final+1; i++)
            {
                anio.Rows.Add(i, i);
            }
            ddlYear.DataSource = anio;
            ddlYear.DataValueField = "ID";
            ddlYear.DataTextField = "ANIO";
            ddlYear.DataBind();            
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
        /// <summary>
        /// Obtiene las iniciales de la compania a partir de su codigo
        /// </summary>
        /// <param name="codCompania">codigo de la compania (ej. 45,66,130)</param>
        /// <returns>retorna las iniciales de la compania (ej. cs,ac,rc)</returns>
        public string obtenerCompania(string codCompania)
        {
            string compania = "";
            switch (codCompania)
            {
                case "45": compania = "CS";
                    break;
                case "66": compania = "AC";
                    break;
                case "130": compania = "RC";
                    break;
                case "192": compania = "RE";
                    break;
                case "199": compania = "AA";
                    break;
            }
            return compania;
        }
        public string obtenerMes(string codMes)
        {
            string strMes = "";
            switch (int.Parse(codMes))
            {
                case 1: strMes = "ENERO"; break;
                case 2: strMes = "FEBRERO"; break;
                case 3: strMes = "MARZO"; break;
                case 4: strMes = "ABRIL"; break;
                case 5: strMes = "MAYO"; break;
                case 6: strMes = "JUNIO"; break;
                case 7: strMes = "JULIO"; break;
                case 8: strMes = "AGOSTO"; break;
                case 9: strMes = "SEPTIEMBRE"; break;
                case 10: strMes = "OCTUBRE"; break;
                case 11: strMes = "NOVIEMBRE"; break;
                case 12: strMes = "DICIEMBRE"; break;
            }
            return strMes;
        }
    }
}
