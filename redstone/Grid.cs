using redstone.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redstone
{
    internal class Grid
    {
        static readonly Cell EmptyCell = new Cell(CellType.Empty, Facing.Up);
        Cell[,] cells;
        int w, h;
        public int Width => w;
        public int Height => h;
        public Grid(int w, int h)
        {
            cells = new Cell[w, h];
            this.w = w;
            this.h = h;
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    cells[x, y] = new Cell(CellType.Empty, Facing.None);
                }
            }
        }
        public Cell this[int w, int h]
        {
            get { if (w >= this.w || h >= this.h || w < 0 || h < 0) return EmptyCell; return cells[w, h]; }
            set { cells[w, h] = value; }
        }

        internal void SetCell(int x, int y, Cell cell)
        {
            cells[x, y] = cell;
            cell.Update(x, y);
        }
    }
}
