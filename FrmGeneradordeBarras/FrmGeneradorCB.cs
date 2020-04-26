using KeepAutomation.Barcode.Bean;
using System;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmGeneradorCB : Form
    {
        public FrmGeneradorCB()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BarCode barcode = new BarCode();
            barcode.Symbology = KeepAutomation.Barcode.Symbology.UPCA;
            barcode.CodeToEncode = "12457182140";
            barcode.X = 2;
            barcode.Y = 30;
            barcode.TopMargin = 10;
            barcode.BottomMargin = 10;
            barcode.LeftMargin = 10;
            barcode.RightMargin = 10;
            barcode.DisplayText = true;
            barcode.DisplayStartStop = true;
            barcode.BarcodeUnit = KeepAutomation.Barcode.BarcodeUnit.Pixel;
            barcode.Orientation = KeepAutomation.Barcode.Orientation.Degree90;
            barcode.DPI = 72;
            barcode.ImageFormat = ImageFormat.Bmp;
            barcode.generateBarcodeToImageFile("C://BPM//CodigoBarras.bmp");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
           appendChecksum("844502861347");
        }

        private string appendChecksum(string code)
        {

            var checksum=0 ;

            for (long j = 0; j < 100; j++)
            {




                long g = long.Parse(code) + 1;
                code = g.ToString();

                var sum = 0;

                for (var i = code.Length; i >= 1; i--)
                {
                    var d = Convert.ToInt32(code.Substring(i - 1, 1));
                    var f = i % 2 == 0 ? 3 : 1;
                    sum += d * f;
                }
                  checksum = (10 - (sum % 10)) % 10;

                textBox1.Text += code + checksum   +"\r\n";
            }

            return code + checksum;
        }
    }
}