using AutoMapper;
using GestionInventarios.Aplicacion.Caracteristicas.Comandos.ActualizarMovInventarios;
using GestionInventarios.Aplicacion.Caracteristicas.Comandos.EliminarMovInventarios;
using GestionInventarios.Aplicacion.Caracteristicas.Comandos.InsertarMovInventarios;
using GestionInventarios.Aplicacion.Persistencia;
using GestionInventarios.Aplicacion.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestionInventarios.Web.Controllers
{
    [Route("inventario")]
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

        [HttpGet("")]
        public async Task<IActionResult> Index(DateTime? fechaInicio, DateTime? fechaFin, string tipoMovimiento, string nroDocumento)
        {
            var movInventarios = await _servicios.ObtenerMovInventariosAsync(fechaInicio, fechaFin, tipoMovimiento, nroDocumento);
            var viewModel = _mapper.Map<IEnumerable<MovInventarioViewModel>>(movInventarios);
            return View(viewModel);
        }

        [HttpGet("crear")]
        public IActionResult Create()
        {
            return View(new MovInventarioViewModel());
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Create(MovInventarioViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var command = _mapper.Map<InsertarMovInventariosCommand>(viewModel);
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(MovInventarioViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var command = _mapper.Map<ActualizarMovInventariosCommand>(viewModel);
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(MovInventarioViewModel viewModel)
        {
            var command = _mapper.Map<EliminarMovInventariosCommand>(viewModel);
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
    }
}
