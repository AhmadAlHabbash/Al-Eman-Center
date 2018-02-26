using System;
using System.Windows;
using System.Windows.Input;

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
