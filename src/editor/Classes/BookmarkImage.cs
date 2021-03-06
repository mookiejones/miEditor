﻿using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using miRobotEditor.Interfaces;

namespace miRobotEditor.Classes
{
    public sealed class BookmarkImage : IImage
    {
        private readonly IImage _baseimage = null;
        private readonly BitmapImage _bitmap;

        public BookmarkImage(BitmapImage bitmap)
        {
            _bitmap = bitmap;
        }

        public ImageSource ImageSource
        {
            get { return _baseimage.ImageSource; }
        }

        public BitmapImage Bitmap
        {
            get { return _bitmap; }
        }

        public Icon Icon
        {
            get { return _baseimage.Icon; }
        }
    }
}