using CentroSaudeProject.Classes;
using CentroSaudeProject.Enums; // Importa o Enum TipoExame
using System;

class Program
{
    static void Main(string[] args)
    {
        // Criando um quarto
        var quarto1 = new Quarto(101);

        // Criando duas camas
        var cama1 = new Cama(1, true);
        var cama2 = new Cama(2, false);

        // Adicionando camas ao quarto
        quarto1.AdicionarCama(cama1); // Deve adicionar com sucesso
        quarto1.AdicionarCama(cama2); // Deve adicionar com sucesso

        // Tentando adicionar uma terceira cama (deve falhar)
        var cama3 = new Cama(3, true);
        quarto1.AdicionarCama(cama3); // Deve mostrar uma mensagem de erro

        // Exibindo o estado do quarto
        Console.WriteLine(quarto1.ToString());

        // Removendo uma cama
        quarto1.RemoverCama(1);

        // Exibindo o estado atualizado do quarto
        Console.WriteLine(quarto1.ToString());
    }
}
