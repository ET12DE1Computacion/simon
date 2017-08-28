using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Simon
{
    public class BackEnd
    {
        MySqlConnection conexion;
        MySqlCommand comando;
        MySqlDataAdapter adaptador;
        DataTable tabla;
        int idJugador;
        
        /*Constructor de la Clase BackEnd, recibe un string
         *para cargar el connectionString de la conexion
        */
        public BackEnd(string conexionBD)
        {
            conexion = new MySqlConnection(conexionBD);    
        }


        /* En este metodo, si se ejecuta una consulta SQL, se lo deja asi a modo demostrativo
         * fijarse, que el DataAdapter es utilizado, porque es necesario traer datos de la base de datos
         * (es necesario traer la tabla que pide el comando)
         */

        public DataTable traerJugadores()
        {
            //Instancio el objeto comando, pasandole como parametro el String de la consulta que voy a hacer y la conexion
            comando = new MySqlCommand("SELECT idJugador, nombre FROM Jugador ORDER BY nombre", conexion);
            //Instancio el adaptador, pasandole como parametro el comando anteriormente creado
            adaptador = new MySqlDataAdapter(comando);
            //Instancio la tabla donde voy a guardar la tabla que traiga el adaptador de datos.
            tabla = new DataTable();
            //Abro la conexion
            conexion.Open();
            //Le digo al objeto adaptador, que ejecute su metodo
            adaptador.Fill(tabla);
            //Cierro la conexion
            conexion.Close();
            /* La tabla, ahora esta cargada con una tabla de 2 columnas, en la primera,
             * tengo el idJugador y en la segunda el nombre. La idea, es usar estos datos
             * en un ComboBox, para poder seleccionar los nombres o escribir nuevos
             * Peeeeero, si bien voy a trabajar con los nombres visualmente, en realidad,
             * 'de fondo' voy a estar trabajando justamente con los id de los jugadores.
             * Entonces a fin de 
             */ 

            //
            //Para C#, cambio el nombre de la primer columna a "id"
            tabla.Columns[0].ColumnName = "id";
            //Para C#, cambio el nombre de la segunda columna a "mostrar"
            tabla.Columns[1].ColumnName = "mostrar";

            //Finalmente, devuelvo la tabla
            return (tabla);
        }


        /* Este metodo, recibe como parametro un nombre
         * y luego invoca al store procedure "altaJugador"
        */
        public void altaJugador(string nombre)  
        {
            //creo el comando, pasandole como parametro el nombre
            //del stored procedure y luego la conexion
            comando = new MySqlCommand("altaJugador", conexion);
            //indico que el comando, es un comando que ejecuta un stored procedure
            comando.CommandType = CommandType.StoredProcedure;
            //En este orden: 1) creo un parametro 2) lo agrego a la lista de parametros del comando
            comando.Parameters.Add(new MySqlParameter("nombreJugador", MySqlDbType.VarChar, 45));
            //Cargo el valor del parametro anteriormente declarado
            comando.Parameters["nombreJugador"].Value = nombre;
            //En este orden: 1) creo un parametro 2) lo agrego a la lista de parametros del comando
            comando.Parameters.Add(new MySqlParameter("unIdJugador", MySqlDbType.Int32));
            //indico que el parametro "idJugador" de la lista de parametros, tiene direccion
            //de salida
            comando.Parameters["unIdJugador"].Direction = ParameterDirection.Output;
            //Abro la conexion
            conexion.Open();
            //Ejecuto el comando
            comando.ExecuteNonQuery();
            //Cierro la conexion
            conexion.Close();

            /* Finalmente, en el parametro "unIdJugador" LUEGO de ejecutarse el comando,
             * vamos a tener el idJugador que se inserto en la BD al momento de que agregamos
             * el jugador; entonces para eso, debemos de obtener el valor del parametro unIdJugador,
             * de la lista de Parametros del comando. Hay que tener en cuenta, que todos los valores
             * de parametros en C#, son siempre objetos del tipo (clase) 'Object' (Objeto) y casi nunca
             * vamos a poder guardarlo en un objeto de otro tipo (clase). Lo "transformamos" al tipo
             * de dato que deseamos, siempre que se pueda, usando el 'casting', lo cual detalleremos
             * en otro momento posterior.
             */
            idJugador = (int)comando.Parameters["unIdJugador"].Value;
        }


        /* Este es un metodo publico, en el cual, por parametro le asignamos
         * el valor del idJugador que contendra para luego poder asignar los puntos
         */
        public void cargarJugador(int unIdJugador)
        {
            idJugador = unIdJugador;
        }


        /* Este metodo, recibe un nivel de dificultad y la cantidad de puntos que se hicieron*/
        public void sumarPuntos(int unaDificultad, int puntosASumar)
        {
            //Creo el comando, lo instancio pasandole el nombre del Stored Procedure "sumarPuntos" al constructor
            //junto con la conexion
            comando = new MySqlCommand("sumarPuntos", conexion);
            //Asigno a la propiedad CommandType, que este comando es un Stored Procedure
            comando.CommandType = CommandType.StoredProcedure;
            //Creo un parametro para un idJugador y lo agrego a la lista de parametros del comando
            comando.Parameters.Add(new MySqlParameter("unIdJugador", MySqlDbType.Int32));
            //Creo un parametro para una dificultad y lo agrego a la lista de parametros del comando
            comando.Parameters.Add(new MySqlParameter("unaDificultad", MySqlDbType.Int32));
            //Creo un parametro para los puntos y lo agrego a la lista de parametros del comando
            comando.Parameters.Add(new MySqlParameter("pts", MySqlDbType.Int32));
            //Asigno un valor al parametro "unIdJugador" de la lista de parametros
            comando.Parameters["unIdJugador"].Value=idJugador;
            //Asigno un valor al parametro "unaDificultad" de la lista de parametros
            comando.Parameters["unaDificultad"].Value=unaDificultad;
            //Asigno un valor al parametro "pts" de la lista de parametros
            comando.Parameters["pts"].Value = puntosASumar;
            //Abro la conexion
            conexion.Open();
            //Ejecuto el comando, ejecutando dentro de la BD el Stored Procedure
            comando.ExecuteNonQuery();
            //Cierro la conexion
            conexion.Close();            
        }


        //Este metodo,solo devuelve la tabla donde estan los puntajes usando un stored procedure
        public DataTable traePuntaje()
        {
            //Instancio el comando, pasandole como parametro "puntaje" que es nombre del
            //Stored Procedure, junto con la conexion
            comando = new MySqlCommand("puntaje", conexion);
            //Indico que el tipo del comando es un Stored Procedure
            comando.CommandType = CommandType.StoredProcedure;
            //Instancio el adaptador, pasandole el comando como parametro
            adaptador = new MySqlDataAdapter(comando);
            //Creo una tabla vacia
            tabla = new DataTable();
            //Abro la conexion
            conexion.Open();
            //Le envio el mensaje Fill (llenar) al objeto adaptador, pasandole como parametro la tabla
            //para que vuelque la tabla resultando del stored procedure ahi
            adaptador.Fill(tabla);
            //Cierro la conexion
            conexion.Close();
            //Le cambio el nombre en C# a la primer columna a "Nombre"
            tabla.Columns[0].ColumnName="Nombre";
            //Le cambio el nombre en C# a la segunda columna a "Dificultad"
            tabla.Columns[1].ColumnName="Dificultad";
            //Le cambio el nombre en C# a la tercer columna a "Puntos"
            tabla.Columns[2].ColumnName="Puntos";

            //finalmente, devuelvo la tabla
            return (tabla);
        }

    }
}
