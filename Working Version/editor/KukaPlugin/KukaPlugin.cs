using Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace KukaPlugin
{
    public class KukaPlugin:IPluginBase,ILanguageClass
    {
        public string Name
        {
            get { return "Kuka Plugin"; }
        }

        public void Loaded()
        {
           
        }

        public void Unloaded()
        {
           
        }

        public string ExtractXYZ(string positionString)
        {
            throw new NotImplementedException();
        }

        public Regex MethodRegex { get; private set; }
        public Regex FieldRegex { get; private set; }
        public Regex EnumRegex { get; private set; }
        public Regex XYZRegex { get; private set; }
        public Regex StructRegex { get; private set; }
        public Regex SignalRegex { get; private set; }
    }
}
