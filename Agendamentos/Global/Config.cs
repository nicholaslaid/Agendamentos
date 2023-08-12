using Agendamentos.Controllers;
using Agendamentos.Models;

namespace Agendamentos.Global
{
    public class Config
    {
        //variaveis lidas do appsettings.json
        public static string fileName = string.Empty;
        public static string folderName = string.Empty;


        //caminhos
        public static string basePath = string.Empty;
        public static string filePath = string.Empty;
        public static string folderPath = string.Empty;
        //Credenciais de acesso ao banco
        public static string dbHost = string.Empty;
        public static string dbPort = string.Empty;
        public static string dbName = string.Empty;
        public static string dbUser = string.Empty;
        public static string dbPass = string.Empty;
        public static void LoadConfigurations()
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            AgendamentosController controller = new AgendamentosController();
            try
            {
                fileName = config.GetValue<string>("Log:FileName");
                folderName = config.GetValue<string>("Log:Foldername");
                dbHost = config.GetValue<string>("dbHost");
                dbPort = config.GetValue<string>("dbPort");
                dbName = config.GetValue<string>("dbName");
                dbUser = config.GetValue<string>("dbUser");
                dbPass = config.GetValue<string>("dbPass");

                basePath = AppDomain.CurrentDomain.BaseDirectory;

                folderPath = Path.Combine(basePath, folderName);

                filePath = Path.Combine(folderPath, fileName);



            }
            catch (Exception ex)
            {

            }
        }
        public static string automaticPermanentToken = string.Empty;
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

       
    }
}
