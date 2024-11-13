using CentroSaudeProject.Enums;

namespace CentroSaudeProject.Classes
{
    public class Exame
    {
        public TipoExame TipoExame { get; set; }
        public Paciente Paciente { get; set; }

        public Exame(TipoExame tipoExame, Paciente paciente)
        {
            TipoExame = tipoExame;
            Paciente = paciente;
        }

        public override string ToString()
        {
            return $"Exame: {TipoExame} para {Paciente.Nome}";
        }
    }
}
