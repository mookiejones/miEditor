﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.CodeCompletion;
using System.Text.RegularExpressions;
using miRobotEditor.ViewModel;

namespace miRobotEditor.Languages
{
    [Localizable(false)]
    public class LanguageBase : AbstractLanguageClass
    {
    	public LanguageBase(){}
    	public LanguageBase(string file):base(file)
    	{    		
    	}

        internal override bool IsFileValid(FileInfo file)
        {
            return false;
        }

        public override DocumentViewModel GetFile(string filename)
        {
            return new DocumentViewModel(filename);
        }

    	#region Properties
        /// <summary>
        /// Sets ComboBox Filter Items for searching
        /// </summary>
        /// <returns></returns>
        public override List<string> SearchFilters
        {
            get
            {
               return DefaultSearchFilters;
            }
        }

        /// <summary>
        /// Sets ComboBox Filter Items for searching
        /// </summary>
        /// <returns></returns>
        public static List<string> DefaultSearchFilters
        {
            get
            {
                return new List<string> { "*.*" };
            }
        }

        #endregion

        internal override string FoldTitle(FoldingSection section, ICSharpCode.AvalonEdit.Document.TextDocument doc)
        {
            if (doc == null) throw new ArgumentNullException("doc");
            var s = Regex.Split(section.Title, "æ");

            var start = section.StartOffset + s[0].Length;
           // var end = section.Length - (s[0].Length + s[1].Length);
            var end = section.Length - s[0].Length;//eval.IndexOf(s[1]);

            return doc.GetText(start, end);
        }


        internal override Typlanguage RobotType { get { return Typlanguage.None; } }

        internal override string FunctionItems
        {
            get { return string.Empty; }
        }

        internal override AbstractFoldingStrategy FoldingStrategy{ get; set; }

        protected override string ShiftRegex
        {
            get { throw new NotImplementedException(); }
        }

        internal override string SourceFile
        {
            get { throw new NotImplementedException(); }
        }

       
        #region Code Completion Section
            internal override IList<ICompletionData> CodeCompletion
        {
            get
            {
                var codeCompletionList = new List<ICompletionData> {new CodeCompletion("Item1")};
                return codeCompletionList;
            }
        }
        #endregion

            
            #region Regular Expressions
            public override Regex MethodRegex {get {return new Regex(String.Empty);}}
    	
		public override Regex StructRegex {get {return new Regex(String.Empty);}}
    	
		public override Regex FieldRegex{get {return new Regex(String.Empty);}}
    	
		public override Regex EnumRegex {get {return new Regex(String.Empty);}}
    	
		public override string CommentChar {
			get {
				throw new NotImplementedException();
			}
		}

        public override Regex SignalRegex { get { return new Regex(String.Empty); } }
        public override string ExtractXYZ(string positionstring)
        {
            var p = new PositionBase(positionstring);
            return p.ExtractFromMatch();
        }

        public override Regex XYZRegex { get { return new Regex(String.Empty); } }
            #endregion
    }
}
