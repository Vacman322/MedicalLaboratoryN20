﻿#pragma checksum "..\..\..\..\Windows\LaborantResearcher\LaborantResearcherWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D68B589D5C813CB9923E0D1043D76DFC810595BC5E5702827EB069C6C780D1FA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MedicalLaboratoryN20.Windows.LaborantResearcher;
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


namespace MedicalLaboratoryN20.Windows.LaborantResearcher {
    
    
    /// <summary>
    /// LaborantResearcherWindow
    /// </summary>
    public partial class LaborantResearcherWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\..\Windows\LaborantResearcher\LaborantResearcherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TimerTB;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Windows\LaborantResearcher\LaborantResearcherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock FioTB;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Windows\LaborantResearcher\LaborantResearcherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock RoleTB;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Windows\LaborantResearcher\LaborantResearcherWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image AvatarImage;
        
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
            System.Uri resourceLocater = new System.Uri("/MedicalLaboratoryN20;component/windows/laborantresearcher/laborantresearcherwind" +
                    "ow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\LaborantResearcher\LaborantResearcherWindow.xaml"
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
            this.TimerTB = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.FioTB = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.RoleTB = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.AvatarImage = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            
            #line 52 "..\..\..\..\Windows\LaborantResearcher\LaborantResearcherWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ExitClick);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 60 "..\..\..\..\Windows\LaborantResearcher\LaborantResearcherWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AnalyzerClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

