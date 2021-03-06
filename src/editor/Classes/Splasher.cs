﻿using System.Windows;

namespace miRobotEditor.Classes
{
    public static class Splasher
    {
        public static Window Splash { private get; set; }

        public static void ShowSplash()
        {
            if (Splash != null)
            {
                Splash.Show();
            }
        }

        public static void CloseSplash()
        {
            if (Splash != null)
            {
                Splash.Close();
            }
        }
    }
}