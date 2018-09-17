using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

using Xamarin.Forms;

namespace Fructika.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public string Version { get; private set; }
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
            IAppVersionProvider versionProvider = DependencyService.Get<IAppVersionProvider>();

            Version = $"Fructika {versionProvider.Version}";

            OpenTwitterCommand = new Command(() => Device.OpenUri(new Uri("https://twitter.com/fructika")));
        }

        public ICommand OpenTwitterCommand { get; }
    }
}