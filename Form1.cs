using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevilishCheatsInstaller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void title_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            downloadShit("https://github.com/CatsheeDev/devilishcheats-files/raw/main/devilishcheats", @"C:\Program Files (x86)\Steam\steamapps\common\Cuphead\Cuphead_Data\StreamingAssets\devilishcheats", false);
            downloadShit("https://github.com/CatsheeDev/devilishcheats-files/raw/main/Assembly-CSharp.dll", @"C:\Program Files (x86)\Steam\steamapps\common\Cuphead\Cuphead_Data\Managed\Assembly-CSharp.dll", true);
        }

        private void downloadShit(string fileUrl, string localPath, bool final)
        {
            try
            {
                if (File.Exists(localPath))
                {
                    string backupPath = localPath + ".bak";
                    File.Move(localPath, backupPath);
                }

                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(fileUrl, localPath);
                    
                    if (final)
                    {
                        MessageBox.Show("Injected Devilish Cheats! Please launch Cuphead.");
                    }
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show("Error downloading file: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("UKNOWN ERROR!!!!!!!!!!!!!!!!!! " + ex.Message);
            }
        }

        private void RestoreBackups()
        {
            RestoreBackupIfExists("C:\\Program Files (x86)\\Steam\\steamapps\\common\\Cuphead\\Cuphead_Data\\StreamingAssets\\devilishcheats");
            RestoreBackupIfExists("C:\\Program Files (x86)\\Steam\\steamapps\\common\\Cuphead\\Cuphead_Data\\Managed\\Assembly-CSharp.dll");
        }

        private void RestoreBackupIfExists(string path)
        {
            string backupPath = path + ".bak";
            if (File.Exists(backupPath))
            {
                File.Delete(path); 
                File.Move(backupPath, path); 
            }
        }

        private void DeleteFiles(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            else if (File.Exists(path))
            {
                File.Delete(path); 
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                DeleteFiles("C:\\Program Files (x86)\\Steam\\steamapps\\common\\Cuphead\\Cuphead_Data\\StreamingAssets\\devilishcheats");
                DeleteFiles("C:\\Program Files (x86)\\Steam\\steamapps\\common\\Cuphead\\Cuphead_Data\\Managed\\Assembly-CSharp.dll");

                RestoreBackups(); 
                MessageBox.Show("Cheats uninstalled successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during uninstall: " + ex.Message);
            }
        }
    }
}
