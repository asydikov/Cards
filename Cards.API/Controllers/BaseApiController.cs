using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Cards.Core.Helpers;
using Cards.Core.Models;
using Cards.Core.Models.OkResponses;
using Cards.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Cards.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public abstract class BaseApiController<TModel, TService> : ControllerBase
   where TModel : ModelBase
   where TService : IServiceBase<TModel>
    {
        protected TService Service { get; private set; }
        public BaseApiController(TService service)
        {
            Service = service;
        }

        protected void SetUserId()
        {
            JwtSecurityTokenHandler jwt = new JwtSecurityTokenHandler();
            Service.UserId = Guid.Empty;
            string token = string.Empty;
            if (Request != null && Request.Headers != null && Request.Headers.ContainsKey("Authorization"))
            {
                token = Request.Headers["Authorization"];
            }
            if (!string.IsNullOrEmpty(token))
            {
                token = token.Replace("Bearer", "").Trim();
            }
            if (jwt.CanReadToken(token))
            {
                JwtSecurityToken jwtSecurityToken = jwt.ReadJwtToken(token);
                Service.UserId = Guid.Parse(jwtSecurityToken.Subject);
            }
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            if (Service == null)
            {
                throw new CardException();
            }
            SetUserId();
            var result = await Service.GetAllAsync();
            return Ok(new OkResponse<TModel>()
            {
                Entities = result
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (Service == null)
            {
                throw new CardException();
            }
            SetUserId();
            var result = await Service.GetAsync(id);
            return Ok(new OkResponse<TModel>()
            {
                Entity = result
            });
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] TModel model)
        {
            if (Service == null)
            {
                throw new CardException();
            }
            SetUserId();
            Guid EntityId = await Service.CreateAsync(model);
            return Ok(new OkResponse<TModel>(EntityId));
        }

        [HttpPut("")]
        public async Task<IActionResult> Put([FromBody] TModel model)
        {
            if (Service == null)
            {
                throw new CardException();
            }
            SetUserId();
            await Service.UpdateAsync(model);
            return Ok(new OkResponse<TModel>(HttpStatusCode.OK.ToString()));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (Service == null)
            {
                throw new CardException();
            }
            SetUserId();
            await Service.DeleteEntityAsync(id);
            return Ok(new OkResponse<TModel>(HttpStatusCode.OK.ToString()));
        }

        protected T GetService<T>()
        {
            return (T)HttpContext.RequestServices.GetService(typeof(T));
        }
    }
}