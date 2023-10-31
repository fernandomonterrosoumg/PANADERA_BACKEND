using ApiNetCore7.Helpers;
using ApiNetCore7.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using System.Transactions;

namespace ApiNetCore7.Handler
{
    public class NegocioHandler : ControllerBase
    {
        private readonly OracleDbManager _OracleDbManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public NegocioHandler(OracleDbManager oracleDbManager, IHttpContextAccessor httpContextAccessor)
        {
            _OracleDbManager = oracleDbManager;
            _httpContextAccessor = httpContextAccessor;
        }


        #region genericos
        private async Task<ActionResult<RespuestaHttp>> ExecuteGenericQuery(string query)
        {
            try
            {
                IEnumerable<dynamic> result = await _OracleDbManager.DapperExecuteQuery<dynamic>(query);
                return Ok(RespuestaHttp.BuildResponse(true, DefResponseMessage.DEF_SUCCESS, result));
            }
            catch (Exception ex)
            {
                return BadRequest(RespuestaHttp.BuildResponse(false, ex.Message));
            }
        }
        #endregion

        public async Task<ActionResult<RespuestaHttpTipado<List<RutaDto>>>> getRutas()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                IEnumerable<RutaDto> rutas = await _OracleDbManager.DapperExecuteQuery<RutaDto>(Queries.Queries.SEL_RUTAS);
                return Ok(RespuestaHttp.BuildResponse(true, DefResponseMessage.DEF_SUCCESS, rutas));
            }
            catch (Exception ex)
            {
                return BadRequest(RespuestaHttp.BuildResponse(false, ex.Message));
            }
        }

        public async Task<ActionResult<RespuestaHttpTipado<InfoRutaDto>>> getInfoRutaById(int ruta_id)
        {
            try
            {
                Dictionary<string, object> parametes = new Dictionary<string, object>();
                parametes.Add("ruta_id", ruta_id);
                InfoRutaDto? result = (await _OracleDbManager.DapperExecuteQuery<InfoRutaDto>(Queries.Queries.SEL_INFO_RUTA_BY_ID, parametes)).FirstOrDefault();
                return Ok(RespuestaHttp.BuildResponse(true, DefResponseMessage.DEF_SUCCESS, result));
            }
            catch (Exception ex)
            {
                return BadRequest(RespuestaHttp.BuildResponse(false, ex.Message));
            }
        }

        public async Task<ActionResult<RespuestaHttp>> getSucursales()
        {
            try
            {
                IEnumerable<object> result = await _OracleDbManager.DapperExecuteQuery<object>(Queries.Queries.SEL_SUCURSALES);
                return Ok(RespuestaHttp.BuildResponse(true, DefResponseMessage.DEF_SUCCESS, result));
            }
            catch (Exception ex)
            {
                return BadRequest(RespuestaHttp.BuildResponse(false, ex.Message));
            }
        }

        public async Task<ActionResult<RespuestaHttp>> post(RutaDto rutaDto)
        {
            try
            {
                var parameters = new Dictionary<string, object>
                    {
                        {"TRANSPORTE_ID", rutaDto.TRANSPORTE_ID},
                        {"DESCRIPCION", rutaDto.DESCRIPCION},
                        {"DISTANCIA", rutaDto.DISTANCIA},
                        {"TIEMPO_ESTIMADO", rutaDto.TIEMPO_ESTIMADO}
                    };

                await _OracleDbManager.DapperExecuteQuery<int>(Queries.Queries.INS_RUTA, parameters);

                return Ok(RespuestaHttp.BuildResponse(true, "Ruta agregada exitosamente."));
            }
            catch (Exception ex)
            {
                return BadRequest(RespuestaHttp.BuildResponse(false, ex.Message));
            }
        }

        public async Task insPedidoDet(int PedidoId, List<PedidoDetalleDto> pedidoDetalleDto, IDbTransaction transaccion)
        {
            foreach (var pedido in pedidoDetalleDto)
            {
                var parameters = new Dictionary<string, object>
                    {
                        {"PEDIDO_ID", PedidoId},
                        {"CANTIDAD", pedido.CANTIDAD},
                        {"PRODUCTO_ID", pedido.PRODUCTO_ID}
                    };
                int queda = (await _OracleDbManager.DapperExecuteQuery<int>("select STOCK_ACTUAL-:cantidad quedaria from producto WHERE producto_id = :PRODUCTO_ID"
                    , parameters)).FirstOrDefault();
                if (queda < 0)
                {
                    throw new InvalidOperationException("El stock no puede ser negativo.");
                }

                await _OracleDbManager.DapperExecuteQuery<int>("UPDATE producto SET STOCK_ACTUAL = STOCK_ACTUAL-:cantidad WHERE producto_id=:PRODUCTO_ID"
                    , parameters, transaccion);
                await _OracleDbManager.DapperExecuteQuery<int>(Queries.Queries.INS_DET_PEDIDO, parameters, transaccion);
            }

        }

        public async Task<ActionResult<RespuestaHttp>> setProducto(ProductoDto productoDto)
        {
            try
            {
                var parametersProducto = new Dictionary<string, object>
            {
                {"RECETA_ID", productoDto.RECETA_ID},
                {"NOMBRE", productoDto.NOMBRE},
                {"DESCRIPCION", productoDto.DESCRIPCION},
                {"SUCURSAL_ID", productoDto.SUCURSAL_ID},
                {"PRECIO", productoDto.PRECIO},
                {"IMAGEN", productoDto.IMAGEN},
                {"STOCK_ORIGINAL", productoDto.STOCK_ORIGINAL},
                {"STOCK_ACTUAL", productoDto.STOCK_ACTUAL}
            };

                await _OracleDbManager.DapperExecuteQuery<dynamic>(Queries.Queries.INS_PRODUCTO, parametersProducto);
                return Ok(RespuestaHttp.BuildResponse(true, "Producto agregado exitosamente."));
            }
            catch (Exception ex)
            {
                return BadRequest(RespuestaHttp.BuildResponse(false, "Error al insertar el producto: " + ex.Message));
            }
        }



        public async Task<ActionResult<RespuestaHttp>> post(PedidoDto pedidoDto, List<PedidoDetalleDto> pedidoDetalleDto)
        {
            IDbTransaction transaccion = _OracleDbManager.BeginTransaction(_OracleDbManager.GetConnection());
            try
            {
                var parameters = new DynamicParameters(new Dictionary<string, object>
                {
                    {"CANTIDAD_SOLICITADA", pedidoDto.CANTIDAD_SOLICITADA},
                    {"FECHA_PEDIDO", pedidoDto.FECHA_PEDIDO},
                    {"USUARIO_ID", _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value},
                    {"RUTA_ID", pedidoDto.RUTA_ID},
                });
                parameters.Add("PedidoIdRetornado", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await _OracleDbManager.DapperExecuteInsertReturn(Queries.Queries.INS_PEDIDO, parameters, transaccion);
                int pedidoId = parameters.Get<int>("PedidoIdRetornado");
                await insPedidoDet(pedidoId, pedidoDetalleDto, transaccion);
                _OracleDbManager.CommitTransaction(transaccion);
                return Ok(RespuestaHttp.BuildResponse(true, $"Pedido {pedidoId} agregado exitosamente.", new { pedidoId }));
            }
            catch (Exception ex)
            {
                _OracleDbManager.RollbackTransaction(transaccion);
                return BadRequest(RespuestaHttp.BuildResponse(false, ex.Message));
            }
        }

        #region inserts
        public async Task<ActionResult<RespuestaHttp>> setRecetaYDetalles(RecetaDto recetaDto)
        {
            IDbTransaction transaccion = _OracleDbManager.BeginTransaction(_OracleDbManager.GetConnection());

            try
            {
                var parametersReceta = new DynamicParameters(new Dictionary<string, object>
                    {
                        {"NOMBRE", recetaDto.NOMBRE},
                        {"DESCRIPCION", recetaDto.DESCRIPCION}
                    });

                parametersReceta.Add("RecetaIdRetornado", dbType: DbType.Int32, direction: ParameterDirection.Output);

                await _OracleDbManager.DapperExecuteInsertReturn(Queries.Queries.INS_RECETA, parametersReceta, transaccion);

                int recetaId = parametersReceta.Get<int>("RecetaIdRetornado");

                foreach (var detalle in recetaDto.DetallesReceta)
                {
                    var parametersDetalle = new Dictionary<string, object>
                        {
                            {"RECETA_ID", recetaId},
                            {"INGREDIENTE_ID", detalle.INGREDIENTE_ID},
                            {"CANTIDAD_NECESARIA", detalle.CANTIDAD_NECESARIA},
                            {"UNIDAD_MEDIDA_ID", detalle.UNIDAD_MEDIDA_ID}
                        };

                    await _OracleDbManager.DapperExecuteQuery<int>(Queries.Queries.INS_RECETA_DETALLE, parametersDetalle, transaccion);
                }

                _OracleDbManager.CommitTransaction(transaccion);

                return Ok(RespuestaHttp.BuildResponse(true, "Receta agregada exitosamente."));
            }
            catch (Exception ex)
            {
                _OracleDbManager.RollbackTransaction(transaccion);
                return BadRequest(RespuestaHttp.BuildResponse(false, "Error al insertar la receta: " + ex.Message));
            }
        }
        #endregion

        #region selects

        public async Task<ActionResult<RespuestaHttp>> getRecetaDetalles()
        {
            return await ExecuteGenericQuery("Select * from RECETA_DETALLE");
        }

        public async Task<ActionResult<RespuestaHttp>> getUsuarios()
        {
            return await ExecuteGenericQuery("Select * from USUARIO");
        }

        public async Task<ActionResult<RespuestaHttp>> getTurnos()
        {
            return await ExecuteGenericQuery("Select * from TURNO");
        }

        public async Task<ActionResult<RespuestaHttp>> getTransportes()
        {
            return await ExecuteGenericQuery("Select * from TRANSPORTE");
        }

        public async Task<ActionResult<RespuestaHttp>> getStatus()
        {
            return await ExecuteGenericQuery("Select * from STATUS");
        }

        public async Task<ActionResult<RespuestaHttp>> getRolTipos()
        {
            return await ExecuteGenericQuery("Select * from ROL_TIPO");
        }

        public async Task<ActionResult<RespuestaHttp>> getMiniSistems()
        {
            return await ExecuteGenericQuery("Select * from MINI_SISTEM");
        }

        public async Task<ActionResult<RespuestaHttp>> getFacturaDetalles()
        {
            return await ExecuteGenericQuery("Select * from FACTURA_DETALLE");
        }

        public async Task<ActionResult<RespuestaHttp>> getFacturas()
        {
            return await ExecuteGenericQuery("Select * from FACTURA");
        }

        public async Task<ActionResult<RespuestaHttp>> getProductos()
        {
            return await ExecuteGenericQuery("Select * from producto");
        }

        public async Task<ActionResult<RespuestaHttp>> GetPedidos()
        {
            return await ExecuteGenericQuery("Select * from pedido");
        }
        

        public async Task<ActionResult<RespuestaHttp>> getUnidadesMedida()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                IEnumerable<object> result = await _OracleDbManager.DapperExecuteQuery<object>(Queries.Queries.SEL_UNIDADES_MEDIDA);
                return Ok(RespuestaHttp.BuildResponse(true, DefResponseMessage.DEF_SUCCESS, result));
            }
            catch (Exception ex)
            {
                return BadRequest(RespuestaHttp.BuildResponse(false, ex.Message));
            }
        }

        public async Task<ActionResult<RespuestaHttp>> getIngredientes()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                IEnumerable<object> result = await _OracleDbManager.DapperExecuteQuery<object>(Queries.Queries.SEL_INGREDIENTES);
                return Ok(RespuestaHttp.BuildResponse(true, DefResponseMessage.DEF_SUCCESS, result));
            }
            catch (Exception ex)
            {
                return BadRequest(RespuestaHttp.BuildResponse(false, ex.Message));
            }
        }

        public async Task<ActionResult<RespuestaHttp>> getPedidoYDetalles()
        {
            try
            {
                return Ok(RespuestaHttp.BuildResponse(true, DefResponseMessage.DEF_SUCCESS, await _OracleDbManager.DapperExecuteQuery<object>(Queries.Queries.SEL_PEDIDOS_Y_DETS)));
            }
            catch (Exception ex)
            {
                return BadRequest(RespuestaHttp.BuildResponse(false, ex.Message));
            }
        }

        public async Task<ActionResult<RespuestaHttp>> getProductosByTienda(int sucursal_id)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("sucursal_id", sucursal_id);
                IEnumerable<object> result = await _OracleDbManager.DapperExecuteQuery<object>(Queries.Queries.SEL_PRODUCTOS_BY_TIENDA, parameters);
                return Ok(RespuestaHttp.BuildResponse(true, DefResponseMessage.DEF_SUCCESS, result));
            }
            catch (Exception ex)
            {
                return BadRequest(RespuestaHttp.BuildResponse(false, ex.Message));
            }
        }

        public async Task<ActionResult<RespuestaHttp>> getRecetaAndDetById(int receta_id)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("receta_id", receta_id);
                IEnumerable<dynamic> result = await _OracleDbManager.DapperExecuteQuery<dynamic>(Queries.Queries.SEL_RECETA_AND_DET_BY_ID, parameters);
                //if (result.Any(r => r.STOCK_ACTUAL == 0))
                //{
                //    return BadRequest(RespuestaHttp.BuildResponse(false, "STOCK_ACTUAL es cero en uno o más ingredientes."));
                //}
                return Ok(RespuestaHttp.BuildResponse(true, DefResponseMessage.DEF_SUCCESS, result));
            }
            catch (Exception ex)
            {
                return BadRequest(RespuestaHttp.BuildResponse(false, ex.Message));
            }
        }

        public async Task<ActionResult<RespuestaHttp>> getRecetas()
        {
            try
            {
                IEnumerable<dynamic> result = await _OracleDbManager.DapperExecuteQuery<dynamic>(Queries.Queries.SEL_RECETAS);
                return Ok(RespuestaHttp.BuildResponse(true, DefResponseMessage.DEF_SUCCESS, result));
            }
            catch (Exception ex)
            {
                return BadRequest(RespuestaHttp.BuildResponse(false, ex.Message));
            }
        }

        public async Task<ActionResult<RespuestaHttp>> getRecetaDetByIdRec(int receta_id)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("receta_id", receta_id);
                IEnumerable<dynamic> result = await _OracleDbManager.DapperExecuteQuery<dynamic>(Queries.Queries.SEL_RECETA_DET_BY_ID, parameters);
                return Ok(RespuestaHttp.BuildResponse(true, DefResponseMessage.DEF_SUCCESS, result));
            }
            catch (Exception ex)
            {
                return BadRequest(RespuestaHttp.BuildResponse(false, ex.Message));
            }
        }

        #endregion
    }
}
