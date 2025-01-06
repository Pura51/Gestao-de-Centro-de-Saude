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
                Console.WriteLine("3. Remover Pacientes");
                Console.WriteLine("4. Alocação Automática de Paciente");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.Write("Escolha uma opção: ");

                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarPaciente(centroSaude);
                        break;
                    case "2":
                        VerPacientes(centroSaude);
                        break;
                    case "3":
                        RemoverPaciente(centroSaude);
                        break;
                    case "4":
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
            try
            {
                Console.Clear();
                Console.WriteLine("=== Adicionar Paciente ===");

                // Verificando se o nome não é nulo ou vazio
                Console.Write("Nome: ");
                string nome = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(nome)) // Verificar se o nome é nulo ou vazio
                {
                    Console.WriteLine("Nome não pode ser vazio. Insira novamente.");
                    Console.Write("Nome: ");
                    nome = Console.ReadLine();
                }

                // Verificando se a idade é válida
                Console.Write("Idade: ");
                int idade;
                while (!int.TryParse(Console.ReadLine(), out idade) || idade <= 0)
                {
                    Console.WriteLine("Idade inválida. Insira novamente.");
                    Console.Write("Idade: ");
                }

                // Verificando se o sexo é válido
                Console.Write("Sexo (M/F): ");
                string sexoInput = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(sexoInput) || (sexoInput != "M" && sexoInput != "F"))
                {
                    Console.WriteLine("Sexo inválido. Insira 'M' para Masculino ou 'F' para Feminino.");
                    Console.Write("Sexo (M/F): ");
                    sexoInput = Console.ReadLine();
                }
                char sexo = char.ToUpper(sexoInput[0]);

                // Solicitando os valores de ccNum e ccNIF
                Console.Write("Número do Cartão de Cidadão (ccNum): ");
                int ccNum;
                while (!int.TryParse(Console.ReadLine(), out ccNum) || ccNum <= 0)
                {
                    Console.WriteLine("Número do Cartão de Cidadão inválido. Insira novamente.");
                    Console.Write("Número do Cartão de Cidadão (ccNum): ");
                }

                Console.Write("Número de Identificação Fiscal (ccNIF): ");
                int ccNIF;
                while (!int.TryParse(Console.ReadLine(), out ccNIF) || ccNIF <= 0)
                {
                    Console.WriteLine("Número de Identificação Fiscal inválido. Insira novamente.");
                    Console.Write("Número de Identificação Fiscal (ccNIF): ");
                }

                // Criando o paciente com todos os dados
                Paciente paciente = new Paciente(nome, idade, sexo, ccNum, ccNIF);
                centroSaude.AdicionarPaciente(paciente);

                Console.WriteLine("Paciente adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        private static void VerPacientes(CentroSaude centroSaude)
        {
            Console.Clear();
            centroSaude.ListarPacientes(); // Chama o método para listar os pacientes
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        private static void RemoverPaciente(CentroSaude centroSaude)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Remover Paciente ===");

                if (centroSaude.Pacientes.Count == 0)
                {
                    Console.WriteLine("Não há pacientes registados.");
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("Lista de Pacientes:");
                for (int i = 0; i < centroSaude.Pacientes.Count; i++)
                {
                    var paciente = centroSaude.Pacientes[i];
                    Console.WriteLine($"{i + 1}. {paciente}");
                }

                Console.Write("Informe o id do paciente que deseja remover: ");
                if (!int.TryParse(Console.ReadLine(), out int escolha) || escolha < 1 || escolha > centroSaude.Pacientes.Count)
                {
                    Console.WriteLine("Id inválido.");
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    return;
                }

                // No caso de RemoverPaciente, se o método espera um ID:
                var pacienteRemover = centroSaude.Pacientes[escolha - 1];
                centroSaude.RemoverPaciente(pacienteRemover.IdPaciente); // Passando o ID, não o objeto paciente
                Console.WriteLine("Paciente removido com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        public static void AlocarPacienteAutomatico(CentroSaude centroSaude)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Alocação Automática de Paciente ===");

                // Escolha do paciente
                Console.Write("Digite o ID do Paciente: ");
                if (!int.TryParse(Console.ReadLine(), out int idPaciente))
                {
                    Console.WriteLine("ID inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                var paciente = centroSaude.Pacientes.FirstOrDefault(p => p.IdPaciente == idPaciente);
                if (paciente == null)
                {
                    Console.WriteLine("Paciente não encontrado. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                if (paciente.CamaOcupada != null)
                {
                    Console.WriteLine($"O paciente já está alocado na cama ID: {paciente.CamaOcupada.IdCama}.");
                    Console.ReadKey();
                    return;
                }

                // Procurar automaticamente um quarto e uma cama disponíveis
                foreach (var quarto in centroSaude.Quartos)
                {
                    var camaDisponivel = quarto.Camas.FirstOrDefault(c => c.Disponivel);
                    if (camaDisponivel != null)
                    {
                        // Atribuir a cama ao paciente
                        paciente.AtribuirCama(camaDisponivel);
                        camaDisponivel.Ocupar();

                        Console.WriteLine($"Paciente {paciente.Nome} foi alocado automaticamente à cama {camaDisponivel.NumeroCama} no quarto {quarto.Numero} com sucesso!");
                        Console.ReadKey();
                        return;
                    }
                }

                Console.WriteLine("Não há camas disponíveis em nenhum quarto.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao alocar paciente: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

    }
}