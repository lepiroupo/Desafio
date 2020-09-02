using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Cache.Interfaces
{
    public interface ICacheManager
    {
        T ObterChache<T>(string chave);
        void GravarCache<T>(string chave, T objeto);
    }
}
