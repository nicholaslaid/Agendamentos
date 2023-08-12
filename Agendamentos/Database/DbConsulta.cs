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
                
               
                    //Gravação sem imagem
                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.CommandText = @"INSERT INTO contatos (name, telefone, email) " +
                                          @"VALUES (@name, @telefone, @email);";


                        cmd.Parameters.AddWithValue("@name", agendamento.nome);
                        cmd.Parameters.AddWithValue("@consulta", agendamento.consulta);
                        cmd.Parameters.AddWithValue("@tempo", agendamento.tempo_previsto);
                         cmd.Parameters.AddWithValue("@tempo", agendamento.profissional);

                    cmd.Parameters.AddWithValue("@tempo", agendamento.cod);

                    cmd.Parameters.AddWithValue("@tempo", agendamento.horario);

                 

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


        public Agendamento Get(int id)
        {

            Agendamento result = new Agendamento();
            DataBaseAcess dba = new DataBaseAcess();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM Agendamentos " +
                                      @"WHERE id = @id;";

                    cmd.Parameters.AddWithValue("@id", id);

                    using (cmd.Connection = dba.OpenConnection())
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result.cod = Convert.ToInt32(reader["id"]);
                            result.nome = reader["name"].ToString();

                            result.consulta = Convert.ToBoolean(reader["consulta"]);
                            result.profissional = reader["profissional"].ToString();

                            result.tempo_previsto = Convert.ToDateTime(reader["data"]);
                            result.tempo_previsto = Convert.ToInt32(reader["id"]);

                        
                        }
                    }
                }
            }
            catch (Exception ex)
            { }

            return result;
        }

        public List<Contacts> GetAll()
        {
            List<Contacts> result = new List<Contacts>();
            DataBaseAcess dba = new DataBaseAcess();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"SELECT p.id, p.name, p.email, p.telefone, p.image " +
                                      @"FROM contatos p " +
                                      @"ORDER BY p.id;";

                    using (cmd.Connection = dba.OpenConnection())
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Contacts contacts = new Contacts();

                            contacts.id = Convert.ToInt32(reader["id"]);
                            contacts.name = reader["name"].ToString();
                            contacts.email = reader["email"].ToString();
                            contacts.telefone = reader["telefone"].ToString();

                            //contacts.imageBmp = new Bitmap(Path.Combine(Config.appRootFolder, Config.imageFolder, contacts.image));

                            if (reader["image"] != DBNull.Value)
                                contacts.image = reader["image"].ToString();
                            else
                                contacts.image = string.Empty;

                            if (!string.IsNullOrEmpty(contacts.image))
                            {
                                using (var stream = new FileStream(Path.Combine(Config.imageFolder, contacts.image), FileMode.Open))
                                {
                                    Bitmap bmp = new Bitmap(stream);
                                    contacts.imageBmp = bmp;
                                }
                            }
                            else
                            {
                                contacts.imageBmp = new Bitmap(Path.Combine(Config.imageDefaultPath));
                            }

                            result.Add(contacts);

                        }
                    }
                }
            }
            catch (Exception ex)
            { }

            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            DataBaseAcess dba = new DataBaseAcess();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.CommandText = @"DELETE FROM contatos " +
                                      @"WHERE id = @id;";

                    cmd.Parameters.AddWithValue("@id", id);

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

        public bool DeleteImageFile(string filePath)
        {
            bool result = false;
            try
            {
                File.Delete(filePath);
                result = true;
            }
            catch (Exception ex)
            { }

            return result;
        }
        public bool Update(Contacts contacts, bool image)
        {
            bool result = false;
            DataBaseAcess dba = new DataBaseAcess();

            try
            {
                if (image)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.CommandText = @"UPDATE contatos " +
                                          @"SET id = @id, name = @name, email = @email, image = @image, telefone = @telefone " +
                                          @"WHERE id = @id;";

                        cmd.Parameters.AddWithValue("@id", contacts.id);
                        cmd.Parameters.AddWithValue("@name", contacts.name);
                        cmd.Parameters.AddWithValue("@email", contacts.email);
                        cmd.Parameters.AddWithValue("@telefone", contacts.telefone);
                        cmd.Parameters.AddWithValue("@image", contacts.image);


                        using (cmd.Connection = dba.OpenConnection())
                        {
                            cmd.ExecuteNonQuery();
                            result = true;
                        }
                    }
                }
                else
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.CommandText = @"UPDATE contatos " +
                                          @"SET id = @id, name = @name, email = @email, telefone = @telefone " +
                                          @"WHERE id = @id;";

                        cmd.Parameters.AddWithValue("@id", contacts.id);
                        cmd.Parameters.AddWithValue("@name", contacts.name);
                        cmd.Parameters.AddWithValue("@email", contacts.email);
                        cmd.Parameters.AddWithValue("@telefone", contacts.telefone);



                        using (cmd.Connection = dba.OpenConnection())
                        {
                            cmd.ExecuteNonQuery();
                            result = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            { }

            return result;
        }
    }
}
