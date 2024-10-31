using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JuegoSnake;
using System.Drawing;
namespace MSTESTVENTANA
{

    [TestClass]
    public class VentanaTests
    {
        [TestMethod]
        public void Constructor_InicializaPropiedadesCorrectamente()
        {
            // Arrange
            string titulo = "Juego de Serpiente";
            int ancho = 80;
            int altura = 25;
            ConsoleColor colorFondo = ConsoleColor.Black;
            ConsoleColor colorLetra = ConsoleColor.White;
            Point limiteSuperior = new Point(0, 0);
            Point limiteInferior = new Point(79, 24);

            // Act
            Ventana ventana = new Ventana(titulo, ancho, altura, colorFondo, colorLetra, limiteSuperior, limiteInferior);

            // Assert
            Assert.AreEqual(titulo, ventana.Titulo);
            Assert.AreEqual(ancho, ventana.Ancho);
            Assert.AreEqual(altura, ventana.Altura);
            Assert.AreEqual(colorFondo, ventana.ColorFondo);
            Assert.AreEqual(colorLetra, ventana.ColorLetra);
            Assert.AreEqual(limiteSuperior, ventana.LimiteSuperior);
            Assert.AreEqual(limiteInferior, ventana.LimiteInferior);
            Assert.AreEqual((limiteInferior.X - limiteSuperior.X - 1) * (limiteInferior.Y - limiteSuperior.Y - 1), ventana.Area); 
        }

        [TestMethod]
        public void Constructor_InicializaAreaCorrectamente()
        {
            // Arrange
            Point limiteSuperior = new Point(1, 1);
            Point limiteInferior = new Point(5, 5);
            int expectedArea = (limiteInferior.X - limiteSuperior.X - 1) * (limiteInferior.Y - limiteSuperior.Y - 1);

            // Act
            Ventana ventana = new Ventana("Titulo", 100, 50, ConsoleColor.Black, ConsoleColor.White, limiteSuperior, limiteInferior);

            // Assert
            Assert.AreEqual(expectedArea, ventana.Area);
        }

        [TestMethod]
        public void Constructor_CalculaAreaConLimitesInvertidos()
        {
            // Arrange
            string titulo = "Juego de Serpiente";
            int ancho = 80;
            int altura = 25;
            ConsoleColor colorFondo = ConsoleColor.Black;
            ConsoleColor colorLetra = ConsoleColor.White;
            Point limiteSuperior = new Point(10, 10);
            Point limiteInferior = new Point(5, 5); // Inverso

            // Act
            Ventana ventana = new Ventana(titulo, ancho, altura, colorFondo, colorLetra, limiteSuperior, limiteInferior);

            // Assert
            Assert.AreEqual(0, ventana.Area); // El área debería ser cero porque los límites son inversos
        }

        [TestMethod]
        public void Constructor_CalculaAreaConLimitesIguales()
        {
            // Arrange
            string titulo = "Juego de Serpiente";
            int ancho = 80;
            int altura = 25;
            ConsoleColor colorFondo = ConsoleColor.Black;
            ConsoleColor colorLetra = ConsoleColor.White;
            Point limiteSuperior = new Point(5, 5);
            Point limiteInferior = new Point(5, 5); // Iguales

            // Act
            Ventana ventana = new Ventana(titulo, ancho, altura, colorFondo, colorLetra, limiteSuperior, limiteInferior);

            // Assert
            Assert.AreEqual(0, ventana.Area); // El área debería ser cero porque los límites son iguales
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_LanzaExcepcionConAnchoNegativo()
        {
            // Arrange
            string titulo = "Juego de Serpiente";
            int ancho = -80; // Negativo
            int altura = 25;
            ConsoleColor colorFondo = ConsoleColor.Black;
            ConsoleColor colorLetra = ConsoleColor.White;
            Point limiteSuperior = new Point(0, 0);
            Point limiteInferior = new Point(79, 24);

            // Act
            Ventana ventana = new Ventana(titulo, ancho, altura, colorFondo, colorLetra, limiteSuperior, limiteInferior);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_LanzaExcepcionConAlturaNegativa()
        {
            // Arrange
            string titulo = "Juego de Serpiente";
            int ancho = 80;
            int altura = -25; // Negativo
            ConsoleColor colorFondo = ConsoleColor.Black;
            ConsoleColor colorLetra = ConsoleColor.White;
            Point limiteSuperior = new Point(0, 0);
            Point limiteInferior = new Point(79, 24);

            // Act
            Ventana ventana = new Ventana(titulo, ancho, altura, colorFondo, colorLetra, limiteSuperior, limiteInferior);
        }
    }
}
