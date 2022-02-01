using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace ControlRiego
{
    static public class BaseDatos
    {
        static string connectionString = "Data Source = ./data.db; Version = 3";

        // Usuarios
        static public string CrearUsuario(Usuario usuario)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        usuario.Clave = Util.Hash(usuario.Clave);

                        string query = "INSERT INTO Usuarios (Nombre, NombreUsuario, Clave, Tipo) VALUES ('{0}', '{1}', '{2}', {3})";
                        query = string.Format(query, usuario.Nombre, usuario.NombreUsuario, usuario.Clave, usuario.Tipo ? "1" : "0");

                        command.CommandText = query;
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        static public Usuario LeerUsuario(string NombreUsuario, string Clave)
        {

            try
            {
                Usuario usuario = null;

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        Clave = Util.Hash(Clave);

                        string query = "SELECT * FROM Usuarios WHERE NombreUsuario = '{0}' AND Clave = '{1}'";
                        query = string.Format(query, NombreUsuario, Clave);

                        command.CommandText = query;

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                usuario = new Usuario();
                                usuario.UsuarioID = Convert.ToInt32(reader["UsuarioID"]);
                                usuario.Nombre = Convert.ToString(reader["Nombre"]);
                                usuario.NombreUsuario = Convert.ToString(reader["NombreUsuario"]);
                                usuario.Clave = Convert.ToString(reader["Clave"]);
                                usuario.Tipo = Convert.ToBoolean(reader["Tipo"]);
                            }
                        }
                    }
                    connection.Close();
                }

                return usuario;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // Radios
        static public string CrearRadio()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "INSERT INTO Radios (BajoVoltaje) VALUES (0)";

                        command.CommandText = query;
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        static public List<Radio> LeerTodosRadios()
        {
            try
            {
                List<Radio> radios = new List<Radio>();

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "SELECT * FROM Radios";

                        command.CommandText = query;
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            Radio radio = new Radio();
                            radio.RadioID = Convert.ToInt32(reader["RadioID"]);
                            radio.BajoVoltaje = Convert.ToBoolean(reader["BajoVoltaje"]);
                            radios.Add(radio);
                        }
                    }
                    connection.Close();
                }

                return radios;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        static public int LeerCantidadRadios()
        {
            try
            {
                int quantity = -1;

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "SELECT COUNT(*) AS Cantidad FROM Radios";

                        command.CommandText = query;
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                                quantity = Convert.ToInt32(reader["Cantidad"]);
                        }
                    }
                    connection.Close();
                }

                return quantity;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        static public string ModificarRadio(Radio radio)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "UPDATE Radios SET BajoVoltaje = {1} WHERE RadioID = {0}";
                        query = string.Format(query, radio.RadioID, radio.BajoVoltaje ? "1" : "0");

                        command.CommandText = query;
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Solenoides
        static public string CrearSolenoide(Solenoide solenoide)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "INSERT INTO Solenoides (Campo, RadioID, NumeroSolenoide) VALUES ('{0}', {1}, {2})";
                        query = string.Format(query, solenoide.Campo, solenoide.RadioID, solenoide.NumeroSolenoide);

                        command.CommandText = query;
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        static public List<Solenoide> LeerTodosSolenoides()
        {
            try
            {
                List<Solenoide> solenoides = new List<Solenoide>();

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "SELECT * FROM Solenoides";

                        command.CommandText = query;
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Solenoide solenoide = new Solenoide();
                                solenoide.SolenoideID = Convert.ToInt32(reader["SolenoideID"]);
                                solenoide.Campo = Convert.ToString(reader["Campo"]);
                                solenoide.RadioID = Convert.ToInt32(reader["RadioID"]);
                                solenoide.NumeroSolenoide = Convert.ToInt32(reader["NumeroSolenoide"]);
                                solenoide.Estado = Convert.ToBoolean(reader["Estado"]);
                                solenoides.Add(solenoide);
                            }
                        }
                    }
                    connection.Close();
                }

                return solenoides;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        static public List<Solenoide> LeerSolenoidesPorRadio(int radio)
        {
            try
            {
                List<Solenoide> solenoides = new List<Solenoide>();

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "SELECT * FROM Solenoides WHERE RadioID = " + radio;

                        command.CommandText = query;
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Solenoide solenoide = new Solenoide();
                                solenoide.SolenoideID = Convert.ToInt32(reader["SolenoideID"]);
                                solenoide.Campo = Convert.ToString(reader["Campo"]);
                                solenoide.RadioID = Convert.ToInt32(reader["RadioID"]);
                                solenoide.NumeroSolenoide = Convert.ToInt32(reader["NumeroSolenoide"]);
                                solenoide.Estado = Convert.ToBoolean(reader["Estado"]);
                                solenoides.Add(solenoide);
                            }
                        }
                    }
                    connection.Close();
                }

                return solenoides;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        static public Solenoide LeerSolenoidePorRadioNumero(int radio, int numero)
        {
            try
            {
                Solenoide solenoide = null;

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "SELECT * FROM Solenoides WHERE RadioID = " + radio + " AND NumeroSolenoide = " + numero;

                        command.CommandText = query;
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                solenoide = new Solenoide();
                                solenoide.SolenoideID = Convert.ToInt32(reader["SolenoideID"]);
                                solenoide.Campo = Convert.ToString(reader["Campo"]);
                                solenoide.RadioID = Convert.ToInt32(reader["RadioID"]);
                                solenoide.NumeroSolenoide = Convert.ToInt32(reader["NumeroSolenoide"]);
                                solenoide.Estado = Convert.ToBoolean(reader["Estado"]);
                            }
                        }
                    }
                    connection.Close();
                }

                return solenoide;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        static public Solenoide LeerSolenoidePorID(int id)
        {
            try
            {
                Solenoide solenoide = null;

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "SELECT * FROM Solenoides WHERE SolenoideID = " + id;

                        command.CommandText = query;
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                solenoide = new Solenoide();
                                solenoide.SolenoideID = Convert.ToInt32(reader["SolenoideID"]);
                                solenoide.Campo = Convert.ToString(reader["Campo"]);
                                solenoide.RadioID = Convert.ToInt32(reader["RadioID"]);
                                solenoide.NumeroSolenoide = Convert.ToInt32(reader["NumeroSolenoide"]);
                                solenoide.Estado = Convert.ToBoolean(reader["Estado"]);
                            }
                        }
                    }
                    connection.Close();
                }

                return solenoide;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        static public string ModificarSolenoide(Solenoide solenoide)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "UPDATE Solenoides SET Estado = {1} WHERE SolenoideID = {0}";
                        query = string.Format(query, solenoide.SolenoideID, solenoide.Estado ? "1" : "0");

                        command.CommandText = query;
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        static public Solenoide LeerSolenoidePorCodigo(string codigo)
        {
            int radio = codigo[1] - '@';
            int numero = codigo[2] - '@';

            return LeerSolenoidePorRadioNumero(radio, numero);
        }

        // Programas
        static public string CrearPrograma(Programa programa)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "INSERT INTO Programas (SolenoideID, Hora, Accion) VALUES ({0}, '{1}', {2})";
                        query = string.Format(query, programa.SolenoideID, programa.Hora, programa.Accion ? 1 : 0);

                        command.CommandText = query;
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "INSERT INTO Programas (SolenoideID, Hora, Accion) VALUES ({0}, '{1}', {2})";
                        query = string.Format(query, programa.SolenoideID, programa.Hora, programa.Accion ? 1 : 0);

                        command.CommandText = query;
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        static public List<Programa> LeerTodosProgramas()
        {
            try
            {
                List<Programa> programas = new List<Programa>();

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "SELECT * FROM Programas ORDER BY SolenoideID, Hora";

                        command.CommandText = query;
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Programa programa = new Programa();
                                programa.ProgramaID = Convert.ToInt32(reader["ProgramaID"]);
                                programa.SolenoideID = Convert.ToInt32(reader["SolenoideID"]);
                                programa.Hora = Convert.ToString(reader["Hora"]);
                                programa.Accion = Convert.ToBoolean(reader["Accion"]);
                                programas.Add(programa);
                            }
                        }
                    }
                    connection.Close();
                }

                return programas;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        static public string BorrarPrograma(Programa programa)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "DELETE FROM Programas WHERE ProgramaID = " + programa.ProgramaID;
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        static public string BorrarTodosProgramas()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "DELETE FROM Programas";
                        command.ExecuteNonQuery();

                        command.CommandText = "UPDATE sqlite_sequence SET seq = 0 WHERE name = 'Programas'";
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Logs
        static public string CrearLog(Log log)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "INSERT INTO Logs (Fecha, Tipo, Info) VALUES ('{0}', '{1}', '{2}')";
                        query = string.Format(query, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), log.Tipo, log.Info);

                        command.CommandText = query;
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        static public List<Log> LeerLogsFecha(DateTime fecha)
        {
            try
            {
                List<Log> logs = new List<Log>();

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string query = "SELECT * FROM Logs WHERE Fecha LIKE '" + fecha.ToString("yyyy/MM/dd") + "%'";

                        command.CommandText = query;
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Log log = new Log();
                                log.LogID = Convert.ToInt32(reader["LogID"]);
                                log.Fecha = Convert.ToDateTime(reader["Fecha"]);
                                log.Tipo = Convert.ToString(reader["Tipo"]);
                                log.Info = Convert.ToString(reader["Info"]);
                                logs.Add(log);
                            }
                        }
                    }
                    connection.Close();
                }

                return logs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
