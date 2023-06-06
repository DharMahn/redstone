using redstone.Cells;
namespace redstone
{
    internal partial class Form1 : Form
    {
        const int CELLSIZE = 20;
        private static Grid g = new Grid(30, 30);
        public static Grid Grid { get { return g; } }
        public Form1()
        {
            InitializeComponent();
            Facing asd = Facing.Right;
            asd |= Facing.Up;
            Console.WriteLine((int)asd + " - " + asd.ToString());
            Grid.SetCell(10, 10, new Cell(CellType.Source, Facing.None));
            Grid.SetCell(11, 10, new Cell(CellType.Cable, Facing.Left | Facing.Right | Facing.Up | Facing.Down));
        }
        Pen cableBrush = new Pen(Color.FromArgb(255,128,192), 3);
        protected override void OnPaint(PaintEventArgs e)
        {
            for (int y = 0; y < g.Height; y++)
            {
                for (int x = 0; x < g.Width; x++)
                {
                    switch (Grid[x, y].Type)
                    {
                        case CellType.Empty:
                            break;
                        case CellType.Cable:
                            cableBrush.Color = Color.FromArgb((15 - Grid[x, y].Value) << 4, cableBrush.Color.G, cableBrush.Color.B);
                            if (Grid[x, y].Facing.HasFlag(Facing.Up))
                            {
                                e.Graphics.DrawLine(cableBrush, (x * CELLSIZE) + (CELLSIZE >> 1), (y * CELLSIZE) + (CELLSIZE >> 1), (x * CELLSIZE) + (CELLSIZE >> 1), y * CELLSIZE);
                            }
                            if (Grid[x, y].Facing.HasFlag(Facing.Down))
                            {
                                e.Graphics.DrawLine(cableBrush, (x * CELLSIZE) + (CELLSIZE >> 1), (y * CELLSIZE) + (CELLSIZE >> 1), (x * CELLSIZE) + (CELLSIZE >> 1), (y + 1) * CELLSIZE);
                            }
                            if (Grid[x, y].Facing.HasFlag(Facing.Left))
                            {
                                e.Graphics.DrawLine(cableBrush, (x * CELLSIZE) + (CELLSIZE >> 1), (y * CELLSIZE) + (CELLSIZE >> 1), x * CELLSIZE, (y * CELLSIZE) + (CELLSIZE >> 1));
                            }
                            if (Grid[x, y].Facing.HasFlag(Facing.Right))
                            {
                                e.Graphics.DrawLine(cableBrush, (x * CELLSIZE) + (CELLSIZE >> 1), (y * CELLSIZE) + (CELLSIZE >> 1), ((x + 1) * CELLSIZE), (y * CELLSIZE) + (CELLSIZE >> 1));
                            }
                            break;
                        case CellType.Repeater:
                            break;
                        case CellType.Comparator:
                            break;
                        case CellType.Source:
                            e.Graphics.FillRectangle(Brushes.Red, x * CELLSIZE, y * CELLSIZE, CELLSIZE, CELLSIZE);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = "Type: " + Grid[e.Location.X / CELLSIZE, e.Location.Y / CELLSIZE].Type + ", Value: " + Grid[e.Location.X / CELLSIZE, e.Location.Y / CELLSIZE].Value;
        }
    }
}