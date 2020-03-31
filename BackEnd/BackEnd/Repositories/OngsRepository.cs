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
    public class OngsRepository : IOngs
    {
        private readonly DBContext _dBContext;

        public OngsRepository(DBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<Ongs> BuscarPorId(string id)
        {
            IQueryable<Ongs> query = _dBContext.Ongs.Where(c => c.Id == id);
            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public bool Deletar(Ongs dados)
        {
            _dBContext.Remove(dados);
            _dBContext.SaveChanges();
            return true;
        }

        public async Task<Ongs[]> Lista()
        {
            IQueryable<Ongs> query = _dBContext.Ongs;
            return await query.AsNoTracking().ToArrayAsync();
        }

        public bool Salvar(Ongs dados)
        {
            try
            {
                if(dados.Id == null)
                {
                    Random random = new Random();
                    int num = random.Next();
                    dados.Id = num.ToString("X");
                    _dBContext.Add(dados);
                }
                else
                {
                    _dBContext.Update(dados);
                }
                _dBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
