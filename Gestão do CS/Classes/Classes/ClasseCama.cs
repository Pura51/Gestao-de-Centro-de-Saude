
namespace CentroSaudeProject.Classes
{
    public class Cama
    {
        #region Propriedades

        public int Id { get; set; }
        public bool Disponivel { get; set; }
        public Paciente PacienteAtual { get; set; }

        #endregion

        #region Construtor

        public Cama(int id, bool disponivel)
        {
            Id = id;
            Disponivel = disponivel;
            PacienteAtual = null;  // Inicialmente a cama está vazia
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Faz a atribuição de um paciente à cama, e muda o estado para ocupada.
        /// </summary>
        public void AtribuirPaciente(Paciente paciente)
        {
            if (Disponivel)
            {
                PacienteAtual = paciente;
                Disponivel = false;
                Console.WriteLine($"Paciente {paciente.Nome} foi atribuído à cama {Id}.");
            }
            else
            {
                Console.WriteLine($"Cama {Id} já está ocupada.");
            }
        }

        /// <summary>
        /// Desocupa a cama e muda o estado para disponivel.
        /// </summary>
        public void LiberarCama()
        {
            if (!Disponivel)
            {
                Console.WriteLine($"Paciente {PacienteAtual.Nome} saiu da cama {Id}.");
                PacienteAtual = null;
                Disponivel = true;
            }
            else
            {
                Console.WriteLine($"Cama {Id} já está disponível.");
            }
        }

        #endregion
    }
}
