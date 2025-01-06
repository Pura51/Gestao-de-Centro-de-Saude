using CentroSaudeProject.Classes;
using CentroSaudeProject.Enums;
using System;
using System.Linq;

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
                Console.WriteLine("3. Adicionar Exames");
                Console.WriteLine("4. Ver Exames");
                Console.WriteLine("5. Remover Exames");
                Console.WriteLine("6. Associar Médico ao Exame");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.Write("Escolha uma opção: ");

                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarConsulta(centroSaude);
                        break;
                    case "2":
                        VerConsultas(centroSaude);
                        break;
                    case "3":
                        AdicionarExames(centroSaude);
                        break;
                    case "4":
                        VerExames(centroSaude);
                        break;
                    case "5":
                        RemoverExames(centroSaude);
                        break;
                    case "6":
                        AssociarMedicoAoExame(centroSaude);
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
            try
            {
                Console.Clear();
                Console.WriteLine("=== Adicionar Consulta ===");

                // Solicita a data da consulta
                Console.Write("Data da Consulta (formato: dd/MM/yyyy): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataConsulta))
                {
                    Console.WriteLine("Data inválida. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Solicita o custo da consulta
                Console.Write("Custo da Consulta: ");
                if (!float.TryParse(Console.ReadLine(), out float custo) || custo < 0)
                {
                    Console.WriteLine("Custo inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Solicita o diagnóstico
                Console.Write("Diagnóstico: ");
                string diagnostico = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(diagnostico))
                {
                    Console.WriteLine("Diagnóstico inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Solicita o médico responsável
                Console.WriteLine("Médicos disponíveis:");
                foreach (var medico in centroSaude.Medicos)
                {
                    Console.WriteLine($"{medico.IdMedico} - {medico.Nome}");
                }
                Console.Write("Digite o ID do médico responsável pela consulta: ");
                if (!int.TryParse(Console.ReadLine(), out int idMedico))
                {
                    Console.WriteLine("ID inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                var medicoResponsavel = centroSaude.Medicos.FirstOrDefault(m => m.IdMedico == idMedico);
                if (medicoResponsavel == null)
                {
                    Console.WriteLine("Médico não encontrado. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Cria a consulta com o médico responsável
                var consulta = new Consulta(dataConsulta, custo, diagnostico, medicoResponsavel);

                // Adiciona a consulta ao centro de saúde
                centroSaude.AdicionarConsulta(consulta);

                Console.WriteLine("Consulta adicionada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar consulta: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }


        private static void VerConsultas(CentroSaude centroSaude)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Adicionar Exames ===");

                // Solicita o ID da consulta
                Console.Write("ID da Consulta: ");
                if (!int.TryParse(Console.ReadLine(), out int idConsulta))
                {
                    Console.WriteLine("ID inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Encontra a consulta correspondente
                var consulta = centroSaude.Consultas.FirstOrDefault(c => c.IdConsulta == idConsulta);
                if (consulta == null)
                {
                    Console.WriteLine("Consulta não encontrada. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Solicita os dados necessários para criar o exame
                Console.Write("Data do Exame (formato: dd/MM/yyyy): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataExame))
                {
                    Console.WriteLine("Data inválida. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Resultado do Exame: ");
                string resultado = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(resultado))
                {
                    Console.WriteLine("Resultado inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("Tipo de Exame (número correspondente):");
                foreach (var tipo in Enum.GetValues(typeof(TipoExame)))
                {
                    Console.WriteLine($"{(int)tipo} - {tipo}");
                }
                if (!Enum.TryParse(Console.ReadLine(), out TipoExame tipoExame))
                {
                    Console.WriteLine("Tipo de Exame inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Solicita o médico responsável
                Console.WriteLine("Médicos disponíveis:");
                foreach (var medico in centroSaude.Medicos)
                {
                    Console.WriteLine($"{medico.IdMedico} - {medico.Nome}");
                }
                Console.Write("Digite o ID do médico responsável pelo exame: ");
                if (!int.TryParse(Console.ReadLine(), out int idMedico))
                {
                    Console.WriteLine("ID inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                var medicoResponsavel = centroSaude.Medicos.FirstOrDefault(m => m.IdMedico == idMedico);
                if (medicoResponsavel == null)
                {
                    Console.WriteLine("Médico não encontrado. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Cria o objeto Exame com os dados fornecidos
                Exame exame = new Exame(dataExame, resultado, tipoExame, medicoResponsavel);

                // Adiciona o exame à consulta
                consulta.AdicionarExame(exame);

                Console.WriteLine("Exame adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar exame: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }


        private static void AdicionarExames(CentroSaude centroSaude)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Adicionar Exames ===");

                // Solicita o ID da consulta
                Console.Write("ID da Consulta: ");
                if (!int.TryParse(Console.ReadLine(), out int idConsulta))
                {
                    Console.WriteLine("ID inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Encontra a consulta correspondente
                var consulta = centroSaude.Consultas.FirstOrDefault(c => c.IdConsulta == idConsulta);
                if (consulta == null)
                {
                    Console.WriteLine("Consulta não encontrada. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Solicita os dados necessários para criar o exame
                Console.Write("Data do Exame (formato: dd/MM/yyyy): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataExame))
                {
                    Console.WriteLine("Data inválida. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Resultado do Exame: ");
                string resultado = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(resultado))
                {
                    Console.WriteLine("Resultado inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("Tipo de Exame (número correspondente):");
                foreach (var tipo in Enum.GetValues(typeof(TipoExame)))
                {
                    Console.WriteLine($"{(int)tipo} - {tipo}");
                }
                if (!Enum.TryParse(Console.ReadLine(), out TipoExame tipoExame))
                {
                    Console.WriteLine("Tipo de Exame inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Solicita o médico responsável
                Console.WriteLine("Médicos disponíveis:");
                foreach (var medico in centroSaude.Medicos)
                {
                    Console.WriteLine($"{medico.IdMedico} - {medico.Nome}");
                }
                Console.Write("Digite o ID do médico responsável pelo exame: ");
                if (!int.TryParse(Console.ReadLine(), out int idMedico))
                {
                    Console.WriteLine("ID inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Encontra o médico responsável
                var medicoResponsavel = centroSaude.Medicos.FirstOrDefault(m => m.IdMedico == idMedico);
                if (medicoResponsavel == null)
                {
                    Console.WriteLine("Médico não encontrado. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Cria o objeto Exame com os dados fornecidos
                Exame exame = new Exame(dataExame, resultado, tipoExame, medicoResponsavel);

                // Adiciona o exame à consulta
                consulta.AdicionarExame(exame);

                Console.WriteLine("Exame adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar exame: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        private static void VerExames(CentroSaude centroSaude)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Lista de Exames ===");

                if (centroSaude.Consultas.Count == 0)
                {
                    Console.WriteLine("Nenhuma consulta cadastrada.");
                }
                else
                {
                    foreach (var consulta in centroSaude.Consultas)
                    {
                        foreach (var exame in consulta.Exames)
                        {
                            // Aqui, usamos a propriedade 'Tipo' para acessar o tipo do exame
                            Console.WriteLine($"Consulta {consulta.IdConsulta} | {exame}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao exibir exames: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        private static void RemoverExames(CentroSaude centroSaude)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Remover Exames ===");

                // Solicita o ID da consulta
                Console.Write("ID da Consulta: ");
                if (!int.TryParse(Console.ReadLine(), out int idConsulta))
                {
                    Console.WriteLine("ID inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Encontra a consulta correspondente
                var consulta = centroSaude.Consultas.FirstOrDefault(c => c.IdConsulta == idConsulta);
                if (consulta == null)
                {
                    Console.WriteLine("Consulta não encontrada. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Exibe os exames da consulta
                Console.WriteLine("Exames da consulta:");
                foreach (var exame in consulta.Exames)
                {
                    Console.WriteLine($"Id: {exame.IdExame} | Data: {exame.DataExame} | Resultado: {exame.Resultado} | Tipo: {exame.Tipo}");
                }

                // Solicita o ID do exame a ser removido
                Console.Write("Digite o ID do Exame a Remover: ");
                if (!int.TryParse(Console.ReadLine(), out int idExame))
                {
                    Console.WriteLine("ID inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Encontra o exame pelo ID
                var exameParaRemover = consulta.Exames.FirstOrDefault(e => e.IdExame == idExame);
                if (exameParaRemover == null)
                {
                    Console.WriteLine("Exame não encontrado. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Remove o exame da consulta
                consulta.RemoverExame(exameParaRemover);

                Console.WriteLine("Exame removido com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao remover exame: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        // Método de associar médico ao exame
        private static void AssociarMedicoAoExame(CentroSaude centroSaude)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Associar Médico ao Exame ===");

                // Solicita o ID da consulta
                Console.Write("ID da Consulta: ");
                if (!int.TryParse(Console.ReadLine(), out int idConsulta))
                {
                    Console.WriteLine("ID inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Encontra a consulta correspondente
                var consulta = centroSaude.Consultas.FirstOrDefault(c => c.IdConsulta == idConsulta);
                if (consulta == null)
                {
                    Console.WriteLine("Consulta não encontrada. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Solicita o ID do exame
                Console.Write("ID do Exame: ");
                if (!int.TryParse(Console.ReadLine(), out int idExame))
                {
                    Console.WriteLine("ID inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Encontra o exame correspondente
                var exame = consulta.Exames.FirstOrDefault(e => e.IdExame == idExame);
                if (exame == null)
                {
                    Console.WriteLine("Exame não encontrado. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Solicita o médico para associar ao exame
                Console.WriteLine("Médicos disponíveis:");
                foreach (var medico in centroSaude.Medicos)
                {
                    Console.WriteLine($"{medico.IdMedico} - {medico.Nome}");
                }
                Console.Write("Digite o ID do médico a ser associado ao exame: ");
                if (!int.TryParse(Console.ReadLine(), out int idMedico))
                {
                    Console.WriteLine("ID inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                var medicoResponsavel = centroSaude.Medicos.FirstOrDefault(m => m.IdMedico == idMedico);
                if (medicoResponsavel == null)
                {
                    Console.WriteLine("Médico não encontrado. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Associa o médico ao exame
                exame.AssociarMedico(medicoResponsavel);
                Console.WriteLine($"Médico {medicoResponsavel.Nome} associado ao exame com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao associar médico ao exame: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
