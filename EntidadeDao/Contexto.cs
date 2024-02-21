using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EntidadeDao
{
    public partial class Contexto : DbContext
    {
        public Contexto()
            : base("name=Contexto1")
        {
        }

        public virtual DbSet<CARRITO> CARRITOes { get; set; }
        public virtual DbSet<CATEGORIA> CATEGORIAs { get; set; }
        public virtual DbSet<COMPRA> COMPRAs { get; set; }
        public virtual DbSet<DETALHE_COMPRA> DETALHE_COMPRA { get; set; }
        public virtual DbSet<Fornecedor> Fornecedors { get; set; }
        public virtual DbSet<Loja> Lojas { get; set; }
        public virtual DbSet<Produto> Produtoes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<USUARIO> USUARIOs { get; set; }
        public virtual DbSet<DEPARTAMENTO> DEPARTAMENTOes { get; set; }
        public virtual DbSet<DISTRITO> DISTRITOes { get; set; }
        public virtual DbSet<PROVINCIA> PROVINCIAs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CATEGORIA>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORIA>()
                .HasMany(e => e.Produtoes)
                .WithOptional(e => e.CATEGORIA)
                .WillCascadeOnDelete();

            modelBuilder.Entity<COMPRA>()
                .Property(e => e.Total)
                .HasPrecision(10, 2);

            modelBuilder.Entity<COMPRA>()
                .Property(e => e.Contacto)
                .IsUnicode(false);

            modelBuilder.Entity<COMPRA>()
                .Property(e => e.Telefone)
                .IsUnicode(false);

            modelBuilder.Entity<COMPRA>()
                .Property(e => e.Direcao)
                .IsUnicode(false);

            modelBuilder.Entity<COMPRA>()
                .Property(e => e.IdDistrito)
                .IsUnicode(false);

            modelBuilder.Entity<COMPRA>()
                .HasMany(e => e.DETALHE_COMPRA)
                .WithOptional(e => e.COMPRA)
                .WillCascadeOnDelete();

            modelBuilder.Entity<DETALHE_COMPRA>()
                .Property(e => e.Total)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Fornecedor>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedor>()
                .Property(e => e.Tellefone)
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedor>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedor>()
                .Property(e => e.Morada)
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedor>()
                .HasMany(e => e.Produtoes)
                .WithOptional(e => e.Fornecedor)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Loja>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Loja>()
                .HasMany(e => e.Produtoes)
                .WithOptional(e => e.Loja)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Produto>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.Preco)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Produto>()
                .Property(e => e.RotaImagem)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .HasMany(e => e.CARRITOes)
                .WithOptional(e => e.Produto)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Produto>()
                .HasMany(e => e.DETALHE_COMPRA)
                .WithOptional(e => e.Produto)
                .WillCascadeOnDelete();

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.Nomes)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.Apelido)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.Senha)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.CARRITOes)
                .WithOptional(e => e.USUARIO)
                .WillCascadeOnDelete();

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.COMPRAs)
                .WithOptional(e => e.USUARIO)
                .WillCascadeOnDelete();

            modelBuilder.Entity<DEPARTAMENTO>()
                .Property(e => e.IdDepartamento)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTAMENTO>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<DISTRITO>()
                .Property(e => e.IdDistrito)
                .IsUnicode(false);

            modelBuilder.Entity<DISTRITO>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<DISTRITO>()
                .Property(e => e.IdProvincia)
                .IsUnicode(false);

            modelBuilder.Entity<DISTRITO>()
                .Property(e => e.IdDepartamento)
                .IsUnicode(false);

            modelBuilder.Entity<PROVINCIA>()
                .Property(e => e.IdProvincia)
                .IsUnicode(false);

            modelBuilder.Entity<PROVINCIA>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<PROVINCIA>()
                .Property(e => e.IdDepartamento)
                .IsUnicode(false);
        }
    }
}
