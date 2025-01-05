using CentroSaudeProject.Classes;
using System;

namespace Menus.Menu
{
    public static class MenuEnfermeiros
    {
        public static void ExibirMenu(CentroSaude centroSaude)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== Gestão de Enfermeiros ===");
                Console.WriteLine("1. Adicionar Enfermeiro");
                Console.WriteLine("2. Listar Enfermeiros");
                Console.WriteLine("3. Atribuir Enfermeiro a uma Cama");
                Console.WriteLine("4. Atribuir Enfermeiro a um Quarto");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.Write("Escolha uma opção: ");

                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarEnfermeiro(centroSaude);
                        break;
                    case "2":
                        ListarEnfermeiros(centroSaude);
                        break;
                    case "3":
                        AtribuirEnfermeiroACama(centroSaude);
                        break;
                    case "4":
                        AtribuirEnfermeiroAQuarto(centroSaude);
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

        private static void AdicionarEnfermeiro(CentroSaude centroSaude)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== Adicionar Enfermeiro ===");

                // Solicitar o nome
                Console.Write("Digite o nome do enfermeiro: ");
                string nome = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(nome))
                {
                    Console.WriteLine("Nome inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Solicitar a idade
                Console.Write("Digite a idade do enfermeiro: ");
                if (!int.TryParse(Console.ReadLine(), out int idade) || idade <= 0)
                {
                    Console.WriteLine("Idade inválida. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Solicitar o número do Cartão de Cidadão (ccNum)
                Console.Write("Digite o número do Cartão de Cidadão (CC): ");
                if (!int.TryParse(Console.ReadLine(), out int ccNum) || ccNum <= 0)
                {
                    Console.WriteLine("Número do CC inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Solicitar o NIF (ccNIF)
                Console.Write("Digite o Número de Identificação Fiscal (NIF): ");
                if (!int.TryParse(Console.ReadLine(), out int ccNIF) || ccNIF <= 0)
                {
                    Console.WriteLine("Número do NIF inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Solicitar o sexo
                Console.Write("Digite o sexo do enfermeiro (M/F): ");
                char sexo = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine(); // Para mover para a próxima linha após a entrada.

                if (sexo != 'M' && sexo != 'F')
                {
                    Console.WriteLine("Sexo inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                // Criar o objeto Enfermeiro
                var enfermeiro = new Enfermeiro(nome, idade, ccNum, ccNIF, sexo);
                centroSaude.AdicionarEnfermeiro(enfermeiro);

                Console.WriteLine($"Enfermeiro {nome} adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar enfermeiro: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }


        private static void ListarEnfermeiros(CentroSaude centroSaude)
        {
            Console.Clear();
            Console.WriteLine("=== Lista de Enfermeiros ===");
            if (centroSaude.Enfermeiros.Count == 0)
            {
                Console.WriteLine("Nenhum enfermeiro cadastrado.");
            }
            else
            {
                foreach (var enfermeiro in centroSaude.Enfermeiros)
                {
                    Console.WriteLine(enfermeiro); // Usa o método ToString da classe Enfermeiro.
                }
            }
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        private static void AtribuirEnfermeiroACama(CentroSaude centroSaude)
        {
            Console.Clear();
            Console.WriteLine("=== Atribuir Enfermeiro a uma Cama ===");

            Console.Write("Digite o ID da cama: ");
            if (!int.TryParse(Console.ReadLine(), out int idCama))
            {
                Console.WriteLine("ID da cama inválido.");
                Console.ReadKey();
                return;
            }

            var cama = centroSaude.Quartos
                .SelectMany(q => q.Camas)
                .FirstOrDefault(c => c.IdCama == idCama);

            if (cama == null)
            {
                Console.WriteLine("Cama não encontrada.");
                Console.ReadKey();
                return;
            }

            Console.Write("Digite o ID do enfermeiro: ");
            if (!int.TryParse(Console.ReadLine(), out int idEnfermeiro))
            {
                Console.WriteLine("ID do enfermeiro inválido.");
                Console.ReadKey();
                return;
            }

            var enfermeiro = centroSaude.Enfermeiros.FirstOrDefault(e => e.IdEnfermeiro == idEnfermeiro);

            if (enfermeiro == null)
            {
                Console.WriteLine("Enfermeiro não encontrado.");
                Console.ReadKey();
                return;
            }

            cama.EnfermeiroResponsavel = enfermeiro;

            Console.WriteLine($"Enfermeiro {enfermeiro._nome} foi atribuído à cama {cama.NumeroCama}.");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        private static void AtribuirEnfermeiroAQuarto(CentroSaude centroSaude)
        {
            Console.Clear();
            Console.WriteLine("=== Atribuir Enfermeiro a um Quarto ===");

            Console.Write("Digite o número do quarto: ");
            if (!int.TryParse(Console.ReadLine(), out int numeroQuarto))
            {
                Console.WriteLine("Número do quarto inválido.");
                Console.ReadKey();
                return;
            }

            var quarto = centroSaude.Quartos.FirstOrDefault(q => q.Numero == numeroQuarto);

            if (quarto == null)
            {
                Console.WriteLine("Quarto não encontrado.");
                Console.ReadKey();
                return;
            }

            Console.Write("Digite o ID do enfermeiro: ");
            if (!int.TryParse(Console.ReadLine(), out int idEnfermeiro))
            {
                Console.WriteLine("ID do enfermeiro inválido.");
                Console.ReadKey();
                return;
            }

            var enfermeiro = centroSaude.Enfermeiros.FirstOrDefault(e => e.IdEnfermeiro == idEnfermeiro);

            if (enfermeiro == null)
            {
                Console.WriteLine("Enfermeiro não encontrado.");
                Console.ReadKey();
                return;
            }

            quarto.EnfermeiroResponsavel = enfermeiro;

            Console.WriteLine($"Enfermeiro {enfermeiro._nome} foi atribuído ao quarto {quarto.Numero}.");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
