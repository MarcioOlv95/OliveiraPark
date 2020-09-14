using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DevIO.App.ViewModels;
using AutoMapper;
using DevIo.Business.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;

namespace DevIO.App.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAvulsoService _avulsoService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger,
                                IAvulsoService avulsoService,
                                IMapper mapper,
                                INotificador notificador) : base(notificador)
        {
            _logger = logger;
            _avulsoService = avulsoService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexAsync()
        {
            HomeViewModel home = new HomeViewModel();

            home.AvulsoViewModelL = _mapper.Map<IEnumerable<AvulsoViewModel>>(await _avulsoService.ObterTodosByDiaAtual());
            home.HaVagaDisponivel = await _avulsoService.HaVagaDisponivel();

            return View(home);
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelErro = new ErrorViewModel();

            if (id == 500)
            {
                modelErro.Mensagem = "Ocorreu um erro! Tente novamente mais tarde ou contate nosso suporte.";
                modelErro.Titulo = "Ocorreu um erro!";
                modelErro.ErroCode = id;
            }
            else if (id == 404)
            {
                modelErro.Mensagem = "A página que está procurando não existe! <br />Em caso de dúvidas entre em contato com nosso suporte.";
                modelErro.Titulo = "Ops! Página não encontrada.";
                modelErro.ErroCode = id;
            }
            else if (id == 403)
            {
                modelErro.Mensagem = "Você não tem permissão para fazer isto.";
                modelErro.Titulo = "Acesso negado";
                modelErro.ErroCode = id;
            }
            else
            {
                return StatusCode(404);
            }

            return View("Error", modelErro);
        }
    }
}
