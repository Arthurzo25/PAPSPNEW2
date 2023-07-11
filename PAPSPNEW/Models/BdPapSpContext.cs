using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PAPSPNEW.Models;

public partial class BdPapSpContext : DbContext
{
    public BdPapSpContext()
    {
    }

    public BdPapSpContext(DbContextOptions<BdPapSpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AvaliacaoUsu> AvaliacaoUsus { get; set; }

    public virtual DbSet<Bairro> Bairros { get; set; }

    public virtual DbSet<Endereco> Enderecos { get; set; }

    public virtual DbSet<HorarioAtendimento> HorarioAtendimentos { get; set; }

    public virtual DbSet<PontoTuristico> PontoTuristicos { get; set; }

    public virtual DbSet<TipoCategorium> TipoCategoria { get; set; }

    public virtual DbSet<TipoContato> TipoContatos { get; set; }

    public virtual DbSet<TipoEntradum> TipoEntrada { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BD_PapSP;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AvaliacaoUsu>(entity =>
        {
            entity.HasKey(e => e.AvaliacaoUsuario).HasName("PK__Avaliaca__6C46CA678E5B1E53");

            entity.ToTable("AvaliacaoUsu");

            entity.Property(e => e.AvaliacaoUsuario)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("avaliacaoUsuario");
            entity.Property(e => e.ComentarioUsuario)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("comentarioUsuario");
            entity.Property(e => e.DataVisita)
                .HasColumnType("date")
                .HasColumnName("dataVisita");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.NomeUsuario)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("nomeUsuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.AvaliacaoUsus)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Avaliacao");
        });

        modelBuilder.Entity<Bairro>(entity =>
        {
            entity.HasKey(e => e.IdBairro).HasName("PK__Bairro__86B592A1185124C6");

            entity.ToTable("Bairro");

            entity.Property(e => e.IdBairro)
                .ValueGeneratedNever()
                .HasColumnName("idBairro");
            entity.Property(e => e.IdPontoTuristico).HasColumnName("idPontoTuristico");
            entity.Property(e => e.NomeBairro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nomeBairro");

            entity.HasOne(d => d.IdPontoTuristicoNavigation).WithMany(p => p.Bairros)
                .HasForeignKey(d => d.IdPontoTuristico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Bairro");
        });

        modelBuilder.Entity<Endereco>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Endereco");

            entity.Property(e => e.Bairro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("bairro");
            entity.Property(e => e.Cep)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.Cidade)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cidade");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.IdBairro).HasColumnName("idBairro");
            entity.Property(e => e.IdEndereco).HasColumnName("idEndereco");
            entity.Property(e => e.IdPontoTuristico).HasColumnName("idPontoTuristico");
            entity.Property(e => e.Logradouro)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NroEnd)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("nroEnd");

            entity.HasOne(d => d.IdBairroNavigation).WithMany()
                .HasForeignKey(d => d.IdBairro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Endereco");

            entity.HasOne(d => d.IdPontoTuristicoNavigation).WithMany()
                .HasForeignKey(d => d.IdPontoTuristico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Endereco1");
        });

        modelBuilder.Entity<HorarioAtendimento>(entity =>
        {
            entity.HasKey(e => e.IdHorarioAtendimento).HasName("PK__HorarioA__B769EC16A496B372");

            entity.ToTable("HorarioAtendimento");

            entity.Property(e => e.IdHorarioAtendimento)
                .ValueGeneratedNever()
                .HasColumnName("idHorarioAtendimento");
            entity.Property(e => e.DiaSemana)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("diaSemana");
            entity.Property(e => e.HorarioFim).HasColumnName("horarioFim");
            entity.Property(e => e.HorarioInicio).HasColumnName("horarioInicio");
            entity.Property(e => e.HorarioIntervalo).HasColumnName("horarioIntervalo");
            entity.Property(e => e.HorarioIntervalo2).HasColumnName("horarioIntervalo2");
            entity.Property(e => e.HorarioIntervalo3).HasColumnName("horarioIntervalo3");
            entity.Property(e => e.HorarioIntervalo4).HasColumnName("horarioIntervalo4");
            entity.Property(e => e.IdPontoTuristico).HasColumnName("idPontoTuristico");

            entity.HasOne(d => d.IdPontoTuristicoNavigation).WithMany(p => p.HorarioAtendimentos)
                .HasForeignKey(d => d.IdPontoTuristico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_HorarioAtendimento");
        });

        modelBuilder.Entity<PontoTuristico>(entity =>
        {
            entity.HasKey(e => e.IdPontoTuristico).HasName("PK__PontoTur__5E44595F4F85D68D");

            entity.ToTable("PontoTuristico");

            entity.Property(e => e.IdPontoTuristico)
                .ValueGeneratedNever()
                .HasColumnName("idPontoTuristico");
            entity.Property(e => e.DescricaoPontoTuristico)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("descricaoPontoTuristico");
            entity.Property(e => e.NomePontoTuristico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nomePontoTuristico");
        });

        modelBuilder.Entity<TipoCategorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__TipoCate__8A3D240CCEDE5D3B");

            entity.Property(e => e.IdCategoria)
                .ValueGeneratedNever()
                .HasColumnName("idCategoria");
            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdPontoTuristico).HasColumnName("idPontoTuristico");

            entity.HasOne(d => d.IdPontoTuristicoNavigation).WithMany(p => p.TipoCategoria)
                .HasForeignKey(d => d.IdPontoTuristico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tipoCategoria");
        });

        modelBuilder.Entity<TipoContato>(entity =>
        {
            entity.HasKey(e => e.IdContato).HasName("PK__tipoCont__278E896D53039FEA");

            entity.ToTable("tipoContato");

            entity.Property(e => e.IdContato)
                .ValueGeneratedNever()
                .HasColumnName("idContato");
            entity.Property(e => e.Celular)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdPontoTuristico).HasColumnName("idPontoTuristico");
            entity.Property(e => e.Telefone1)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefone1");
            entity.Property(e => e.TelefoneComer)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Whatsapp)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPontoTuristicoNavigation).WithMany(p => p.TipoContatos)
                .HasForeignKey(d => d.IdPontoTuristico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tipoContanto");
        });

