using ChallengeCoodesh_CROM.Models.Entitie;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCoodesh_CROM.Interface
{
    public interface IMyService
    {
        Task<IEnumerable<Data>> GetArticles(int limit);
        Task<int> GetCount();
    }
}
