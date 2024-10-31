using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Drawing;

namespace MoverCabezaTest
{
    [TestClass]
    public class UnitTest1
    {
        private Snake? snake;
        private Juego? _juego;

        public object Direccion { get; private set; }

        [TestInitialize]
        public void Setup()
        {
            snake = new Snake(new Point(5, 5), ConsoleColor.Red, ConsoleColor.White, null, null);
        }

        [TestMethod]
        public void TestMethod1()
        {
            snake._direccion = Direccion.Derecha;
            snake.MoverCabeza();
            Assert.AreEqual(new Point(6, 5), snake.Cabeza);
        }

        [TestMethod]
        public void TestMoverCabeza_Izquierda()
        {
            snake._direccion = Direccion.
            snake.MoverCabeza();
            Assert.AreEqual(new Point(4, 5), snake.Cabeza);

        }

        [TestMethod]
        public void MoverCabeza_MueveIzquierda_CabezaDecrementaX()
        {
            // Arrange
            Point cabezaInicial = new Point(5, 5);
            _juego = new Juego(cabezaInicial, ConsoleColor.Green, Direccion.Izquierda);

            // Act
            _juego.MoverCabeza();

            // Assert
            Assert.AreEqual(new Point(4, 5), _juego.Cabeza);
        }

        [TestMethod]
        public void MoverCabeza_MueveArriba_CabezaDecrementaY()
        {
            // Arrange
            Point cabezaInicial = new Point(5, 5);
            _juego = new Juego(cabezaInicial, ConsoleColor.Green, Direccion.Arriba);

            // Act
            _juego.MoverCabeza();

            // Assert
            Assert.AreEqual(new Point(5, 4), _juego.Cabeza);
        }

        [TestMethod]
        public void MoverCabeza_LlamaColisionesMarco()
        {
            // Arrange
            var mockJuego = new Mock<Juego>();
            mockJuego.Setup(j => j.ColisionesMarco()).Verifiable();

            // Act
            mockJuego.Object.MoverCabeza();

            // Assert
            mockJuego.Verify(j => j.ColisionesMarco(), Times.Once);
        }


    }

}