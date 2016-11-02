using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RTScraper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            List<RTSites> RTList = new List<RTSites>();
            RTList.Add(new RTSites("Rooster Teeth", "https://roosterteeth.com/rt-favicon.png"));
            RTList.Add(new RTSites("Achievement Hunter", "https://achievementhunter.roosterteeth.com/ah-favicon.png"));
            RTList.Add(new RTSites("Funhaus", "https://funhaus.roosterteeth.com/fh-favicon.png"));
            RTList.Add(new RTSites("ScrewAttack", "https://screwattack.roosterteeth.com/sa-favicon.png"));
            RTList.Add(new RTSites("Game Attack", "https://gameattack.roosterteeth.com/ga-favicon.png"));
            RTList.Add(new RTSites("The Know", "https://theknow.roosterteeth.com/tk-favicon.png"));
            RTList.Add(new RTSites("Cow Chop", "https://cowchop.roosterteeth.com/cc-favicon.png"));

            InitializeComponent();


            RTSitesList.ItemsSource = RTList;

            string webpage;
            List<string[]> ShowArrays = new List<string[]>();
            string[] ShowBlocks;
            using (var wc = new System.Net.WebClient())
            {
                webpage = wc.DownloadString("http://cowchop.roosterteeth.com/show");
            }
            int checkchar = 0;
            checkchar = webpage.IndexOf("<h2>New");
            checkchar = checkchar + 61;
            webpage = webpage.Remove(0, checkchar);
            webpage = webpage.Remove(webpage.IndexOf("<!-- =============== BEGIN FOOTER =============== -->") - 3);
            ShowBlocks = webpage.Split(new string[] { "</li>" }, StringSplitOptions.None);
            foreach (var item in ShowBlocks)
            {
                if (item == ShowBlocks[ShowBlocks.Count() - 1])
                {
                    return;
                }
                MessageBox.Show(item);
                ShowArrays.Add(item.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None));
            }
            
        }
    }

    public class RTSites
    {
        public string Name { get; set; }
        public string Image { get; set; }

        public RTSites(string Name, string Image)
        {
            this.Name = Name;
            this.Image = Image;
        }
    }
}
