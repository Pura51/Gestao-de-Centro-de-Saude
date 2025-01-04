using CentroSaudeProject.Classes;
using System;

namespace Menus.Menu
{
    public static class MenuQuartos
    {
        public static void ExibirMenu(CentroSaude centroSaude)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== Gestão de Quartos ===");
                Console.WriteLine("1. Adicionar Quarto");
                Console.WriteLine("2. Ver Quartos");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.Write("Escolha uma opção: ");

                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarQuarto(centroSaude);
                        break;
                    case "2":
                        VerQuartos(centroSaude);
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

        private static void AdicionarQuarto(CentroSaude centroSaude)
        {
        }

        private static void VerQuartos(CentroSaude centroSaude)
        {
        }
    }
}
