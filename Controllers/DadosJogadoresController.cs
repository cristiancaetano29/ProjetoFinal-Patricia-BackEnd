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
    [ApiController]
    [Route("api/[controller]")]
    public class DadosJogadoresController : Controller
    {
        private readonly RpgContext _context;
        public DadosJogadoresController(RpgContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<dadosJogador>> GetAll() =>
            _context.dadosJogador.ToList();

        [HttpGet("{idJogador}", Name = "GetDadosJogadores")]
        public ActionResult<dadosJogador> GetById(int idJogador)
        {
            var dadosJogadores = _context.dadosJogador.Find(idJogador);

            if (dadosJogadores == null)
            {
                return NotFound();
            }

            return dadosJogadores;
        }

        [HttpPost]
        public async Task<ActionResult> post(dadosJogador dadosJogadoresModel)
        {
            try{
                _context.dadosJogador.Add(dadosJogadoresModel);
                await _context.SaveChangesAsync();
                return CreatedAtRoute("GetDadosJogadores", new { idJogador = dadosJogadoresModel.id }, dadosJogadoresModel);
            }
            catch(Exception e){
                return BadRequest(e);
            }
        }

        [HttpPut("{idJogador}")]
        public async Task<IActionResult> put (int idJogador, dadosJogador dadosJogadoresModel)
        {
            try{
                var response = await _context.dadosJogador.FindAsync(idJogador);
                if(idJogador != response.id){
                    return BadRequest();
                }

                response.namePlayer = dadosJogadoresModel.namePlayer;
                response.namePersonagem = dadosJogadoresModel.namePersonagem;
                response.agilidade = dadosJogadoresModel.agilidade;
                response.vigor = dadosJogadoresModel.vigor;
                response.presenca = dadosJogadoresModel.presenca;
                response.forca = dadosJogadoresModel.forca;
                response.origem = dadosJogadoresModel.origem;
                response.classe = dadosJogadoresModel.classe;
                /*
                response.nex = dadosJogadoresModel.nex;
                response.pv = dadosJogadoresModel.pv;
                response.sam = dadosJogadoresModel.sam;
                */
                await _context.SaveChangesAsync();
                return CreatedAtRoute("GetDadosJogadores", new { idJogador = dadosJogadoresModel.id }, dadosJogadoresModel);
            }
            catch(Exception e){
                return BadRequest(e);
            }
        }

        [HttpDelete("{idJogador}")]
        public async Task<ActionResult> delete(int idJogador)
        {
            try{
                var response = await _context.dadosJogador.FindAsync(idJogador);
                if(response == null){
                    return NotFound();
                }
                _context.dadosJogador.Remove(response);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch(Exception e){
                return BadRequest(e);
            }
        }
    }
}