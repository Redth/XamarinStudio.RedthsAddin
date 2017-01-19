 using System;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui.Content;
using MonoDevelop.Projects;
using MonoDevelop.Ide.Gui;

namespace RedthAddin
{
    public class EditProjectFileCommandHandler : CommandHandler
    {
        protected override void Run ()
        {
            var item = IdeApp.ProjectOperations.CurrentSelectedProject;

            IdeApp.OpenFiles (new [] {
                new FileOpenInformation (item.Files[0].FilePath, item.Files[0].Project)
            });
        }

        protected override void Update (CommandInfo info)
        {
            info.Enabled = true;
        }
    }
}
