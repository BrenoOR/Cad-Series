﻿using System;

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
                        //AtualizarSerie();
                        break;
                    case "4":
                        //ExcluirSerie();
                        break;
                    case "5":
                        //VisualizarSerie();
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

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série:");

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

            Serie novaSerie = new Serie(id: repo.ProximoID(),
                                        genero: (Genero)inputGenero,
                                        titulo: inputTitulo,
                                        ano: inputAno,
                                        descricao: inputDescricao);
            
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
                Console.WriteLine("#ID {0}: - {1}", serie.getID(), serie.getTitulo());
            }
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
