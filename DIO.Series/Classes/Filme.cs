using System;

namespace DIO.Series
{
    public class Filme : EntidadeBase
    {
        private Genero Genero { get; set; }

        private string Titulo { get; set; }

        private string Descricao { get; set; }

        private int Ano { get; set; }

        private bool Excluido { get; set; }

        public Filme(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string result = "";
            result += "Gênero: " + this.Genero + Environment.NewLine;
            result += "Título: " + this.Titulo + Environment.NewLine;
            result += "Descrição: " + this.Descricao + Environment.NewLine;
            result += "Ano de Lançamento: " + this.Ano + Environment.NewLine;
            result += "Excluído: " + this.Excluido;
            return result;
        }

        public string getTitulo()
        {
            return this.Titulo;
        }

        public int getID()
        {
            return this.id;
        }

        public bool getExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}