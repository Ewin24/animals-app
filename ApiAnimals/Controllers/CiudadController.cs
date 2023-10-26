using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAnimals.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiAnimals.Controllers;

public class CiudadController : BaseControllerApi
{
    private readonly IUnitOfWork _UnitOfWork;
    private readonly IMapper _mapper;

    public CiudadController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _UnitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Ciudad>>> Get()
    {
        var items = await _UnitOfWork.Ciudades.GetAllAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<IEnumerable<Ciudad>>> Get(int id)
    {
        var item = await _UnitOfWork.Ciudades.GetByIdAsync(id);
        return Ok(item);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<Ciudad>> Post(CiudadDto itemDto)
    {
        var item = _mapper.Map<Ciudad>(itemDto);
        this._UnitOfWork.Ciudades.Add(item);
        await _UnitOfWork.SaveAsync();
        if (item == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = item.Id }, item);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<Ciudad>> Put(int id, [FromBody] Ciudad item)
    {
        if (item.Id == 0)
        {
            item.Id = id;
        }
        if (item.Id != id)
        {
            return BadRequest();
        }
        if (item == null)
        {
            return NotFound();
        }
        _UnitOfWork.Ciudades.Update(item);
        await _UnitOfWork.SaveAsync();
        return item;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var item = await _UnitOfWork.Ciudades.GetByIdAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        _UnitOfWork.Ciudades.Remove(item);
        await _UnitOfWork.SaveAsync();
        return NoContent();
    }
}

