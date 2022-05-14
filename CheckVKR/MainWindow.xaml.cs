using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace CheckVKR
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

        /// <summary>
        /// Открытия диалогового окна и обработка выбора файлов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFile(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Filter = "Doc files (*.docx)|*.docx| All files (*.*)|*.*"
            };
            
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (var path in openFileDialog.FileNames)
                {
                    var btnForOpenFile = new Button
                    {
                        Content = Path.GetFileName(path),
                        Width = 200,
                        Height = 40
                    };

                    StackOpenFiles.Items.Add(btnForOpenFile);
                    StackOpenFiles.Items.Remove(StartLabelforErrors);
                }
            }
        }
    }
}