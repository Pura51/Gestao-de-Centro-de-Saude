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

                // Criando o paciente
                Paciente paciente = new Paciente(nome, idade, sexo);
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

                var pacienteRemover = centroSaude.Pacientes[escolha - 1];
                centroSaude.RemoverPaciente(pacienteRemover);
                Console.WriteLine("Paciente removido com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

    }
}
