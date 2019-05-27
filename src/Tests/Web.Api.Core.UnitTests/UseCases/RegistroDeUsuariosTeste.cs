using System.Threading.Tasks;
using Moq;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Dto.GatewayResponses.Repositories;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Core.UseCases;
using Xunit;

namespace Web.Api.Core.UnitTests.UseCases
{
  public class RegistroDeUsuariosTeste
  {

    [Fact]
    public async void Pode_Registrar_Usuario()
    {
      // arrange

      
      var mockUserRepository = new Mock<IUserRepository>();
      mockUserRepository
        .Setup(repo => repo.Create(It.IsAny<User>(), It.IsAny<string>()))
        .Returns(Task.FromResult(new CreateUserResponse("", true)));

      
      var useCase = new RegisterUserUseCase(mockUserRepository.Object);

      var mockOutputPort = new Mock<IOutputPort<RegisterUserResponse>>();
      mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<RegisterUserResponse>()));

      // act

      
      var response = await useCase.Handle(new RegisterUserRequest(string.Empty, "Rossano", "Sousa", "me@domain.com", "rubens_nc", "123456789"), mockOutputPort.Object);

      // assert
      Assert.True(response);
    }
  }
}
