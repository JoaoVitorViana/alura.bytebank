using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ByteBank.Infraestrutura.Testes;

public class AgenciaRepositorioTestes
{
    private readonly IAgenciaRepositorio _repositorio;
    public AgenciaRepositorioTestes()
    {
        var servico = new ServiceCollection();
        servico.AddTransient<IAgenciaRepositorio, AgenciaRepositorio>();
        var provedor = servico.BuildServiceProvider();
        _repositorio = provedor.GetService<IAgenciaRepositorio>() ?? throw new NotImplementedException();
    }


    [Fact]
    public void ExcecaoConsultaPorAgenciaPorId()
    {
        //Act
        //Assert
        Assert.Throws<Exception>(
            () => _repositorio.ObterPorId(33)
        );
    }
}