using MahApps.Metro.Controls;
using System.Text.RegularExpressions;
using System.Windows;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace cProefSyntra
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : MetroWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        MainWindow main = new MainWindow();

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if(LoginTxtBoxEmail.Text.Length == 0)
            {
                LoginEmailErrorMessage.Text = "Enter an email.";
                LoginTxtBoxEmail.Focus();
            }
            else if(!Regex.IsMatch(LoginTxtBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                LoginEmailErrorMessage.Text = "Enter a valid email.";
                LoginTxtBoxEmail.Select(0, LoginTxtBoxEmail.Text.Length);
                LoginTxtBoxEmail.Focus();
            }
            else
            {
                string email = LoginTxtBoxEmail.Text;
                string password = LoginPwBoxPassword.Password;

                MongoClient client = new MongoClient("mongodb://VincentVH:Vincent159Derp@ds217560.mlab.com:17560/c-proef_syntra");

                /// Testing DB code (needs to be replaced)
                var db = client.GetDatabase("c-proef_syntra");
                var collection = db.GetCollection<Employee>("employees");

                /// Create a unique field for Email Address
                var options = new CreateIndexOptions() { Unique = true };
                var field = new StringFieldDefinition<Employee>("Email");
                var IndexDefintion = new IndexKeysDefinitionBuilder<Employee>().Ascending(field);
                collection.Indexes.CreateOneAsync(IndexDefintion, options);
                Employee employee = new Employee("Vincent", "Van Herreweghe", "CEO", "vincentvanherreweghe@gmail.com", "Vincent159Derp", true);
                collection.InsertOne(employee);
            }
        }

        private void LoginRegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registration = new RegisterWindow();

            registration.Show();
            Close();
        }

        private void LoginForgotPwd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
