namespace CentroSaudeProject.Classes
{
    public class Cama
    {
        public int Id { get; private set; }
        public bool Disponivel { get; set; }

        private static int ProximoId = 1;

        public Cama()
        {
            Id = ProximoId++;
            Disponivel = true;
        }

        public override string ToString() => $"Cama {Id} - {(Disponivel ? "Disponível" : "Ocupada")}";
    }
}
