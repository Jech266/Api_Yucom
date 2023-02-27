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

namespace Yucom.Controllers
{
    [ApiController]
    [Route("api/Boleto")]
    public class BoletoController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public BoletoController(ApplicationDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }
        
        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<BoletoCreationDTO>>> get()
        {
            var boleto = await context.Boletos.ToListAsync();

            return mapper.Map<List<BoletoCreationDTO>>(boleto);
        }



        [HttpPost("{EventoId:int}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Post (int EventoId, BoletoCreationDTO boletoCreationDTO)
        {
            var ExisteEvento = await context.Boletos.AnyAsync(x => x.IdEvento == EventoId);
            if(ExisteEvento)
            {
                return BadRequest($"El boleto: {boletoCreationDTO.Id} ya Existe");
            }

            var boleto = mapper.Map<Boleto>(boletoCreationDTO);
            context.Add(boleto);
            await context.SaveChangesAsync();
            return Ok();
        } 



        [HttpPut("{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Put (Boleto boleto, int id)
        {
            if (boleto.Id != id)
            {
                return BadRequest("El Id no existe en el sistema");
            }

            var existe = await context.Boletos.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }
            context.Update(boleto);
            await context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id:int}")]
        
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Boletos.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }
            context.Remove(new Boleto(){Id = id});
            await context.SaveChangesAsync();
            return Ok();
        }        
    }
}