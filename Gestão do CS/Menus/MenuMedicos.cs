using CentroSaudeProject.Classes;
using System;
using System.Linq;

namespace Menus.Menu
{
    public static class MenuMedicos
    {
        public static void ExibirMenu(CentroSaude centroSaude)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== Gestão de Médicos ===");
                Console.WriteLine("1. Adicionar Médico");
                Console.WriteLine("2. Ver Médicos");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.Write("Escolha uma opção: ");

                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarMedico(centroSaude);
                        break;
                    case "2":
                        VerMedicos(centroSaude);
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

        private static void AdicionarMedico(CentroSaude centroSaude)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Adicionar Médico ===");

                // Solicita o nome do médico
                Console.Write("Nome do Médico: ");
                string nome = Console.ReadLine() ?? string.Empty;

                // Solicita a idade
                Console.Write("Idade do Médico: ");
                if (!int.TryParse(Console.ReadLine(), out int idade) || idade < 0)
                {
                    Console.WriteLine("Idade inválida. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Solicita o número de cartão de cidadão (CC)
                Console.Write("Número do CC do Médico: ");
                if (!int.TryParse(Console.ReadLine(), out int ccNum) || ccNum <= 0)
                {
                    Console.WriteLine("Número de CC inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Solicita o NIF
                Console.Write("NIF do Médico: ");
                if (!int.TryParse(Console.ReadLine(), out int ccNIF) || ccNIF <= 0)
                {
                    Console.WriteLine("NIF inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Solicita o sexo
                Console.Write("Sexo do Médico (M/F): ");
                char sexo = Console.ReadKey().KeyChar;
                Console.WriteLine();

                // Cria o objeto Médico
                var medico = new Medico(nome, idade, ccNum, ccNIF, sexo);

                // Adiciona o médico ao centro de saúde
                centroSaude.AdicionarMedico(medico);

                Console.WriteLine("Médico adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar médico: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        private static void VerMedicos(CentroSaude centroSaude)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Lista de Médicos ===");

                if (centroSaude.Medicos.Count == 0)
                {
                    Console.WriteLine("Nenhum médico cadastrado.");
                }
                else
                {
                    foreach (var medico in centroSaude.Medicos)
                    {
                        Console.WriteLine($"ID: {medico.IdMedico} | Nome: {medico._nome} | Idade: {medico._idade} | Sexo: {medico._sexo}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao exibir médicos: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
