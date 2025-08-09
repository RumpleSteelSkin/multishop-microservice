using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controller;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoOperationsController(ICargoOperationService cargoOperationService) : ControllerBase
{
    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        List<GetAllCargoOperationDto> getAllCargoOperationDtos = [];
        getAllCargoOperationDtos.AddRange(cargoOperationService.GetAll()
            .Select(value => new GetAllCargoOperationDto
            {
                Id = value.Id, Barcode = value.Barcode, Description = value.Description,
                OperationDate = value.OperationDate,
            }));
        return Ok(getAllCargoOperationDtos);
    }

    [HttpGet("GetById/{id}")]
    public IActionResult GetById(int id)
    {
        var value = cargoOperationService.GetById(id);
        GetByIdCargoOperationDto getByIdCargoOperationDto = new()
        {
            Barcode = value.Barcode, Description = value.Description, OperationDate = value.OperationDate,
        };
        return Ok(getByIdCargoOperationDto);
    }

    [HttpPost("Create")]
    public IActionResult Create([FromBody] CreateCargoOperationDto value)
    {
        CargoOperation cargoOperation = new()
        {
            Barcode = value.Barcode, Description = value.Description, OperationDate = value.OperationDate,
        };
        cargoOperationService.Insert(cargoOperation);
        return Ok("Cargo operation created");
    }

    [HttpDelete("Delete/{id}")]
    public IActionResult Delete(int id)
    {
        cargoOperationService.Delete(id);
        return Ok("Cargo operation deleted");
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] UpdateCargoOperationDto value)
    {
        CargoOperation cargoOperation = new()
        {
            Id = value.Id, Barcode = value.Barcode, Description = value.Description,
            OperationDate = value.OperationDate,
        };
        cargoOperationService.Update(cargoOperation);
        return Ok("Cargo operation updated");
    }
}