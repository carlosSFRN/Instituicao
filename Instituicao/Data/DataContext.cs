using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Instituicao.Models;


namespace Instituicao.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Turma> Turma { get; set; }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Escola> Escola { get; set; }
    }
}
