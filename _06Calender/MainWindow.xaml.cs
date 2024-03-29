﻿using System;
using System.Collections.Generic;
using System.IO;
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

namespace _06Calender
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

        private void SaveEvents() 
        {
            try
            {
                StreamWriter sw = new StreamWriter(
                    cldDate.SelectedDate.ToString().Replace('/', ' ').Remove(9));
                for (int i = 0; i < lbxEvents.Items.Count; i++)
                {
                    sw.WriteLine(lbxEvents.Items[i]);
                }
                sw.Close();

            }
            catch (Exception)
            {

            }
        }
        private void cldDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader(
               cldDate.SelectedDate.ToString().Replace('/', ' ').Remove(9));
                while (!sr.EndOfStream)
                {
                    lbxEvents.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            catch (Exception ex)
            {

            }
           
        }

        private void lbxEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDelete.IsEnabled = true;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string item = txbTime.Text + " : " + txbName.Text;
            lbxEvents.Items.Add(item);
            SaveEvents();
        } 
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            lbxEvents.Items.Remove(lbxEvents.SelectedItem);
            SaveEvents();
        }
    }
}
