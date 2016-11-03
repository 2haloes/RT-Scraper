using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RTScraper
{
    public class Episodes
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Runtime { get; set; }
        public string UploadTime { get; set; }
        public string SponserImage { get; set; }
        public string PageURL { get; set; }

        public Episodes(string Title, string Image, string Runtime, string UploadTime, string SponserImage, string PageURL)
        {
            this.Title = Title;
            this.Image = Image;
            this.Runtime = Runtime;
            this.UploadTime = UploadTime;
            this.SponserImage = SponserImage;
            this.PageURL = PageURL;
        }

        public static List<Episodes> ExtractEpisodes(string PageURL)
        {
            string Webpage;
            List<Episodes> AllEpisodes = new List<Episodes>();
            using (var wc = new System.Net.WebClient())
            {
                Webpage = wc.DownloadString(PageURL);
            }
            // Reverse seasons from count (1 = 12 etc.)
            if (Webpage.IndexOf("pull-right") != -1)
            {
                AllEpisodes = FromShowPage(Webpage);
            }
            else
            {
                AllEpisodes = FromSeasonPage(Webpage);
            }
            return AllEpisodes;
        }

        private static List<Episodes> FromShowPage(string Webpage)
        {
            List<Episodes> AllEpisodes = new List<Episodes>();
            List<string[]> EpisodesArray = new List<string[]>();
            string[] EpisodeBlocks;
            int checkchar = 0;
            checkchar = Webpage.IndexOf("tab-content-episodes");
            Webpage = Webpage.Remove(0, checkchar);

            EpisodeBlocks = Webpage.Split(new string[] { "</li>" }, StringSplitOptions.None);
            foreach (string item in EpisodeBlocks)
            {
                if (item == EpisodeBlocks[EpisodeBlocks.Count() - 1])
                {

                }
                else
                {
                    EpisodesArray.Add(item.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None));
                }
            }

            foreach (string[] item in EpisodesArray)
            {
                string PageURL = null;
                string Name = null;
                string Image = null;
                string Info = null;
                string SponserImage = null;
                string Runtime = null;

                foreach (string stringitem in item)
                {
                    if (stringitem.IndexOf("<a ") != -1)
                    {
                        PageURL = stringitem.Remove(0, stringitem.IndexOf('"') + 1);
                        PageURL = PageURL.Remove(PageURL.IndexOf('"'));
                    }
                    else if (stringitem.IndexOf("<img") != -1)
                    {
                        Image = stringitem.Remove(0, stringitem.IndexOf('"') + 3);
                        Image = Image.Remove(Image.IndexOf('"'));
                        Image = "https://" + Image;
                    }
                    else if (stringitem.IndexOf("<p class=\"name\"") != -1)
                    {
                        Name = stringitem.Remove(0, stringitem.IndexOf('>') + 1);
                        Name = Name.Remove(Name.IndexOf('<'));
                    }
                    else if (stringitem.IndexOf("<p class=\"post-stamp\"") != -1)
                    {
                        Info = stringitem.Remove(0, stringitem.IndexOf('>') + 1);
                        Info = Info.Remove(Info.IndexOf('<'));
                    }
                    else if (stringitem.IndexOf("icon ion-star") != -1)
                    {
                        SponserImage = "★";
                    }
                    else if (stringitem.IndexOf("ion-play") != -1)
                    {
                        Runtime = stringitem.Remove(0, stringitem.IndexOf("ion-play") + 15);
                        Runtime = Runtime.Remove(Runtime.IndexOf('<'));
                    }
                }

                if (Name == null)
                {
                    break;
                }
                AllEpisodes.Add(new Episodes(Name, Image, Runtime, Info, SponserImage, PageURL));
            }
            return AllEpisodes;
        }

        private static List<Episodes> FromSeasonPage(string Webpage)
        {
            List<Episodes> AllEpisodes = new List<Episodes>();
            List<string> AllLinks = new List<string>();
            List<int> LinkIndexs = new List<int>();
            int index = Webpage.IndexOf("pull-right");
            while (index != -1)
            {
                LinkIndexs.Add(index);
                index = Webpage.IndexOf("pull-right", index + "pull-right".Length);
            }
            return AllEpisodes;
        }
    }
}
