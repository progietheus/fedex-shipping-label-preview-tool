using ShippingLabelPreview;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public DataGridPrinter dataGridPrinter1 { get; set; }
        public DataGrid dataGrid1 { get; set; }

        public PrintDocument printDocument1 { get; set; }
        public Label peripheral_title { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.peripheral_title = new Label();
            this.peripheral_title.BackColor = System.Drawing.Color.White;
            this.peripheral_title.Font = new System.Drawing.Font("Times New Roman", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.peripheral_title.ForeColor = System.Drawing.Color.Black;
            this.peripheral_title.Location = new System.Drawing.Point(80, 10);
            this.peripheral_title.Name = "peripheral_title";
            this.peripheral_title.TabIndex = 1;
            this.peripheral_title.Text = "Peripheral Item List";

            this.dataGrid1 = new DataGrid();
            this.dataGrid1.AlternatingBackColor = Color.LightGray;
            this.dataGrid1.Location = new Point(0, 50);
            this.dataGrid1.BackColor = Color.White;

            printDocument1 = new PrintDocument();
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("4x6", 400, 600);
            printDocument1.DefaultPageSettings.Margins.Top = 5;
            printDocument1.DefaultPageSettings.Margins.Left = 20;
            printDocument1.DefaultPageSettings.Margins.Bottom = 0;
            printDocument1.PrinterSettings.PrinterName = "<Network Printer Location";

            printDocument1.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                Graphics g = e1.Graphics;
                // Draw a label title for the grid
                DrawTopLabel(g);
                // draw the datagrid using the DrawDataGrid method passing the Graphics surface
                bool more = dataGridPrinter1.DrawDataGrid(g);
                // if there are more pages, set the flag to cause the form to trigger another print            page event
                if (more == true)
                {
                    e1.HasMorePages = true;
                    dataGridPrinter1.PageNumber++;

                };

            };
        }
        private void DrawTopLabel(Graphics g)
        {
            int TopMargin = printDocument1.DefaultPageSettings.Margins.Top;

            g.FillRectangle(new SolidBrush(peripheral_title.BackColor), peripheral_title.Location.X, peripheral_title.Location.Y + TopMargin, peripheral_title.Size.Width, peripheral_title.Size.Height);
            g.DrawString(peripheral_title.Text, peripheral_title.Font, new SolidBrush(peripheral_title.ForeColor), peripheral_title.Location.X, peripheral_title.Location.Y + TopMargin, new StringFormat());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radio_peripheral.Checked)
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    dt.Columns.Add(col.Name);
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataRow dRow = dt.NewRow();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dRow[cell.ColumnIndex] = cell.Value;
                    }
                    dt.Rows.Add(dRow);
                }

                dataGridPrinter1 = new DataGridPrinter(dataGrid1, printDocument1, dt);

                PrintPreviewDialog ppvw = new PrintPreviewDialog();
                try
                {
                    dataGridPrinter1.PageNumber = 1;
                    dataGridPrinter1.RowCount = 0;
                    //printDocument1.Print();
                    ppvw.Document = printDocument1;
                    ppvw.ShowDialog();
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception Occured While Printing", ex);
                }
            }
            else
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += PrintPage;
                pd.Print();
            }
        }

        private void PrintPage(object o, PrintPageEventArgs e)
        {
            System.Drawing.Image i = pictureBox1.Image;
            Rectangle m = e.PageBounds;

            if ((double)i.Width / (double)i.Height > (double)m.Width / (double)m.Height) // image is wider
            {
                m.Height = (int)((double)i.Height / (double)i.Width * (double)m.Width);
            }
            else
            {
                m.Width = (int)((double)i.Width / (double)i.Height * (double)m.Height);
            }
            e.Graphics.DrawImage(i, m);
        }

        private Image ByteToImage(Byte[] byteArrayIn)
        {
            using (MemoryStream mStream = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(mStream);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] bytes = Convert.FromBase64String(txt_manual.Text.Trim());
            Image image = ByteToImage(bytes);
            pictureBox1.Image = image;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            var derp = new ImagePreview();
            derp.pictureBox2.Image = pictureBox1.Image;
            derp.ShowDialog();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (radio_peripheral.Checked)
            {
                pnl_manual.Hide();
                pnl_peripheral.Show();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_manual.Checked)
            {
                pnl_manual.Show();
                pnl_peripheral.Hide();
            }
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
