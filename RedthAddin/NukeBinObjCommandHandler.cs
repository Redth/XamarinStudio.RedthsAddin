using System;
using System.IO;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui.Content;
using MonoDevelop.Projects;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Core;
using MonoDevelop.Core.Execution;
using MonoDevelop.Core.ProgressMonitoring;

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
            var progressMonitor = IdeApp.Workbench.ProgressMonitors.GetStatusProgressMonitor("Obliterating Output Paths...", Stock.StatusSolutionOperation, false, true, false);

            System.Threading.Tasks.Task.Run(() => {
               try {
                   var item = IdeApp.ProjectOperations.CurrentSelectedItem;

                   var sln = item as Solution;
                   if (sln != null) {
                       foreach (var proj in sln.GetAllProjects())
                           NukeBinObj(proj);
                   } else {
                       var prj = item as Project;
                       if (prj != null)
                           NukeBinObj(prj);
                   }

                   progressMonitor.ReportSuccess("Obliterated Output Paths!");
                   progressMonitor.Dispose();
                }
                catch { }
            });
        }

        protected override void Update (CommandInfo info)
        {
            info.Enabled = true;
        }

        public static void NukeBinObj(Project proj)
        {
            try {
                foreach (var cfg in proj.Configurations) {
                    var c = cfg as ProjectConfiguration;

                    if (Directory.Exists(c.OutputDirectory))
                        Directory.Delete(c.OutputDirectory, true);

                    if (Directory.Exists(c.IntermediateOutputDirectory))
                        Directory.Delete(c.IntermediateOutputDirectory, true);
                }
            } catch { }
        }
    }
}
