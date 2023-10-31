using ApiNetCore7.Handler;
using ApiNetCore7.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNetCore7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegocioController : ControllerBase
    {

        private readonly NegocioHandler _NegocioHandler;
        public NegocioController(NegocioHandler negocioHandler)
        {
            _NegocioHandler = negocioHandler;
        }

        [HttpGet("getRutas")]
        public async Task<ActionResult<RespuestaHttpTipado<List<RutaDto>>>> Rutas()
        {
            return await _NegocioHandler.getRutas();
        }

        [HttpGet("getInfoRutaById")]
        public async Task<ActionResult<RespuestaHttpTipado<InfoRutaDto>>> InfoRutaById(int ruta_id)
        {
            return await _NegocioHandler.getInfoRutaById(ruta_id);
        }
        

        [HttpGet("getSucursales")]
        public async Task<ActionResult<RespuestaHttp>> Sucursales()
        {
            return await _NegocioHandler.getSucursales();
        }

        [HttpPost("postRuta")]
        public async Task<ActionResult<RespuestaHttp>> postRuta(RutaDto rutaDto)
        {
            return await _NegocioHandler.post(rutaDto);
        }

        [HttpPost("postPedido")]
        [Authorize]
        public async Task<ActionResult<RespuestaHttp>> postPedido(PedidoCompletoDto pedidoCompleto)
        {
            return await _NegocioHandler.post(pedidoCompleto.pedido, pedidoCompleto.detalles);
        }

        [HttpPost("postRecetaYDetalles")]
        [Authorize]
        public async Task<ActionResult<RespuestaHttp>> postRecetaYDetalles(RecetaDto recetaDto)
        {
            return await _NegocioHandler.setRecetaYDetalles(recetaDto);
        }

        [HttpGet("getUnidadesMedida")]
        public async Task<ActionResult<RespuestaHttp>> UnidadesMedida()
        {
            return await _NegocioHandler.getUnidadesMedida();
        }

        [HttpGet("getIngredientes")]
        public async Task<ActionResult<RespuestaHttp>> getIngredientes()
        {
            return await _NegocioHandler.getIngredientes();
        }

        [HttpGet("getProductosByTienda")]
        public async Task<ActionResult<RespuestaHttp>> ProductosByTienda(int sucursal_id)
        {
            return await _NegocioHandler.getProductosByTienda(sucursal_id);
        }

        [HttpGet("getRecetaAndDetById")]
        public async Task<ActionResult<RespuestaHttp>> RecetaAndDetById(int receta_id)
        {
            return await _NegocioHandler.getRecetaAndDetById(receta_id);
        }

        [HttpGet("getRecetas")]
        public async Task<ActionResult<RespuestaHttp>> Recetas()
        {
            return await _NegocioHandler.getRecetas();
        }

        [HttpGet("getRecetaDetByIdRec")]
        public async Task<ActionResult<RespuestaHttp>> RecetaDetByIdRec(int receta_id)
        {
            return await _NegocioHandler.getRecetaDetByIdRec(receta_id);
        }

        [HttpPost("setProducto")]
        public async Task<ActionResult<RespuestaHttp>> setProducto(ProductoDto productoDto)
        {
            return await _NegocioHandler.setProducto(productoDto);
        }

        [HttpGet("getPedidoYDetalles")]
        public async Task<ActionResult<RespuestaHttp>> getPedidoYDetalles()
        {
            return await _NegocioHandler.getPedidoYDetalles();
        }

        
        [HttpGet("getRecetaDetalles")]
        public async Task<ActionResult<RespuestaHttp>> RecetaDetalles()
        {
            return await _NegocioHandler.getRecetaDetalles();
        }

        [HttpGet("getUsuarios")]
        public async Task<ActionResult<RespuestaHttp>> Usuarios()
        {
            return await _NegocioHandler.getUsuarios();
        }

        [HttpGet("getTurnos")]
        public async Task<ActionResult<RespuestaHttp>> Turnos()
        {
            return await _NegocioHandler.getTurnos();
        }

        [HttpGet("getTransportes")]
        public async Task<ActionResult<RespuestaHttp>> Transportes()
        {
            return await _NegocioHandler.getTransportes();
        }

        [HttpGet("getStatus")]
        public async Task<ActionResult<RespuestaHttp>> Status()
        {
            return await _NegocioHandler.getStatus();
        }

        [HttpGet("getRolTipos")]
        public async Task<ActionResult<RespuestaHttp>> RolTipos()
        {
            return await _NegocioHandler.getRolTipos();
        }

        [HttpGet("getMiniSistems")]
        public async Task<ActionResult<RespuestaHttp>> MiniSistems()
        {
            return await _NegocioHandler.getMiniSistems();
        }

        [HttpGet("getFacturaDetalles")]
        public async Task<ActionResult<RespuestaHttp>> FacturaDetalles()
        {
            return await _NegocioHandler.getFacturaDetalles();
        }

        [HttpGet("getFacturas")]
        public async Task<ActionResult<RespuestaHttp>> Facturas()
        {
            return await _NegocioHandler.getFacturas();
        }

        [HttpGet("getProductos")]
        public async Task<ActionResult<RespuestaHttp>> getProductos()
        {
            return await _NegocioHandler.getProductos();
        }

        [HttpGet("GetPedidos")]
        public async Task<ActionResult<RespuestaHttp>> GetPedidos()
        {
            return await _NegocioHandler.GetPedidos();
        }
        

    }
}
