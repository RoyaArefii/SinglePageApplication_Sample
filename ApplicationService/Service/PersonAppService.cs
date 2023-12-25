using SinglePageApplication.ApplicationService.Contracts;
using SinglePageApplication.ApplicationService.Dtos.PersonDtos;
using SinglePageApplication.Models.Contracts;
using SinglePageApplication.Models.DomainModels;

namespace SinglePageApplication.ApplicationService.Service
{
    public class PersonAppService:IPersonAppService
    {
        #region [-Cttor-]
        private readonly IPersonRepository _personRepository;

        public PersonAppService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        #endregion

        #region[-Delete(DeleteServiceDto deleteServiceDto) -]   
        public async Task Delete(DeletePersonAppDto deleteServiceDto)
        {
            var deletedPerson = await _personRepository.SelectById(deleteServiceDto.Id);

            await _personRepository.Delete(deletedPerson);
        }
        #endregion

        #region [-Insert(InsertServiceDto insertServiceDto)-]
        public async Task Insert(InsertPersonAppDto insertServiceDto)
        {
            var insertPerson = new Person
            {
                Id = insertServiceDto.Id,
                FName = insertServiceDto.FName,
                LName = insertServiceDto.LName
            };
            await _personRepository.Insert(insertPerson);
        }
        #endregion

        #region [-Save()-]
        public async Task Save()
        {
            await _personRepository.Save();
        }
        #endregion

        #region [-Task<IEnumerable<SelectPersonAppDto>> Select()-]
        public async Task<IEnumerable<SelectPersonAppDto>> Select()
        {
            var persons = await _personRepository.Select();
            var selectPersonDtos = new List<SelectPersonAppDto>();
            foreach (var person in persons)
            {
                var selectPerson = new SelectPersonAppDto
                {
                    Id = person.Id,
                    FName = person.FName,
                    LName = person.LName
                };
                selectPersonDtos.Add(selectPerson);
            };
            return selectPersonDtos;
        }
        #endregion

        #region [-SelectById(Guid id)-]
        public async Task<SelectPersonAppDto> SelectById(Guid id)
        {
            var selectPerson = await _personRepository.SelectById(id);
            SelectPersonAppDto selectServiceDto = new SelectPersonAppDto()
            {
                Id = selectPerson.Id,
                FName = selectPerson.FName,
                LName = selectPerson.LName,

            };
            return selectServiceDto;
        }
        #endregion

        #region [-Update(UpdateServiceDto updateServiceDto)-]
        public async Task Update(UpdatePersonAppDto updateServiceDto)
        {
            var updatePerson = await _personRepository.SelectById(updateServiceDto.Id);
            updatePerson.Id = updateServiceDto.Id;
            updatePerson.FName = updateServiceDto.FName;
            updatePerson.LName = updateServiceDto.LName;

            await _personRepository.Update(updatePerson);
        }
        #endregion
    }
}
