using Microsoft.EntityFrameworkCore;
using moduloApi.Dominio.Entidades;

namespace moduloApi.Infraestrutura.Db;

public class DbContexto : DbContext
{
    private readonly IConfiguration _ConfiguracaoAppSettings;
    public DbContexto(IConfiguration configuracaoAppSettings)
    {
        _ConfiguracaoAppSettings = configuracaoAppSettings;
    }
    public DbSet<Administrador> Administradores { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var stringConexao = _ConfiguracaoAppSettings.GetConnectionString("mysql")?.ToString();
            if (!string.IsNullOrEmpty(stringConexao))
            {
                optionsBuilder.UseMySql(stringConexao, ServerVersion.AutoDetect(stringConexao));
            }
            ;
        }
    }
}