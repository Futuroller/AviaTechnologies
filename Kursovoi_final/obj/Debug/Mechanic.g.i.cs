﻿#pragma checksum "..\..\Mechanic.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C2B82C8CACCB28823F6CD3C207E4A2AD7E15BD49C5154C61032CF19A7D6B1A28"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Kursovoi_final;
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


namespace Kursovoi_final {
    
    
    /// <summary>
    /// Mechanic
    /// </summary>
    public partial class Mechanic : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\Mechanic.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchTextBox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Mechanic.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ManufacturerComboBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Mechanic.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ClearSearchButton;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Mechanic.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox PartsListBox;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\Mechanic.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ManageMaintenancesButton;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\Mechanic.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddToRequestButton;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\Mechanic.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonVihod;
        
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
            System.Uri resourceLocater = new System.Uri("/Kursovoi_final;component/mechanic.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Mechanic.xaml"
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
            this.SearchTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 30 "..\..\Mechanic.xaml"
            this.SearchTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ManufacturerComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 32 "..\..\Mechanic.xaml"
            this.ManufacturerComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ManufacturerComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ClearSearchButton = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\Mechanic.xaml"
            this.ClearSearchButton.Click += new System.Windows.RoutedEventHandler(this.ClearSearchButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.PartsListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.ManageMaintenancesButton = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\Mechanic.xaml"
            this.ManageMaintenancesButton.Click += new System.Windows.RoutedEventHandler(this.ManageMaintenancesButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.AddToRequestButton = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\Mechanic.xaml"
            this.AddToRequestButton.Click += new System.Windows.RoutedEventHandler(this.AddToRequestButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ButtonVihod = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\Mechanic.xaml"
            this.ButtonVihod.Click += new System.Windows.RoutedEventHandler(this.ButtonVihod_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

