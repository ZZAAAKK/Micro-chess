using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Micro_chess
{
    public partial class Board : Form
    {
        private List<Label> cells = new List<Label>();
        private List<string> breadcrumbs = new List<string>();
        private Dictionary<Label, BasePiece> pieces = new Dictionary<Label, BasePiece>();
        private string startSeed;
        private BasePiece selectedPiece;
        private bool whiteTurn = true;

        public Board()
        {
            InitializeComponent();
            InitialiseCells();
            startSeed = GetRandomSeed();
            breadcrumbs.Add(startSeed);
            RenderBoard(startSeed);
        }

        private void InitialiseCells()
        {
            cells.AddRange(Controls.OfType<Label>());
            cells = cells.OrderBy(x => x.Name).ToList();
        }

        private void RenderBoard(string seed)
        {
            string[] cellData = seed.Split('|');
            pieces.Clear();

            for (int i = 0; i < cells.Count; i++)
            {
                if (cellData[i] == string.Empty)
                {
                    cells[i].Image = null;
                }
                else
                {
                    char type = cellData[i].ToCharArray()[0];
                    bool colour = cellData[i].ToCharArray()[1] == 'W';
                    BasePiece piece = null;

                    switch (type)
                    {
                        case 'P':
                            piece = new Pawn(colour);
                            break;
                        case 'B':
                            piece = new Bishop(colour);
                            break;
                        case 'K':
                            piece = new Knight(colour);
                            break;
                        case 'R':
                            piece = new Rook(colour);
                            break;
                        default:
                            break;
                    }

                    if (piece != null)
                    {
                        pieces.Add(cells[i], piece);
                        RenderPiece(i, piece);
                    }
                }
            }

            CheckForVictory(seed);

            if (IsStalemate)
                EnactStalement();
        }

        private void RenderPiece(int index, BasePiece piece) => cells[index].Image = piece.Image;

        private void Cell_Click(object sender, EventArgs e)
        {
            string cellName = (sender as Label).Name.Replace("Cell", "");
            Point pos = new Point(int.Parse(cellName.ToCharArray()[0].ToString()), int.Parse(cellName.ToCharArray()[1].ToString()));
            ResetCellColours();

            if (selectedPiece != null)
            {
                Label _ = cells.Where(x => x.Name == $"Cell{pos.X}{pos.Y}").First();

                if (pieces.ContainsKey(_) && pieces[_] == selectedPiece)
                {
                    selectedPiece = null;
                    return;
                }

                if (selectedPiece.AvailableMoves.Contains(pos))
                {                    
                    if (pieces.ContainsKey(_))
                    {
                        pieces.Remove(_);
                    }

                    pieces.Remove(pieces.Where(x => x.Value == selectedPiece).First().Key);

                    pieces.Add(_, selectedPiece);

                    CreateBreadcrumb();
                    selectedPiece = null;
                }
                else
                {
                    selectedPiece = null;
                }
            }
            else if (pieces.ContainsKey(sender as Label))
            {
                BasePiece piece = pieces[sender as Label];

                if (piece != selectedPiece && piece.IsWhite == whiteTurn)
                {
                    selectedPiece = piece;

                    piece.CalculateAvailableMoves(pos);

                    if (selectedPiece.Type != PieceType.Knight)
                    {
                        CheckForInvalidMoves(piece.AvailableMoves, pos, out List<Point> invalidMoves);

                        foreach (Point p in invalidMoves)
                        {
                            piece.AvailableMoves.Remove(p);
                        }
                    }                    

                    HighlightAvailableMoves(piece.AvailableMoves);
                }
            }
        }
        
        private void CreateBreadcrumb()
        {
            StringBuilder crumb = new StringBuilder();

            foreach (Label cell in cells)
            {
                if (pieces.ContainsKey(cell))
                {
                    crumb.Append(pieces[cell].Code);
                }
                crumb.Append("|");
            }

            whiteTurn = !whiteTurn;
            AddBreadcrumb(crumb.ToString());
        }

        private void AddBreadcrumb(string crumb)
        {
            if (scrlHistory.Value != scrlHistory.Maximum)
            {
                while (breadcrumbs.Count > scrlHistory.Value + 1)
                {
                    breadcrumbs.RemoveAt(breadcrumbs.IndexOf(breadcrumbs.Last()));
                }
            }

            breadcrumbs.Add(crumb);
            scrlHistory.Maximum = breadcrumbs.Count - 1;
            scrlHistory.Value = scrlHistory.Maximum;
            RenderBoard(crumb);
        }

        private void ResetCellColours()
        {
            foreach (Label cell in cells)
            {
                string cellName = cell.Name.Replace("Cell", "");

                cell.BackColor = (int.Parse(cellName.ToCharArray()[0].ToString()) + int.Parse(cellName.ToCharArray()[1].ToString())) % 2 == 0
                    ? Color.White
                    : Color.Black;
            }
        }

        private void CheckForInvalidMoves(List<Point> moves, Point pos, out List<Point> invalidMoves)
        {
            invalidMoves = new List<Point>();

            foreach (Point move in moves)
            {
                Label _ = cells.Where(x => x.Name == $"Cell{move.X}{move.Y}").FirstOrDefault();
                
                if (pieces.ContainsKey(_))
                {
                    if (pieces[_].IsWhite == selectedPiece.IsWhite)
                    {
                        invalidMoves.Add(move);
                    }

                    if (!(pos.X == 1 && pos.Y == 1))
                    {
                        Point delta = new Point(move.X - pos.X, move.Y - pos.Y);

                        invalidMoves.AddRange(moves.Where(x => x.X == pos.X + (delta.X * 2) && x.Y == pos.Y + (delta.Y * 2)).ToList());
                    }
                }                
            }
        }

        private void HighlightAvailableMoves(List<Point> moves)
        {
            foreach (Point move in moves)
            {
                cells.Where(x => x.Name == $"Cell{move.X}{move.Y}").FirstOrDefault().BackColor = Color.Green;
            }
        }

        private void CheckForVictory(string crumb)
        {
            string[] nibbles = crumb.Split('|');
            int whiteCount = 0;
            int blackCount = 0;

            foreach (string nibble in nibbles)
            {
                if (nibble == string.Empty)
                {
                    continue;
                }
                else if (nibble.ToCharArray()[1] == 'W')
                {
                    whiteCount++;
                }
                else
                {
                    blackCount++;
                }
            }

            lblVictory.Text = $"{(whiteCount == 0 ? "Black" : blackCount == 0 ? "White" : "?")} Wins!\n\nClick here to play again.";
            pnlVictory.Visible = whiteCount == 0 || blackCount == 0;
        }

        private bool CheckForStalemate()
        {
            if (breadcrumbs.Count < 12)
            {
                return false;
            }
            else
            {
                List<string> crumbs = breadcrumbs.TakeLast(12);
                List<string> head = crumbs.Take(4).ToList();
                List<string> body = new List<string>() { crumbs[4], crumbs[5], crumbs[6], crumbs[7] };
                List<string> tail = crumbs.TakeLast(4);
                
                return ExtentionMethods.SequenceEqual(head, new IEnumerable<string>[]{ body, tail });
            }
        }

        private bool IsStalemate => CheckForStalemate();

        private void EnactStalement()
        {
            lblVictory.Text = "Stalemate!\n\nClick here to play again.";
            pnlVictory.Visible = true;
        }

        private void ScrlHistory_Scroll(object sender, ScrollEventArgs e) => RenderBoard(breadcrumbs[Math.Max(0, (sender as ScrollBar).Value)]);

        private void NewGame(object sender, EventArgs e)
        {
            breadcrumbs.Clear();
            pieces.Clear();
            selectedPiece = null;
            whiteTurn = true;
            startSeed = GetRandomSeed();
            AddBreadcrumb(startSeed);
            pnlVictory.Visible = false;
        }

        private string GetRandomSeed()
        {
            StringBuilder seed = new StringBuilder();
            Random random = new Random();
            List<string> whitePieces = new List<string>() { "BW", "KW", "RW" };
            List<string> blackPieces = new List<string>() { "BB", "KB", "RB" };

            for (int i = 0; i < 3; i++)
            {
                int pawnCount = seed.ToString().Split('|').Where(x => x == "PW").ToList().Count();

                if ((random.Next(0, 10) % 2) == 0)
                {

                    if (pawnCount < 2)
                    {
                        seed.Append("PW");
                    }
                    else
                    {
                        int index = random.Next(0, whitePieces.Count);
                        seed.Append(whitePieces[index]);
                        whitePieces.RemoveAt(index);
                    }
                }
                else
                {
                    if (i == 2 && pawnCount == 0)
                    {
                        seed.Append("PW");
                    }
                    else
                    {
                        int index = random.Next(0, whitePieces.Count);
                        seed.Append(whitePieces[index]);
                        whitePieces.RemoveAt(index);
                    }
                }
                seed.Append("|");
            }
                
            seed.Append("|||");

            for (int i = 0; i < 3; i++)
            {
                int pawnCount = seed.ToString().Split('|').Where(x => x == "PB").ToList().Count();

                if ((random.Next(0, 10) % 2) == 0)
                {
                    if (pawnCount < 2)
                    {
                        seed.Append("PB");
                    }
                    else
                    {
                        int index = random.Next(0, blackPieces.Count);
                        seed.Append(blackPieces[index]);
                        blackPieces.RemoveAt(index);
                    }
                }
                else
                {
                    if (i == 2 && pawnCount == 0)
                    {
                        seed.Append("PB");
                    }
                    else
                    {
                        int index = random.Next(0, blackPieces.Count);
                        seed.Append(blackPieces[index]);
                        blackPieces.RemoveAt(index);
                    }
                }
                seed.Append("|");
            }

            return seed.ToString();
        }

        private void BtnExit_Click(object sender, EventArgs e) => Application.Exit();
    }

    public enum PieceType
    {
        Pawn = 0,
        Bishop = 1,
        Knight = 2,
        Rook = 4
    }
}
