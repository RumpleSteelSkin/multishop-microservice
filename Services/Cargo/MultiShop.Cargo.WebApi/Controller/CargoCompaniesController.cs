using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controller;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoCompaniesController(ICargoCompanyService cargoCompanyService) : ControllerBase
{
    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        List<GetAllCargoCompanyDto> getAllCargoCompanyDtos = [];
        getAllCargoCompanyDtos.AddRange(cargoCompanyService.GetAll()
            .Select(value => new GetAllCargoCompanyDto { Name = value.Name, Id = value.Id }));
        return Ok(getAllCargoCompanyDtos);
    }

    [HttpGet("GetById/{id}")]
    public IActionResult GetById(int id)
    {
        GetByIdCargoCompanyDto getByIdCargoCompanyDto = new() { Name = cargoCompanyService.GetById(id).Name };
        return Ok(getByIdCargoCompanyDto);
    }

    [HttpPost("Create")]
    public IActionResult Create([FromBody] CreateCargoCompanyDto cargoCompanyDto)
    {
        CargoCompany cargoCompany = new() { Name = cargoCompanyDto.Name };
        cargoCompanyService.Insert(cargoCompany);
        return Ok("Cargo company created");
    }

    [HttpDelete("Delete/{id}")]
    public IActionResult Delete(int id)
    {
        cargoCompanyService.Delete(id);
        return Ok("Cargo company deleted");
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] UpdateCargoCompanyDto cargoCompanyDto)
    {
        CargoCompany cargoCompany = new() { Id = cargoCompanyDto.Id, Name = cargoCompanyDto.Name };
        cargoCompanyService.Update(cargoCompany);
        return Ok("Cargo company updated");
    }
}