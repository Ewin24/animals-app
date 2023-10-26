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
public class ServicioController : BaseControllerApi
{
    private readonly IUnitOfWork _UnitOfWork;
    private readonly IMapper _mapper;

    public ServicioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _UnitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Servicio>>> Get()
    {
        var items = await _UnitOfWork.Servicios.GetAllAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<IEnumerable<Servicio>>> Get(int id)
    {
        var item = await _UnitOfWork.Servicios.GetByIdAsync(id);
        return Ok(item);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<Servicio>> Post(ServicioDto itemDto)
    {
        var item = _mapper.Map<Servicio>(itemDto);
        this._UnitOfWork.Servicios.Add(item);
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

    public async Task<ActionResult<Servicio>> Put(int id, [FromBody] Servicio item)
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
        _UnitOfWork.Servicios.Update(item);
        await _UnitOfWork.SaveAsync();
        return item;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var item = await _UnitOfWork.Servicios.GetByIdAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        _UnitOfWork.Servicios.Remove(item);
        await _UnitOfWork.SaveAsync();
        return NoContent();
    }
}