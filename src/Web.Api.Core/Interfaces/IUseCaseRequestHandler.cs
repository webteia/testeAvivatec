using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Api.Core.Domain.Entities;

namespace Web.Api.Core.Interfaces
{
    public interface IUseCaseRequestHandler<in TUseCaseRequest, out TUseCaseResponse> where TUseCaseRequest : IUseCaseRequest<TUseCaseResponse>
    {
        Task<bool> Handle(TUseCaseRequest message, IOutputPort<TUseCaseResponse> outputPort);
        Task<bool> UpdateHandle(TUseCaseRequest message, IOutputPort<TUseCaseResponse> outputPort);
        IEnumerable<User> GetAll();
        Task<bool> Delete(string Id);
        Task<User> FindById(string userId);
    }
}
