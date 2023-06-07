using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redstone.Cells
{
    internal class Cell
    {
        CellType type;
        private Facing facing;

        public Facing Facing
        {
            get { return facing; }
            set { facing = value; }
        }

        public CellType Type => type;
        public byte Value => value;
        byte value = 0;
        public Cell(CellType type, Facing facing)
        {
            this.type = type;
            this.facing = facing;
        }
        public UpdateDirections Update(int x, int y)
        {
            switch (type)
            {
                case CellType.Empty:
                    break;
                case CellType.Cable:
                    return UpdateCable(x, y);
                case CellType.Repeater:
                    break;
                case CellType.Comparator:
                    break;
                case CellType.Source:
                    return UpdateSource(x, y);
                default:
                    break;
            }
            return UpdateDirections.None;
        }

        private UpdateDirections UpdateSource(int x, int y)
        {
            return (UpdateDirections)30;
        }

        private UpdateDirections UpdateCable(int x, int y)
        {
            UpdateDirections dirs = new UpdateDirections();
            if (facing.HasFlag(Facing.Up))
            {
                if (Form1.Grid[x, y - 1].value > value)
                {
                    value = Form1.Grid[x, y - 1].value;
                    dirs |= UpdateDirections.Up;
                }
            }
            if (facing.HasFlag(Facing.Right))
            {
                if (Form1.Grid[x+1, y].value > value)
                {
                    value = Form1.Grid[x+1, y].value;
                    dirs |= UpdateDirections.Right;
                }
            }
            if (facing.HasFlag(Facing.Down))
            {
                if (Form1.Grid[x, y + 1].value > value)
                {
                    value = Form1.Grid[x, y + 1].value;
                    dirs |= UpdateDirections.Down;
                }
            }
            if (facing.HasFlag(Facing.Left))
            {
                if (Form1.Grid[x - 1, y].value > value)
                {
                    value = Form1.Grid[x - 1, y].value;
                    dirs |= UpdateDirections.Left;
                }
            }
            return dirs;
        }
    }
}
