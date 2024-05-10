using Booking.BLL.Interfaces;
using Booking.BLL.Models;
using Booking.WebAPI.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Booking.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApartamentController : ControllerBase
    {
        private readonly IApartamentService _apartamentService;

        public ApartamentController(IApartamentService apartamentService)
        {
            _apartamentService = apartamentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApartamentModel>>> Get()
        { 
            var apartaments = await _apartamentService.GetAllAsync();

            return Ok(apartaments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApartamentModel>> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Apartament id cant be empty");
            }

            var apartament = await _apartamentService.GetByIdAsync(id);

            return Ok(apartament);
        }

        [HttpPost]
        public async Task<ActionResult<ApartamentModel>> Create(ApartamentModel model)
        {
            string errors = Validator.Apartament(model);

            if (!string.IsNullOrEmpty(errors))
            {
                return BadRequest(errors);
            }

            var apartament = await _apartamentService.AddAsync(model);

            return Ok(apartament);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest("Apartament id cant be empty");
            }

            await _apartamentService.DeleteAsync(id);

            return Ok();
        }

        [HttpPatch]
        public async Task<ActionResult<ApartamentModel>> Update(ApartamentModel model)
        {
            string errors = Validator.Apartament(model);

            if (!string.IsNullOrEmpty(errors))
            {
                return BadRequest(errors);
            }

            var apartament = await _apartamentService.UpdateAsync(model);

            return Ok(apartament);
        }
    }
}
