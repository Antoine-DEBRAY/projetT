﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F9F7424AF7E223F8A48918A05305B2577A7CE2CE4190BF12A6F9934D5CE05ACB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

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
using appliWPFBDDpersonnels;


namespace appliWPFBDDpersonnels {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listeviewPersonnels;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboboxFonctions;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox inputNom;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button boutonQuitter;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboboxServices;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelServices;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelFonctions;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imagePersonnels;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelPersonnels;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelService;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelFonction;
        
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
            System.Uri resourceLocater = new System.Uri("/appliWPFBDDpersonnels;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.listeviewPersonnels = ((System.Windows.Controls.ListView)(target));
            
            #line 12 "..\..\MainWindow.xaml"
            this.listeviewPersonnels.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listeviewPersonnels_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.comboboxFonctions = ((System.Windows.Controls.ComboBox)(target));
            
            #line 19 "..\..\MainWindow.xaml"
            this.comboboxFonctions.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.comboboxFonctions_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 19 "..\..\MainWindow.xaml"
            this.comboboxFonctions.MouseEnter += new System.Windows.Input.MouseEventHandler(this.comboboxFonctions_MouseEnter);
            
            #line default
            #line hidden
            
            #line 19 "..\..\MainWindow.xaml"
            this.comboboxFonctions.IsMouseDirectlyOverChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.comboboxFonctions_IsMouseDirectlyOverChanged);
            
            #line default
            #line hidden
            
            #line 19 "..\..\MainWindow.xaml"
            this.comboboxFonctions.Initialized += new System.EventHandler(this.comboboxFonctions_Initialized);
            
            #line default
            #line hidden
            return;
            case 3:
            this.inputNom = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\MainWindow.xaml"
            this.inputNom.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.inputNom_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.boutonQuitter = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\MainWindow.xaml"
            this.boutonQuitter.Click += new System.Windows.RoutedEventHandler(this.boutonQuitter_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.comboboxServices = ((System.Windows.Controls.ComboBox)(target));
            
            #line 22 "..\..\MainWindow.xaml"
            this.comboboxServices.MouseEnter += new System.Windows.Input.MouseEventHandler(this.comboboxServices_MouseEnter);
            
            #line default
            #line hidden
            
            #line 22 "..\..\MainWindow.xaml"
            this.comboboxServices.IsMouseDirectlyOverChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.comboboxServices_IsMouseDirectlyOverChanged);
            
            #line default
            #line hidden
            
            #line 22 "..\..\MainWindow.xaml"
            this.comboboxServices.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.comboboxServices_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 22 "..\..\MainWindow.xaml"
            this.comboboxServices.Initialized += new System.EventHandler(this.comboboxServices_Initialized);
            
            #line default
            #line hidden
            return;
            case 6:
            this.labelServices = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.labelFonctions = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.imagePersonnels = ((System.Windows.Controls.Image)(target));
            return;
            case 9:
            this.labelPersonnels = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.labelService = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.labelFonction = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

