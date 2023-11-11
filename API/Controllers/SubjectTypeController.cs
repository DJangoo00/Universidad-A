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
public class SubjectTypeController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public SubjectTypeController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    //Controladores genericos
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<SubjectTypeDto>>> Get()
    {
        var entidad = await unitofwork.SubjectTypes.GetAllAsync();
        return mapper.Map<List<SubjectTypeDto>>(entidad);
    }

    [HttpGet("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SubjectTypeDto>> Get(int id)
    {
        var entidad = await unitofwork.SubjectTypes.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        return this.mapper.Map<SubjectTypeDto>(entidad);
    }

    [HttpPost]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SubjectType>> Post(SubjectTypeDto entidadDto)
    {
        var entidad = this.mapper.Map<SubjectType>(entidadDto);
        this.unitofwork.SubjectTypes.Add(entidad);
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

    public async Task<ActionResult<SubjectTypeDto>> Put(int id, [FromBody] SubjectTypeDto entidadDto)
    {
        if (entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<SubjectType>(entidadDto);
        unitofwork.SubjectTypes.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }
    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var entidad = await unitofwork.SubjectTypes.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        unitofwork.SubjectTypes.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }
    //consultas avanzadas
    
}