using DevIo.Business.Interfaces.Repository;
using DevIo.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class AvulsoRepository : Repository<Avulso>, IAvulsoRepository
    {
        public AvulsoRepository(ParkContext context) : base(context) { }

        public async Task<Avulso> ObterPelaPlaca(string placa)
        {
            return await Db.Avulsos.AsNoTracking().FirstOrDefaultAsync(x => x.Placa == placa);
        }

        public async override Task<List<Avulso>> ObterTodos()
        {
            return await Db.Avulsos.OrderByDescending(x => x.DataCadastro).ThenBy(z => z.DataAlteracao).AsNoTracking().ToListAsync();
        }

        public async Task<List<Avulso>> ObterTodosByDiaAtual()
        {
            return await Db.Avulsos.Where(x => x.DataCadastro.Day == DateTime.Now.Day).AsNoTracking().ToListAsync();
        }
    }
}
