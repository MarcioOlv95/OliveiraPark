using DevIo.Business.Interfaces.Repository;
using DevIo.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class MensalRepository : Repository<Mensal>, IMensalRepository
    {
        public MensalRepository(ParkContext context) : base(context) { }

        public async Task<Mensal> ObterPorIDLoadClienteAndCarroAndPagamentosAsync(Guid id)
        {
            return await Db.Mensais.AsNoTracking()
                .Include(x => x.Cliente)
                .Include(x => x.Carro)
                .Include(x => x.Pagamentos)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
