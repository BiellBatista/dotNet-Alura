using _05_XX_xUnit_Moq.Core.Commands;
using _05_XX_xUnit_Moq.Core.Models;
using _05_XX_xUnit_Moq.Infrastructure;
using _05_XX_xUnit_Moq.Services.Handlers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;

namespace _05_XX_xUnit_Moq.Testes
{
    public class CadastraTarefaHandlerExecute
    {
        [Fact]
        public void DadaTarefaComInfoValidasDeveIncluirNoBD()
        {
            //arrange
            var comando = new CadastraTarefa("Estudar Xunit", new Categoria("Estudo"), new DateTime(2019, 12, 31));

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                .UseInMemoryDatabase("DbTarefasContext")
                .Options;
            var context = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(context);

            var mock = new Mock<ILogger<CadastraTarefaHandler>>();

            var handler = new CadastraTarefaHandler(repo, mock.Object);

            //act
            handler.Execute(comando); //SUT >> CadastraTarefaHandlerExecute

            //assert
            var tarefa = repo.ObtemTarefas(t => t.Titulo == "Estudar Xunit").FirstOrDefault();
            Assert.NotNull(tarefa);
        }

        [Fact]
        public void QuandoExceptionForLancadaResultadoIsSuccessDeveSerFalso()
        {
            //arrange
            var comando = new CadastraTarefa("Estudar Xunit", new Categoria("Estudo"), new DateTime(2019, 12, 31));

            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();

            var mock = new Mock<IRepositorioTarefas>(); //mocando o objeto a ser criado

            //configurando o objeto, no meu caso, criando a exce��o
            // quando vc criar o m�todo "IncluirTarefas", lance a exce��o..
            //mock faz um setup para quando o m�todo IncluirTarefas for chamado para qualquer algumento de entrada (do tipo Tarefa)..
            //lance a exce��a..
            mock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>())).Throws(new Exception("Houve um erro na inclus�o de tarefas"));

            var repo = mock.Object; //falando para o mock me dar o objeto que foi mocado e configurado em cima
            var handler = new CadastraTarefaHandler(repo, mockLogger.Object);

            //act
            CommandResult resultado = handler.Execute(comando);

            //assert
            Assert.False(resultado.IsSuccess);
        }

        [Fact]
        public void QuandoExceptionForLancadaDeveLogarAMensagemDaExcecao()
        {
            //arrange
            var mensagemDeErroEsperada = "Houve um erro na inclus�o de tarefas";
            var excecaoEsperada = new Exception(mensagemDeErroEsperada);
            var comando = new CadastraTarefa("Estudar Xunit", new Categoria("Estudo"), new DateTime(2019, 12, 31));

            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();

            var mock = new Mock<IRepositorioTarefas>(); //mocando o objeto a ser criado

            //configurando o objeto, no meu caso, criando a exce��o
            // quando vc criar o m�todo "IncluirTarefas", lance a exce��o..
            //mock faz um setup para quando o m�todo IncluirTarefas for chamado para qualquer algumento de entrada (do tipo Tarefa)..
            //lance a exce��a..
            mock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>())).Throws(excecaoEsperada);

            var repo = mock.Object; //falando para o mock me dar o objeto que foi mocado e configurado em cima
            var handler = new CadastraTarefaHandler(repo, mockLogger.Object);

            //act
            CommandResult resultado = handler.Execute(comando);

            //assert
            // n�o consigo utilizar a verifica��o do mock, em m�todos de extensoes
            //mockLogger.Verify(l => l.LogError(mensagemDeErroEsperada), Times.Once());
            mockLogger.Verify(l => l.Log(
                LogLevel.Error, // n�vel de log
                It.IsAny<EventId>(), // identificador do evento
                It.IsAny<object>(), // objeto que ser� logado (mensagem)
                excecaoEsperada, // excecao que ser� logada (j� est� com a mensagem)
                It.IsAny<Func<object, Exception, string>>()), // funcao que converte o objeto e a excecao em uma string
                Times.Once());
        }
    }
}
// n�o consigo utilizar a verifica��o do mock, em m�todos de extensoes
/**
 * Dubl�s para Testes
 * 
 * Dummy Object: s�o objetos que eu tenho que criar, mas que n�o s�o utilizados no assert. Neste teste, tenho como exemplos as categorias.
 * Fake Object: s�o classes que eu crio/uso para simular um recurso, de forma leve. Por exemplo, o reposit�rio fake e o inMemoryDatabase.
 * Stubs: � um objeto do qual eu preciso fornecer alguma informa��o de entrada para o teste. Por exemplo, o lan�amento de uma exce��o, porque foi preciso
 *  mockar um objeto (simular). Em resumo, ele simula um objeto, do qual � necess�rio fornecer informa��o
 */
