using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Interfaces
{
    public interface IOngs
    {
        Task<Ongs[]> Lista();
        Task<Ongs>   BuscarPorId(string id);
        bool Salvar(Ongs dados);
        bool Deletar(Ongs dados);
    }
}
