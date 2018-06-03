using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Hu_s_WindowExplorer
{
    /// <summary>
    /// TopBar.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TopBar : UserControl
    {
        MainPage mainPage;
        Stack<string> backStack;
        Stack<string> forwardStack;
        string path;

        public TopBar()
        {
            InitializeComponent();

            pathTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            backStack = new Stack<string>();
            forwardStack = new Stack<string>();
        }

        public void SetMainPage(MainPage main)
        {
            mainPage = main;
        }

        public void ClearForwardStack()
        {
            forwardStack.Clear();
        }
        private void PathTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
            {
                if (Directory.Exists(pathTextBox.Text))
                {
                    backStack.Push(path);
                    ClearForwardStack();
                    mainPage.SetMainPage(pathTextBox.Text);
                    path = pathTextBox.Text;
                    mainPage.SetPath(path);
                }
            }
        }

        public void AddBackList(string path)
        {
            backStack.Push(path);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if(backStack.Count > 0)
            {
                if (!pathTextBox.Text.Equals(backStack.Peek()))
                {
                    forwardStack.Push(pathTextBox.Text);
                    pathTextBox.Text = backStack.Peek();
                    path = backStack.Peek();
                    mainPage.SetPath(path);

                    mainPage.SetMainPage(backStack.Pop());
                }
            }
        }

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            if(forwardStack.Count > 0)
            {
                if (!pathTextBox.Text.Equals(forwardStack.Peek()))
                {
                    backStack.Push(pathTextBox.Text);
                    pathTextBox.Text = forwardStack.Peek();
                    path = forwardStack.Peek();
                    mainPage.SetPath(path);

                    mainPage.SetMainPage(forwardStack.Pop());
                }
            }
        }

        private void ParentButton_Click(object sender, RoutedEventArgs e)
        {
            if (!path.Equals(System.IO.Path.GetPathRoot(path)))
            {
                backStack.Push(path);
                path = Directory.GetParent(path).ToString();
                pathTextBox.Text = path;
                mainPage.SetPath(path);

                mainPage.SetMainPage(path);
            }
        }

        public void SetPath(string path)
        {
            this.path = path;
        }
    }
}
