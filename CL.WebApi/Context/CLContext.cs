
using System.Collections.Immutable;
using CL.Core.Domains;
using CL.WebApi.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CL.WebApi.Context
{
    public class CLContext : DbContext
    {
        public CLContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Funcao> Funcoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TelefoneConfiguration());
        }
    }
}

