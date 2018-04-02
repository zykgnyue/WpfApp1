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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        internal Student stu = null;
        public MainWindow()
        {
            InitializeComponent();
            stu = new Student();

            //here binding DataContext, in Xaml binding data path
            //Test Push Second time
            textBlkDetail.DataContext = this.stu;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            Binding bindingTextbox = new Binding();
            //****** binding object setting
            //bingding source
            bindingTextbox.Source = this.stu;
            //binding property Name
            bindingTextbox.Path = new PropertyPath("LastName");
            //Binding mode:twoWay
            bindingTextbox.Mode = BindingMode.TwoWay;

            //default updatetrigger is Tetxbox lost focus
            //below is to trigger update when Text changed
            bindingTextbox.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            //*******binding Target object's property with source property
            this.textBoxLastName.SetBinding(TextBox.TextProperty, bindingTextbox);
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            //Data flow Source to target
            stu.LastName += " #Source to Target# ";
            
        }

        private void buttonTarget2Source_Click(object sender, RoutedEventArgs e)
        {

            textBoxLastName.Text += "@Target2Source@ ";
            

        }

        private void textBoxLastName_LostFocus(object sender, RoutedEventArgs e)
        {
            string x = textBoxLastName.Text;
        }

        private void buttonStudentDetail_Click(object sender, RoutedEventArgs e)
        {
            WindowStudentDetail win1 = new WindowStudentDetail(this);
            //win1 below will not block MainWindow until win1 closed
            win1.Show();

            //win1 below will block MainWindow until win1 closed
            //win1.ShowDialog();
        }
    }
}
