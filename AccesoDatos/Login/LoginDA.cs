using Entidades.Login;
using Entidades.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Login
{
    public class LoginDA
    {
        public LoginBE IniciarSesion(SqlConnection cnBD, LoginBE obe)
        {
            LoginBE lobe = null;
            List<ListaComboBE> lobeT = null;
            ListaComboBE obeT = null;
            List<MenuBE> lobeM = null;
            MenuBE obeM = null;
            MenuDetalleBE obeMD = null;
            List<DetalleInfoBE> lobe1 = null;
            DetalleInfoBE obe1 = null;
            List<DetalleInfoBE> lobe2 = null;
            DetalleInfoBE obe2 = null;

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_Login_Sesion]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@UsuarioLogin", SqlDbType.VarChar, 20).Value = obe.usuarioLogin;
                cmd.Parameters.Add("@PassWord", SqlDbType.VarChar, 50).Value = obe.passwordLogin;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    if (drd.HasRows)
                    {
                        #region Columnas
                        int pos_UsuarioLogin = drd.GetOrdinal("UsuarioLogin");
                        int pos_UsuarioId = drd.GetOrdinal("UsuarioId");
                        int pos_UsuarioNombre = drd.GetOrdinal("UsuarioNombre");
                        int pos_UsuarioApePat = drd.GetOrdinal("UsuarioApePat");
                        int pos_UsuarioApeMat = drd.GetOrdinal("UsuarioApeMat");
                        int pos_UsuarioDNI = drd.GetOrdinal("UsuarioDNI");
                        int pos_Email = drd.GetOrdinal("Email");
                        int pos_IdCliente = drd.GetOrdinal("IdCliente");
                        int pos_Cliente = drd.GetOrdinal("Cliente");
                        int pos_isAdministrador = drd.GetOrdinal("isAdministrador");
                        int pos_IdPerfil = drd.GetOrdinal("IdPerfil");
                        int pos_PerfilDes = drd.GetOrdinal("PerfilDes");
                        int pos_imagen = drd.GetOrdinal("imagen");
                        int pos_background = drd.GetOrdinal("background");
                        //DATOS DEL CLIENTE BASE
                        int pos_tittleHeader = drd.GetOrdinal("tittleHeader");
                        int pos_imageHeader = drd.GetOrdinal("imageHeader");
                        int pos_tittleFooter = drd.GetOrdinal("tittleFooter");
                        int pos_footer = drd.GetOrdinal("footer");
                        int pos_isTipoProducto = drd.GetOrdinal("isTipoProducto");
                        int pos_isCostoProduccion = drd.GetOrdinal("isCostoProduccion");
                        int pos_isFechaVenProd = drd.GetOrdinal("isFechaVenProd");
                        int pos_isLaboratorio = drd.GetOrdinal("isLaboratorio");
                        int pos_isNombreGenerico = drd.GetOrdinal("isNombreGenerico");
                        int pos_isGrupoMedico = drd.GetOrdinal("isGrupoMedico");
                        int pos_isTipoMedico = drd.GetOrdinal("isTipoMedico");
                        int pos_isTipoPresentacion = drd.GetOrdinal("isTipoPresentacion");
                        int pos_isComposicion = drd.GetOrdinal("isComposicion");
                        int pos_isContraIndicaciones = drd.GetOrdinal("isContraIndicaciones");
                        int pos_isUbicacion = drd.GetOrdinal("isUbicacion");
                        int pos_isLote = drd.GetOrdinal("isLote");
                        #endregion columnas
                        while (drd.Read())
                        {
                            #region listado
                            lobe = new LoginBE();
                            lobe.usuarioLogin = drd.GetString(pos_UsuarioLogin);
                            lobe.usuarioId = drd.GetInt32(pos_UsuarioId);
                            lobe.usuarioNombre = drd.GetString(pos_UsuarioNombre);
                            lobe.usuarioApePat = drd.GetString(pos_UsuarioApePat);
                            lobe.usuarioApeMat = drd.GetString(pos_UsuarioApeMat);
                            lobe.usuarioDNI = drd.GetString(pos_UsuarioDNI);
                            lobe.email = drd.GetString(pos_Email);
                            lobe.idCliente = drd.GetInt32(pos_IdCliente);
                            lobe.cliente = drd.GetString(pos_Cliente);
                            lobe.idPerfil = drd.GetInt32(pos_IdPerfil);
                            lobe.perfil = drd.GetString(pos_PerfilDes);
                            lobe.imagen = drd.GetString(pos_imagen);
                            lobe.background = drd.GetString(pos_background);
                            lobe.loMenu = new List<MenuBE>();
                            lobe.loFooter = new List<DetalleInfoBE>();
                            lobe.loNotification = new List<DetalleInfoBE>();
                            //DATOS DEL CLIENTE BASE
                            lobe.tittleHeader = drd.GetString(pos_tittleHeader);
                            lobe.imageHeader = drd.GetString(pos_imageHeader);
                            lobe.tittleFooter = drd.GetString(pos_tittleFooter);
                            lobe.footer = drd.GetString(pos_footer);
                            //PERMISOS DEL CLIENTE
                            lobe.isAdministrador = drd.GetBoolean(pos_isAdministrador);
                            lobe.isTipoProducto = drd.GetBoolean(pos_isTipoProducto);
                            lobe.isCostoProduccion = drd.GetBoolean(pos_isCostoProduccion);
                            lobe.isFechaVenProd = drd.GetBoolean(pos_isFechaVenProd);
                            lobe.isLaboratorio = drd.GetBoolean(pos_isLaboratorio);
                            lobe.isNombreGenerico = drd.GetBoolean(pos_isNombreGenerico);
                            lobe.isGrupoMedico = drd.GetBoolean(pos_isGrupoMedico);
                            lobe.isTipoMedico = drd.GetBoolean(pos_isTipoMedico);
                            lobe.isTipoPresentacion = drd.GetBoolean(pos_isTipoPresentacion);
                            lobe.isComposicion = drd.GetBoolean(pos_isComposicion);
                            lobe.isContraIndicaciones = drd.GetBoolean(pos_isContraIndicaciones);
                            lobe.isUbicacion = drd.GetBoolean(pos_isUbicacion);
                            lobe.isLote = drd.GetBoolean(pos_isLote);
                            #endregion listado
                        }
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region Columnas
                        int pos_IdTienda = drd.GetOrdinal("codigo");
                        int pos_NombreTienda = drd.GetOrdinal("descripcion");
                        #endregion columnas
                        lobeT = new List<ListaComboBE>();
                        while (drd.Read())
                        {
                            #region listado
                            obeT = new ListaComboBE();
                            obeT.codigo = drd.GetInt32(pos_IdTienda);
                            obeT.descripcion = drd.GetString(pos_NombreTienda);
                            lobeT.Add(obeT);
                            #endregion listado
                        }
                        lobe.loTienda = lobeT;
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region columnas
                        int pos_IdMenu = drd.GetOrdinal("IdMenu");
                        int pos_Menu = drd.GetOrdinal("Menu");
                        int pos_MenuParent = drd.GetOrdinal("MenuParent");
                        int pos_IconClass = drd.GetOrdinal("IconClass");
                        int pos_Url = drd.GetOrdinal("Url");
                        int pos_isActive = drd.GetOrdinal("isActive");
                        #endregion columnas
                        lobeM = new List<MenuBE>();
                        while (drd.Read())
                        {
                            #region listado
                            obeM = new MenuBE();
                            obeM.id = drd.GetInt32(pos_IdMenu);
                            obeM.description = drd.GetString(pos_Menu);
                            obeM.idParent = drd.GetInt32(pos_MenuParent);
                            obeM.icon = drd.GetString(pos_IconClass);
                            obeM.url = drd.GetString(pos_Url);
                            obeM.active = drd.GetBoolean(pos_isActive);
                            obeM.detalle = new List<MenuDetalleBE>();
                            #endregion listado
                            #region carga
                            if (obeM.idParent != 0)
                            {
                                obeMD = new MenuDetalleBE();
                                obeMD.id = drd.GetInt32(pos_IdMenu);
                                obeMD.description = drd.GetString(pos_Menu);
                                obeMD.idParent = 0;
                                obeMD.icon = drd.GetString(pos_IconClass);
                                obeMD.url = drd.GetString(pos_Url);
                                obeMD.active = drd.GetBoolean(pos_isActive);

                                int index = lobeM.FindIndex(ind => ind.id == obeM.idParent);
                                if(index != -1)
                                {
                                    lobeM[index].detalle.Add(obeMD);
                                }
                            } else
                            {
                                lobeM.Add(obeM);
                            }
                            #endregion carga
                        }
                        lobe.loMenu = lobeM;
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region columnas
                        int pos_Id = drd.GetOrdinal("id");
                        int pos_Icon = drd.GetOrdinal("icon");
                        int pos_URL = drd.GetOrdinal("url");
                        #endregion columnas
                        lobe1 = new List<DetalleInfoBE>();
                        while (drd.Read())
                        {
                            #region listado
                            obe1 = new DetalleInfoBE();
                            obe1.id = drd.GetInt32(pos_Id);
                            obe1.icon = drd.GetString(pos_Icon);
                            obe1.url = drd.GetString(pos_URL);
                            lobe1.Add(obe1);
                            #endregion listado
                        }
                        lobe.loFooter = lobe1;
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region columnas
                        int pos_Id = drd.GetOrdinal("id");
                        int pos_Icon = drd.GetOrdinal("icon");
                        int pos_IconColor = drd.GetOrdinal("iconColor");
                        int pos_Description = drd.GetOrdinal("description");
                        #endregion columnas
                        lobe2 = new List<DetalleInfoBE>();
                        while (drd.Read())
                        {
                            #region listado
                            obe2 = new DetalleInfoBE();
                            obe2.id = drd.GetInt32(pos_Id);
                            obe2.icon = drd.GetString(pos_Icon);
                            obe2.iconColor = drd.GetString(pos_IconColor);
                            obe2.description = drd.GetString(pos_Description);
                            lobe2.Add(obe2);
                            #endregion listado
                        }
                        lobe.loNotification = lobe2;
                    }
                }
            }
            return lobe;
        }


    }
}
