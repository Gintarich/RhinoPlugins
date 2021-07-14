using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;
using System;
using System.Collections.Generic;
using Plugin1.Clases;
using static Plugin1.DataAccess.AddModelData;

namespace Plugin1
{
    public class ImportRfmModel : Command
    {
        public ImportRfmModel()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static ImportRfmModel Instance { get; private set; }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName => "ImportRfmModel";

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            string folderPath = @"Z:\DARBS\2021\PROJEKTI\ARA_2021_L06_BK0_PAMATI_angars_MUIZAS_3_K_BEDRITIS_JF\3_KONSTRUKCIJAS\3_Teklas modeli\GH_FAILI\References\2021.07.21_Ramis_3D_KOPNU_SHEMA\";
            
            (var mymembers, var setsOfMembers) = GetModel(folderPath);
            #region Test1
            //Populate nodes
            var nodes = GetNodes(folderPath);
            //populate lines
            var lines = GetLines(folderPath);
            //populate members
            var members = GetMembers(folderPath);
            //populate sets of members

            //Convert model from meters to milimeters, flip it and get rhino Points out of it
            foreach (Node node in nodes)
            {
                node.Magnify();
                node.Flip();
            }

            //Add Node objec to line object
            foreach (var line in lines)
            {
                line.PopulateNodes(nodes);
            }

            //Add Line object to Member object
            foreach (var member in members)
            {
                member.PopulateLines(lines);
            }
            foreach (var line in lines)
            {
                doc.Objects.AddLine(line.StartPoint.GetRhinoPoint(), line.EndPoint.GetRhinoPoint());
            }
            #endregion





            doc.Views.Redraw();
            // TODO: start here modifying the behaviour of your command.
            // ---
            //RhinoApp.WriteLine("The {0} command will add a line right now.", EnglishName);
            //
            //Point3d pt0;
            //using (GetPoint getPointAction = new GetPoint())
            //{
            //    getPointAction.SetCommandPrompt("Please select the start point");
            //    if (getPointAction.Get() != GetResult.Point)
            //    {
            //        RhinoApp.WriteLine("No start point was selected.");
            //        return getPointAction.CommandResult();
            //    }
            //    pt0 = getPointAction.Point();
            //}
            //
            //Point3d pt1;
            //using (GetPoint getPointAction = new GetPoint())
            //{
            //    getPointAction.SetCommandPrompt("Please select the end point");
            //    getPointAction.SetBasePoint(pt0, true);
            //    getPointAction.DynamicDraw +=
            //      (sender, e) => e.Display.DrawLine(pt0, e.CurrentPoint, System.Drawing.Color.DarkRed);
            //    if (getPointAction.Get() != GetResult.Point)
            //    {
            //        RhinoApp.WriteLine("No end point was selected.");
            //        return getPointAction.CommandResult();
            //    }
            //    pt1 = getPointAction.Point();
            //}
            //
            //doc.Objects.AddLine(pt0, pt1);
            //doc.Views.Redraw();
            //RhinoApp.WriteLine("The {0} command added one line to the document.", EnglishName);

            // ---
            return Result.Success;
        }
    }
}
