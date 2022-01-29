using System;
using System.Collections.Generic;
using dio.mangas.Interfaces;

namespace dio.mangas
{
    public class MangasRepositorio : IRepositorio<Mangas>
    {

        private List<Mangas> listaMangas = new List<Mangas>();
        public void Atualiza(int id, Mangas objeto)
        {
            listaMangas[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaMangas[id].Excluir();
        }

        public void Insere(Mangas objeto)
        {
            listaMangas.Add(objeto);
        }

        public List<Mangas> Lista()
        {
            return listaMangas;
        }

        public int ProximoId()
        {
            return listaMangas.Count;
        }

        public Mangas RetornaPorId(int id)
        {
            return listaMangas[id];
        }
    }
}