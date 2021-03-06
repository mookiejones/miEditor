﻿using System;
using System.IO;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using miRobotEditor.Abstract;
using miRobotEditor.Classes;
using miRobotEditor.Controls;
using miRobotEditor.Controls.TextEditor;
using miRobotEditor.Enums;
using miRobotEditor.Interfaces;
using miRobotEditor.Languages;

namespace miRobotEditor.ViewModel
{
    public sealed class KukaViewModel : DocumentBase, IEditorDocument
    {
        #region GridRow

        /// <summary>
        ///     The <see cref="GridRow" /> property's name.
        /// </summary>
        private const string GridRowPropertyName = "GridRow";

        private int _gridrow = 1;

        /// <summary>
        ///     Sets and gets the GridRow property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public int GridRow
        {
            get { return _gridrow; }

            set
            {
                if (_gridrow == value)
                {
                    return;
                }

// ReSharper disable once ExplicitCallerInfoArgument
                
                _gridrow = value;
// ReSharper disable once ExplicitCallerInfoArgument
                RaisePropertyChanged(GridRowPropertyName);
            }
        }

        #endregion

        #region ToggleGridCommand

        private RelayCommand _toggleGridCommand;

        /// <summary>
        ///     Gets the ToggleGridCommand.
        /// </summary>
        public RelayCommand ToggleGridCommand
        {
            get
            {
                return _toggleGridCommand
                       ?? (_toggleGridCommand = new RelayCommand(ToggleGrid, CanToggleGrid));
            }
        }


        public bool CanToggleGrid()
        {
            return Grid != null;
        }

        #endregion

        #region Grid

        /// <summary>
        ///     The <see cref="Grid" /> property's name.
        /// </summary>
        private const string GridPropertyName = "Grid";

        private ExtendedGridSplitter _grid = new ExtendedGridSplitter();

        /// <summary>
        ///     Sets and gets the Grid property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public ExtendedGridSplitter Grid
        {
            get { return _grid; }

            set
            {
                if (Equals(_grid, value))
                {
                    return;
                }

// ReSharper disable once ExplicitCallerInfoArgument
                
                _grid = value;
// ReSharper disable once ExplicitCallerInfoArgument
                RaisePropertyChanged(GridPropertyName);
            }
        }

        #endregion

        #region Source

        /// <summary>
        ///     The <see cref="Source" /> property's name.
        /// </summary>
        private const string SourcePropertyName = "Source";

        private Editor _source = new Editor();

        /// <summary>
        ///     Sets and gets the Source property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public Editor Source
        {
            get { return _source; }

            set
            {
                if (Equals(_source, value))
                {
                    return;
                }

// ReSharper disable once ExplicitCallerInfoArgument
                
                _source = value;
// ReSharper disable once ExplicitCallerInfoArgument
                RaisePropertyChanged(SourcePropertyName);
            }
        }

        #endregion

        #region Data

        /// <summary>
        ///     The <see cref="Data" /> property's name.
        /// </summary>
        private const string DataPropertyName = "Data";

        private Editor _data = new Editor();

        /// <summary>
        ///     Sets and gets the Data property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public Editor Data
        {
            get { return _data; }

            set
            {
                if (Equals(_data, value))
                {
                    return;
                }

// ReSharper disable once ExplicitCallerInfoArgument
                
                _data = value;
// ReSharper disable once ExplicitCallerInfoArgument
                RaisePropertyChanged(DataPropertyName);
            }
        }

        #endregion

        #region DataRow

        /// <summary>
        ///     The <see cref="DataRow" /> property's name.
        /// </summary>
        private const string DataRowPropertyName = "DataRow";

        private int _dataRow = 2;

        /// <summary>
        ///     Sets and gets the DataRow property.
        ///     Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public int DataRow
        {
            get { return _dataRow; }

            set
            {
                if (_dataRow == value)
                {
                    return;
                }

// ReSharper disable once ExplicitCallerInfoArgument
                
                _dataRow = value;
// ReSharper disable once ExplicitCallerInfoArgument
                RaisePropertyChanged(DataRowPropertyName);
            }
        }

        #endregion

