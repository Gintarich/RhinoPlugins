using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;
using System;
using System.Collections.Generic;
using Plugin1.Clases;
using RLine = Rhino.Geometry.Line;
using static Plugin1.DataAccess.AddModelData;
using static Plugin1.HelperMethods.RhinoHelperMethods;

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
            
            List<Clases.Line> lines = new List<Clases.Line>();
            foreach (var member in mymembers)
            {

                //Start point of member line
                var start = member.Line.StartPoint.GetRhinoPoint();
                //End point of member line
                var end = member.Line.EndPoint.GetRhinoPoint();
                //Rhino Line
                RLine line = new RLine { From = start ,To = end };
                //Add attributes
                var uId = doc.Objects.AddLine(member.Line.StartPoint.GetRhinoPoint(), member.Line.EndPoint.GetRhinoPoint());
                var obj = doc.Objects.FindId(uId);
                obj.Attributes.SetUserString("Profile", member.Profile.ProfileName);
                obj.Attributes.SetUserString("Name", member.Comment);
                
            }
            foreach (var setOfMember in setsOfMembers)
            {
                //Start point of member line
                var start = setOfMember.Line.StartPoint.GetRhinoPoint();
                //End point of member line
                var end = setOfMember.Line.EndPoint.GetRhinoPoint();
                //Rhino Line
                RLine line = new RLine { From = start,To = end };
                //Add attributes
                var uId = doc.Objects.AddLine(setOfMember.Line.StartPoint.GetRhinoPoint(), setOfMember.Line.EndPoint.GetRhinoPoint());
                var obj = doc.Objects.FindId(uId);
                obj.Attributes.SetUserString("Profile", setOfMember.Members[0].Profile.ProfileName);
                obj.Attributes.SetUserString("Name", setOfMember.Members[0].Comment);
            }

           
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
