using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Plugin
{
    public interface IPluginBase
    {
        string Name { get; }
        void Loaded();
        void Unloaded();
    }

    public interface ILanguageClass
    {
        Regex MethodRegex { get; }
        Regex FieldRegex { get; }
        Regex EnumRegex { get; }
        Regex XYZRegex { get; }
        Regex StructRegex { get; }
        Regex SignalRegex { get; }

        string ExtractXYZ(string positionString);

    }

   
}
