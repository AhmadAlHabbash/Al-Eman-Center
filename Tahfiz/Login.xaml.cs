using System;
using System.Windows;
using System.Windows.Input;
using Tahfiz.classes;

namespace Tahfiz
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        //
        // Veriables
        // 
        private bool check = false;

        //
        // Username TextBox Responce Design
        //
        private void username_textbox_MouseCapturedChange(object sender, DependencyPropertyChangedEventArgs e)
        {
            username_textbox.Opacity = 1;
            if (username_textbox.Text.Equals("انقر لإضافة نص1"))
            {
                username_textbox.Text = "";
            }
        }
        private void username_textbox_MouseLeave(object sender, MouseEventArgs e)
        {
            username_textbox.Opacity = .8;
        }
        private void username_textbox_KeyboardFChange(object sender, DependencyPropertyChangedEventArgs e)
        {
            username_textbox.Opacity = 1;
            if (username_textbox.Text.Equals("انقر لإضافة نص"))
            {
                username_textbox.Text = "";
            }
        }
        private void username_textbox_LostFoucus(object sender, RoutedEventArgs e)
        {
            username_textbox.Opacity = .8;
            if (username_textbox.Text.Equals(""))
            {
                username_textbox.Text = "انقر لإضافة نص";
            }
        }
        //
        // Log In Button
        //
        public void login_button_Click(object sender, RoutedEventArgs e)
        {
            string id = username_textbox.Text;
            string pass = password_textbox.Password;
            
            if (id == null || id.Trim().Equals(""))
            {
                MessageBox.Show("تأكد من إدخال اسم المستخدم");
                return;
            }
            if (pass == null || pass.Equals(""))
            {
                MessageBox.Show("تأكد من إدخال كلمة المرور");
                return;
            }

            Model model = Model.getInstance();
            User user = model.login(id, pass);
            if (user != null)
            {
                check = true;
            }
            if (check)
            {
                MessageBox.Show("مرحبا بك في البرنامج");
                this.Hide();
                new MainWindow().Show();
            }
            else
            {
                MessageBox.Show("خطأ في اسم المستخدم أو كلمة المرور", "خطأ");
            }
        }

        private void changePassword_button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void LoginWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Environment.Exit(0);
            MessageBoxResult result = MessageBox.Show("Are you sure!", "Exit", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Cancel, MessageBoxOptions.DefaultDesktopOnly);
            if (result.ToString() == "OK")
            {
                Environment.Exit(0);
            }
            else if (result.ToString() == "Cancel")
            {
                e.Cancel = true;
            }
        }
    }
}
