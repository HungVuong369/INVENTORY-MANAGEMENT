﻿#pragma checksum "..\..\..\..\..\..\..\UserControls\Cashier\CRUD\Create\Create Order\ConfirmOrder.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A949E7B52FCA9214BD65383453B7CA86263896B1"
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
    /// ConfirmOrder
    /// </summary>
    public partial class ConfirmOrder : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\..\..\..\..\..\UserControls\Cashier\CRUD\Create\Create Order\ConfirmOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lbDateCreated;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\..\..\..\UserControls\Cashier\CRUD\Create\Create Order\ConfirmOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lbOrderID;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\..\..\..\..\UserControls\Cashier\CRUD\Create\Create Order\ConfirmOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgProducts;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\..\..\..\..\UserControls\Cashier\CRUD\Create\Create Order\ConfirmOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnConfirm;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\..\..\..\..\..\UserControls\Cashier\CRUD\Create\Create Order\ConfirmOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/HungVuong_WPF_C4_B1;component/usercontrols/cashier/crud/create/create%20order/co" +
                    "nfirmorder.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\UserControls\Cashier\CRUD\Create\Create Order\ConfirmOrder.xaml"
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
            this.lbDateCreated = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.lbOrderID = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.dgProducts = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.btnConfirm = ((System.Windows.Controls.Button)(target));
            
            #line 150 "..\..\..\..\..\..\..\UserControls\Cashier\CRUD\Create\Create Order\ConfirmOrder.xaml"
            this.btnConfirm.Click += new System.Windows.RoutedEventHandler(this.btnConfirm_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 154 "..\..\..\..\..\..\..\UserControls\Cashier\CRUD\Create\Create Order\ConfirmOrder.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

