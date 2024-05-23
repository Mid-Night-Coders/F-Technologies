using FTech.Application.DataTransferObjects.Cars;
using FTech.Infrastructure.Services.Cars;
using Microsoft.AspNetCore.Mvc;

namespace FTech.Presentation.Controllers.Cars;

public class CarController : BaseController
{
    private readonly ICarService carService;

    public CarController(ICarService carService)
    {
        this.carService = carService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromForm]CarForCreationDTO dto)
        => Ok(await carService.CreateAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
        => Ok(await carService.GetAllAsync());
     
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute(Name ="id")]long id)
        => Ok(await carService.GetByIdAsync(id));

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync([FromRoute(Name = "id")]long id)
        =>Ok(await carService.DeleteAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> ModifyAsync([FromRoute(Name = "id")]long id, [FromForm] CarForCreationDTO dto)
        => Ok(await carService.UpdateAsync(id, dto));

}
