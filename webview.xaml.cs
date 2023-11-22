using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            // webView.Source = "https://www.youtube.com";
            var localhtml = new HtmlWebViewSource();
            localhtml.Html = @"html><body>
                                <h1>xamarin webview</h1>
                                <p>this is my first xamarin local html</p>
                               </body></html>";
            webView.Source = localhtml;
        }
    }
}
