using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepo repo = new SerieRepo();
        static void Main(string[] args)
        {
            string option = getOpcaoUsuario();
            string programStatus = setProgStatus(option);

            while (option.ToUpper() != "X")
            {
                switch(programStatus)
                {
                    case "Filme":
                        option = getOpcaoUsuarioFilmes();
                        while ((option.ToUpper() != "X"))
                        {
                            switch(option)
                            {
                                case "1":
                                    //ListarFilmes();
                                    break;
                                case "2":
                                    //InserirFilme();
                                    break;
                                case "3":
                                    //AtualizarFilme();
                                    break;
                                case "4":
                                    //ExcluirFilme();
                                    break;
                                case "5":
                                    //VisualizarFilme();
                                    break;
                                case "V":
                                    programStatus = setProgStatus("");
                                    break;
                                case "C":
                                    Console.Clear();
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                            if (programStatus == "")
                            {
                                break;
                            }
                            option = getOpcaoUsuarioFilmes();
                        }
                        break;
                    case "Serie":
                        option = getOpcaoUsuarioSeries();
                        while ((option.ToUpper() != "X"))
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
                                case "V":
                                    programStatus = setProgStatus("");
                                    break;
                                case "C":
                                    Console.Clear();
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                            if (programStatus == "")
                            {
                                break;
                            }
                            option = getOpcaoUsuarioSeries();
                        }
                        break;
                }

                option = getOpcaoUsuario();
                programStatus = setProgStatus(option);
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

        private static string setProgStatus(string opcao)
        {
            switch (opcao)
            {
                case "1":
                    return "Serie";
                case "2":
                    return "Filme";
                case "C":
                    Console.Clear();
                    return "";
                default:
                    return "";
            }
        }

        private static string getOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo à DIO Entertainment!!!");
            Console.WriteLine("O que desejas?");

            Console.WriteLine("1 - Séries");
            Console.WriteLine("2 - Filmes");
            
            Console.WriteLine("C - Limpar a tela");
            Console.WriteLine("X - Sair");

            string opcao = Console.ReadLine().ToUpper();            
            Console.WriteLine();
            return opcao;
        }

        private static string getOpcaoUsuarioFilmes()
        {
            Console.WriteLine();
            Console.WriteLine("Você escolheu Filmes!");
            Console.WriteLine("O que desejas?");

            Console.WriteLine("1 - Listar Filmes");
            Console.WriteLine("2 - Inserir novo Filme");
            Console.WriteLine("3 - Atualizar Filme");
            Console.WriteLine("4 - Excluir Filme");
            Console.WriteLine("5 - Visualizar Filme");
            
            Console.WriteLine("C - Limpar a tela");
            Console.WriteLine("V - Voltar");
            Console.WriteLine("X - Sair");

            string opcao = Console.ReadLine().ToUpper();            
            Console.WriteLine();
            return opcao;
        }

        private static string getOpcaoUsuarioSeries()
        {
            Console.WriteLine();
            Console.WriteLine("Você escolheu Séries!");
            Console.WriteLine("O que desejas?");

            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir nova Série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");

            Console.WriteLine("C - Limpar a tela");
            Console.WriteLine("V - Voltar");
            Console.WriteLine("X - Sair");

            string opcao = Console.ReadLine().ToUpper();            
            Console.WriteLine();
            return opcao;
        }
    }
}
