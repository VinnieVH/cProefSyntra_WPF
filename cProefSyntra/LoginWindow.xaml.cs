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
        RegisterWindow registration = new RegisterWindow();
        MongoClient client = new MongoClient("mongodb://VincentVH:Vincent159Derp@ds217560.mlab.com:17560/c-proef_syntra");



        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if(TxtBoxEmail.Text.Length == 0)
            {
                EmailErrorMessage.Text = "Enter an email.";
                TxtBoxEmail.Focus();
            }
            else if(!Regex.IsMatch(TxtBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                EmailErrorMessage.Text = "Enter a valid email.";
                TxtBoxEmail.Select(0, TxtBoxEmail.Text.Length);
                TxtBoxEmail.Focus();
            }
            else
            {
                string email = TxtBoxEmail.Text;
                string password = PwBoxPassword.Password;


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

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            registration.Show();
            Close();
        }

        private void ForgotPwd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
