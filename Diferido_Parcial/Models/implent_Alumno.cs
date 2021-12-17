using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using Diferido_Parcial.Models;

namespace Diferido_Parcial.Models
{
    public class implent_Alumno
    {
        public List<Alumn> GetAlumns()
        {

            List<Alumn> Codlist = new List<Alumn>();
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqconn = new MySqlConnection(mainconn);
            string sqlquery = "select * from alumno";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqconn);
            mysqconn.Open();

            MySqlDataAdapter mda = new MySqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            mda.Fill(dt);

            mysqconn.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Codlist.Add(new Alumn
                {
                    CodAlumno = Convert.ToInt32(dr["codAlumno"]),
                    Nombres = Convert.ToString(dr["nombres"]),
                    apellidos = Convert.ToString(dr["apellidos"]),
                    edad = Convert.ToInt32(dr["edad"]),
                    direccion = Convert.ToString(dr["direccion"])
                });
            }

            return Codlist;
        }

        public bool insertal(Alumn inserAlun)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqconn = new MySqlConnection(mainconn);
            string sqlquery = "insert into alumno (codAlumno,nombres,apellidos,edad,direccion) values ('"+inserAlun.CodAlumno +"','"+inserAlun.Nombres+"','"+inserAlun.apellidos+"','"+inserAlun.edad +"','"+inserAlun.direccion+"')";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqconn);
            mysqconn.Open();
            int i = sqlcomm.ExecuteNonQuery();
            mysqconn.Close();
            if (i>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool editalum(Alumn alumedit)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqconn = new MySqlConnection(mainconn);
            string sqlquery = "update alumno set nombres = '"+alumedit.Nombres+ "'' where codAlumno ='"+alumedit.CodAlumno+"'";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqconn);
            mysqconn.Open();
            int i = sqlcomm.ExecuteNonQuery();
            mysqconn.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool eliminaralumno (int id)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqconn = new MySqlConnection(mainconn);
            string sqlquery = "Delete from alumno where  codAlumno="+id;
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqconn);
            mysqconn.Open();
            int i = sqlcomm.ExecuteNonQuery();
            mysqconn.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


}