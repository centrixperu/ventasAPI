using Entidades.DashBoard;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.DashBoard
{
    public class DashBoardDA
    {

        public DashBoard_DatosInicialesBE ListarDatosIniciales(SqlConnection cnBD, string usuario)
        {
            List<DashBoardBE> loGraficoDia = new List<DashBoardBE>();
            DashBoardBE obeGraficoDia = new DashBoardBE();
            List<DashBoardBE> loGraficoSemana = new List<DashBoardBE>();
            DashBoardBE obeGraficoSemana = new DashBoardBE();
            List<DashBoardBE> loGraficoMes = new List<DashBoardBE>();
            DashBoardBE obeGraficoMes = new DashBoardBE();
            DashBoard_DatosInicialesBE obe = new DashBoard_DatosInicialesBE();

            using (SqlCommand cmd = new SqlCommand("[dbo].[USP_DashBoard_Grafico]", cnBD))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;

                using (SqlDataReader drd = cmd.ExecuteReader())
                {
                    obe = new DashBoard_DatosInicialesBE();
                    loGraficoDia = new List<DashBoardBE>();
                    loGraficoSemana = new List<DashBoardBE>();
                    loGraficoMes = new List<DashBoardBE>();

                    if (drd.HasRows)
                    {
                        #region columnas
                        int pos_Serie = drd.GetOrdinal("serie");
                        int pos_Label = drd.GetOrdinal("label");
                        #endregion columnas
                        //loGraficoDia = new List<DashBoardBE>();
                        obeGraficoDia = new DashBoardBE();
                        List<Decimal> serie = new List<Decimal>();
                        List<String> label = new List<String>();
                        while (drd.Read())
                        {
                            #region cargarData
                            serie.Add(drd.GetInt32(pos_Serie));
                            label.Add(drd.GetString(pos_Label));
                            #endregion cargarData
                        }
                        obeGraficoDia.serie = serie;
                        obeGraficoDia.label = label;
                        loGraficoDia.Add(obeGraficoDia);
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region columnas
                        int pos_Serie = drd.GetOrdinal("serie");
                        int pos_Label = drd.GetOrdinal("label");
                        #endregion columnas
                        //loGraficoSemana = new List<DashBoardBE>();
                        obeGraficoSemana = new DashBoardBE();
                        List<Decimal> serie = new List<Decimal>();
                        List<String> label = new List<String>();
                        while (drd.Read())
                        {
                            #region cargarData
                            serie.Add(drd.GetInt32(pos_Serie));
                            label.Add(drd.GetString(pos_Label));
                            #endregion cargarData
                        }
                        obeGraficoSemana.serie = serie;
                        obeGraficoSemana.label = label;
                        loGraficoSemana.Add(obeGraficoSemana);
                    }
                    drd.NextResult();
                    if (drd.HasRows)
                    {
                        #region columnas
                        int pos_Serie = drd.GetOrdinal("serie");
                        int pos_Label = drd.GetOrdinal("label");
                        #endregion columnas
                        //loGraficoMes = new List<DashBoardBE>();
                        obeGraficoMes = new DashBoardBE();
                        List<Decimal> serie = new List<Decimal>();
                        List<String> label = new List<String>();
                        while (drd.Read())
                        {
                            #region cargarData
                            serie.Add(drd.GetInt32(pos_Serie));
                            label.Add(drd.GetString(pos_Label));
                            #endregion cargarData
                        }
                        obeGraficoMes.serie = serie;
                        obeGraficoMes.label = label;
                        loGraficoMes.Add(obeGraficoMes);
                    }
                    obe.loGraficoDia = loGraficoDia;
                    obe.loGraficoSemana = loGraficoSemana;
                    obe.loGraficoMes = loGraficoMes;
                }
            }
            return obe;
        }
    }
}
