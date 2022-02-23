using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3Panel
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        public StackPanel設定 StackPanel { get; } = new();
        public Grid設定 Grid { get; } = new();

        public class 長方形設定 : ObservableObject
        {
            double width = 64;
            public double Width { get => width; set => SetProperty(ref width, value); }
            double height = 64;
            public double Height { get => height; set => SetProperty(ref height, value); }
        }

        public class Grid設定
        {
            public 長方形設定 黒 { get; } = new();
            public 長方形設定 白 { get; } = new();
            public 長方形設定 赤 { get; } = new();
            public 長方形設定 橙 { get; } = new();
            public 長方形設定 黄 { get; } = new();

            public 長方形設定 緑 { get; } = new();
            public 長方形設定 青 { get; } = new();
            public 長方形設定 藍 { get; } = new();
            public 長方形設定 紫 { get; } = new();
        }

        public class StackPanel設定 : ObservableObject
        {
            public Orientation[] AllOrientations { get; } = new[] {Orientation.Horizontal, Orientation.Vertical};

            Orientation orientation;
            public Orientation Orientation { get => orientation; set => SetProperty(ref orientation, value); }

            public 長方形設定 赤 { get; } = new();
            public 長方形設定 橙 { get; } = new();
            public 長方形設定 黄 { get; } = new();

            public 長方形設定 緑 { get; } = new();
            public 長方形設定 青 { get; } = new();
            public 長方形設定 藍 { get; } = new();
            public 長方形設定 紫 { get; } = new();
        }
        

    }
}
