using System;
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
using System.Windows.Shapes;
using WpfApp1.Model;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for addDialog.xaml
    /// </summary>
    public partial class addDialog : Window
    {

        public class CloseEventArgs : EventArgs
        {
            Book Book
            {
                get;
                set;
            }
        }
        private addDialogViewModel vm;
        
        public addDialog()
        {
            InitializeComponent();
            vm = new addDialogViewModel();
            DataContext = vm;
        }

        

        void closeApp(object sender, EventArgs e)
        {
            DialogResult = false;
            vm.close();
            this.Close();
        }

        void addHandler(object sender, EventArgs e)
        {
            DialogResult = true;
            vm.Save();
            this.Close();
        }
    }
}
