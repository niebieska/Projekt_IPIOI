﻿#pragma checksum "..\..\FiltryXY.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6F0188EF90F58205D6AC7B4B1C724F4269F3E4421182DC0AC0E31432B80579FD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using AnalizaMorfologicznaObrazow_WPF;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace AnalizaMorfologicznaObrazow_WPF {
    
    
    /// <summary>
    /// FiltryXY
    /// </summary>
    public partial class FiltryXY : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\FiltryXY.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImgPhoto;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\FiltryXY.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnLoad;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\FiltryXY.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox XFilter;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\FiltryXY.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox YFilter;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\FiltryXY.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImgResult;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\FiltryXY.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnApply;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\FiltryXY.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider ThresholdSlider;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\FiltryXY.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSaveResult;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AnalizaMorfologicznaObrazow_WPF;component/filtryxy.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\FiltryXY.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ImgPhoto = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.BtnLoad = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\FiltryXY.xaml"
            this.BtnLoad.Click += new System.Windows.RoutedEventHandler(this.BtnLoad_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.XFilter = ((System.Windows.Controls.ListBox)(target));
            return;
            case 4:
            this.YFilter = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.ImgResult = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.BtnApply = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\FiltryXY.xaml"
            this.BtnApply.Click += new System.Windows.RoutedEventHandler(this.BtnApply_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ThresholdSlider = ((System.Windows.Controls.Slider)(target));
            return;
            case 8:
            this.BtnSaveResult = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\FiltryXY.xaml"
            this.BtnSaveResult.Click += new System.Windows.RoutedEventHandler(this.BtnSaveResult_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
