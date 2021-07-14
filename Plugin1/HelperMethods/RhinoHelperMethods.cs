using Rhino;
using Rhino.DocObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin1.HelperMethods
{
    public static class RhinoHelperMethods
    {
        public static int GetLayerIndex(RhinoDoc doc, string layerName,Color c)
        {
            if (String.IsNullOrEmpty(layerName)||!Layer.IsValidName(layerName))
            {
                return 0;
            }
            else
            {
                var layer = doc.Layers.FindName(layerName);
                if (layer == null)
                {
                    var layerIndex = doc.Layers.Add(layerName, c);
                    return layerIndex;
                }
                else
                {
                    return layer.Index;
                }
            }
        }
    }
}
