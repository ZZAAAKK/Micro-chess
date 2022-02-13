using Micro_chess.Properties;
using System;
using System.Drawing;

namespace Micro_chess
{
    class Bishop : BasePiece
    {
        public Bishop(bool isWhite)
        {
            type = PieceType.Bishop;
            this.isWhite = isWhite;

            image = this.isWhite ? Resources.Bishop_White : Resources.Bishop_Black;
            code = $"B{(this.isWhite ? "W" : "B")}";
        }

        public override void CalculateAvailableMoves(Point position)
        {
            for (int i = -2; i <= 2; i++)
            {
                for (int j = -2; j <= 2; j++)
                {
                    if (Math.Abs(i) != Math.Abs(j))
                    {
                        continue;
                    }
                    else
                    {
                        if (position.X + i < 0 || position.X + i > 2 || position.Y + j < 0 || position.Y + j > 2)
                            continue;

                        availableMoves.Add(new Point(position.X + i, position.Y + j));
                    }
                }
            }
        }
    }
}
