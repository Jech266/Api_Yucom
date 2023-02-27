using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yucom.DTOs;
using Yucom.Entity;

namespace Yucom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DestacadosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper imapper;

        public DestacadosController(ApplicationDbContext context, IMapper imapper)
        {
            this.context = context;
            this.imapper = imapper;
        }

        [HttpPost("{IdEvento}")]
        public async Task<ActionResult> post ( int IdEvento, DestacadoCreationDTO destacadoCreationDTO)
        {
            var existeEvento = await context.Eventos.AnyAsync(x => x.Id == IdEvento);
            if(!existeEvento)
            {
                return BadRequest($"No existe el evento");
            }

            var destacado = imapper.Map<Destacados>(destacadoCreationDTO);
            context.Add(destacado);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<Destacados>>> get()
        {
            var destacado = await context.destacados
                .ToListAsync();

            return imapper.Map<List<Destacados>>(destacado);
        }
    }
}