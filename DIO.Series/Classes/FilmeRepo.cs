using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class FilmeRepo : IRepositorio<Filme>
    {
        private List<Filme> listaSerie = new List<Filme>();
        public void Atualiza(int id, Filme entidade)
        {
            listaSerie[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(Filme entidade)
        {
            listaSerie.Add(entidade);
        }

        public List<Filme> Lista()
        {
            return this.listaSerie;
        }

        public int ProximoID()
        {
            return this.listaSerie.Count;
        }

        public Filme RetornaPorID(int id)
        {
            return listaSerie[id];
        }
    }
}