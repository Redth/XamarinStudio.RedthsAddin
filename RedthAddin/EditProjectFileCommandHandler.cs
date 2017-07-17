 using System;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui.Content;
using MonoDevelop.Projects;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Core.FileSystem;

namespace RedthAddin
{
    public class EditProjectFileCommandHandler : CommandHandler
    {
        protected override void Run ()
        {
            var item = IdeApp.ProjectOperations.CurrentSelectedProject;

            if (item != null && item.FileName != null)
                IdeApp.Workbench.OpenDocument(item.FileName, item, true);
        }

        protected override void Update (CommandInfo info)
        {
            info.Enabled = true;
        }
    }
}
