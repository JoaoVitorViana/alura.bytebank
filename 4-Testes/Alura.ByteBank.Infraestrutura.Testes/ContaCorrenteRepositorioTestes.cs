using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ByteBank.Infraestrutura.Testes;

public class ContaCorrenteRepositorioTestes
{
    private readonly IContaCorrenteRepositorio _repositorio;
    public ContaCorrenteRepositorioTestes()
    {
        var servico = new ServiceCollection();
        servico.AddTransient<IContaCorrenteRepositorio, ContaCorrenteRepositorio>();
        var provedor = servico.BuildServiceProvider();
        _repositorio = provedor.GetService<IContaCorrenteRepositorio>() ?? throw new NotImplementedException();
    }

    [Fact]
    public void TestaAtualizaSaldoDeterminadaConta()
    {
        // Arrange
        var conta = _repositorio.ObterPorId(1);
        double saldoNovo = 15;
        conta.Saldo = saldoNovo;
        
        // Arc
        var atualizado = _repositorio.Atualizar(1, conta);
        
        // Assert
        Assert.True(atualizado);
    }

    [Fact]
    public void TestaInsereUmaNovaContaCorrenteNoBancoDeDados()
    {
        // Arrange
        var conta = new ContaCorrente
        {
            Saldo = 10,
            Identificador = Guid.NewGuid(),
            Cliente = new Cliente
            {
                Nome = "Kent Nelso",
                CPF = "486.074.980-45",
                Identificador = Guid.NewGuid(),
                Profissao = "Bancário",
                Id = 1
            },
            Agencia = new Agencia
            {
                Nome = "Agencia Central Coast City",
                Identificador = Guid.NewGuid(),
                Id = 1,
                Endereco = "Rua das flores, 25",
                Numero = 147
            }
        };

        // Act
        var retorno = _repositorio.Adicionar(conta);

        // Assert
        Assert.True(retorno);
    }
}
