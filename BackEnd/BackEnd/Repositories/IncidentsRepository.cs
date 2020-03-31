using BackEnd.Data;
using BackEnd.Interfaces;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Repositories
{
    public class IncidentsRepository : IIncidents
    {
        private readonly DBContext _dBContext;

        public IncidentsRepository(DBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public bool Deletar(Incidents dados)
        {
            _dBContext.Remove(dados);
            _dBContext.SaveChanges();
            return true;
        }

        public async Task<Incidents[]> Lista()
        {
            IQueryable<Incidents> query = _dBContext.Incidents.Include("Ongs");
            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<Incidents[]> ListaPorOng(string ongId)
        {
            IQueryable<Incidents> query = _dBContext.Incidents.Where(c => c.OngsId == ongId);
            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<Incidents> BuscarPorId(int id)
        {
            IQueryable<Incidents> query = _dBContext.Incidents.Where(c => c.Id == id);
            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public bool Salvar(Incidents dados)
        {
            try
            {
                if (dados.Id == 0)
                {
                    _dBContext.Add(dados);
                }
                else
                {
                    _dBContext.Update(dados);
                }
                _dBContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<Incidents> BuscarHasOng(int id, string ongid)
        {
            IQueryable<Incidents> query = _dBContext.Incidents.Where(c => c.Id == id && c.OngsId == ongid);
            return await query.AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
