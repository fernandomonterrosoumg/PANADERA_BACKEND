using ApiNetCore7.Helpers;
using ApiNetCore7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace ApiNetCore7.Handler
{
    public class UsuarioHandler : ControllerBase
    {
        private readonly OracleDbManager _OracleDbManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UsuarioHandler(OracleDbManager oracleDbManager, IHttpContextAccessor httpContextAccessor)
        {
            _OracleDbManager = oracleDbManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<RespuestaHttp> GetUsuarioConRol()
        {
            RespuestaHttp response = null;
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                IEnumerable<UsuarioConRolDto> usuarios = await _OracleDbManager.DapperExecuteQuery<UsuarioConRolDto>(Queries.Queries.SEL_USERS_AND_ROL, parameters);

                response = RespuestaHttp.BuildResponse(true, DefResponseMessage.DEF_SUCCESS, usuarios);
            }
            catch (Exception ex)
            {
                response = RespuestaHttp.BuildResponse(false, ex.Message);
            }
            return response;
        }

        

        public async Task<ActionResult<RespuestaHttp>> LoginYGenerarToken(string nombreUsuario, string contrasena)
        {
            RespuestaHttp response = null;
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {":nombreUsuario", nombreUsuario},
                    {":contrasena", contrasena}
                };

                UsuarioConRolDto usuario = (await _OracleDbManager.DapperExecuteQuery<UsuarioConRolDto>(Queries.Queries.SEL_LOGIN, parameters)).FirstOrDefault();
                if (usuario != null)
                {
                    string token = GenerarToken(usuario);

                    response = new RespuestaHttp(
                        true,
                        DefResponseMessage.DEF_SUCCESS,
                        new { usuario = usuario, token = token }
                    );
                    return Ok(response);
                }
                else
                {
                    response = new RespuestaHttp(
                        false,
                        "Credenciales inválidas",
                        null
                    );
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response = new RespuestaHttp(
                    false,
                    ex.Message,
                    null
                );
                return StatusCode(500, response);
            }
        }

        private string GenerarToken(UsuarioConRolDto usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("asdv234234^&%&^%&^hjsdfb2%%%safwefwef"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.USUARIO_ID.ToString()),
                    new Claim(ClaimTypes.Name, usuario.Usuario),
                    new Claim("rol", usuario.ROL_TIPO_ID.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}
