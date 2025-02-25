﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace To_Do_List
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_Task_Click(object sender, RoutedEventArgs e)
        {
            if (TaskInput.Text != "")
            {
                TaskList.Items.Add(TaskInput.Text);
                TaskInput.Text = "";
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(TaskList.SelectedItem!=null)
            {
                TaskList.Items.Remove(TaskList.SelectedItem);
            }
        }
    }
}
