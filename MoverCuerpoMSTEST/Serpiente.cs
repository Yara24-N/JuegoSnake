using System.Drawing;

namespace MoverCuerpoMSTEST
{
    internal class Serpiente
    {
        internal bool _comiendo;

        public List<Point> Cuerpo { get; internal set; }
        public ConsoleColor ColorCuerpo { get; internal set; }

        internal void MoverCuerpo(Point posCabezaAnterior)
        {
            throw new NotImplementedException();
        }
    }
}