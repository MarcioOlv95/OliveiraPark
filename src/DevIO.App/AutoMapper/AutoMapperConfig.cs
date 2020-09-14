using AutoMapper;
using DevIo.Business.Models;
using DevIO.App.ViewModels;

namespace DevIO.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Avulso, AvulsoViewModel>().ReverseMap();
            CreateMap<Mensal, MensalViewModel>().ReverseMap();
            CreateMap<Carro, CarroViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Pagamento, PagamentoViewModel>().ReverseMap();
        }
    }
}
