using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoFinalPatricia.Models;

namespace ProjetoFinalPatricia.Data
{
    public class RpgContext : DbContext
    {
        /*public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options){

        }*/
        protected readonly IConfiguration Configuration;
        public RpgContext(IConfiguration configuration){
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlServer(Configuration.GetConnectionString("StringConexaoSQLServer"));
        }
        public DbSet<player> player { get; set;}
        public DbSet<poderes> poderes { get; set;}
        public DbSet<dadosJogador> dadosJogador { get; set;}
    }
}