﻿#pragma checksum "..\..\FindPassword.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FA6D9BD51F29BAB879F093C8DAC5CCF9A1C088AC"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using Hu_s_SignUp;
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


namespace Hu_s_SignUp {
    
    
    /// <summary>
    /// FindPassword
    /// </summary>
    public partial class FindPassword : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\FindPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label title;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\FindPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label answer;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\FindPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox idTextBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\FindPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox emailTextBox;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\FindPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button emailButton;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\FindPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid confirmPanel;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\FindPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox confirmTextBox;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\FindPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button checkNumberButton;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\FindPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label timerLabel;
        
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
            System.Uri resourceLocater = new System.Uri("/Hu_s_SignUp;component/findpassword.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\FindPassword.xaml"
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
            this.title = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.answer = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.idTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\FindPassword.xaml"
            this.idTextBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.TextBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.emailTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\FindPassword.xaml"
            this.emailTextBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.TextBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.emailButton = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\FindPassword.xaml"
            this.emailButton.Click += new System.Windows.RoutedEventHandler(this.EmailButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.confirmPanel = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.confirmTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\FindPassword.xaml"
            this.confirmTextBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.TextBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.checkNumberButton = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\FindPassword.xaml"
            this.checkNumberButton.Click += new System.Windows.RoutedEventHandler(this.CheckNumberButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.timerLabel = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

