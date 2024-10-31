using System.Drawing;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JuegoSnake;

namespace MoverCuerpoMSTEST
{
   [TestClass]
    public class UnitTest1
    {
    
        private Serpiente _serpiente;

        [TestInitialize]
        public void Setup()
        {
            // Inicializamos la serpiente con un cuerpo inicial.
            _serpiente = new Serpiente
            {
                Cuerpo = new List<Point>
            {
                new Point(5, 5),
                new Point(5, 6)
            },
                ColorCuerpo = ConsoleColor.Green,
                _comiendo = false
            };
        }

        [TestMethod]
        public void MoverCuerpo()
        {
            // Arrange
            var posCabezaAnterior = new Point(5, 6);

            // Act
            _serpiente.MoverCuerpo(posCabezaAnterior);

            // Assert
            Assert.AreEqual(2, _serpiente.Cuerpo.Count);
            Assert.AreEqual(new Point(5, 6), _serpiente.Cuerpo[0]); // La nueva cabeza
            Assert.AreEqual(new Point(5, 5), _serpiente.Cuerpo[1]); // La antigua cabeza se convierte en el nuevo cuerpo
        }

        [TestMethod]
        public void NoMueveCuerpo()
        {
            // Arrange
            var posCabezaAnterior = new Point(5, 6);
            _serpiente._comiendo = true; // Simulamos que está comiendo

            // Act
            _serpiente.MoverCuerpo(posCabezaAnterior);

            // Assert
            Assert.AreEqual(2, _serpiente.Cuerpo.Count);
            Assert.AreEqual(new Point(5, 6), _serpiente.Cuerpo[0]); // La nueva cabeza
            Assert.AreEqual(new Point(5, 5), _serpiente.Cuerpo[1]); // La antigua cabeza se convierte en el nuevo cuerpo
        }

        [TestMethod]
        public void NoCausaError()
        {
            // Arrange
            var posCabezaAnterior = new Point(-1, -1); // Posición fuera de límites

            // Act
            _serpiente.MoverCuerpo(posCabezaAnterior);

            // Assert
            Assert.AreEqual(2, _serpiente.Cuerpo.Count);
            Assert.AreEqual(new Point(-1, -1), _serpiente.Cuerpo[0]); // La nueva cabeza
            Assert.AreEqual(new Point(5, 5), _serpiente.Cuerpo[1]); // El cuerpo no se mueve
        }

        [TestMethod]
        public void AgregaCabezaCorrectamente()
        {
            // Arrange
            _serpiente.Cuerpo.Clear(); // Limpiar el cuerpo
            var posCabezaAnterior = new Point(5, 6);

            // Act
            _serpiente.MoverCuerpo(posCabezaAnterior);

            // Assert
            Assert.AreEqual(1, _serpiente.Cuerpo.Count);
            Assert.AreEqual(new Point(5, 6), _serpiente.Cuerpo[0]); // La cabeza es la única parte
        }

        [TestMethod]
        public void ActualizaCabezaCorrectamente()
        {
            // Arrange
            _serpiente.Cuerpo = new List<Point> { new Point(5, 5) }; // Cuerpo con una sola parte
            var posCabezaAnterior = new Point(5, 6);

            // Act
            _serpiente.MoverCuerpo(posCabezaAnterior);

            // Assert
            Assert.AreEqual(1, _serpiente.Cuerpo.Count);
            Assert.AreEqual(new Point(5, 6), _serpiente.Cuerpo[0]); // La cabeza es la única parte*/
        }
    }
}