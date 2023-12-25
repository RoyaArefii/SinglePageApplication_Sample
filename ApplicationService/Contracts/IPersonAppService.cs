using SinglePageApplication.ApplicationService.Contracts.IApplicationService;
using SinglePageApplication.ApplicationService.Dtos.PersonDtos;
using SinglePageApplication.Models.DomainModels;

namespace SinglePageApplication.ApplicationService.Contracts
{
    public interface IPersonAppService : IApplicationService<Person, InsertPersonAppDto, SelectPersonAppDto, UpdatePersonAppDto, DeletePersonAppDto>
    {
    }
}
