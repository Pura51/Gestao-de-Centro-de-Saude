using CentroSaudeProject.Classes;
using System;

namespace Menus.Menu
{
    public static class MenuPacientes
    {
        public static void ExibirMenu(CentroSaude centroSaude)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== Gestão de Pacientes ===");
                Console.WriteLine("1. Adicionar Paciente");
                Console.WriteLine("2. Ver Pacientes");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarPaciente(centroSaude);
                        break;
                    case "2":
                        VerPacientes(centroSaude);
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void AdicionarPaciente(CentroSaude centroSaude)
        {
        }

        private static void VerPacientes(CentroSaude centroSaude)
        {
        }
    }
}
