using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevIO.App.ViewModels;
using AutoMapper;
using DevIo.Business.Models;
using DevIo.Business.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace DevIO.App.Controllers
{
    [Authorize]
    public class AvulsosController : BaseController
    {
        private readonly IAvulsoService _avulsoService;
        private readonly IMapper _mapper;

        public AvulsosController(IAvulsoService avulsoService,
                                IMapper mapper,
                                INotificador notificador) : base(notificador)
        {
            _avulsoService = avulsoService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<AvulsoViewModel>>(await _avulsoService.ObterTodos()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AvulsoViewModel avulsoViewModel)
        {
            if (ModelState.IsValid)
                return RedirectToAction(nameof(Index));

            var avulso = _mapper.Map<Avulso>(avulsoViewModel);
            await _avulsoService.Adicionar(avulso);

            if (!OperacaoValida())
                return View(avulsoViewModel);

            return RedirectToAction("Index");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AvulsoViewModel avulsoViewModel)
        {
            if (id != Guid.Empty && avulsoViewModel.HrEntrada > avulsoViewModel.HrSaida)
                ModelState.AddModelError("HrSaida", "O horário de saída deve ser maior que o de entrada");

            if (!ModelState.IsValid)
                return PartialView("_EditarAvulso", avulsoViewModel);

            var avulso = _mapper.Map<Avulso>(avulsoViewModel);

            if (id == Guid.Empty)
                await _avulsoService.Adicionar(avulso);
            else
                await _avulsoService.Atualizar(avulso);

            if (!OperacaoValida())
                return PartialView("_EditarAvulso", avulsoViewModel);

            var url = Url.Action("ObterAvulsos", "Avulsos");

            TempData["Sucess"] = "Avulso salvo com sucesso";

            return Json(new { success = true, url });
        }

        [HttpGet]
        public IActionResult CalcularPreco(Guid id, DateTime dataSaida)
        {
            var preco = _avulsoService.CalcularPreco(id, dataSaida);

            return Json(preco);
        }

        public async Task<IActionResult> EditarAvulso(Guid id)
        {
            AvulsoViewModel avulso = new AvulsoViewModel();

            if (id != Guid.Empty)
            {
                avulso = _mapper.Map<AvulsoViewModel>(await _avulsoService.ObterPorID(id));
                if (avulso.HrSaida == DateTime.MinValue)
                    avulso.HrSaida = null;
            }
            else
            {    
                avulso.Id = Guid.Empty;
                avulso.HrEntrada = Convert.ToDateTime(DateTime.Now.ToString("g"));
                avulso.HrSaida = null;
            }

            return PartialView("_EditarAvulso", avulso);
        }

        public async Task<IActionResult> ObterAvulsos()
        {
            var avulsos = _mapper.Map<IEnumerable<AvulsoViewModel>>(await _avulsoService.ObterTodosByDiaAtual());

            return PartialView("_ListaAvulsos", avulsos);
        }

    }
}
