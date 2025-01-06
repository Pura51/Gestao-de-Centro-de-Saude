using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentroSaudeProject.Classes;

namespace Menus.Menu
{
    public static class MenuCamas
    {
        public static void ExibirMenu(CentroSaude centroSaude)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== Gest�o de Camas ===");
                Console.WriteLine("1. Adicionar Cama a um Quarto");
                Console.WriteLine("2. Ver Camas de um Quarto");
                Console.WriteLine("3. Remover Cama de um Quarto");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.Write("Escolha uma op��o: ");

                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarCama(centroSaude);
                        break;
                    case "2":
                        VerCamas(centroSaude);
                        break;
                    case "3":
                        RemoverCama(centroSaude);
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Op��o inv�lida. Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void AdicionarCama(CentroSaude centroSaude)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Adicionar Cama ===");

                Console.Write("Digite o ID do Quarto: ");
                if (!int.TryParse(Console.ReadLine(), out int idQuarto))
                {
                    Console.WriteLine("ID inv�lido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                var quarto = centroSaude.Quartos.FirstOrDefault(q => q.IdQuarto == idQuarto);
                if (quarto == null)
                {
                    Console.WriteLine("Quarto n�o encontrado. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Digite o n�mero da cama: ");
                if (!int.TryParse(Console.ReadLine(), out int numeroCama))
                {
                    Console.WriteLine("N�mero da cama inv�lido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                var cama = new Cama(numeroCama, true);
                quarto.AdicionarCama(cama);

                Console.WriteLine("Cama adicionada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar cama: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        private static void VerCamas(CentroSaude centroSaude)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Ver Camas de um Quarto ===");

                Console.Write("Digite o ID do Quarto: ");
                if (!int.TryParse(Console.ReadLine(), out int idQuarto))
                {
                    Console.WriteLine("ID inv�lido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                var quarto = centroSaude.Quartos.FirstOrDefault(q => q.IdQuarto == idQuarto);
                if (quarto == null)
                {
                    Console.WriteLine("Quarto n�o encontrado. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine($"=== Camas do Quarto {quarto.Numero} ===");
                foreach (var cama in quarto.Camas)
                {
                    Console.WriteLine(cama);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao visualizar camas: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        private static void RemoverCama(CentroSaude centroSaude)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Remover Cama ===");

                Console.Write("Digite o ID do Quarto: ");
                if (!int.TryParse(Console.ReadLine(), out int idQuarto))
                {
                    Console.WriteLine("ID inv�lido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                var quarto = centroSaude.Quartos.FirstOrDefault(q => q.IdQuarto == idQuarto);
                if (quarto == null)
                {
                    Console.WriteLine("Quarto n�o encontrado. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine($"=== Camas do Quarto {quarto.Numero} ===");
                foreach (var cama in quarto.Camas)
                {
                    Console.WriteLine($"ID: {cama.IdCama} | N�mero: {cama.NumeroCama} | Dispon�vel: {cama.Disponivel}");
                }

                Console.Write("Digite o ID da Cama a ser removida: ");
                if (!int.TryParse(Console.ReadLine(), out int idCama))
                {
                    Console.WriteLine("ID inv�lido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                var camaRemover = quarto.Camas.FirstOrDefault(c => c.IdCama == idCama);
                if (camaRemover == null)
                {
                    Console.WriteLine("Cama n�o encontrada. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                quarto.RemoverCama(camaRemover);
                Console.WriteLine("Cama removida com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao remover cama: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
        public static void AtribuirEnfermeiroACama(CentroSaude centroSaude)
        {
            Console.Clear();
            Console.WriteLine("=== Atribuir Enfermeiro a uma Cama ===");

            Console.Write("Digite o ID da cama: ");
            int idCama = int.Parse(Console.ReadLine());
            var cama = centroSaude.Camas.FirstOrDefault(c => c.IdCama == idCama);
            if (cama == null)
            {
                Console.WriteLine("Cama não encontrada.");
                return;
            }

            Console.Write("Digite o ID do enfermeiro: ");
            int idEnfermeiro = int.Parse(Console.ReadLine());
            var enfermeiro = centroSaude.Enfermeiros.FirstOrDefault(e => e.IdEnfermeiro == idEnfermeiro);
            if (enfermeiro == null)
            {
                Console.WriteLine("Enfermeiro não encontrado.");
                return;
            }

            cama.EnfermeiroResponsavel = enfermeiro;
            Console.WriteLine($"Enfermeiro {enfermeiro.Nome} foi atribuído à cama {cama.NumeroCama}.");
        }

    }
}