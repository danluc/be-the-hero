using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Interfaces
{
    public interface IIncidents
    {
        Task<Incidents[]> Lista();
        Task<Incidents[]> ListaPorOng(string ongId);
        Task<Incidents>   BuscarPorId(int id);
        Task<Incidents>   BuscarHasOng(int id, string ongid);
        bool Salvar(Incidents dados);
        bool Deletar(Incidents dados);
    }
}
