﻿using System;
using System.Windows;
using System.Windows.Controls;

namespace Hu_s_WindowExplorer
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        SideBar sideBar;
        MainPage mainPage;
        TopBar topBar;

        public MainWindow()
        {
            InitializeComponent();
            sideBar = new SideBar();
            topBar = new TopBar();
            mainPage = new MainPage();
            mainPage.SetTopBar(topBar);
            sideBar.SetMainPageAndTopBar(mainPage,topBar);
            topBar.SetMainPage(mainPage);

            Grid.SetColumn(mainPage, 1);
            Grid.SetRow(topBar, 0);

            mainPage.SetMainPage(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            topBar.pathTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            subGrid.Children.Add(sideBar);
            subGrid.Children.Add(mainPage);
            mainGrid.Children.Add(topBar);
            sideBar.MakeTreeView();
        }
        
    }
}
