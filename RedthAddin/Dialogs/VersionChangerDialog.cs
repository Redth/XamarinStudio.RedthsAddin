using System;
using MonoDevelop.Projects;
using MonoDevelop.Core.ProgressMonitoring;
using System.Threading.Tasks;
using System.Collections.Generic;
using Gdk;

namespace RedthAddin.Dialogs
{
    public partial class VersionChangerDialog : Gtk.Dialog
    {
        public VersionChangerDialog ()
        {
            this.Build ();
        }
    }
}
