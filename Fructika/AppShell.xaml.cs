using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Fructika
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }
        void OnShellNavigating(object sender, ShellNavigatingEventArgs e)
        {
            var events = e;
        }
    }
}
