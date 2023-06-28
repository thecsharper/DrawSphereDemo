namespace DrawSphereDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeSpherePoints();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private const int SphereRadius = 100;
        private const int SphereResolution = 20;

        private Point3D[] spherePoints;

        private void InitializeSpherePoints()
        {
            spherePoints = new Point3D[SphereResolution * SphereResolution];

            for (int i = 0; i < SphereResolution; i++)
            {
                double theta = 2 * Math.PI * i / SphereResolution;

                for (int j = 0; j < SphereResolution; j++)
                {
                    double phi = 2 * Math.PI * j / SphereResolution;
                    double x = SphereRadius * Math.Sin(theta) * Math.Cos(phi);
                    double y = SphereRadius * Math.Sin(theta) * Math.Sin(phi);
                    double z = SphereRadius * Math.Cos(theta);
                    spherePoints[i * SphereResolution + j] = new Point3D(x, y, z);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.TranslateTransform(ClientSize.Width / 2, ClientSize.Height / 2);

            foreach (Point3D point in spherePoints)
            {
                int pixelSize = 2;
                int x = (int)Math.Round(point.X);
                int y = (int)Math.Round(point.Y);
                int z = (int)Math.Round(point.Z);
                int brightness = Math.Max(0, 255 - (int)Math.Round(point.Z / SphereRadius * 255));
                if(brightness > 255)
                {
                    brightness = 255;
                }
                Color color = Color.FromArgb(brightness, brightness, brightness);
                SolidBrush brush = new SolidBrush(color);
                graphics.FillEllipse(brush, x, y, pixelSize, pixelSize);
            }
        }
    }
}

public class Point3D
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public Point3D(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}


