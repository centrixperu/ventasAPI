using AccesoDatos.AdministrarProducto;
using AccesoDatos.Maestros;
using Entidades.AdministrarProducto;
using Entidades.Ajustes;
using Entidades.Almacen.AdministrarProducto;
using Entidades.Almacen.AsignarAlmacen;
using Entidades.Utils;
using Logica.ArchivosAdjuntos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.AdministrarProducto
{
    public class AdministrarProductoBL
    {
        string strCnx;
        string CnxCliente = "";
        string strCnxRule;
        AdministrarProductoDA oAdministrarProductoDA;
        ArchivosAdjuntosBL oArchivosAdjuntosBL;
        MaestrosDA oMaestrosDA;

        public AdministrarProductoBL(int idCliente)
        {
            CnxCliente = ConfigurationManager.AppSettings[idCliente.ToString()].ToString();
            strCnx = ConfigurationManager.ConnectionStrings[CnxCliente].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oAdministrarProductoDA = new AdministrarProductoDA();
            oArchivosAdjuntosBL = new ArchivosAdjuntosBL();
            oMaestrosDA = new MaestrosDA();
        }

        public AdministrarProducto_DatosInicialesBE ListarDatosIniciales(string usuario, int idCliente)
        {
            AdministrarProducto_DatosInicialesBE lobe = new AdministrarProducto_DatosInicialesBE();

            List<ListaComboTextBE> obeUnidadMedida = new List<ListaComboTextBE>();
            List<ListaComboTextBE> obeSegmento = new List<ListaComboTextBE>();
            List<ListaComboTextBE> obeFamilia = new List<ListaComboTextBE>();
            List<ListaComboTextBE> obeClase = new List<ListaComboTextBE>();
            List<ListaComboTextBE> obeProducto = new List<ListaComboTextBE>();
            List<ListaComboBE> obeTipoPresentacion = new List<ListaComboBE>();
            List<ListaComboBE> obeGrupoMedico = new List<ListaComboBE>();
            List<ListaComboBE> obeLaboratorio = new List<ListaComboBE>();
            ClienteBE obeCliente = new ClienteBE();

            using (SqlConnection conR = new SqlConnection(strCnxRule))
            {
                conR.Open();
                obeUnidadMedida = oMaestrosDA.UnidadMedida(conR, usuario);
                obeSegmento = oMaestrosDA.Segmento(conR, usuario);
                obeFamilia = oMaestrosDA.Familia(conR, usuario, "00");
                obeClase = oMaestrosDA.Clase(conR, usuario, "00", "00");
                obeProducto = oMaestrosDA.Producto(conR, usuario, "00", "00", "00");
                obeCliente = oMaestrosDA.DatosCliente(conR, usuario, idCliente);
                obeTipoPresentacion = oMaestrosDA.Producto_TipoPresentacion(conR, usuario, idCliente);
                obeGrupoMedico = oMaestrosDA.Producto_GrupoMedico(conR, usuario, idCliente);
                obeLaboratorio = oMaestrosDA.Producto_Laboratorio(conR, usuario, idCliente);
            }

            List<ListaComboBE> obeTalla = new List<ListaComboBE>();
            List<ListaComboBE> obeTipoProducto = new List<ListaComboBE>();
            List<ListaComboBE> obeColor = new List<ListaComboBE>();
            List<AdministrarProductoBE> obeLista = new List<AdministrarProductoBE>();

            List<ReporteColumnas> loColumns = new List<ReporteColumnas>();
            List<AdministrarProductoExportBE> loExport = new List<AdministrarProductoExportBE>();

            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                obeTalla = oMaestrosDA.Talla(con, usuario);
                obeColor = oMaestrosDA.Color(con, usuario);
                obeTipoProducto = oMaestrosDA.ComboTipoProducto(con, usuario, idCliente);
                obeLista = oAdministrarProductoDA.ListaProducto(con, usuario, out loColumns, out loExport);
            }

            lobe.loUnidadMedida = obeUnidadMedida;
            lobe.loSegmentos = obeSegmento;
            lobe.loFamilia = obeFamilia;
            lobe.loClase = obeClase;
            lobe.loProducto = obeProducto;
            lobe.loTalla = obeTalla;
            lobe.loColor = obeColor;
            lobe.loTipoProducto = obeTipoProducto;
            lobe.loLista = obeLista;

            lobe.loProdLaboratorio = obeLaboratorio;
            lobe.loProdGrupo = obeGrupoMedico;
            lobe.loProdTipoPresentacion = obeTipoPresentacion;

            lobe.loColumns = loColumns;
            lobe.loExport = loExport;
            return lobe;
        }
        public List<AsignarAlmacen_ProductoBE> ListarProductos(string usuario, int idCliente, string busqueda)
        {
            List<AsignarAlmacen_ProductoBE> lobe = new List<AsignarAlmacen_ProductoBE>();

            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                lobe = oMaestrosDA.ListaProducto(con, usuario, 1, 0, busqueda);
            }

            return lobe;
        }

        public List<ListaComboTextBE> ListarFamilia(string usuario, string codigo)
        {
            List<ListaComboTextBE> obeFamilia = new List<ListaComboTextBE>();
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                obeFamilia = oMaestrosDA.Familia(con, usuario, codigo);
            }
            return obeFamilia;
        }
        public List<ListaComboTextBE> ListarClase(string usuario, string idsegmento, string codigo)
        {
            List<ListaComboTextBE> obeClase = new List<ListaComboTextBE>();
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                obeClase = oMaestrosDA.Clase(con, usuario, idsegmento, codigo);
            }
            return obeClase;
        }
        public List<ListaComboTextBE> ListarProducto(string usuario, string idsegmento, string idfamilia, string codigo)
        {
            List<ListaComboTextBE> obeProducto = new List<ListaComboTextBE>();
            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                obeProducto = oMaestrosDA.Producto(con, usuario, idsegmento, idfamilia, codigo);
            }
            return obeProducto;
        }

        public bool Guardar(AdministrarProductoBE obe, out bool rptaF, out string msjError)
        {
            bool rpta = false;
            rptaF = false;
            msjError = "";
            int id = 0;
            SqlTransaction sqltrans;
            SqlTransaction sqltransArch;
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oAdministrarProductoDA.Guardar(con, sqltrans, obe, out id, out msjError);
                if (rpta)
                {
                    sqltrans.Commit();
                    if (id != 0 && obe.loarchivos.Count > 0)
                    {
                        //for (var j = 0; j < obe.loarchivos.Count; j += 1)
                        //{
                        //    obe.loarchivos[j].NombreCarpeta = id.ToString().PadLeft(12, '0');
                        //}
                        string msj = "";
                        rptaF = oArchivosAdjuntosBL.GuardarArchivoVUE(obe.loarchivos, out msj);
                        if (rptaF)
                        {
                            sqltransArch = con.BeginTransaction();
                            string[] rutas = msj.Split('#');
                            for (var i = 0; i < rutas.Length; i += 1)
                            {
                                rptaF = oAdministrarProductoDA.GuardarURL(con, sqltransArch, rutas[i], id, obe.UsrCreador);
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
                }
                else
                {
                    sqltrans.Rollback();
                }
            }
            return rpta;
        }

        public bool Actualizar(AdministrarProductoBE obe, out bool rptaF, out string msjError)
        {
            bool rpta = false;
            rptaF = false;
            msjError = "";
            int id = 0;
            SqlTransaction sqltrans;
            SqlTransaction sqltransArch;
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oAdministrarProductoDA.Actualizar(con, sqltrans, obe, out id, out msjError);
                if (rpta)
                {
                    sqltrans.Commit();
                    if (id != 0 && obe.loarchivos.Count > 0)
                    {
                        //for (var j = 0; j < obe.loarchivos.Count; j += 1)
                        //{
                        //    obe.loarchivos[j].NombreCarpeta = id.ToString().PadLeft(12, '0');
                        //}
                        string msj = "";
                        rptaF = oArchivosAdjuntosBL.GuardarArchivoVUE(obe.loarchivos, out msj);
                        if (rptaF)
                        {
                            sqltransArch = con.BeginTransaction();
                            string[] rutas = msj.Split('#');
                            for (var i = 0; i < rutas.Length; i += 1)
                            {
                                rptaF = oAdministrarProductoDA.GuardarURL(con, sqltransArch, rutas[i], id, obe.UsrCreador);
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
                }
                else
                {
                    sqltrans.Rollback();
                }
            }
            return rpta;
        }

        public bool Eliminar(AdministrarProductoBE obe)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oAdministrarProductoDA.Eliminar(con, sqltrans, obe);
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

        public bool EliminarAdjunto(int Id, string URL, int IdProducto, string UsrModificador)
        {
            bool rpta = false;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oAdministrarProductoDA.EliminarAdjunto(con, sqltrans, Id, URL, IdProducto, UsrModificador);
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
