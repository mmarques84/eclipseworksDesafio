using eclipseworksDesafio.Application.Services;
using eclipseworksDesafio.Core.Interfaces;
using Moq;

namespace TestesUnitario.Projeto
{
    [TestFixture]
    public class ProjetoServiceTests
    {
        private Mock<IProjetoRepository> _mockRepo;
        private ProjetoService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IProjetoRepository>();
            _service = new ProjetoService(_mockRepo.Object);
        }

        [Test]
        public async Task GetProjetoByIdAsync_ReturnsProjeto()
        {
            // Arrange
            
            var projetoId = 1;
            var projeto = new eclipseworksDesafio.Core.Entities.Projeto { Id = projetoId, Descricao = "Test Projeto" };
            _mockRepo.Setup(repo => repo.GetId(projetoId)).ReturnsAsync(projeto);

            // Act
            var result = await _service.GetId(projetoId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(projetoId, result.Id);
            Assert.AreEqual("Test Projeto", result.Descricao);
        }
    }
}
