﻿#pragma checksum "..\..\..\..\..\UserControls\Stocker\Views\ucViewDetailReceipt.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DD0BF830161E9AA415E75437CDB662600779EE38"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HungVuong_WPF_C4_B1;
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


namespace HungVuong_WPF_C4_B1 {
    
    
    /// <summary>
    /// ucViewDetailReceipt
    /// </summary>
    public partial class ucViewDetailReceipt : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\..\UserControls\Stocker\Views\ucViewDetailReceipt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbFeature;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\..\UserControls\Stocker\Views\ucViewDetailReceipt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DatePicker;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\..\UserControls\Stocker\Views\ucViewDetailReceipt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtInput;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\..\UserControls\Stocker\Views\ucViewDetailReceipt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnView;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\..\UserControls\Stocker\Views\ucViewDetailReceipt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgDetailReceipt;
        
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
            System.Uri resourceLocater = new System.Uri("/HungVuong_WPF_C4_B1;component/usercontrols/stocker/views/ucviewdetailreceipt.xam" +
                    "l", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\UserControls\Stocker\Views\ucViewDetailReceipt.xaml"
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
            this.cbFeature = ((System.Windows.Controls.ComboBox)(target));
            
            #line 30 "..\..\..\..\..\UserControls\Stocker\Views\ucViewDetailReceipt.xaml"
            this.cbFeature.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbFeature_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.txtInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnView = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\..\..\UserControls\Stocker\Views\ucViewDetailReceipt.xaml"
            this.btnView.Click += new System.Windows.RoutedEventHandler(this.btnView_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dgDetailReceipt = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

