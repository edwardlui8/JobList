using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace JobList
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Job> jobs = new ObservableCollection<Job>();

        public MainPage()
        {
            this.InitializeComponent();

            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.indeed.co.uk/jobs?q=graduate%20software%20engineer&l=South%20East%20London,%20Greater%20London&radius=10&sort=date");

            var cards = doc.DocumentNode.SelectNodes("//a[@data-tn-element='jobTitle']");
            foreach(var card in cards)
            {
                string href = card.Attributes["href"].Value;
                jobs.Add(new Job { Title = card.InnerText, Link = "https://www.indeed.co.uk" + href });
                }
        }

        public ObservableCollection<Job> Jobs
        {
            get
            {
                return jobs;
            }
        }

        private void Link_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as HyperlinkButton;
            if (button != null)
            {
                string url = @button.Content as string;
                OpenUri(new Uri(url));
            }
        }

        private async void OpenUri(Uri uri)
        {
            await Windows.System.Launcher.LaunchUriAsync(uri);
        }
    }
}
