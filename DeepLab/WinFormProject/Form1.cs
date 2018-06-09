using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Runtime.InteropServices;

namespace WinFormProject
{

    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }
        
        
        //------------------------------------------------------------------------------------------------------------------
        //PInvoke
        [DllImport("OpenCVDotNet.dll")]
        [return: MarshalAs(UnmanagedType.LPStr)]
        private static extern string DetectObjectsInImage(IntPtr p, int size);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPInvoke_Click(object sender, EventArgs e)
        {
            //allow user to open jpg file 
            OpenFileDialog dlogOpen = new OpenFileDialog();
            dlogOpen.Filter = "Jpg Files|*.jpg";

            if (dlogOpen.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            pictureBoxInputImage.Image = Bitmap.FromFile(dlogOpen.FileName);
            pictureBoxInputImage.Refresh();

            byte[] imageData;

            using (var stream = new MemoryStream())
            {
                pictureBoxInputImage.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                imageData = stream.ToArray();
            }

            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(byte)) * imageData.Length);
            Marshal.Copy(imageData, 0, p, imageData.Length);
            string data = DetectObjectsInImage(p, imageData.Length);
            Marshal.FreeHGlobal(p);

            txtBoxTFOutput.Text = data;
        }
    }
}

