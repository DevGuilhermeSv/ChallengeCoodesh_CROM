using System;
using System.Collections.Generic;
using System.Linq;
using challengeCoodesh.DbConfig.IRepository;
using ChallengeCoodesh_CROM.Models.Entitie;
using MongoDB.Driver;

namespace challengeCoodesh.DbConfig.Repository
{
    public class ArticlesRepository : IArticlesRepository
    {
        DbConfig db = new DbConfig();
        public void Adicionar(Articles article)
        {
            throw new NotImplementedException();
        }

        public Articles Buscar(int id)
        {
            var database = db.database;
            var collection = database.GetCollection<Articles>("data");
            return collection.FindSync(ar => ar.id == id).Current.ElementAt(0);
        }

        public IEnumerable<Articles> Buscar()
        {
            var database = db.database;
            var collection = database.GetCollection<Articles>("data");
            return collection.FindSync(ar => true).Current;
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
