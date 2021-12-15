using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challengeCoodesh.DbConfig.IRepository;
using ChallengeCoodesh_CROM.Models.Entitie;

namespace challengeCoodesh.DbConfig.Repository
{
    public class ArticlesRepository : IArticlesRepository
    {
        public void Adicionar(Articles article)
        {
            throw new NotImplementedException();
        }

        public Articles Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Articles> Buscar()
        {
            throw new NotImplementedException();
        }

        public void Editar(int ID, Articles article)
        {
            throw new NotImplementedException();
        }

        public void Removar(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
