using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCoodesh.Models.Interface
{
    public interface IMyService
    {
        Task<HttpResponseMessage> GetPage();
    }
}
