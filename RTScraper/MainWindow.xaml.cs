using System;
using System.Collections.Generic;
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
