using CentroSaudeProject.Classes;
using Menus.Menu;

namespace GestaoCentroSaude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CentroSaude centroSaude = new CentroSaude(); // Instância central do sistema
            bool executar = true;

            while (executar)
            {
                Console.Clear();
                Console.WriteLine("=== Sistema de Gestão do Centro de Saúde ===");
                Console.WriteLine("1. Gestão de Funcionários");
                Console.WriteLine("2. Gestão de Pacientes");
                Console.WriteLine("3. Gestão de Quartos");
                Console.WriteLine("4. Gestão de Consultas");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        MenuFuncionarios.ExibirMenu(centroSaude);
                        break;
                    case "2":
                        MenuPacientes.ExibirMenu(centroSaude);
                        break;
                    case "3":
                        MenuQuartos.ExibirMenu(centroSaude);
                        break;
                    case "4":
                        MenuConsultas.ExibirMenu(centroSaude);
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
