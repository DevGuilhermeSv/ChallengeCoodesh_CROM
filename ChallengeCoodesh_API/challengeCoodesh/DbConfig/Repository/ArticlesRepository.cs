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
            var database = db.database;
            var collection = database.GetCollection<Articles>("Data");
            collection.InsertOne(article);
        }

        public Articles Buscar(int id)
        {
            var database = db.database;
            var collection = database.GetCollection<Articles>("Data");
            return collection.Find(ar => ar.id == id).FirstOrDefault();
        }

        public IEnumerable<Articles> Buscar(int? _init, int? _finish)
        {
            var database = db.database;
            var collection = database.GetCollection<Articles>("Data");
            var data = collection.Find(ar => true).Skip(_init).Limit(_finish).ToList().OrderBy(ar=>ar.id);
            return data;
        }
            
    

        public void Editar(int ID, Articles article)
        {
            var database = db.database;
            var collection = database.GetCollection<Articles>("Data");
            collection.ReplaceOne(ar => ar.id == ID, article);
        }

        public void Remover(int ID)
        {
            var database = db.database;
            var collection = database.GetCollection<Articles>("Data");
            var data = collection.DeleteOne(ar => ar.id == ID);
            
        }
    }
}
