using System;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using Mono.TextEditor;
using MonoDevelop.Ide.Gui.Content;
using RedthAddin.Processors;
using MonoDevelop.Projects;

namespace RedthAddin
{
    public enum NukeBinObjCommands
    {
        Nuke,
    }

    public class ObliterateOutputCommandHandler : CommandHandler
    {
        protected override void Run ()
        {
            var item = IdeApp.ProjectOperations.CurrentSelectedItem;

            var sln = item as Solution;
            if (sln != null) {
                SolutionProcessor.NukeBinObj (sln);
                return;
            } 

            var prj = item as Project;
            if (prj != null)
                SolutionProcessor.NukeBinObj (prj);               
        }

        protected override void Update (CommandInfo info)
        {
            info.Enabled = true;
        }
    }
}
