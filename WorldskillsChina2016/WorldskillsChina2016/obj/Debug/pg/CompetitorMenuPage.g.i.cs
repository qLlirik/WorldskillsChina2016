﻿#pragma checksum "..\..\..\pg\CompetitorMenuPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "13FCC16CD634889D1D769717614CDDDA"
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
using WorldskillsChina2016.pg;


namespace WorldskillsChina2016.pg {
    
    
    /// <summary>
    /// CompetitorMenuPage
    /// </summary>
    public partial class CompetitorMenuPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\pg\CompetitorMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Run txbDayTime;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\pg\CompetitorMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Run txbGenderHi;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\pg\CompetitorMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Run txbName;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\pg\CompetitorMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgUserImage;
        
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
            System.Uri resourceLocater = new System.Uri("/WorldskillsChina2016;component/pg/competitormenupage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\pg\CompetitorMenuPage.xaml"
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
            this.txbDayTime = ((System.Windows.Documents.Run)(target));
            return;
            case 2:
            this.txbGenderHi = ((System.Windows.Documents.Run)(target));
            return;
            case 3:
            this.txbName = ((System.Windows.Documents.Run)(target));
            return;
            case 4:
            this.imgUserImage = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            
            #line 34 "..\..\..\pg\CompetitorMenuPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.click_MyProfile);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 35 "..\..\..\pg\CompetitorMenuPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.click_MySkills);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 36 "..\..\..\pg\CompetitorMenuPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.click_MyResults);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

