using Micro_chess.Properties;
using System.Drawing;

namespace Micro_chess
{
    class Pawn : BasePiece
    {
        public Pawn(bool isWhite)
        {
            type = PieceType.Pawn;
            this.isWhite = isWhite;

            image = this.isWhite ? Resources.Pawn_White : Resources.Pawn_Black;
            code = $"P{(this.isWhite ? "W" : "B")}";
        }

        public override void CalculateAvailableMoves(Point position)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (position.X + i < 0 || position.X + i > 2 || position.Y + j < 0 || position.Y + j > 2)
                        continue;

                    availableMoves.Add(new Point(position.X + i, position.Y + j));
                }
            }
        }
    }
}
