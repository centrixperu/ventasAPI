using AccesoDatos.Maestros;
using AccesoDatos.Venta;
using Entidades.Ajustes;
using Entidades.Almacen.AsignarAlmacen;
using Entidades.Utils;
using Entidades.Venta;
using Entidades.Venta.ListadoVenta;
using Entidades.Venta.RegistroVenta;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica.ArchivosAdjuntos;

namespace Logica.Venta
{
    public class VentaBL
    {
        string strCnx;
        string strCnxRule;
        string CnxCliente = "";
        VentaDA oVentaDA;
        MaestrosDA oMaestrosDA;
        ArchivosAdjuntosBL oArchivosAdjuntosBL;

        public VentaBL(int idCliente)
        {
            CnxCliente = ConfigurationManager.AppSettings[idCliente.ToString()].ToString();
            strCnx = ConfigurationManager.ConnectionStrings[CnxCliente].ConnectionString;
            strCnxRule = ConfigurationManager.ConnectionStrings["cnxRules"].ConnectionString;
            oVentaDA = new VentaDA();
            oMaestrosDA = new MaestrosDA();
            oArchivosAdjuntosBL = new ArchivosAdjuntosBL();
        }

        public Venta_DatosInicialesBE ListarDatosIniciales(string usuario, int idCliente)
        {
            Venta_DatosInicialesBE obe = new Venta_DatosInicialesBE();
            List<ListaComboBE> loTienda = new List<ListaComboBE>();
            List<EmisorBE> loEmisor = new List<EmisorBE>();
            List<ListaComboTextBE> loTipoDocIdentidad = new List<ListaComboTextBE>();

            using (SqlConnection con = new SqlConnection(strCnxRule))
            {
                con.Open();
                loTienda = oMaestrosDA.ComboTienda(con, usuario, idCliente, -1);
                loEmisor = oMaestrosDA.ListaEmisor(con, usuario, idCliente);
                loTipoDocIdentidad = oMaestrosDA.TipoDocumentoIdentidad(con, usuario);
            }

            obe.loTienda = loTienda;
            obe.loEmisor = loEmisor;
            obe.loTipoDocIdentidad = loTipoDocIdentidad;

            return obe;
        }
        public Venta_DatosInicialesBE ListarComprobantes(string usuario, int idCliente, int idTienda)
        {
            Venta_DatosInicialesBE obe = new Venta_DatosInicialesBE();
            //List<AsignarAlmacen_ProductoBE> loProducto = new List<AsignarAlmacen_ProductoBE>();
            List<ListaComboBE> loComprobante = new List<ListaComboBE>();
            //ClienteBE loCliente = new ClienteBE();

            using (SqlConnection conR = new SqlConnection(strCnxRule))
            {
                conR.Open();
                loComprobante = oMaestrosDA.ComboComprobanteTienda(conR, usuario, idCliente, idTienda);
                //loCliente = oMaestrosDA.DatosCliente(conR, usuario, idCliente);
            }

            /*using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                loProducto = oMaestrosDA.ListaProductoXTienda(con, usuario, idCliente, idTienda);
            }*/

            /*if (loProducto != null && loProducto.Count > 0)
            {
                for (int j = 0; j < loProducto.Count; j += 1)
                {
                    loProducto[j].isTipoProducto = loCliente.isTipoProducto;
                    loProducto[j].isFechaVenProd = loCliente.isFechaVenProd;
                    loProducto[j].isCostoProduccion = loCliente.isCostoProduccion;
                }
            }*/

            obe.loComprobante = loComprobante;
            //obe.loProducto = loProducto;

            return obe;
        }
        public Venta_DatosInicialesBE ListarProductos(string usuario, int idCliente, int idTienda)
        {
            Venta_DatosInicialesBE obe = new Venta_DatosInicialesBE();
            List<AsignarAlmacen_ProductoBE> loProducto = new List<AsignarAlmacen_ProductoBE>();
            List<AsignarAlmacen_ProductoBE> loTipoProducto = new List<AsignarAlmacen_ProductoBE>();
            //List<ListaComboBE> loComprobante = new List<ListaComboBE>();
            //ClienteBE loCliente = new ClienteBE();

            /*using (SqlConnection conR = new SqlConnection(strCnxRule))
            {
                conR.Open();
                loComprobante = oMaestrosDA.ComboComprobanteTienda(conR, usuario, idCliente, idTienda);
                loCliente = oMaestrosDA.DatosCliente(conR, usuario, idCliente);
            }*/

            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                loProducto = oMaestrosDA.ListaProductoXTienda(con, usuario, idCliente, idTienda);
                loTipoProducto = oMaestrosDA.ListaTipoProductoXTienda(con, usuario, idCliente, idTienda);
            }
            

