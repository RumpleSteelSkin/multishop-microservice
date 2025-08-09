using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controller;

[Route("api/[controller]")]
[ApiController]
public class CargoDetailsController(ICargoDetailService cargoDetailService) : ControllerBase
{
    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        List<GetAllCargoDetailDto> getAllCargoDetailDtos = [];
        getAllCargoDetailDtos.AddRange(cargoDetailService.GetAll()
            .Select(value => new GetAllCargoDetailDto
            {
                Id = value.Id, Barcode = value.Barcode, CargoCompanyId = value.CargoCompanyId,
                ReceiverCustomer = value.ReceiverCustomer, SenderCustomer = value.SenderCustomer,
            }));
        return Ok(getAllCargoDetailDtos);
    }

    [HttpGet("GetById/{id}")]
    public IActionResult GetById(int id)
    {
        var value = cargoDetailService.GetById(id);
        GetByIdCargoDetailDto getByIdCargoDetailDto = new()
        {
            Barcode = value.Barcode, CargoCompanyId = value.CargoCompanyId,
            ReceiverCustomer = value.ReceiverCustomer, SenderCustomer = value.SenderCustomer,
        };
        return Ok(getByIdCargoDetailDto);
    }

    [HttpPost("Create")]
    public IActionResult Create([FromBody] CreateCargoDetailDto value)
    {
        CargoDetail cargoDetail = new()
        {
            Barcode = value.Barcode, CargoCompanyId = value.CargoCompanyId,
            ReceiverCustomer = value.ReceiverCustomer, SenderCustomer = value.SenderCustomer,
        };
        cargoDetailService.Insert(cargoDetail);
        return Ok("Cargo detail created");
    }

    [HttpDelete("Delete/{id}")]
    public IActionResult Delete(int id)
    {
        cargoDetailService.Delete(id);
        return Ok("Cargo detail deleted");
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] UpdateCargoDetailDto value)
    {
        CargoDetail cargoDetail = new()
        {
            Id = value.Id, Barcode = value.Barcode, CargoCompanyId = value.CargoCompanyId,
            ReceiverCustomer = value.ReceiverCustomer, SenderCustomer = value.SenderCustomer,
        };
        cargoDetailService.Update(cargoDetail);
        return Ok("Cargo detail updated");
    }
}