using Microsoft.EntityFrameworkCore;
using moduloApi.Dominio.Entidades;

namespace moduloApi.Infraestrutura.Db;

public class DbContexto : DbContext
{
    public DbSet<Administrador> Administradores { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("String de conexão", ServerVersion.AutoDetect("String de conexão"));
    }
}