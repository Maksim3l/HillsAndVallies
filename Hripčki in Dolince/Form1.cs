using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace Hripčki_in_Dolince
{
    public partial class Login : Form
    {
        public static string connString = ConfigurationManager.ConnectionStrings["Dolince"].ConnectionString;
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
      
        private bool ValidateUser(string usernameOrEmail, string password)
        {
            try
            {
                string commandText = "SELECT COUNT(*) FROM Users WHERE (Username = @UsernameOrEmail OR Email = @UsernameOrEmail) AND Password = @Password";
                using (SqlConnection connection = new SqlConnection(connString))
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@UsernameOrEmail", usernameOrEmail);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validating user: " + ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        private void LogLogin(string username)
        {
            string path = @"C:\Users\lokna\source\repos\Hripčki in Dolince\login_log.txt";
            StreamWriter writer = File.AppendText(path);

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string message = string.Format("{0} - User {1} logged in.", timestamp, username);

            writer.WriteLine(message);
            writer.Flush();
            writer.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (Username.Visible != true)
            {
                label2.Visible = true;
                label1.Visible = true;
                Username.Visible = true;
                Password.Visible = true;
                Lastname.Visible = false;
                Firstname.Visible = false;
                Username2.Visible = false;
                Password2.Visible = false;
                Phonenum.Visible = false;
                ConPassword.Visible = false;
                Email.Visible = false;
                Gender.Visible = false;
                label10.Visible = false;
                label9.Visible = false;
                label8.Visible = false;
                label7.Visible = false;
                label6.Visible = false;
                label5.Visible = false;
                label4.Visible = false;
                label3.Visible = false;
            }
            else
            {
                string usernameOrEmail = Username.Text;
                string password = Password.Text;

                bool loginSuccess = ValidateUser(usernameOrEmail, password);

                if (loginSuccess)
                {

                    MessageBox.Show("User login was successful!", "Successful login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LogLogin(usernameOrEmail);

                    this.Hide();
                    
                        Home Home = new Home();
                        Home.info[0] = Username.Text;
                        Home.info[1] = Password.Text;
                        Home.ShowDialog();

                }
                else
                {

                    MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Firstname.Text) || string.IsNullOrEmpty(Lastname.Text) || string.IsNullOrEmpty(Username2.Text) || string.IsNullOrEmpty(Email.Text) || string.IsNullOrEmpty(Password2.Text) || string.IsNullOrEmpty(ConPassword.Text) || string.IsNullOrEmpty(Gender.Text))
            {
                if(Username2.Visible != true)
                {
                    label2.Visible = false;
                    label1.Visible = false;
                    Username.Visible = false;
                    Password.Visible = false;
                    Lastname.Visible = true;
                    Firstname.Visible = true;
                    Username2.Visible = true;
                    Password2.Visible = true;
                    Phonenum.Visible = true;
                    ConPassword.Visible = true;
                    Email.Visible = true;
                    Gender.Visible = true;
                    label10.Visible = true;
                    label9.Visible = true;
                    label8.Visible = true;
                    label7.Visible = true;
                    label6.Visible = true;
                    label5.Visible = true;
                    label4.Visible = true;
                    label3.Visible = true;
                }
                else
                {
                    MessageBox.Show("Please fill in all required fields.", "Sign Up Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            if (Password2.Text != ConPassword.Text)
            {
                MessageBox.Show("The password and confirm password fields do not match.", "Sign Up Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = connString;

            try
            {
                string commandText = "INSERT INTO USERS (lastname, firstname, username, gender, email, phone_number, password) VALUES (@Firstname, @Lastname, @Username,@Gender, @Email, @Phonenum, @Password)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@Firstname", Firstname.Text);
                    command.Parameters.AddWithValue("@Lastname", Lastname.Text);
                    command.Parameters.AddWithValue("@Username", Username2.Text);
                    command.Parameters.AddWithValue("@Gender", Gender.Text);
                    command.Parameters.AddWithValue("@Email", Email.Text);
                    command.Parameters.AddWithValue("@Phonenum", Phonenum.Text);
                    command.Parameters.AddWithValue("@Password", Password2.Text);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User created successfully!", "Sign Up Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Firstname.Text = "";
                        Lastname.Text = "";
                        Username2.Text = "";
                        Gender.Text = "";
                        Email.Text = "";
                        Phonenum.Text = "";
                        Password2.Text = "";
                        ConPassword.Text = "";
                        label2.Visible = true;
                        label1.Visible = true;
                        Username.Visible = true;
                        Password.Visible = true;
                        Lastname.Visible = false;
                        Firstname.Visible = false;
                        Username2.Visible = false;
                        Password2.Visible = false;
                        Phonenum.Visible = false;
                        ConPassword.Visible = false;
                        Email.Visible = false;
                        Gender.Visible = false;
                        label10.Visible = false;
                        label9.Visible = false;
                        label8.Visible = false;
                        label7.Visible = false;
                        label6.Visible = false;
                        label5.Visible = false;
                        label4.Visible = false;
                        label3.Visible = false;

                    }
                    else
                    {
                        MessageBox.Show("Error creating user.", "Sign Up Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating user: " + ex.Message, "Sign Up Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
