using System.Collections.Generic; // benötigt für Listen

namespace gdi_PointAndClick
{
    public partial class FrmMain : Form
    {
        List<Rectangle> rectangles = new List<Rectangle>();

        public FrmMain()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        private void FrmMain_Paint(object sender, PaintEventArgs e)
        {
            // Hilfsvarablen
            Graphics g = e.Graphics;
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            // Zeichenmittel
            Random random = new Random();
            Color[] rngFarben = {Color.White, Color.Black, Color.Yellow, Color.Green, Color.Gold, Color.Orange, Color.Blue, Color.Red, Color.Turquoise};
            Brush b = new SolidBrush(rngFarben[random.Next(rngFarben.Length)]);


            for (int i = 0; i < rectangles.Count; i++)
            {
                g.FillRectangle(b, rectangles[i]);
            }

        }

        private void FrmMain_MouseClick(object sender, MouseEventArgs e)
        {
            Point mausposition = e.Location;
            bool frei = true;
            Random random = new Random();

            for (int i = 0; i < rectangles.Count; i++)
            {
                if (rectangles[i].Contains(mausposition))
                {
                    frei = false;
                }
            }
            if (frei)
            {
                int size = random.Next(10,50);

                Rectangle r = new Rectangle(mausposition.X - (size / 2), mausposition.Y - (size / 2), size, size);

                rectangles.Add(r);  // Kurze Variante: rectangles.Add( new Rectangle(...)  );
            }

            Refresh();
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                rectangles.Clear();
                Refresh();
            }
        }
    }
}