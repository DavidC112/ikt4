using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IKT_Project_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int size;
        public MainWindow()
        {
            InitializeComponent();
            Size.Items.Add(3);
            Size.Items.Add(4);
            Size.Items.Add(5);
            Size.SelectedIndex = 0;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Window2 win2 = new Window2();
            win2.Show();
            this.Close();
        }

        private void Size_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            size = (int)Size.SelectedItem;
        }
    }
}
