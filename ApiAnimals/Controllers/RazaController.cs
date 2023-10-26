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
public class RazaController : BaseControllerApi
{
    private readonly IUnitOfWork _UnitOfWork;
    private readonly IMapper _mapper;

    public RazaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _UnitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Raza>>> Get()
    {
        var items = await _UnitOfWork.Razas.GetAllAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<IEnumerable<Raza>>> Get(int id)
    {
        var item = await _UnitOfWork.Razas.GetByIdAsync(id);
        return Ok(item);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<Raza>> Post(Raza itemDto)
    {
        var item = _mapper.Map<Raza>(itemDto);
        this._UnitOfWork.Razas.Add(item);
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

    public async Task<ActionResult<Raza>> Put(int id, [FromBody] Raza item)
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
        _UnitOfWork.Razas.Update(item);
        await _UnitOfWork.SaveAsync();
        return item;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var item = await _UnitOfWork.Razas.GetByIdAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        _UnitOfWork.Razas.Remove(item);
        await _UnitOfWork.SaveAsync();
        return NoContent();
    }
}