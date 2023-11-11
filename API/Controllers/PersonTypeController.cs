using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using API.Dtos;
using Domain.Interfaces;
using Domain.Entities;
using API.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;
/* [ApiVersion("1.0")]
[ApiVersion("1.1")]
[Authorize] */
public class PersonTypeController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public PersonTypeController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    //Controladores genericos
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonTypeDto>>> Get()
    {
        var entidad = await unitofwork.PersonTypes.GetAllAsync();
        return mapper.Map<List<PersonTypeDto>>(entidad);
    }

    [HttpGet("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonTypeDto>> Get(int id)
    {
        var entidad = await unitofwork.PersonTypes.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        return this.mapper.Map<PersonTypeDto>(entidad);
    }

    [HttpPost]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonType>> Post(PersonTypeDto entidadDto)
    {
        var entidad = this.mapper.Map<PersonType>(entidadDto);
        this.unitofwork.PersonTypes.Add(entidad);
        await unitofwork.SaveAsync();
        if (entidad == null)
        {
            return BadRequest();
        }
        entidadDto.Id = entidad.Id;
        return CreatedAtAction(nameof(Post), new { id = entidadDto.Id }, entidadDto);
    }

    [HttpPut("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<PersonTypeDto>> Put(int id, [FromBody] PersonTypeDto entidadDto)
    {
        if (entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<PersonType>(entidadDto);
        unitofwork.PersonTypes.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }
    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var entidad = await unitofwork.PersonTypes.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        unitofwork.PersonTypes.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }
    //consultas avanzadas
    
}