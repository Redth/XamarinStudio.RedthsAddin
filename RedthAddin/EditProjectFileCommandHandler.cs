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


			//var userp = item.UserProperties;
			//var pp = item.ProjectProperties.GetProperties();

			//var pol = item.Policies.DirectGetAll ();

			//foreach (var po in pol)
			//{
			//	if (po.PolicyType == typeof(TextStylePolicy))
			//	{
			//		var scope = po.Scope;
			//		var tsp = po.Policy as TextStylePolicy;

			//		if (tsp.TabsToSpaces)
			//		{
			//			Console.WriteLine("TABS TO SPACES");
			//		}
			//	}
			//}
			//foreach (var p in pp)
			//{
			//	Console.WriteLine(p.Name + " : " + p.Value);


			//}
			//Console.WriteLine(pp);

        }

        protected override void Update (CommandInfo info)
        {
            info.Enabled = true;
        }
    }
}
