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
        List<RTSites> RTList;
        public MainWindow()
        {
            RTList = new List<RTSites>();
            RTList.Add(new RTSites("Rooster Teeth", "https://roosterteeth.com/rt-favicon.png", "http://roosterteeth.com/show"));
            RTList.Add(new RTSites("Achievement Hunter", "https://achievementhunter.roosterteeth.com/ah-favicon.png", "http://achievementhunter.roosterteeth.com/show"));
            RTList.Add(new RTSites("Funhaus", "https://funhaus.roosterteeth.com/fh-favicon.png", "http://funhaus.roosterteeth.com/show"));
            RTList.Add(new RTSites("ScrewAttack", "https://screwattack.roosterteeth.com/sa-favicon.png", "http://screwattack.roosterteeth.com/show"));
            RTList.Add(new RTSites("Game Attack", "https://gameattack.roosterteeth.com/ga-favicon.png", "http://gameattack.roosterteeth.com/show"));
            RTList.Add(new RTSites("The Know", "https://theknow.roosterteeth.com/tk-favicon.png", "http://theknow.roosterteeth.com/show"));
            RTList.Add(new RTSites("Cow Chop", "https://cowchop.roosterteeth.com/cc-favicon.png", "http://cowchop.roosterteeth.com/show"));

            InitializeComponent();


            RTSitesList.ItemsSource = RTList;

            /**/
            
        }

        private void RTSitesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SiteLabel.Content = RTList[RTSitesList.SelectedIndex].Name;
            SiteImage.Source = new BitmapImage(new Uri(RTList[RTSitesList.SelectedIndex].Image));
            Shows.ShowScraper(RTList[RTSitesList.SelectedIndex].SiteURL);
        }
    }

    public class RTSites
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string SiteURL { get; set; }

        public RTSites(string Name, string Image, string SiteURL)
        {
            this.Name = Name;
            this.Image = Image;
            this.SiteURL = SiteURL;
        }
    }


}
