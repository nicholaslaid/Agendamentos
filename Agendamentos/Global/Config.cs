using Agendamentos.Models;

namespace Agendamentos.Global
{
    public class Config
    {
        public static List<Agendamento> Agen = new List<Agendamento>();

        public static void GerarProdutos()
        { 
            Agendamento ag = new Agendamento();

            Guid guid = Guid.NewGuid();
           

            ag.cod = guid; 
            ag.nome = "Pedro";
            ag.profissional = "Maira";
            ag.tempo_previsto = 30;
            ag.consulta = true;
            ag.horario = Convert.ToDateTime("20/03/2005");

            Agen.Add(ag);

            ag = new Agendamento();
            Guid guidd = Guid.NewGuid();


            ag.cod = guidd;
            ag.nome = "Joao";
            ag.profissional = "Paulo";
            ag.tempo_previsto = 60;
            ag.consulta = true;
            ag.horario = Convert.ToDateTime("20/03/2005");


            Agen.Add(ag);

        }

        /* public string GenerateToken(string user, string pass)
        {
            string result = string.Empty;
           
            if (user == "admin" && pass == "admin")
            {
                Guid guid = Guid.NewGuid();
                result = guid.ToString();
                Config.automaticDynamicToken = result;
                Config.lifeTime = DateTime.Now.AddSeconds(Config.tempo);
            }

            return result;
        }
        */
    }
}
