using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevIO.App.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using DevIO.App.Extensions;
using DevIo.Business.Interfaces.Service;
using DevIo.Business.Models;

namespace DevIO.App.Controllers
{
    [Authorize]
    public class MensaisController : BaseController
    {
        private readonly IMensalService _mensalService;
        private readonly IMapper _mapper;

        public MensaisController(IMensalService mensalService, 
                                IMapper mapper,
                                INotificador notificador) : base (notificador)
        {
            _mensalService = mensalService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<MensalViewModel>>(await _mensalService.ObterTodos()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
                return NotFound();

            var mensal = _mapper.Map<MensalViewModel>(await _mensalService.ObterPorID(id));

            if (mensal == null)
                return NotFound();

            return View(mensal);
        }

        [ClaimsAuthorize("Mensais", "Criar")]
        public IActionResult Create()
        {
            return View();
        }

        [ClaimsAuthorize("Mensais", "Criar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MensalViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var mensal = _mapper.Map<Mensal>(model);

            await _mensalService.Adicionar(mensal);

            if (!OperacaoValida())
                return View(model);

            return RedirectToAction(nameof(Index));
        }

        [ClaimsAuthorize("Mensais", "Editar")]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
                return NotFound();

            var mensal = await _mensalService.ObterPorIDLoadClienteAndCarroAndPagamentos(id);
            
            if (mensal == null)
                return NotFound();

            var model = _mapper.Map<MensalViewModel>(mensal);

            return View(model);
        }

        [ClaimsAuthorize("Mensais", "Editar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, MensalViewModel model)
        {
            if (id != model.Id)
                return NotFound();

            var mensal = _mapper.Map<Mensal>(model);

            if (ModelState.IsValid)
                await _mensalService.Atualizar(mensal);

            TempData["Sucesso"] = "Dados salvos com sucesso";

            return RedirectToAction("Index");
        }

        [ClaimsAuthorize("Mensais", "Excluir")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
                return NotFound();

            var mensal = await _mensalService.ObterPorID(id);
            
            if (mensal == null)
                return NotFound();

            var model = _mapper.Map<MensalViewModel>(mensal);

            return View(model);
        }

        [ClaimsAuthorize("Mensais", "Excluir")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _mensalService.Remover(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
