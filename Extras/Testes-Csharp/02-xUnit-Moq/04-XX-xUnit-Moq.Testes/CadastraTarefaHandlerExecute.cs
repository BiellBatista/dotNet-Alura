using _04_XX_xUnit_Moq.Core.Commands;
using _04_XX_xUnit_Moq.Core.Models;
using _04_XX_xUnit_Moq.Infrastructure;
using _04_XX_xUnit_Moq.Services.Handlers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;
using Moq;

namespace _04_XX_xUnit_Moq.Testes
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

            var handler = new CadastraTarefaHandler(repo);

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

            var mock = new Mock<IRepositorioTarefas>(); //mocando o objeto a ser criado

            //configurando o objeto, no meu caso, criando a exce��o
            // quando vc criar o m�todo "IncluirTarefas", lance a exce��o..
            //mock faz um setup para quando o m�todo IncluirTarefas for chamado para qualquer algumento de entrada (do tipo Tarefa)..
            //lance a exce��a..
            mock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>())).Throws(new Exception("Houve um erro na inclus�o de tarefas"));

            var repo = mock.Object; //falando para o mock me dar o objeto que foi mocado e configurado em cima
            var handler = new CadastraTarefaHandler(repo);

            //act
            CommandResult resultado = handler.Execute(comando);

            //assert
            Assert.False(resultado.IsSuccess);
        }
    }
}

/**
 * Dubl�s para Testes
 * 
 * Dummy Object: s�o objetos que eu tenho que criar, mas que n�o s�o utilizados no assert. Neste teste, tenho como exemplos as categorias.
 * Fake Object: s�o classes que eu crio/uso para simular um recurso, de forma leve. Por exemplo, o reposit�rio fake e o inMemoryDatabase.
 * Stubs: � um objeto do qual eu preciso fornecer alguma informa��o de entrada para o teste. Por exemplo, o lan�amento de uma exce��o, porque foi preciso
 *  mockar um objeto (simular). Em resumo, ele simula um objeto, do qual � necess�rio fornecer informa��o
 */
