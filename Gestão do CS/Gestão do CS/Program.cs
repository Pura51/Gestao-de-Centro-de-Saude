using System;
using Menus.Menu;
using CentroSaudeProject.Classes;
using CentroSaudeProject.Enums;

namespace GestaoCentroSaude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Criação da instância de CentroSaude
            CentroSaude centroSaude = new CentroSaude();

            bool executar = true;

            while (executar)
            {
                Console.Clear();
                Console.WriteLine("=== Sistema de Gestão do Centro de Saúde ===");
                Console.WriteLine("1. Gestão de Funcionários");
                Console.WriteLine("2. Gestão de Pacientes");
                Console.WriteLine("3. Gestão de Quartos");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        // Passa a instância do CentroSaude para o menu de funcionários
                        MenuFuncionarios.ExibirMenu(centroSaude);
                        break;
                    case "2":
                        // Passa a instância do CentroSaude para o menu de pacientes
                        MenuPacientes.ExibirMenu(centroSaude);
                        break;
                    case "3":
                        // Passa a instância do CentroSaude para o menu de quartos
                        MenuQuartos.ExibirMenu(centroSaude);
                        break;
                    case "0":
                        executar = false;
                        Console.WriteLine("Encerrando o sistema...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
