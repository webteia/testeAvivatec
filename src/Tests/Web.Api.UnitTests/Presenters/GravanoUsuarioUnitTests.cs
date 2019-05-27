using System.Net;
using Newtonsoft.Json;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Presenters;
using Xunit;

namespace Web.Api.UnitTests.Presenters
{
    public class GravanoUsuarioUnitTests
    {
        [Fact]
        public void Contem_Ok_Status_Code_Se_Sucesso()
        {
            // arrange
            var presenter = new RegisterUserPresenter();

            // act
            presenter.Handle(new RegisterUserResponse("", true));

            // assert
            Assert.Equal((int)HttpStatusCode.OK,presenter.ContentResult.StatusCode);
        }

        [Fact]
        public void Contem_Id_Quando_Use_Case_Sucess()
        {
            // arrange
            var presenter = new RegisterUserPresenter();

            // act
            presenter.Handle(new RegisterUserResponse("1234", true));

            // assert
            dynamic data = JsonConvert.DeserializeObject(presenter.ContentResult.Content);
            Assert.True(data.success.Value);
            Assert.Equal("1234",data.id.Value);
        }

        [Fact]
        public void Contem_Error_Quando_Use_Case_Falhar()
        {
            // arrange
            var presenter = new RegisterUserPresenter();

            // act
            presenter.Handle(new RegisterUserResponse(new [] {"faltando primeiro nome"}));

            // assert
            dynamic data = JsonConvert.DeserializeObject(presenter.ContentResult.Content);
            Assert.False(data.success.Value);
            Assert.Equal("faltando primeiro nome", data.errors.First.Value);
        }
    }
}
