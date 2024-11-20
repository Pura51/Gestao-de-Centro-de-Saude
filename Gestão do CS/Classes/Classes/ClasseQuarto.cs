using System.Collections.Generic;

namespace CentroSaudeProject.Classes
{
    public class Quarto
    {
        public int Numero { get; private set; }
        public List<Cama> Camas { get; private set; } = new List<Cama>();

        public Quarto(int numero)
        {
            Numero = numero;
        }

        public void AdicionarCama(Cama cama) => Camas.Add(cama);

        public override string ToString() => $"Quarto {Numero}: {Camas.Count} camas";
    }
}
