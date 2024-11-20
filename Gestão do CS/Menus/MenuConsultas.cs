using CentroSaudeProject.Classes;
using System;

namespace Menus.Menu
{
    public static class MenuConsultas
    {
        public static void ExibirMenu(CentroSaude centroSaude)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== Gestão de Consultas ===");
                Console.WriteLine("1. Adicionar Consulta");
                Console.WriteLine("2. Ver Consultas");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarConsulta(centroSaude);
                        break;
                    case "2":
                        VerConsultas(centroSaude);
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

        private static void AdicionarConsulta(CentroSaude centroSaude)
        {
        }

        private static void VerConsultas(CentroSaude centroSaude)
        {
        }
    }
}
