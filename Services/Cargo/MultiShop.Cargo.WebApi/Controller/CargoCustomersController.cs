using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controller;

[Route("api/[controller]")]
[ApiController]
public class CargoCustomersController(ICargoCustomerService cargoCustomerService) : ControllerBase
{
    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        List<GetAllCargoCustomerDto> getAllCargoCustomerDtos = [];
        getAllCargoCustomerDtos.AddRange(cargoCustomerService.GetAll()
            .Select(value => new GetAllCargoCustomerDto
            {
                Name = value.Name, Id = value.Id, Address = value.Address, UserCustomerId = value.UserCustomerId,
                City = value.City, District = value.District, Phone = value.Phone, Email = value.Email,
                SurName = value.SurName
            }));
        return Ok(getAllCargoCustomerDtos);
    }

    [HttpGet("GetById/{id}")]
    public IActionResult GetById(int id)
    {
        var value = cargoCustomerService.GetById(id);
        GetByIdCargoCustomerDto getByIdCargoCustomerDto = new()
        {
            Name = value.Name, Address = value.Address, UserCustomerId = value.UserCustomerId,
            City = value.City, District = value.District, Phone = value.Phone, Email = value.Email,
            SurName = value.SurName
        };
        return Ok(getByIdCargoCustomerDto);
    }

    [HttpPost("Create")]
    public IActionResult Create([FromBody] CreateCargoCustomerDto value)
    {
        CargoCustomer cargoCustomer = new()
        {
            Name = value.Name, Address = value.Address, UserCustomerId = value.UserCustomerId,
            City = value.City, District = value.District, Phone = value.Phone, Email = value.Email,
            SurName = value.SurName
        };
        cargoCustomerService.Insert(cargoCustomer);
        return Ok("Cargo customer created");
    }

    [HttpDelete("Delete/{id}")]
    public IActionResult Delete(int id)
    {
        cargoCustomerService.Delete(id);
        return Ok("Cargo customer deleted");
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] UpdateCargoCustomerDto value)
    {
        CargoCustomer cargoCustomer = new()
        {
            Id = value.Id, Name = value.Name, Address = value.Address, UserCustomerId = value.UserCustomerId,
            City = value.City, District = value.District, Phone = value.Phone, Email = value.Email,
            SurName = value.SurName
        };
        cargoCustomerService.Update(cargoCustomer);
        return Ok("Cargo customer updated");
    }
}