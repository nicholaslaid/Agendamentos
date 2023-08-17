using Agendamentos.Global;
using Agendamentos.Models;
using Npgsql;

namespace Agendamentos.Database
{
    public class DbConsulta
    {
        public bool Add(Agendamento agendamento)
        {
            bool result = false;

            DataBaseAcess dba = new DataBaseAcess();

            try
            {
                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.CommandText = @"INSERT INTO agendamentos (cod, name, profissional, tempo, data, consulta) " +
                                          @"VALUES (@cod, @name, @profissional, @tempo, @data, @consulta);";

                    cmd.Parameters.AddWithValue("@cod", agendamento.cod);
                    cmd.Parameters.AddWithValue("@name", agendamento.nome);
                        cmd.Parameters.AddWithValue("@consulta", agendamento.consulta);
                        cmd.Parameters.AddWithValue("@tempo", agendamento.tempo_previsto);
                         cmd.Parameters.AddWithValue("@profissional", agendamento.profissional);


                    cmd.Parameters.AddWithValue("@data", agendamento.horario);

                 

                    using (cmd.Connection = dba.OpenConnection())
                        {
                            cmd.ExecuteNonQuery();
                        }
                        result = true;
                    }
                
            }
            catch
            { }
            return result;
        }


        public Agendamento Get(string cod)
        {

            Agendamento agen = new Agendamento();
            DataBaseAcess dba = new DataBaseAcess();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM agendamentos " +
                                      @"WHERE cod = @cod;";

                    cmd.Parameters.AddWithValue("@cod", cod);

                    using (cmd.Connection = dba.OpenConnection())
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                           agen.id = Convert.ToInt32(reader["id"]);
                            agen.cod = reader["cod"].ToString();
                            agen.horario = Convert.ToDateTime(reader["data"]);
                            agen.tempo_previsto = Convert.ToInt32(reader["tempo"]);
                            agen.nome = reader["name"].ToString();
                            agen.profissional = reader["profissional"].ToString();
                            agen.consulta = Convert.ToBoolean(reader["consulta"].ToString());


                        }
                    }
                }
            }
            catch (Exception ex)
            { }

            return agen;
        }

        public List<Agendamento> GetAll()
        {
            List<Agendamento> result = new List<Agendamento>();
            DataBaseAcess dba = new DataBaseAcess();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"SELECT a.id, a.cod, a.name, a.profissional, a.tempo, a.data, a.consulta " +
                                      @"FROM agendamentos a " +
                                      @"ORDER BY a.cod;";

                    using (cmd.Connection = dba.OpenConnection())
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Agendamento agen = new Agendamento();

                            agen.id = Convert.ToInt32(reader["id"]);
                            agen.cod = reader["cod"].ToString();
                            agen.horario = Convert.ToDateTime(reader["data"]);
                            agen.tempo_previsto = Convert.ToInt32(reader["tempo"]);
                            agen.nome = reader["name"].ToString();
                            agen.profissional = reader["profissional"].ToString();
                            agen.consulta = Convert.ToBoolean(reader["consulta"].ToString());

                           

                            result.Add(agen);

                        }
                    }
                }
            }
            catch (Exception ex)
            { }

            return result;
        }

        public bool Delete(string id)
        {
            bool result = false;
            DataBaseAcess dba = new DataBaseAcess();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"DELETE FROM agendamentos " +
                                      @"WHERE cod = @cod;";

                    cmd.Parameters.AddWithValue("@cod", id);

                    using (cmd.Connection = dba.OpenConnection())
                    {
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            { }

            return result;
        }

      
        public bool Update(Agendamento agen)
        {
            bool result = false;
            DataBaseAcess dba = new DataBaseAcess();

            try
            {
  
                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.CommandText = @"UPDATE agendamentos " +
                                          @"SET cod = @cod, id = @id, name = @name, profissional = @profissional, tempo = @tempo, data = @data, consulta = @consulta " +
                                          @"WHERE cod = @cod;";

                         cmd.Parameters.AddWithValue("@id", agen.id);
                             cmd.Parameters.AddWithValue("@cod", agen.cod);
                        cmd.Parameters.AddWithValue("@name", agen.nome);
                        cmd.Parameters.AddWithValue("@profissional", agen.profissional);
                        cmd.Parameters.AddWithValue("@consulta", agen.consulta);
                        cmd.Parameters.AddWithValue("@tempo", agen.tempo_previsto);
                        cmd.Parameters.AddWithValue("@data", agen.horario);


                    using (cmd.Connection = dba.OpenConnection())
                        {
                            cmd.ExecuteNonQuery();
                            result = true;
                        }
                    }
                
            }
            catch (Exception ex)
            { }

            return result;
        }
    }
}
