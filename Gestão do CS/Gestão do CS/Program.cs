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
                Console.WriteLine("1. Gestão de Pacientes");
                Console.WriteLine("2. Gestão de Quartos");
                Console.WriteLine("3. Gestão de Consultas");
                Console.WriteLine("4. Gestão de Camas");
                Console.WriteLine("5. Gestão de Médicos");
                Console.WriteLine("6. Gestão de Enfermeiros");
                Console.WriteLine("7. Alocação Automática de Paciente");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        MenuPacientes.ExibirMenu(centroSaude);
                        break;
                    case "2":
                        MenuQuartos.ExibirMenu(centroSaude);
                        break;
                    case "3":
                        MenuConsultas.ExibirMenu(centroSaude);
                        break;
                    case "4":
                        MenuCamas.ExibirMenu(centroSaude);
                        break;
                    case "5":
                        MenuMedicos.ExibirMenu(centroSaude);
                        break;
                    case "6":
                        MenuEnfermeiros.ExibirMenu(centroSaude);
                        break;    
                    case "7":
                        Console.Write("Digite o ID do Paciente para alocar automaticamente: ");
                        if (int.TryParse(Console.ReadLine(), out int idPaciente))
                        {
                            centroSaude.AlocarPacienteAutomatico(idPaciente);
                        }
                        else
                        {
                            Console.WriteLine("ID inválido.");
                        }
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "0":
                        executar = false;
                        Console.WriteLine("A Encerrar o sistema...");
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