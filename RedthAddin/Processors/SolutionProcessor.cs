using System;
using System.Linq;
using System.Collections.ObjectModel;
using MonoDevelop.Projects;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using MonoDevelop.Core.ProgressMonitoring;

namespace RedthAddin.Processors
{
    public class SolutionProcessor
    {
        /// <summary>
        /// Nukes the bin/ and obj/ folders of all projects in the solution
        /// </summary>
        /// <param name="sln">The solution.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public static void NukeBinObj (Solution sln)
        {
            if (sln == null)
                return;

            try {
                foreach (var proj in sln.GetAllProjects())
                    NukeBinObj (proj);
            } catch {

            }
        }

        public static void NukeBinObj (Project proj)
        {
            try {
                foreach (var cfg in proj.Configurations) {
                    var c = cfg as ProjectConfiguration;

                    if (Directory.Exists (c.OutputDirectory))
                        Directory.Delete (c.OutputDirectory, true);

                    if (Directory.Exists (c.IntermediateOutputDirectory))
                        Directory.Delete (c.IntermediateOutputDirectory, true);
                }
            } catch {

            }
        }
    }
}

