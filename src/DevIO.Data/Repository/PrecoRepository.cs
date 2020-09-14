using DevIo.Business.Interfaces.Repository;
using DevIo.Business.Models;
using DevIO.Data.Context;

namespace DevIO.Data.Repository
{
    public class PrecoRepository :Repository<Preco>, IPrecoRepository
    {
        public PrecoRepository(ParkContext context) : base(context) { }
    }
}
