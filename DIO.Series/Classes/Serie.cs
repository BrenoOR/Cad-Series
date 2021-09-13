using System;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }

        private string Titulo { get; set; }

        private string Descricao { get; set; }

        private int Ano { get; set; }

        private int Temporadas { get; set; }

        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano, int temporadas)
        {
            this.id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Temporadas = temporadas;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string result = "";
            result += "Gênero: " + this.Genero + Environment.NewLine;
            result += "Título: " + this.Titulo + Environment.NewLine;
            result += "Descrição: " + this.Descricao + Environment.NewLine;
            result += "Ano de Início: " + this.Ano + Environment.NewLine;
            result += "Número de Temporadas: " + this.Temporadas + Environment.NewLine;
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