using MahApps.Metro.Controls;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace cProefSyntra
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : MetroWindow
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            if(RegisterFirstName.Text.Length == 0)
            {
                RegisterFirstNameErrorMessage.Text = "Enter a first name.";
                RegisterFirstName.Focus();
            }
            else if(RegisterLastName.Text.Length == 0)
            {
                RegisterLastNameError.Text = "Enter a last name.";
                RegisterLastName.Focus();
            }
            else if(RegisterEmail.Text.Length == 0)
            {
                RegisterEmailErrorMessage.Text = "Enter an email address.";
                RegisterEmail.Focus();
            }
            else if(!Regex.IsMatch(RegisterEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                RegisterEmailErrorMessage.Text = "Enter a valid email address.";
                RegisterEmail.Select(0, RegisterEmail.Text.Length);
                RegisterEmail.Focus();
            }
            else if(RegisterPwBoxPassword.Password.Length == 0)
            {
                RegisterPwErrorMessage.Text = "Enter a email address";
                RegisterPwBoxPassword.Focus();
            }
            else
            {
                RegisterLastNameError.Text = "";
                RegisterFirstNameErrorMessage.Text = "";
                RegisterPwErrorMessage.Text = "";
                RegisterEmailErrorMessage.Text = "";

                var first_Name = RegisterFirstName.Text;
                var last_Name = RegisterLastName.Text;
                var job_Title = "";
                var email = RegisterEmail.Text;
                var password = RegisterPwBoxPassword.Password;
                var isAdmin = false;

                MongoClient client = new MongoClient("mongodb://VincentVH:Vincent159Derp@ds217560.mlab.com:17560/c-proef_syntra");

                Employee employee = new Employee(first_Name, last_Name, job_Title, email, password, isAdmin);

                var db = client.GetDatabase("c-proef_syntra");
                var collection = db.GetCollection<Employee>("employees");             

                collection.InsertOneAsync(employee);

                LoginWindow login = new LoginWindow();
                login.Show();
                Close();
            }
        
        }

        private void RegisterHaveAccount_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();

            login.Show();
            Close();
        }
    }
}
