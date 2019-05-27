using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Dto.GatewayResponses.Repositories;

namespace Web.Api.Core.Interfaces.Gateways.Repositories
{
    public interface IUserRepository
    {
        Task<CreateUserResponse> Create(User user, string password);
        Task<CreateUserResponse> UpDate(User user, string password);
        Task<CreateUserResponse> Delete(string id);
        IEnumerable<User> GetAll();
        Task<User> FindById(string userId);
        Task<User> FindByName(string userName);
        Task<bool> CheckPassword(User user, string password);
    }
}
