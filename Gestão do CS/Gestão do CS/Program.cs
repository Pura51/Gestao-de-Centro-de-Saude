using CentroSaudeProject.Classes;
using CentroSaudeProject.Enums; // Importa o Enum TipoExame
using System;

class Program
{
    static void Main()
    {
        // Criando instâncias de Pacientes e Funcionários
        var paciente1 = new Paciente("João Silva", 35);
        var paciente2 = new Paciente("Maria Souza", 28);

        var funcionario1 = new Funcionario("Dr. Carlos", Categoria.Medico);
        var funcionario2 = new Funcionario("Ana Oliveira", Categoria.Enfermeiro);

        // Criando a instância do Centro de Saúde
        var centroSaude = new CentroSaude();

        // Adicionando pacientes e funcionários
        centroSaude.AdicionarPaciente(paciente1);
        centroSaude.AdicionarPaciente(paciente2);

        centroSaude.AdicionarFuncionario(funcionario1);
        centroSaude.AdicionarFuncionario(funcionario2);

        // Mostrar os pacientes
        Console.WriteLine("Pacientes Cadastrados:");
        foreach (var paciente in centroSaude.ObterPacientes())
        {
            Console.WriteLine(paciente.ToString());
        }

        // Mostrar os funcionários
        Console.WriteLine("\nFuncionários Cadastrados:");
        foreach (var funcionario in centroSaude.ObterFuncionarios())
        {
            Console.WriteLine(funcionario.ToString());
        }
    }
}
