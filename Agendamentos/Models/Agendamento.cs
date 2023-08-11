namespace Agendamentos.Models
{
    public class Agendamento
    {
        public Guid cod { get; set; }

        public string nome { get; set; }

        public string profissional { get; set; }

        public DateTime horario { get; set; }

        public int tempo_previsto { get; set; }

        public bool consulta { get; set; }
    }
}
