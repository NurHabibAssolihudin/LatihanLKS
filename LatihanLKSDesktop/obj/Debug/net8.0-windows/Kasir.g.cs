﻿#pragma checksum "..\..\..\Kasir.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EDC48A6701DFCB170AC8B1A55589079457BEFC07"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LatihanLKSDesktop;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace LatihanLKSDesktop {
    
    
    /// <summary>
    /// Kasir
    /// </summary>
    public partial class Kasir : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\Kasir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox input_menu;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Kasir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox input_harga_satuan;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Kasir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox input_total_harga;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Kasir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox input_quantitas;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Kasir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock id_kasir;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Kasir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagrid;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Kasir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label total_harga;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Kasir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox input_pembayaran;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Kasir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label kembalian;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/LatihanLKSDesktop;component/kasir.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Kasir.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 14 "..\..\..\Kasir.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Logout);
            
            #line default
            #line hidden
            return;
            case 2:
            this.input_menu = ((System.Windows.Controls.ComboBox)(target));
            
            #line 18 "..\..\..\Kasir.xaml"
            this.input_menu.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.PilihMenu);
            
            #line default
            #line hidden
            return;
            case 3:
            this.input_harga_satuan = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\..\Kasir.xaml"
            this.input_harga_satuan.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.InputHarga);
            
            #line default
            #line hidden
            return;
            case 4:
            this.input_total_harga = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.input_quantitas = ((System.Windows.Controls.TextBox)(target));
            
            #line 26 "..\..\..\Kasir.xaml"
            this.input_quantitas.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.InputQuantitas);
            
            #line default
            #line hidden
            return;
            case 6:
            this.id_kasir = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            
            #line 28 "..\..\..\Kasir.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.InsertIntoKeranjang);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 29 "..\..\..\Kasir.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ResetDatagrid);
            
            #line default
            #line hidden
            return;
            case 9:
            this.datagrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 10:
            this.total_harga = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.input_pembayaran = ((System.Windows.Controls.TextBox)(target));
            
            #line 43 "..\..\..\Kasir.xaml"
            this.input_pembayaran.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.InputPembayaran);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 44 "..\..\..\Kasir.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveTransaksi);
            
            #line default
            #line hidden
            return;
            case 13:
            this.kembalian = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

