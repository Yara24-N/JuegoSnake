using JuegoSnake;
using Moq;
using System.Drawing;


namespace Comidatest
{
  /*  [TestClass]
    public class ComidaTest
    {
        private Comida comida;
        private Ventana ventana;
        private Snake snake;

        [TestInitialize]
        public void Setup()
        {
            ventana = new Ventana(new Point(0, 0), new Point(10, 10));
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }*/

 [TestClass]
    public class ComidaTests
    {
        private Mock<Ventana> mockVentana;
        private Mock<Snake> mockSnake;
        private Comida comida;

        [TestInitialize]
        public void Setup()
        {
            mockVentana = new Mock<Ventana>();
            mockVentana.Setup(v => v.LimiteSuperior).Returns(new Point(0, 0));
            mockVentana.Setup(v => v.LimiteInferior).Returns(new Point(20, 20));
            mockVentana.Setup(v => v.Area).Returns(400);

            mockSnake = new Mock<Snake>();
            mockSnake.Setup(s => s.Cuerpo).Returns(new List<Point> { new Point(5, 5) });
            mockSnake.Setup(s => s.Cabeza).Returns(new Point(5, 5));

            comida = new Comida(ConsoleColor.Red, mockVentana.Object);
        }

        [TestMethod]
        public void TestGenerarComida_PosicionValida()
        {
            bool result = comida.GenerarComida(mockSnake.Object);
            Assert.IsTrue(result);
            Assert.IsTrue(comida.Posicion.X >= 1 && comida.Posicion.X < 20);
            Assert.IsTrue(comida.Posicion.Y >= 1 && comida.Posicion.Y < 20);
        }

        [TestMethod]
        public void TestGenerarComida_PosicionNoEnCuerpo()
        {
            mockSnake.Setup(s => s.Cuerpo).Returns(new List<Point> { new Point(10, 10), new Point(11, 10) });
            mockSnake.Setup(s => s.Cabeza).Returns(new Point(12, 10));

            bool result = comida.GenerarComida(mockSnake.Object);
            Assert.IsTrue(result);
            Assert.IsFalse(mockSnake.Object.Cuerpo.Contains(comida.Posicion));
            Assert.AreNotEqual(mockSnake.Object.Cabeza, comida.Posicion);
        }

        [TestMethod]
        public void TestGenerarComida_SnakeFull()
        {
            mockVentana.Setup(v => v.Area).Returns(1);
            mockSnake.Setup(s => s.Cuerpo).Returns(new List<Point> { new Point(0, 0) });

            bool result = comida.GenerarComida(mockSnake.Object);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestDibujar()
        {
            comida.Posicion = new Point(5, 5);
            var output = new StringWriter();
            Console.SetOut(output);

            comida.GenerarComida(mockSnake.Object);

            string expectedOutput = "█"; // Unicode character for block
            Assert.IsTrue(output.ToString().Contains(expectedOutput));
        }

        [TestMethod]
        public void TestColor()
        {
            Assert.AreEqual(ConsoleColor.Red, comida.Color);
        }




       /*  [TestClass]
         public class ComidaTests
         {
             private Comida comida;
             private Ventana ventana;
             private Snake snake;

             [TestInitialize]
             public void Setup()
             {
                 ventana = new Ventana
                 {
                     LimiteSuperior = new Point(0, 0),
                     LimiteInferior = new Point(20, 20),
                     Area = 400
                 };

                 snake = new Snake
                 {
                     Cuerpo = new List<Point> { new Point(5, 5) },
                     Cabeza = new Point(5, 5)
                 };

                 comida = new Comida(ConsoleColor.Red, ventana);
             }

             [TestMethod]
             public void TestGenerarComida_PosicionValida()
             {
                 bool result = comida.GenerarComida(snake);
                 Assert.IsTrue(result);
                 Assert.IsTrue(comida.Posicion.X >= 1 && comida.Posicion.X < 20);
                 Assert.IsTrue(comida.Posicion.Y >= 1 && comida.Posicion.Y < 20);
             }

             [TestMethod]
             public void TestGenerarComida_PosicionNoEnCuerpo()
             {
                 snake.Cuerpo = new List<Point> { new Point(10, 10), new Point(11, 10) };
                 snake.Cabeza = new Point(12, 10);

                 bool result = comida.GenerarComida(snake);
                 Assert.IsTrue(result);
                 Assert.IsFalse(snake.Cuerpo.Contains(comida.Posicion));
                 Assert.AreNotEqual(snake.Cabeza, comida.Posicion);
             }

             [TestMethod]
             public void TestGenerarComida_SnakeFull()
             {
                 ventana.Area = 1;
                 snake.Cuerpo = new List<Point> { new Point(0, 0) };

                 bool result = comida.GenerarComida(snake);
                 Assert.IsFalse(result);
             }

             [TestMethod]
             public void TestColor()
             {
                 Assert.AreEqual(ConsoleColor.Red, comida.Color);
             }

             [TestMethod]
             public void TestPosicionInicial()
             {
                 Assert.AreEqual(new Point(0, 0), comida.Posicion);
             }*/
         }
}

/*}*/