        modelBuilder.Entity<TipoEntradum>(entity =>
        {
            entity.HasKey(e => e.IdEntrada).HasName("PK__TipoEntr__19943CE008C2E01D");

            entity.Property(e => e.IdEntrada)
                .ValueGeneratedNever()
                .HasColumnName("idEntrada");
            entity.Property(e => e.EntradaGratuita)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("entradaGratuita");
            entity.Property(e => e.EntradaGratuita1)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("entradaGratuita1");
            entity.Property(e => e.EntradaGratuita2)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("entradaGratuita2");
            entity.Property(e => e.EntradaGratuita3)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("entradaGratuita3");
            entity.Property(e => e.IdPontoTuristico).HasColumnName("idPontoTuristico");
            entity.Property(e => e.ValorAcompanhantePcd)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("valorAcompanhantePCD");
            entity.Property(e => e.ValorAdulto)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("valorAdulto");
            entity.Property(e => e.ValorEstudante)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("valorEstudante");
            entity.Property(e => e.ValorMaior60)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("valorMaior60");
            entity.Property(e => e.ValorProfessor)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("valorProfessor");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A6FCBD5A74");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnName("idUsuario");
            entity.Property(e => e.EmailUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("emailUsuario");
            entity.Property(e => e.NomeUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nomeUsuario");
            entity.Property(e => e.SenhaUsuario)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("senhaUsuario");
            entity.Property(e => e.SobrenomeUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("sobrenomeUsuario");
            entity.Property(e => e.UserUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userUsuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
