using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Desafio_Pluft.WebAPI.Domains
{
    public partial class DesafioPluftContext : DbContext
    {
        public DesafioPluftContext()
        {
        }

        public DesafioPluftContext(DbContextOptions<DesafioPluftContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agendamentos> Agendamentos { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Estabelecimentos> Estabelecimentos { get; set; }
        public virtual DbSet<Lojistas> Lojistas { get; set; }
        public virtual DbSet<ProdutoAgendamentos> ProdutoAgendamentos { get; set; }
        public virtual DbSet<Produtos> Produtos { get; set; }
        public virtual DbSet<StatusAgendamento> StatusAgendamento { get; set; }
        public virtual DbSet<TipoEstabelecimento> TipoEstabelecimento { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\MSSQLSERVER2; initial catalog = Desafio_Pluft;user id = sa; pwd = 132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agendamentos>(entity =>
            {
                entity.ToTable("AGENDAMENTOS");

                entity.Property(e => e.DataAgendamento)
                    .HasColumnName("Data_Agendamento")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataCriacao)
                    .HasColumnName("Data_Criacao")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");

                entity.Property(e => e.IdEstabelecimento).HasColumnName("Id_Estabelecimento");

                entity.Property(e => e.IdLojista).HasColumnName("Id_Lojista");

                entity.Property(e => e.IdStatus).HasColumnName("Id_Status");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__AGENDAMEN__Id_Cl__4F7CD00D");

                entity.HasOne(d => d.IdEstabelecimentoNavigation)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdEstabelecimento)
                    .HasConstraintName("FK__AGENDAMEN__Id_Es__5070F446");

                entity.HasOne(d => d.IdLojistaNavigation)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdLojista)
                    .HasConstraintName("FK__AGENDAMEN__Id_Lo__52593CB8");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdStatus)
                    .HasConstraintName("FK__AGENDAMEN__Id_St__5165187F");
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.ToTable("CLIENTES");

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__CLIENTES__C1F897311A59CD88")
                    .IsUnique();

                entity.HasIndex(e => e.Rg)
                    .HasName("UQ__CLIENTES__321537C88262F8BB")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("Data_Nascimento")
                    .HasColumnType("datetime");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasColumnName("RG")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__CLIENTES__Id_Usu__47DBAE45");
            });

            modelBuilder.Entity<Estabelecimentos>(entity =>
            {
                entity.ToTable("ESTABELECIMENTOS");

                entity.HasIndex(e => e.Cnpj)
                    .HasName("UQ__ESTABELE__AA57D6B47D611E84")
                    .IsUnique();

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("CNPJ")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HorarioFuncionamento)
                    .HasColumnName("Horario_Funcionamento")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoEstabelec).HasColumnName("Id_Tipo_Estabelec");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Vagas)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoEstabelecNavigation)
                    .WithMany(p => p.Estabelecimentos)
                    .HasForeignKey(d => d.IdTipoEstabelec)
                    .HasConstraintName("FK__ESTABELEC__Id_Ti__3E52440B");
            });

            modelBuilder.Entity<Lojistas>(entity =>
            {
                entity.ToTable("LOJISTAS");

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__LOJISTAS__C1F89731792801A8")
                    .IsUnique();

                entity.HasIndex(e => e.Rg)
                    .HasName("UQ__LOJISTAS__321537C8F1C15B51")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("Data_Nascimento")
                    .HasColumnType("datetime");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasColumnName("RG")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Lojistas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__LOJISTAS__Id_Usu__4CA06362");
            });

            modelBuilder.Entity<ProdutoAgendamentos>(entity =>
            {
                entity.ToTable("PRODUTO_AGENDAMENTOS");

                entity.Property(e => e.IdAgendamento).HasColumnName("Id_Agendamento");

                entity.Property(e => e.IdProdutos).HasColumnName("Id_Produtos");

                entity.HasOne(d => d.IdAgendamentoNavigation)
                    .WithMany(p => p.ProdutoAgendamentos)
                    .HasForeignKey(d => d.IdAgendamento)
                    .HasConstraintName("FK__PRODUTO_A__Id_Ag__75A278F5");

                entity.HasOne(d => d.IdProdutosNavigation)
                    .WithMany(p => p.ProdutoAgendamentos)
                    .HasForeignKey(d => d.IdProdutos)
                    .HasConstraintName("FK__PRODUTO_A__Id_Pr__76969D2E");
            });

            modelBuilder.Entity<Produtos>(entity =>
            {
                entity.ToTable("PRODUTOS");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdEstabelec).HasColumnName("Id_Estabelec");

                entity.Property(e => e.Preco).HasColumnType("money");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstabelecNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdEstabelec)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PRODUTOS__Id_Est__6FE99F9F");
            });

            modelBuilder.Entity<StatusAgendamento>(entity =>
            {
                entity.ToTable("STATUS_AGENDAMENTO");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoEstabelecimento>(entity =>
            {
                entity.ToTable("TIPO_ESTABELECIMENTO");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.ToTable("TIPO_USUARIO");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__USUARIOS__A9D1053402150BE8")
                    .IsUnique();

                entity.Property(e => e.DataCriacao)
                    .HasColumnName("Data_Criacao")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdEstabelecimento).HasColumnName("Id_Estabelecimento");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("Id_Tipo_Usuario");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstabelecimentoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdEstabelecimento)
                    .HasConstraintName("FK__USUARIOS__Id_Est__4222D4EF");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__USUARIOS__Id_Tip__4316F928");
            });
        }
    }
}
