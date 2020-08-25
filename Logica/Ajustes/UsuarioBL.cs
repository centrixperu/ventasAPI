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
    public class UsuarioBL
    {
        //string strCnx;
        string strCnxRule;
        //string CnxCliente = "";
        UsuarioDA oUsuarioDA;
        MaestrosDA oMaestrosDA;
        ArchivosAdjuntosBL oArchivosAdjuntosBL;

        public UsuarioBL(int idCliente)
        {
            //CnxCliente = ConfigurationManager.AppSettings[idCliente.ToString()].ToString();
           // strCnx = ConfigurationManager.ConnectionStrings[CnxCliente].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oUsuarioDA = new UsuarioDA();
            oMaestrosDA = new MaestrosDA();
            oArchivosAdjuntosBL = new ArchivosAdjuntosBL();
        }

        public Usuario_DatosInicialesBE ListarDatosIniciales(string usuario, int idCliente)
        {
            Usuario_DatosInicialesBE obe = new Usuario_DatosInicialesBE();
            List<UsuarioBE> lobe = new List<UsuarioBE>();
            List<ListaComboBE> loCliente = new List<ListaComboBE>();
            List<ListaComboBE> loPerfil = new List<ListaComboBE>();

            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                loCliente = oMaestrosDA.Cliente(con, usuario, idCliente);
                lobe = oUsuarioDA.ListarDatosIniciales(con, usuario);
                loPerfil = oMaestrosDA.ComboPerfil(con, usuario, idCliente);
            }

            obe.loListado = lobe;
            obe.loCliente = loCliente;
            obe.loPerfil = loPerfil;

            return obe;
        }

        public Usuario_DatosInicialesBE ListarDatosCambioCliente(string usuario, int idCliente)
        {
            Usuario_DatosInicialesBE obe = new Usuario_DatosInicialesBE();
            List<ListaComboBE> loPerfil = new List<ListaComboBE>();
            List<ListaComboDetallado> loTienda = new List<ListaComboDetallado>();

            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                loPerfil = oMaestrosDA.ComboPerfil(con, usuario, idCliente);
                loTienda = oMaestrosDA.Tienda(con, usuario);
            }

            obe.loPerfil = loPerfil;
            obe.loTienda = loTienda;

            return obe;
        }

        public bool Guardar(UsuarioBE obe, out bool rptaL)
        {
            bool rpta = false;
            int idUsuario = 0;
            rptaL = false;
            SqlTransaction sqltrans;
            SqlTransaction sqltransLogo;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oUsuarioDA.Guardar(con, sqltrans, obe, out idUsuario);
                if (rpta)
                {
                    sqltrans.Commit();
                    //----- GUARDAR LOGO
                    #region logo
                    if (idUsuario != 0 && obe.lologo.Count > 0)
                    {
                        for (var j = 0; j < obe.lologo.Count; j += 1)
                        {
                            obe.lologo[j].NombreCarpeta = obe.IdCliente.ToString();//.PadLeft(12, '0');
                        }
                        string msj = "";
                        rptaL = oArchivosAdjuntosBL.GuardarArchivoVUE(obe.lologo, out msj);
                        if (rptaL)
                        {
                            sqltransLogo = con.BeginTransaction();
                            string[] rutas = msj.Split('#');
                            for (var i = 0; i < rutas.Length; i += 1)
                            {
                                rptaL = oUsuarioDA.GuardarURLLogo(con, sqltransLogo, rutas[i], idUsuario, obe.UsrCreador);
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

        public bool Actualizar(UsuarioBE obe, out bool rptaL)
        {
            bool rpta = false;
            int idUsuario = 0;
            rptaL = false;
            SqlTransaction sqltrans;
            SqlTransaction sqltransLogo;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oUsuarioDA.Actualizar(con, sqltrans, obe, out idUsuario);
                if (rpta)
                {
                    sqltrans.Commit();
                    //----- GUARDAR LOGO
                    #region logo
                    if (idUsuario != 0 && obe.lologo.Count > 0)
                    {
                        for (var j = 0; j < obe.lologo.Count; j += 1)
                        {
                            obe.lologo[j].NombreCarpeta = obe.IdCliente.ToString();//.PadLeft(12, '0');
                        }
                        string msj = "";
                        rptaL = oArchivosAdjuntosBL.GuardarArchivoVUE(obe.lologo, out msj);
                        if (rptaL)
                        {
                            sqltransLogo = con.BeginTransaction();
                            string[] rutas = msj.Split('#');
                            for (var i = 0; i < rutas.Length; i += 1)
                            {
                                rptaL = oUsuarioDA.GuardarURLLogo(con, sqltransLogo, rutas[i], idUsuario, obe.UsrCreador);
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

        public bool Eliminar(UsuarioBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oUsuarioDA.Eliminar(con, sqltrans, obe);
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
