using Microsoft.AspNetCore.Mvc;
using SinglePageApplication.ApplicationService.Contracts;
using SinglePageApplication.ApplicationService.Dtos.PersonDtos;
using SinglePageApplication.Controllers.Dtos.PersonDtos;
using System.Text.Json;

namespace SinglePageApplication.Controllers
{
    public class PersonController : Controller
    {
        #region [-Ctor-]
        private readonly IPersonAppService _personAppService;

        public PersonController(IPersonAppService personAppService)
        {
            _personAppService = personAppService;
        }
        #endregion

        #region [-Index()-]
        public async Task<IActionResult> Index()// خروجی متد استاد async نیست ولی JsonResult است !!!!!
        {
            var persons = await _personAppService.Select();
            var selectPersonDtos = new List<SelectPersonDto>();
            foreach (var person in persons)
            {
                var selectPersonDto = new SelectPersonDto
                {
                    Id = person.Id,
                    FName = person.FName,
                    LName = person.LName,
                };
                selectPersonDtos.Add(selectPersonDto);
            }
            return View(selectPersonDtos);
            //return Json(new { data = selectPersonDtos });// ,return Json(new { data = result },JsonRequestBehavior.AllowGet------.net befor core);
        }
        #endregion

        #region [Get_Delete(Guid id)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var person = await _personAppService.SelectById(id);
            var deletePersonDto = new DeletePersonDto
            {
                Id = person.Id,
                FName = person.FName,
                LName = person.LName,
            };
            return View(deletePersonDto);
            //await _personAppService.Delete(person);
        }
        #endregion

        #region [-Post_Delete(DeletePersonDto deletePersonDto)-]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeletePersonDto deletePersonDto)
        {
            var person = await _personAppService.SelectById(deletePersonDto.Id);
            var deleteServiecDto = new DeletePersonAppDto
            {
                Id = person.Id,
                FName = person.FName,
                LName = person.LName,
            };
            await _personAppService.Delete(deleteServiecDto);
            //await _personAppService.Save();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region[-Post_Create(InsertPersonDto insertPersonDto) -]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InsertPersonDto insertPersonDto)
        {
            if (ModelState.IsValid)
            {
                var person = new InsertPersonAppDto()
                {
                    Id = new Guid(),
                    FName = insertPersonDto.FName,
                    LName = insertPersonDto.LName
                };
                if (insertPersonDto == null)
                {
                    return NotFound();
                }
                await _personAppService.Insert(person);
                return RedirectToAction(nameof(Index));
            }
            return View(insertPersonDto);
        }
        #endregion

        #region[-Get_Create(InsertPersonDto insertPersonDto) -]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        #endregion

        #region [-Post_Edit(UpdatePersonDto updatePersonDto)-]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdatePersonDto updatePersonDto)
        {

            if (ModelState.IsValid)
            {

                var person = new UpdatePersonAppDto()
                {
                    Id = updatePersonDto.Id,
                    FName = updatePersonDto.FName,
                    LName = updatePersonDto.LName
                };
                if (person == null)
                {
                    return NotFound();
                }
                await _personAppService.Update(person);
                return RedirectToAction("Index");

            }
            // await _personAppService.Save();// dont required in this layer because savechanges in repository will be check
            return View(updatePersonDto);
        }
        #endregion

        #region[-Get_Edit(UpdatePersonDto updatePersonDto)-]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var person = await _personAppService.SelectById(id);
            if (id == null || person == null)
            {
                return NotFound();
            }
            var updatePersonDto = new UpdatePersonDto
            {
                Id = person.Id,
                FName = person.FName,
                LName = person.LName
            };

            return View(updatePersonDto);
        }
        #endregion

        #region [-Details(Guid id)-]
        public async Task<IActionResult> Details(Guid id)
        {
            if (_personAppService is null) return Problem("Entity set 'TrainingProjectDbContext.Person' is null.");

            var person = await _personAppService.SelectById(id);
            if (person is not null)
            {
                var selectPersonDto = new SelectPersonDto
                {
                    Id = person.Id,
                    FName = person.FName,
                    LName = person.LName,
                };
                return View(selectPersonDto);
            }
            TempData["Index"] = "User not found";
            return RedirectToAction(nameof(Index));
        }
    }

    #endregion
}