            /*if (loProducto != null && loProducto.Count > 0)
            {
                for (int j = 0; j < loProducto.Count; j += 1)
                {
                    loProducto[j].isTipoProducto = loCliente.isTipoProducto;
                    loProducto[j].isFechaVenProd = loCliente.isFechaVenProd;
                    loProducto[j].isCostoProduccion = loCliente.isCostoProduccion;
                }
            }*/

            //obe.loComprobante = loComprobante;
            obe.loProducto = loProducto;
            obe.loTipoProducto = loTipoProducto;

            return obe;
        }

        public List<ListaArchivosAdjuntos> ListarImagenProducto(string usuario, int idProducto)
        {
            List<ListaArchivosAdjuntos> obe = new List<ListaArchivosAdjuntos>();

            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                obe = oMaestrosDA.ListarImagenProducto(con, usuario, idProducto);
            }

            return obe;
        }

        public RespuestaBE Anular(string usuario, int idCliente, int idVenta, out VentaBE obe)
        {
            RespuestaBE rpta = new RespuestaBE();
            List<ListaCorrelativoVentaBE> loComprobante = new List<ListaCorrelativoVentaBE>();
            obe = new VentaBE();
            obe.UsrCreador = usuario;
            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                rpta = oVentaDA.Datos_Anular(con, usuario, idVenta, out obe);
                if (rpta.codigo == 1)
                {
                    SqlTransaction sqltransRule;
                    using (SqlConnection conR = new SqlConnection(strCnxRule))
                    {
                        conR.Open();
                        sqltransRule = conR.BeginTransaction();
                        loComprobante = oVentaDA.TraerCorrelativoAnulacion(conR, sqltransRule, obe);
                        if (loComprobante != null && loComprobante.Count > 0)
                        {
                            obe.UsuarioSOL = loComprobante[0].UsuarioSOL;
                            obe.ClaveSOL = loComprobante[0].ClaveSOL;
                            obe.RUC = loComprobante[0].RUC;
                            obe.URLCertificado = loComprobante[0].URLCertificado;
                            obe.ClaveDigital = loComprobante[0].ClaveDigital;
                            //obe.c_id_documentoNC = loComprobante[0].Serie + '-' + loComprobante[0].Correlativo;
                            //obe.c_tipo_documentoNC = loComprobante[0].TipoDocumentoNC;
                            //obe.c_tipo_documento_nombreNC = loComprobante[0].TipoDocumentoNombreNC;

                            sqltrans = con.BeginTransaction();
                            rpta = oVentaDA.GuardarNV(con, sqltrans, obe);
                            rpta.isFactOnline = loComprobante[0].isFact;
                            if (rpta.codigo == 1)
                            {
                                sqltransRule.Commit();
                                sqltrans.Commit();
                            }
                            else
                            {
                                sqltransRule.Rollback();
                                sqltrans.Rollback();
                            }
                        }
                        else
                        {
                            sqltransRule.Rollback();
                        }
                    }
                }
            }
            return rpta;
        }

        public RespuestaBE AnularNC(string usuario, int idCliente, int idVenta, out VentaBE obe)
        {
            RespuestaBE rpta = new RespuestaBE();
            List<ListaCorrelativoVentaBE> loComprobante = new List<ListaCorrelativoVentaBE>();
            obe = new VentaBE();

            SqlTransaction sqltrans;
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                rpta = oVentaDA.Datos_AnularNC(con, usuario, idVenta, out obe);
                obe.UsrCreador = usuario;
                if (rpta.codigo == 1)
                {
                    SqlTransaction sqltransRule;
                    using (SqlConnection conR = new SqlConnection(strCnxRule))
                    {
                        conR.Open();
                        sqltransRule = conR.BeginTransaction();
                        loComprobante = oVentaDA.TraerCorrelativoAnulacionNC(conR, sqltransRule, obe);
                        if (loComprobante != null && loComprobante.Count > 0)
                        {
                            obe.UsuarioSOL = loComprobante[0].UsuarioSOL;
                            obe.ClaveSOL = loComprobante[0].ClaveSOL;
                            obe.RUC = loComprobante[0].RUC;
                            obe.URLCertificado = loComprobante[0].URLCertificado;
                            obe.ClaveDigital = loComprobante[0].ClaveDigital;
                            obe.c_id_documentoNC = loComprobante[0].Serie + '-' + loComprobante[0].Correlativo;
                            obe.c_tipo_documentoNC = loComprobante[0].TipoDocumentoNC;
                            obe.c_tipo_documento_nombreNC = loComprobante[0].TipoDocumentoNombreNC;

                            sqltrans = con.BeginTransaction();
                            rpta = oVentaDA.GuardarNC(con, sqltrans, obe);
                            rpta.isFactOnline = loComprobante[0].isFact;
                            if (rpta.codigo == 1)
                            {
                                sqltransRule.Commit();
                                sqltrans.Commit();
                            }
                            else
                            {
                                sqltransRule.Rollback();
                                sqltrans.Rollback();
                            }
                        }
                        else
                        {
                            sqltransRule.Rollback();
                        }
                    }
                }
            }
            return rpta;
        }

        public RespuestaBE Guardar(VentaBE obe)
        {
            RespuestaBE rpta = new RespuestaBE();
            List<ListaCorrelativoVentaBE> loComprobante = new List<ListaCorrelativoVentaBE>();
            SqlTransaction sqltransRule;
            using (SqlConnection conR = new SqlConnection(strCnxRule))
            {
                conR.Open();
                sqltransRule = conR.BeginTransaction();
                loComprobante = oVentaDA.TraerCorrelativo(conR, sqltransRule, obe);

                if (loComprobante != null && loComprobante.Count > 0)
                {
                    obe.UsuarioSOL = loComprobante[0].UsuarioSOL;
                    obe.ClaveSOL = loComprobante[0].ClaveSOL;
                    obe.RUC = loComprobante[0].RUC;
                    obe.URLCertificado = loComprobante[0].URLCertificado;
                    obe.ClaveDigital = loComprobante[0].ClaveDigital;
                    obe.c_id_documento = loComprobante[0].Serie + '-' + loComprobante[0].Correlativo;
                    obe.c_id_documentoNV = loComprobante[0].SerieNV + '-' + loComprobante[0].CorrelativoNV;
                    obe.t_impresion = loComprobante[0].impresion;
                    for (var i = 0; i < obe.loDetalle.Count; i += 1)
                    {
                        obe.loDetalle[i].c_id_documento = loComprobante[0].Serie + '-' + loComprobante[0].Correlativo;
                    }
                    obe.c_fecha_emision = DateTime.Now.ToString("MM/dd/yyyy");
                    SqlTransaction sqltrans;
                    int id = 0;
                    bool rptaF = true;
                    using (SqlConnection con = new SqlConnection(strCnx))
                    {
                        con.Open();
                        sqltrans = con.BeginTransaction();
                        rpta = oVentaDA.Guardar(con, sqltrans, obe, loComprobante, out id);
                        if (rpta.codigo == 1 || rpta.codigo == 2)
                        {
                            rpta.isFactOnline = loComprobante[0].isFact;
                            if (id != 0 && obe.loarchivos.Count > 0)
                            {
                                string msj = "";
                                rptaF = oArchivosAdjuntosBL.GuardarArchivoVUE(obe.loarchivos, out msj);
                                if (rptaF)
                                {
                                    string[] rutas = msj.Split('#');
                                    for (var i = 0; i < rutas.Length; i += 1)
                                    {
                                        rptaF = oVentaDA.GuardarReceta(con, sqltrans, rutas[i], id, obe.UsrCreador);
                                        if (!rptaF)
                                        {
                                            break;
                                        }
                                    }
                                }
                            }

                            if (rptaF)
                            {
                                sqltrans.Commit();
                                sqltransRule.Commit();
                            }
                            else
                            {
                                sqltrans.Rollback();
                                sqltransRule.Rollback();
                                rpta.descripcion = "Ocurrió un error al guardar recetas. " + rpta.descripcion;
                                rpta.codigo = 0;
                            }                            
                        }
                        else
                        {
                            sqltransRule.Rollback();
                            sqltrans.Rollback();
                            rpta.descripcion = "Ocurrió un error al guardar información. " + rpta.descripcion;
                            rpta.codigo = 0;
                        }
                    }
                }
                else
                {
                    sqltransRule.Rollback();
                    rpta = new RespuestaBE();
                    rpta.descripcion = "No existe comprobante configurado.";
                    rpta.codigo = 0;
                }
            }
            return rpta;
        }

        public RespuestaBE GuardarACuenta(VentaBE obe)
        {
            RespuestaBE rpta = new RespuestaBE();
            obe.UsuarioSOL = "";
            obe.ClaveSOL = "";
            obe.RUC = "";
            obe.URLCertificado = "";
            obe.ClaveDigital = "";
            obe.c_id_documento = "";
            obe.c_id_documentoNV = "";
            obe.t_impresion = "";
            obe.c_fecha_emision = DateTime.Now.ToString("MM/dd/yyyy");
            SqlTransaction sqltrans;
            int id = 0;
            bool rptaF = true;
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                sqltrans = con.BeginTransaction();
                rpta = oVentaDA.GuardarACuenta(con, sqltrans, obe, out id);
                if (rpta.codigo == 1 || rpta.codigo == 2)
                {
                    rpta.isFactOnline = false;
                    if (id != 0 && obe.loarchivos.Count > 0)
                    {
                        string msj = "";
                        rptaF = oArchivosAdjuntosBL.GuardarArchivoVUE(obe.loarchivos, out msj);
                        if (rptaF)
                        {
                            string[] rutas = msj.Split('#');
                            for (var i = 0; i < rutas.Length; i += 1)
                            {
                                rptaF = oVentaDA.GuardarReceta(con, sqltrans, rutas[i], id, obe.UsrCreador);
                                if (!rptaF)
                                {
                                    break;
                                }
                            }
                        }
                    }

                    if (rptaF)
                    {
                        sqltrans.Commit();
                    } 
                    else
                    {
                        sqltrans.Rollback();
                        rpta.descripcion = "Ocurrio un error al guardar recetas. " + rpta.descripcion;
                        rpta.codigo = 0;
                    }
                }
                else
                {
                    sqltrans.Rollback();
                    rpta.descripcion = "Ocurrio un error al guardar información. " + rpta.descripcion;
                    rpta.codigo = 0;
                }
            }
            return rpta;
        }
        
        public RegistroVentaBE RegistroVentas(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin)
        {
            List<ListaComboBE> lobeTienda = new List<ListaComboBE>();
            using (SqlConnection conR = new SqlConnection(strCnxRule))
            {
                conR.Open();
                lobeTienda = oMaestrosDA.ComboTienda(conR, usuario, idCliente, -1);
            }

            RegistroVentaBE obe = new RegistroVentaBE();
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                if (isDia)
                {
                    obe = oVentaDA.RegistroVentasDia(con, usuario, idCliente, fechaInicio, lobeTienda);
                }
                else if (isMes)
                {
                    obe = oVentaDA.RegistroVentasMes(con, usuario, idCliente, fechaInicio, lobeTienda);
                }
                else if (isAnio)
                {
                    obe = oVentaDA.RegistroVentasAnio(con, usuario, idCliente, fechaInicio, lobeTienda);
                }
                else if (isRango)
                {
                    obe = oVentaDA.RegistroVentasRango(con, usuario, idCliente, fechaInicio, fechaFin, lobeTienda);
                }
            }

            return obe;
        }

        public RegistroVentaBE VerDetalleVenta(string usuario, int idCliente, int idVenta)
        {
            RegistroVentaBE obe = new RegistroVentaBE();
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                obe = oVentaDA.VerDetalleVenta(con, usuario, idCliente, idVenta);
            }

            return obe;
        }

        public ListadoVentaBE ListadoVentas(string usuario, int idCliente, bool isDia, bool isMes, bool isAnio, bool isRango,
                                                    string fechaInicio, string fechaFin)
        {
            List<ListaComboBE> lobeTienda = new List<ListaComboBE>();
            using (SqlConnection conR = new SqlConnection(strCnxRule))
            {
                conR.Open();
                lobeTienda = oMaestrosDA.ComboTienda(conR, usuario, idCliente, -1);
            }

            ListadoVentaBE obe = new ListadoVentaBE();
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                if (isDia)
                {
                    obe = oVentaDA.ListadoVentasDia(con, usuario, idCliente, fechaInicio, lobeTienda);
                }
                else if (isMes)
                {
                    obe = oVentaDA.ListadoVentasMes(con, usuario, idCliente, fechaInicio, lobeTienda);
                }
                else if (isAnio)
                {
                    obe = oVentaDA.ListadoVentasAnio(con, usuario, idCliente, fechaInicio, lobeTienda);
                }
                else if (isRango)
                {
                    obe = oVentaDA.ListadoVentasRango(con, usuario, idCliente, fechaInicio, fechaFin, lobeTienda);
                }
            }

            return obe;
        }

        public ListadoVentaBE ListadoVentasACuenta(string usuario, int idCliente, string codCliente)
        {
            List<ListaComboBE> lobeTienda = new List<ListaComboBE>();
            using (SqlConnection conR = new SqlConnection(strCnxRule))
            {
                conR.Open();
                lobeTienda = oMaestrosDA.ComboTienda(conR, usuario, idCliente, -1);
            }

            ListadoVentaBE obe = new ListadoVentaBE();
            using (SqlConnection con = new SqlConnection(strCnx))
            {
                con.Open();
                obe = oVentaDA.ListadoVentasACuenta(con, usuario, idCliente, codCliente, lobeTienda);
            }

            return obe;
        }

        public RespuestaBE VentaACuenta(VentaBE obe)
        {
            RespuestaBE rpta = new RespuestaBE();
            List<ListaCorrelativoVentaBE> loComprobante = new List<ListaCorrelativoVentaBE>();
            SqlTransaction sqltransRule;
            using (SqlConnection conR = new SqlConnection(strCnxRule))
            {
                conR.Open();
                sqltransRule = conR.BeginTransaction();
                loComprobante = oVentaDA.TraerCorrelativo(conR, sqltransRule, obe);

                if (loComprobante != null && loComprobante.Count > 0)
                {
                    obe.UsuarioSOL = loComprobante[0].UsuarioSOL;
                    obe.ClaveSOL = loComprobante[0].ClaveSOL;
                    obe.RUC = loComprobante[0].RUC;
                    obe.URLCertificado = loComprobante[0].URLCertificado;
                    obe.ClaveDigital = loComprobante[0].ClaveDigital;
                    obe.c_id_documento = loComprobante[0].Serie + '-' + loComprobante[0].Correlativo;
                    obe.c_id_documentoNV = loComprobante[0].SerieNV + '-' + loComprobante[0].CorrelativoNV;
                    obe.t_impresion = loComprobante[0].impresion;
                    for (var i = 0; i < obe.loDetalle.Count; i += 1)
                    {
                        obe.loDetalle[i].c_id_documento = loComprobante[0].Serie + '-' + loComprobante[0].Correlativo;
                    }
                    obe.c_fecha_emision = DateTime.Now.ToString("MM/dd/yyyy");
                    SqlTransaction sqltrans;
                    int id = 0;
                    bool rptaF = true;
                    using (SqlConnection con = new SqlConnection(strCnx))
                    {
                        con.Open();
                        sqltrans = con.BeginTransaction();
                        rpta = oVentaDA.VentaACuenta(con, sqltrans, obe, loComprobante, out id);
                        if (rpta.codigo == 1 || rpta.codigo == 2)
                        {
                            rpta.isFactOnline = loComprobante[0].isFact;
                            
                            if (rptaF)
                            {
                                sqltrans.Commit();
                                sqltransRule.Commit();
                            }
                            else
                            {
                                sqltrans.Rollback();
                                sqltransRule.Rollback();
                                rpta.descripcion = "Ocurrió un error al guardar recetas. " + rpta.descripcion;
                                rpta.codigo = 0;
                            }
                        }
                        else
                        {
                            sqltransRule.Rollback();
                            sqltrans.Rollback();
                            rpta.descripcion = "Ocurrió un error al guardar información. " + rpta.descripcion;
                            rpta.codigo = 0;
                        }
                    }
                }
                else
                {
                    sqltransRule.Rollback();
                    rpta = new RespuestaBE();
                    rpta.descripcion = "No existe comprobante configurado.";
                    rpta.codigo = 0;
                }
            }
            return rpta;
        }

    }
}
