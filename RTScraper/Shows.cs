using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RTScraper
{
    public class Shows
    {
        public string ShowURL { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Info { get; set; }

        public Shows(string ShowURL, string Name, string Image, string Info)
        {
            this.ShowURL = ShowURL;
            this.Name = Name;
            this.Image = Image;
            this.Info = Info;
        }

        public static void ShowScraper(string SiteURL)
        {
            string webpage;
            List<string[]> ShowArrays = new List<string[]>();
            List<Shows> AllShows = new List<Shows>();
            string[] ShowBlocks;
            using (var wc = new System.Net.WebClient())
            {
                webpage = wc.DownloadString(SiteURL);
            }
            int checkchar = 0;
            checkchar = webpage.IndexOf("<h2>New");
            checkchar = checkchar + 61;
            webpage = webpage.Remove(0, checkchar);
            webpage = webpage.Remove(webpage.IndexOf("<!-- =============== BEGIN FOOTER =============== -->") - 3);
            ShowBlocks = webpage.Split(new string[] { "</li>" }, StringSplitOptions.None);
            foreach (string item in ShowBlocks)
            {
                if (item == ShowBlocks[ShowBlocks.Count() - 1])
                {

                }
                else
                {
                    ShowArrays.Add(item.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None));
                }
            }
            foreach (string[] item in ShowArrays)
            {
                string ShowURL;
                string Name;
                string Image;
                string Info;

                foreach (string stringitem in item)
                {
                    if (stringitem.IndexOf("<a") != -1)
                    {
                        ShowURL = stringitem.Remove(0, stringitem.IndexOf('"') + 1);
                        ShowURL = ShowURL.Remove(ShowURL.IndexOf('"'));
                        MessageBox.Show(ShowURL);
                    }
                    else if (stringitem.IndexOf("<img") != -1)
                    {
                        Image = stringitem.Remove(0, stringitem.IndexOf('"') + 1);
                        Image = Image.Remove(Image.IndexOf('"'));
                        MessageBox.Show(Image);
                    }
                    else if (stringitem.IndexOf("<p class=\"name\"") != -1)
                    {
                        Name = stringitem.Remove(0, stringitem.IndexOf('>') + 1);
                        Name = Name.Remove(Name.IndexOf('<'));
                        MessageBox.Show(Name);
                    }
                    else if (stringitem.IndexOf("<p class=\"post-stamp\"") != -1)
                    {
                        Info = stringitem.Remove(0, stringitem.IndexOf('>') + 1);
                        Info = Info.Remove(Info.IndexOf('<'));
                        MessageBox.Show(Info);
                    }
                }
            }
        }
    }
}
