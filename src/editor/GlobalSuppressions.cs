// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.
//
// To add a suppression to this file, right-click the message in the 
// Code Analysis results, point to "Suppress Message", and click 
// "In Suppression File".
// You do not need to add suppressions to this file manually.

using System.Diagnostics.CodeAnalysis;

[assembly:
    SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities", Scope = "member",
        Target = "miRobotEditor.ViewModel.ArchiveInfoViewModel.#GetValues(System.String,System.Int32)")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Scope = "type",
        Target = "miRobotEditor.Views.Editor")]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA2235:MarkAllNonSerializableFields", Scope = "member",
        Target = "miRobotEditor.Classes.EditorOptions.#_lineNumbersForeground")]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA2235:MarkAllNonSerializableFields", Scope = "member",
        Target = "miRobotEditor.Classes.EditorOptions.#_foldToolTipBackgroundBorderColor")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1065:DoNotRaiseExceptionsInUnexpectedLocations", Scope = "member",
        Target =
            "miRobotEditor.Controls.AngleConverter.Classes.Vector3D.#miRobotEditor.Controls.AngleConverter.Interfaces.IGeometricElement3D.Position"
        )]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times", Scope = "member",
        Target =
            "miRobotEditor.Controls.RecentFileList+XmlPersister.#Save(System.Collections.Generic.IEnumerable`1<System.String>)"
        )]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times", Scope = "member",
        Target = "miRobotEditor.Controls.RecentFileList+XmlPersister.#Load(System.Int32)")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1065:DoNotRaiseExceptionsInUnexpectedLocations", Scope = "member",
        Target =
            "miRobotEditor.Classes.Plane3D.#miRobotEditor.Controls.AngleConverter.Interfaces.IGeometricElement3D.Position"
        )]
[assembly: SuppressMessage("Microsoft.Design", "CA2210:AssembliesShouldHaveValidStrongNames")]
[assembly: SuppressMessage("Microsoft.Design", "CA1014:MarkAssembliesWithClsCompliant")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag", Scope = "member",
        Target = "miRobotEditor.ViewModel.ArchiveInfoViewModel.#FlagVisibility")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Scope = "member",
        Target =
            "miRobotEditor.Abstract.AbstractFoldingStrategy.#CreateNewFoldings(ICSharpCode.AvalonEdit.Document.TextDocument,System.Int32&)"
        )]