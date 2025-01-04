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
            try
            {
                Console.Clear();
                Console.WriteLine("=== Adicionar Quarto ===");
                Console.Write("Digite o número do quarto: ");

                if (!int.TryParse(Console.ReadLine(), out int numero) || numero <= 0)
                {
                    Console.WriteLine("Número inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Criar novo quarto e adicionar ao centro de saúde
                var quarto = new Quarto(numero);
                centroSaude.AdicionarQuarto(quarto);

                Console.WriteLine("Quarto adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar quarto: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        private static void VerQuartos(CentroSaude centroSaude)
        {
            try
            {
                Console.Clear();
                if (centroSaude.Quartos.Count == 0)
                {
                    Console.WriteLine("Nenhum quarto cadastrado.");
                }
                else
                {
                    centroSaude.ListarQuartos(); // Usando o método já existente na classe
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao exibir quartos: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }       

    }
}
