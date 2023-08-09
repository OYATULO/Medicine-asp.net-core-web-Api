using Medicine.API.Services.IData;
using Medicine.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medicine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatients Ipatient;
        private readonly IForDynamicData forDynamicData;
        public PatientsController(IPatients patients,IForDynamicData forDynamic) { 
            Ipatient = patients;
            forDynamicData = forDynamic;
        }
        // GET: api/<PatientsController>
        [HttpGet]
        public async Task<IEnumerable<Patients>> Get() => await Ipatient.GetAllPattients();

        [HttpGet("{Name}")]
        public async Task<IEnumerable<Patients>> GetlistByName(string Name) => await Ipatient.GetListByName(Name);

        [HttpGet("{Id:int}")]
        public async Task<Patients> GetlistByName(int Id) => await Ipatient.GetListById(Id);

        [HttpGet("Pages")]
        public async Task<IEnumerable<Patients>> GetlistByPage(int page, int limit) => await Ipatient.GetListByPage(page, limit);

        [HttpPost]
        public async Task<IActionResult> InsertNew(Patients data) => await Ipatient.Insert(data) ? Ok("Успешно добавлено") : BadRequest("Ошибка");

        [HttpPut]
        public async Task<IActionResult> Update(Patients data) => await Ipatient.Update(data) ? Ok("Успешно обновлено") : BadRequest("Ошибка");

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id) => await Ipatient.Delete(Id) ? Ok("Успешно удалено") : BadRequest("Ошибка");

        [HttpGet("district")]
        public async Task<IEnumerable<District>> GetDistrict() => await forDynamicData.GetAllData(new District());
    }
}
