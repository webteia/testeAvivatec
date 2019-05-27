using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Interfaces.UseCases;
using Web.Api.Presenters;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IRegisterUserUseCase _registerUserUseCase;
        private readonly RegisterUserPresenter _registerUserPresenter;

        private readonly ILoginUseCase _loginUseCase;
        private readonly LoginPresenter _loginPresenter;

        public AccountsController(IRegisterUserUseCase registerUserUseCase, RegisterUserPresenter registerUserPresenter, ILoginUseCase loginUseCase, LoginPresenter loginPresenter)
        {
            _registerUserUseCase = registerUserUseCase;
            _registerUserPresenter = registerUserPresenter;

            _loginUseCase = loginUseCase;
            _loginPresenter = loginPresenter;
        }

        // POST api/accounts
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Models.Request.RegisterUserRequest request)
        {
            if (!ModelState.IsValid)
            { // Quando model for inválido
                return BadRequest(ModelState);
            }
            await _registerUserUseCase.Handle(new RegisterUserRequest(request.Id, request.FirstName, request.LastName, request.Email, request.UserName,request.Password), _registerUserPresenter);
            return _registerUserPresenter.ContentResult;
        }

        // Get api/accounts
        [HttpGet]
        public async Task<ActionResult> GetAll([FromBody] Models.Request.LoginRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _loginUseCase.Handle(new LoginRequest(request.UserName, request.Password), _loginPresenter);
            if (_loginPresenter.ContentResult.StatusCode == (int)HttpStatusCode.OK)
            {
                return Ok(_registerUserUseCase.GetAll());
            }
            else
                return Unauthorized();
        }

        // Update api/accounts
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Models.Request.RegisterUserRequest request)
        {
            if (!ModelState.IsValid)
            { // Quando model for inválido
                return BadRequest(ModelState);
            }
            await _registerUserUseCase.UpdateHandle(new RegisterUserRequest(request.Id, request.FirstName, request.LastName, request.Email, request.UserName, request.Password), _registerUserPresenter);
            return _registerUserPresenter.ContentResult;
        }

        // Update api/accounts
        [HttpDelete]
        public async Task<ActionResult> Delete(string Id)
        {            
            var returning = await _registerUserUseCase.Delete(Id);
            return Ok(returning);
        }
    }
}
