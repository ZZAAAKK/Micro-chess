using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro_chess
{
    public abstract class BasePiece
    {
        protected PieceType type;
        protected bool isWhite;
        protected List<Point> availableMoves = new List<Point>();
        protected Bitmap image;
        protected string code;

        public abstract void CalculateAvailableMoves(Point position);

        public PieceType Type => type;
        public bool IsWhite => isWhite;
        public List<Point> AvailableMoves => availableMoves;
        public Bitmap Image => image;
        public string Code => code;
    }
}
