using Medicine.API.Services.Data;
using Medicine.API.Services.IData;
using Medicine.Models;
using Microsoft.AspNetCore.Mvc;
using NPOI.POIFS.Crypt.Dsig;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medicine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctors IDoctors;
        private readonly IForDynamicData dynamicData;
        public DoctorController(IDoctors idata, IForDynamicData dynamicData)
        {
            IDoctors = idata;
            this.dynamicData = dynamicData;
        }

        [HttpGet]
        public async Task<IEnumerable<Doctors>> Get() => await IDoctors.GetListDoctors();

        [HttpGet("{Name}")]
        public async Task<IEnumerable<Doctors>> GetlistByName(string Name) => await IDoctors.GetListByName(Name);

        [HttpGet("{Id:int}")]
        public async Task<Doctors> GetlistByName(int Id) => await IDoctors.GetListById(Id);

        [HttpGet("Pages")]
        public async Task<IEnumerable<Doctors>> GetlistByPage(int page, int limit) => await IDoctors.GetListByPage(page, limit);
        
        [HttpPost]
        public async Task<IActionResult> InsertNew(Doctors data) => await IDoctors.Insert(data) ? Ok("Успешно добавлено") : BadRequest("Ошибка");
         
        [HttpPut]
        public async Task<IActionResult> Update(Doctors data) => await IDoctors.Update(data) ? Ok("Успешно обновлено") : BadRequest("Ошибка");

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id) => await IDoctors.Delete(Id) ? Ok("Успешно удалено") : BadRequest("Ошибка");

        [HttpGet("district")]
        public async Task<IEnumerable<District>> GetDistrict() => await dynamicData.GetAllData(new District());

        [HttpGet("Cabinet")]
        public async Task<IEnumerable<Cabinet>> GetCabinet() => await dynamicData.GetAllData(new Cabinet());

        [HttpGet("Specialization")]
        public async Task<IEnumerable<Specialization>> GetSpecialization() => await dynamicData.GetAllData(new Specialization());

    }
}
