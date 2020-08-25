using AccesoDatos.Ajustes;
using AccesoDatos.Maestros;
using Entidades.Ajustes;
using Entidades.Utils;
using Logica.ArchivosAdjuntos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Ajustes
{
    public class ClienteBL
    {

        //string strCnx;
        string strCnxRule;
        ClienteDA oClienteDA;
        MaestrosDA oMaestrosDA;
        ArchivosAdjuntosBL oArchivosAdjuntosBL;

        public ClienteBL()
        {
            //strCnx = ConfigurationManager.ConnectionStrings["cnxChelita"].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oClienteDA = new ClienteDA();
            oMaestrosDA = new MaestrosDA();
            oArchivosAdjuntosBL = new ArchivosAdjuntosBL();
        }

        public Cliente_DatosInicialesBE ListarDatosIniciales(string usuario, int idCliente)
        {
            Cliente_DatosInicialesBE obe = new Cliente_DatosInicialesBE();
            List<ClienteBE> lobe = new List<ClienteBE>();
            List<ListaComboTextBE> loTipoDocIdentidad = new List<ListaComboTextBE>();

            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                lobe = oClienteDA.ListarDatosIniciales(con, usuario);
                loTipoDocIdentidad = oMaestrosDA.TipoDocumentoIdentidad(con, usuario);
            }

            obe.loListado = lobe;
            obe.loTipoDocIdentidad = loTipoDocIdentidad;

            return obe;
        }

        public bool Guardar(ClienteBE obe, out bool rptaF, out bool rptaL)
        {
            bool rpta = false;
            rptaF = false;
            rptaL = false;
            int idCliente = 0;
            SqlTransaction sqltrans;
            SqlTransaction sqltransArch;
            SqlTransaction sqltransLogo;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oClienteDA.Guardar(con, sqltrans, obe, out idCliente);
                if (rpta)
                {
                    sqltrans.Commit();
                    //----- GUARDAR CERTIFICADO
                    #region certificado
                    if (idCliente != 0 && obe.loarchivos.Count > 0)
                    {
                        for (var j = 0; j < obe.loarchivos.Count; j += 1)
                        {
                            obe.loarchivos[j].NombreCarpeta = idCliente.ToString();//.PadLeft(12, '0');
                        }
                        string msj = "";
                        rptaF = oArchivosAdjuntosBL.GuardarArchivoVUE(obe.loarchivos, out msj);
                        if (rptaF)
                        {
                            sqltransArch = con.BeginTransaction();
                            string[] rutas = msj.Split('#');
                            for (var i = 0; i < rutas.Length; i += 1)
                            {
                                rptaF = oClienteDA.GuardarURL(con, sqltransArch, rutas[i], idCliente, obe.UsrCreador);
                                if (!rptaF)
                                {
                                    break;
                                }
                            }

                            if (rptaF)
                            {
                                sqltransArch.Commit();
                            }
                            else
                            {
                                sqltransArch.Rollback();
                            }
                        }
                        else
                        {
                            rptaF = true;
                        }
                    }
#endregion certificado
                    //----- GUARDAR LOGO
                    #region logo
                    if (idCliente != 0 && obe.lologo.Count > 0)
                    {
                        for (var j = 0; j < obe.lologo.Count; j += 1)
                        {
                            obe.lologo[j].NombreCarpeta = idCliente.ToString();//.PadLeft(12, '0');
                        }
                        string msj = "";
                        rptaL = oArchivosAdjuntosBL.GuardarArchivoVUE(obe.lologo, out msj);
                        if (rptaL)
                        {
                            sqltransLogo = con.BeginTransaction();
                            string[] rutas = msj.Split('#');
                            for (var i = 0; i < rutas.Length; i += 1)
                            {
                                rptaL = oClienteDA.GuardarURLLogo(con, sqltransLogo, rutas[i], idCliente, obe.UsrCreador);
                                if (!rptaL)
                                {
                                    break;
                                }
                            }

                            if (rptaL)
                            {
                                sqltransLogo.Commit();
                            }
                            else
                            {
                                sqltransLogo.Rollback();
                            }
                        }
                        else
                        {
                            rptaL = true;
                        }
                    }
                    #endregion logo
                }
                else
                {
                    sqltrans.Rollback();
                }
            }
            return rpta;
        }

        public bool Actualizar(ClienteBE obe, out bool rptaF, out bool rptaL)
        {
            bool rpta = false;
            rptaF = false;
            rptaL = false;
            int idCliente = 0;
            SqlTransaction sqltrans;
            SqlTransaction sqltransArch;
            SqlTransaction sqltransLogo;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oClienteDA.Actualizar(con, sqltrans, obe, out idCliente);
                if (rpta)
                {
                    sqltrans.Commit();
                    //----- GUARDAR CERTIFICADO
                    #region certificado
                    if (idCliente != 0 && obe.loarchivos.Count > 0)
                    {
                        for (var j = 0; j < obe.loarchivos.Count; j += 1)
                        {
                            obe.loarchivos[j].NombreCarpeta = idCliente.ToString();//.PadLeft(12, '0');
                        }
                        string msj = "";
                        rptaF = oArchivosAdjuntosBL.GuardarArchivoVUE(obe.loarchivos, out msj);
                        if (rptaF)
                        {
                            sqltransArch = con.BeginTransaction();
                            string[] rutas = msj.Split('#');
                            for (var i = 0; i < rutas.Length; i += 1)
                            {
                                rptaF = oClienteDA.GuardarURL(con, sqltransArch, rutas[i], idCliente, obe.UsrCreador);
                                if (!rptaF)
                                {
                                    break;
                                }
                            }

                            if (rptaF)
                            {
                                sqltransArch.Commit();
                            }
                            else
                            {
                                sqltransArch.Rollback();
                            }
                        }
                    }
                    else
                    {
                        rptaF = true;
                    }
                    #endregion certificado
                    //----- GUARDAR LOGO
                    #region logo
                    if (idCliente != 0 && obe.lologo.Count > 0)
                    {
                        for (var j = 0; j < obe.lologo.Count; j += 1)
                        {
                            obe.lologo[j].NombreCarpeta = idCliente.ToString();//.PadLeft(12, '0');
                        }
                        string msj = "";
                        rptaL = oArchivosAdjuntosBL.GuardarArchivoVUE(obe.lologo, out msj);
                        if (rptaL)
                        {
                            sqltransLogo = con.BeginTransaction();
                            string[] rutas = msj.Split('#');
                            for (var i = 0; i < rutas.Length; i += 1)
                            {
                                rptaL = oClienteDA.GuardarURLLogo(con, sqltransLogo, rutas[i], idCliente, obe.UsrCreador);
                                if (!rptaL)
                                {
                                    break;
                                }
                            }

                            if (rptaL)
                            {
                                sqltransLogo.Commit();
                            }
                            else
                            {
                                sqltransLogo.Rollback();
                            }
                        }
                    }
                    else
                    {
                        rptaL = true;
                    }
                    #endregion logo
                }
                else
                {
                    sqltrans.Rollback();
                }
            }
            return rpta;
        }

        public bool Eliminar(ClienteBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oClienteDA.Eliminar(con, sqltrans, obe);
                if (rpta)
                {
                    sqltrans.Commit();
                }
                else
                {
                    sqltrans.Rollback();
                }
            }
            return rpta;
        }

        public bool EliminarLogo(ClienteBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oClienteDA.EliminarLogo(con, sqltrans, obe);
                if (rpta)
                {
                    sqltrans.Commit();
                }
                else
                {
                    sqltrans.Rollback();
                }
            }
            return rpta;
        }

    }
}
