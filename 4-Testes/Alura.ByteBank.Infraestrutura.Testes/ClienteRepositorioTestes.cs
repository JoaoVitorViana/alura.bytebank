using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ByteBank.Infraestrutura.Testes;

public class ClienteRepositorioTestes
{
    private readonly IClienteRepositorio _repositorio;
    
    //public ClienteRepositorioTestes(IClienteRepositorio repositorio)
    public ClienteRepositorioTestes()
    {
        var servico = new ServiceCollection();
        servico.AddTransient<IClienteRepositorio, ClienteRepositorio>();
        var provedor = servico.BuildServiceProvider();
        _repositorio = provedor.GetService<IClienteRepositorio>() ?? throw new NotImplementedException();
    }

    [Fact]
    public void TestaObterTodosClientes()
    {
        //Arrange

        //Act
        var lista = _repositorio.ObterTodos();

        //Assert
        Assert.NotNull(lista);
        Assert.Equal(4, lista?.Count);
    }

    [Fact]
    public void TestaObterClientePorId()
    {
        //Arrange
        //Act
        var cliente = _repositorio.ObterPorId(1);

        //Assert
        Assert.NotNull(cliente);
    }
}
