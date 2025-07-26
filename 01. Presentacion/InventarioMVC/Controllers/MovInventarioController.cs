using AutoMapper;
using GestionInventarios.Aplicacion.Caracteristicas.Comandos.ActualizarMovInventarios;
using GestionInventarios.Aplicacion.Caracteristicas.Comandos.EliminarMovInventarios;
using GestionInventarios.Aplicacion.Caracteristicas.Comandos.InsertarMovInventarios;
using GestionInventarios.Aplicacion.Caracteristicas.Consultas.ObtenerMovInventarios;
using GestionInventarios.Aplicacion.Persistencia;
using GestionInventarios.Aplicacion.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestionInventarios.Web.Controllers
{
    public class MovInventarioController : Controller
    {
        private readonly IMovInventariosServicios _servicios;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public MovInventarioController(IMovInventariosServicios servicios, IMediator mediator, IMapper mapper)
        {
            _servicios = servicios;
            _mediator = mediator;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var query = new ObtenerMovInventarioQuery();
            var movInventarios = _servicios.ObtenerMovInventariosAsync(query).Result;
            var lista = _mapper.Map<IEnumerable<MovInventarioViewModel>>(movInventarios);
            return View(lista);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerMovInventarios(MovInventarioViewModel viewModel)
        {
            var query = new ObtenerMovInventarioQuery
            {
                TipoMovimiento = viewModel.TipoMovimiento,
                NroDocumento = viewModel.NroDocumento
            };
            var movInventarios = await _servicios.ObtenerMovInventariosAsync(query);
            var result = _mapper.Map<IEnumerable<MovInventarioViewModel>>(movInventarios);
            return View("Index", result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovInventarioViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var command = _mapper.Map<InsertarMovInventariosCommand>(viewModel);
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Editar(string tipoMovimiento, string nroDocumento)
        {
            var query = new ObtenerMovInventarioQuery { TipoMovimiento = tipoMovimiento, NroDocumento = nroDocumento };
            var movInventario = await _servicios.ObtenerMovInventariosAsync(query);
            if (movInventario == null) return NotFound();
            var viewModel = _mapper.Map<MovInventarioViewModel>(movInventario.FirstOrDefault());
            return View("Update", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(MovInventarioViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var command = _mapper.Map<ActualizarMovInventariosCommand>(viewModel);
            await _mediator.Send(command);
            return RedirectToAction("Index", viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(string tipoMovimiento, string nroDocumento)
        {
            var query = new ObtenerMovInventarioQuery { TipoMovimiento = tipoMovimiento, NroDocumento = nroDocumento };
            var movInventario = await _servicios.ObtenerMovInventariosAsync(query);
            if (movInventario == null) return NotFound();
            var viewModel = _mapper.Map<MovInventarioViewModel>(movInventario.FirstOrDefault());
            return View("Delete", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(MovInventarioViewModel viewModel)
        {
            var command = _mapper.Map<EliminarMovInventariosCommand>(viewModel);
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
    }
}
