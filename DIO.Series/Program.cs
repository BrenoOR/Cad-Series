using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepo repo = new SerieRepo();
        static void Main(string[] args)
        {
            string option = getOpcaoUsuario();

            while (option.ToUpper() != "X")
            {
                switch(option)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                option = getOpcaoUsuario();
            }
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Visualizar série:");
            Console.Write("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            var serie = repo.RetornaPorID(idSerie);

            Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Excluir série:");
            Console.Write("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());
            Console.WriteLine("Você têm certeza disso? S/N");
            
            string response = Console.ReadLine();
            switch(response)
            {
                case "S":
                case "Sim":
                case "Y":
                case "Yes":
                case "Yep":
                    repo.Exclui(idSerie);
                    break;
                case "N":
                case "Não":
                case "No":
                case "Nope":
                    Console.WriteLine("Ufa!!! Tenha um bom dia!");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Atualizar série:");
            Console.Write("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            Serie serieAtt = generateSerie(idSerie);
            
            repo.Atualiza(idSerie, serieAtt);
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série:");

            Serie novaSerie = generateSerie(repo.ProximoID());
            
            repo.Insere(novaSerie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries:");

            var lista = repo.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach(var serie in lista)
            {
                var excluido = serie.getExcluido();
                if (!excluido)
                {
                    Console.WriteLine("#ID {0}: - {1}", serie.getID(), serie.getTitulo());
                }
            }
        }

        private static Serie generateSerie(int idSerie)
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Escolha o gênero entre as opções acima: ");
            int inputGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série: ");
            string inputTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de lançamento da série: ");
            int inputAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Escreva a sinopse da série: ");
            string inputDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: idSerie,
                                        genero: (Genero)inputGenero,
                                        titulo: inputTitulo,
                                        ano: inputAno,
                                        descricao: inputDescricao);

            return novaSerie;
        }

        private static string getOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo à DIO Séries!!!");
            Console.WriteLine("O que desejas?");

            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir nova Série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("C - Limpar a tela");
            Console.WriteLine("X - Sair");

            string opcao = Console.ReadLine().ToUpper();            
            Console.WriteLine();
            return opcao;
        }
    }
}
