using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
namespace WebTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
           DialogResult dl= this.folderBrowserDialog1.ShowDialog();
           if (DialogResult.OK==dl)
           {
               string folder = this.folderBrowserDialog1.SelectedPath;
               List <string> list=new List<string>();
               FileHelper.GetFiles(folder,list);
               foreach (string s in list)
               {
                   var it = s.ToLower();
                   if (it.IndexOf(".jpg") > -1 || it.IndexOf(".jpeg") > -1 || it.IndexOf(".png") > -1 
                       || it.IndexOf(".jpeg") > -1 || it.IndexOf(".gif") > -1)
                   {
                       if (s.IndexOf("_450_300") <= -1 && s.IndexOf("_160_120") <= -1)
                       {
                           string smallPath = s.Replace(".", "_160_120.");
                           string dPath = s.Replace(".", "_800_800.");
                          // ImageHelper.GetPicThumbnailWidth(s, smallPath, 120, 160, 100);
                           bool isZipSuccess = ImageHelper.GetPicThumbnailWidth(s, dPath, 800, 800, 80);
                       }
                   }
                  
                  
               }
               MessageBox.Show("操作完成");
           }
            
        }
    }
}
