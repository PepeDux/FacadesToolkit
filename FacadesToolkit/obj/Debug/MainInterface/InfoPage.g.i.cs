﻿#pragma checksum "..\..\..\MainInterface\InfoPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "544E045CF869BBFE0B54873B4A3F3BBBD8FA3555B45C6D63A81FB321C1D6F3DB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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


namespace FacadesToolkit {
    
    
    /// <summary>
    /// InfoPage
    /// </summary>
    public partial class InfoPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 87 "..\..\..\MainInterface\InfoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Version;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\MainInterface\InfoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Cutting;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\MainInterface\InfoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Coordinater;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\MainInterface\InfoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SFLIB;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\..\MainInterface\InfoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Support;
        
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
            System.Uri resourceLocater = new System.Uri("/FacadesToolkit;component/maininterface/infopage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainInterface\InfoPage.xaml"
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
            this.Version = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.Cutting = ((System.Windows.Controls.Button)(target));
            
            #line 97 "..\..\..\MainInterface\InfoPage.xaml"
            this.Cutting.Click += new System.Windows.RoutedEventHandler(this.Cutting_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Coordinater = ((System.Windows.Controls.Button)(target));
            
            #line 107 "..\..\..\MainInterface\InfoPage.xaml"
            this.Coordinater.Click += new System.Windows.RoutedEventHandler(this.Coordinater_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SFLIB = ((System.Windows.Controls.Button)(target));
            
            #line 117 "..\..\..\MainInterface\InfoPage.xaml"
            this.SFLIB.Click += new System.Windows.RoutedEventHandler(this.SFLIB_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Support = ((System.Windows.Controls.Button)(target));
            
            #line 133 "..\..\..\MainInterface\InfoPage.xaml"
            this.Support.Click += new System.Windows.RoutedEventHandler(this.Support_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
