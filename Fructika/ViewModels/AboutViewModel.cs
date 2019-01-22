using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

using Xamarin.Forms;

namespace Fructika.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public IEnumerable<string> ImageAttributions => (new string[]
        {
                "@nhillier",
                "@mjtangonan",
                "@jonathanpielmayer",
                "@georgiavagim",
                "@mero_dnt",
                "@promotion",
                "@unibodies",
                "@jorgezapatag",
                "@daviidstreit",
                "@neonbrand",
                "@the_alp_photography",
                "@sylvanusurban",
                "@danielcgold",
                "@daen_2chinda",
                "@oldskool2016",
                "@m15ky",
                "@heftiba",
                "@romankraft",
                "@eaterscollective",
                "@foodiesfeed",
                "@miroslava"
        }).OrderBy(c => c);

        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
    }
}