        public KukaViewModel(string filepath, AbstractLanguageClass lang)
            : base(filepath, lang)
        {
            Grid.Loaded += Grid_Loaded;
            ShowGrid = false;
            FileLanguage = lang;
            Source.FileLanguage = FileLanguage;
            Data.FileLanguage = FileLanguage;
            Source.GotFocus += (s, e) => TextBox = (s as Editor);
            Data.GotFocus += (s, e) => TextBox = (s as Editor);
            Source.TextChanged += (s, e) => TextChanged(s);
            Data.TextChanged += (s, e) => TextChanged(s);
            Source.IsModified = false;
            Data.IsModified = false;
        }

        private bool ShowGrid
        {
            set
            {
                switch (value)
                {
                    case false:
                        if (Data == null)
                        {
                            Data = new Editor();
                        }
                        Data.Visibility = Visibility.Collapsed;
                        Grid.Visibility = Visibility.Collapsed;
                        break;
                    case true:
                        Data.Text = FileLanguage.DataText;
// ReSharper disable once AssignNullToNotNullAttribute
                        Data.Filename = Path.Combine(Path.GetDirectoryName(FileName), FileLanguage.DataName);
                        Data.SetHighlighting();
                        Data.Visibility = Visibility.Visible;
                        Grid.Visibility = Visibility.Visible;
                        GridRow = 1;
                        DataRow = 2;
                        break;
                }
            }
        }

        public static KukaViewModel Instance { get; set; }

        public new void SelectText(IVariable var)
        {
            if (var.Name == null)
            {
                throw new ArgumentNullException("var");
            }
            if (TextBox.Variables == null)
            {
                SwitchTextBox();
            }
            var flag = TextBox.Text.Length >= var.Offset;
            if (flag)
            {
                TextBox.SelectText(var);
            }
            else
            {
                TextBox = Data;
                flag = (TextBox.Text.Length >= var.Offset);
                if (flag)
                {
                    TextBox.SelectText(var);
                }
            }
        }

        public override void Close()
        {
            CheckClose(Source);
            CheckClose(Data);
        }

        public override void Load(string filepath)
        {
            FilePath = filepath;
            Instance = this;

            //TODO Is this right?
            TextBox.FileLanguage = FileLanguage;
            FileLanguage = TextBox.FileLanguage;
            Source.FileLanguage = FileLanguage;
            Grid.IsAnimated = false;
            var flag = Path.GetExtension(filepath) == ".dat";
            IconSource = Utilities.LoadBitmap(Global.ImgSrc);
            Source.Filename = filepath;
            Source.SetHighlighting();
            Source.Text = (flag ? FileLanguage.DataText : FileLanguage.SourceText);
            if (FileLanguage is KUKA && !String.IsNullOrEmpty(FileLanguage.DataText) &&
                Source.Text != FileLanguage.DataText)
            {
                ShowGrid = true;
                Data.FileLanguage = FileLanguage;
// ReSharper disable once AssignNullToNotNullAttribute
                Data.Filename = Path.Combine(Path.GetDirectoryName(filepath), FileLanguage.DataName);
                Data.Text = FileLanguage.DataText;
                Data.SetHighlighting();
            }
            TextBox = ((Source.Filename == filepath) ? Source : Data);
            Grid.IsAnimated = true;
// ReSharper disable once ExplicitCallerInfoArgument
            RaisePropertyChanged("Title");
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Grid.IsAnimated = false;
            Grid.Collapse();
            Grid.IsCollapsed = true;
            Grid.IsAnimated = true;
        }

        private void CheckClose(Editor txtBox)
        {
            if (txtBox != null && txtBox.IsModified)
            {
                var messageBoxResult =
                    MessageBox.Show(string.Format("Save changes for file '{0}'?", txtBox.Filename), "miRobotEditor",
                        MessageBoxButton.YesNoCancel);
                if (messageBoxResult != MessageBoxResult.Cancel)
                {
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        Save(txtBox);
                    }
                }
            }
        }

        private void SwitchTextBox()
        {
            switch (TextBox.EditorType)
            {
                case EDITORTYPE.SOURCE:
                    TextBox = Data;
                    break;
                case EDITORTYPE.DATA:
                    TextBox = Source;
                    break;
            }
        }

        private void ToggleGrid()
        {
            if (Grid.IsCollapsed)
            {
                Grid.Expand();
            }
            else
            {
                Grid.Collapse();
            }
        }
    }
}