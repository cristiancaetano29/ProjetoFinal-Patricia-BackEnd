using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ProjetoFinalPatricia.Data;
using ProjetoFinalPatricia.Models;

namespace ProjetoFinalPatricia.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class poderesController : Controller
    {
        private readonly RpgContext _context;
        public poderesController(RpgContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<poderes>> GetAll() =>
            _context.poderes.ToList();

        [HttpGet("{idPoder}", Name = "GetPoderes")]
        public ActionResult<poderes> GetById(int idPoder)
        {
            var poderes = _context.poderes.Find(idPoder);

            if (poderes == null)
            {
                return NotFound();
            }

            return poderes;
        }

        [HttpPost]
        public async Task<ActionResult> post(poderes poderesModel)
        {
            try{
                _context.poderes.Add(poderesModel);
                await _context.SaveChangesAsync();
                return CreatedAtRoute("GetPoderes", new { idPoder = poderesModel.id }, poderesModel);
            }
            catch(Exception e){
                return BadRequest(e);
            }
        }

        [HttpPut("{idPoder}")]
        public async Task<ActionResult> put(int idPoder, poderes poderesModel)
        {
            try{
                var response = await _context.poderes.FindAsync(idPoder);
                if(idPoder != response.id){
                    return BadRequest();
                }
                response.nome = poderesModel.nome;
                response.tipo = poderesModel.tipo;
                response.descricao = poderesModel.descricao;
                await _context.SaveChangesAsync();
                return CreatedAtRoute("GetPoderes", new { idPoder = poderesModel.id }, poderesModel);
            }
            catch(Exception e){
                return BadRequest(e);
            }
        }

        [HttpDelete("{idPoder}")]
        public async Task<ActionResult> delete(int idPoder)
        {
            try{
                var poderes = _context.poderes.Find(idPoder);
                if (poderes == null)
                {
                    return NotFound();
                }

                _context.poderes.Remove(poderes);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch(Exception e){
                return BadRequest(e);
            }
        }
    }
}