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
                Console.WriteLine("3. Gestão de Camas");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarQuarto();
                        break;
                    case "2":
                        VerQuartos();
                        break;
                    case "3":
                        // Chama o menu de camas passando a instância do CentroSaude
                        MenuCamas.ExibirMenu(centroSaude);
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

        private static void AdicionarQuarto()
        {
            Console.WriteLine("Funcionalidade de adicionar quarto ainda não implementada.");
            Console.ReadKey();
        }

        private static void VerQuartos()
        {
            Console.WriteLine("Funcionalidade de visualizar quartos ainda não implementada.");
            Console.ReadKey();
        }
    }
}
