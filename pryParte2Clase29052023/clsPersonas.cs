using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace pryParte2Clase29052023
{
    class clsPersonas
    {

        //propfull agrega variable privada y propiedad
        //no hace falta asique las comento
        //private int edad;

        //public int Edad
        //{
        //    get { return edad; }
        //    set { edad = value; }
        //}

        private OleDbConnection Conector;
        private OleDbCommand Comando;
        private OleDbDataAdapter Adaptador;
        private DataTable Tabla;
        private string sql;

        public clsPersonas()
        {
            Conector = new OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=IES21.mdb");
            Comando = new OleDbCommand();
            Adaptador = new OleDbDataAdapter(Comando);
            Tabla = new DataTable();
            Comando.Connection = Conector;
            Comando.CommandType = CommandType.Text; //para trabajar con SQL
            


        }

        public void listar(DataGridView dgv, string ojo)
        {
            //SIN * ELIJO QUE QUIERO MOSTRAR DE LA TABLA
            sql = "SELECT nombre, dni, edad  FROM Personas WHERE ojos='" + ojo + "'";
            
            //LE PASO INSTRUCCION SQL
            Comando.CommandText = sql;
            //SUBE UNICAMENTE LOS REGISTROS DEL COLOR DE OJO 
            Adaptador.Fill(Tabla);
            dgv.DataSource = Tabla;

        }
    }
}
