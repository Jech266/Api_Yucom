using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yucom.DTOs;
using Yucom.Entity;
using Yucom.Utilidades;

namespace Yucom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SedeController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public readonly IMapper Mapper;

        public SedeController(ApplicationDbContext context, IMapper mapper)
        {
            this.Mapper = mapper;
            this.context = context;
        }

        [HttpGet("Paginación")]
        [AllowAnonymous]
        public async Task<ActionResult<List<SedeCreationDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            var queryable = context.sedes
            .AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);
            var Establecimiento = await queryable.OrderBy(Establecimiento => Establecimiento.Nombre).Paginar(paginacionDTO).Where(z => z.Status == true).ToListAsync();
            return Mapper.Map<List<SedeCreationDTO>>(Establecimiento);
        }

        [HttpGet("dato/{Dato}")]
        [AllowAnonymous]
        public async Task<ActionResult<Sede>> Get (string Dato)
        {
            var NombreSede = await context.sedes
                .FirstOrDefaultAsync(x => x.Nombre.Contains(Dato));

            var rfc = await context.sedes
                .FirstOrDefaultAsync(x => x.RFC == Dato);
            
            if (NombreSede == null)
            {
                return rfc;
            } if (rfc == null)
            {
                return NombreSede;
            }

            return NotFound();
             
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Sede>> Get (int id)
        {
            var sede = await context.sedes.FirstOrDefaultAsync(x => x.Id == id);
            if(sede == null)
            {
                return NotFound();
            }

            return sede;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody]SedeCreationDTO sedeCreationDTO)
        {
            var existeSede = await context.sedes.AnyAsync(x => x.RFC == sedeCreationDTO.RFC);

            if (existeSede)
            {
                return BadRequest($"La sede con RFC: {sedeCreationDTO.RFC} ya EXISTE en el sistema");
            }
            var sede = Mapper.Map<Sede>(sedeCreationDTO);

            context.Add(sede);
            await context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{RFC}")]
        public async Task<ActionResult> Put(SedeCreationDTO sedeCreationDTO, string RFC)
        {
            if (sedeCreationDTO.RFC != RFC)
            {
                return BadRequest($"El RFC: {RFC} no se encuentra en el sistema");
            }

            var existe = await context.sedes.AnyAsync(x => x.RFC == RFC);
            if (!existe)
            {
                return NotFound();
            }
            var sede =Mapper.Map<Sede>(sedeCreationDTO);

            context.Update(sede);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{RFC}")]
        public async Task<ActionResult> Delete(string RFC)
        {
            var existe = await context.sedes.AnyAsync(x => x.RFC == RFC);
            if (!existe)
            {
                return NotFound();
            }
            
            context.Remove(new Sede(){RFC = RFC});
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}