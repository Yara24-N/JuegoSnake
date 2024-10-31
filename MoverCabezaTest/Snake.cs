using System.Drawing;

namespace MoverCabezaTest
{
    internal class Snake
    {
        internal object _direccion;
        private Point point;
        private ConsoleColor red;
        private ConsoleColor white;
        private object value1;
        private object value2;

        public Snake(Point point, ConsoleColor red, ConsoleColor white, object value1, object value2)
        {
            this.point = point;
            this.red = red;
            this.white = white;
            this.value1 = value1;
            this.value2 = value2;
        }

        public Point Cabeza { get; internal set; }

        internal void MoverCabeza()
        {
            throw new NotImplementedException();
        }
    }
}