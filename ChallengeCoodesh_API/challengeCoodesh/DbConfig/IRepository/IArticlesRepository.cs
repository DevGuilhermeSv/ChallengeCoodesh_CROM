using ChallengeCoodesh_CROM.Models.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challengeCoodesh.DbConfig.IRepository
{
    public interface IArticlesRepository
    {
        public void Adicionar(Articles article);
        public Articles Buscar(int id);
        public IEnumerable<Articles> Buscar();
        public void Editar(int ID, Articles article);
        public void Removar(int ID);

    }
}
