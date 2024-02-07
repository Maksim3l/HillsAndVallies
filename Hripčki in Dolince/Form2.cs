using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;




namespace Hripčki_in_Dolince
{
    public partial class Home : Form
    {
        public static string[] info = new string[20];
        public static string connString = ConfigurationManager.ConnectionStrings["Dolince"].ConnectionString;
        public static string carrier;
        public Home()
        {
            InitializeComponent();
        }

        public bool Trydress()
        {
            try
            {
                string commandText = "SELECT * FROM ADDRESSES AS A FULL JOIN USERS AS U ON A.address_id = U.address_id WHERE username = '" + info[3] + "' OR email = '" + info[5] + "' AND password = '" + info[8] + "'";
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(commandText, connection);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            info[9] = Convert.ToString(reader["address_id"]);
                            info[10] = Convert.ToString(reader["country"]);
                            info[11] = Convert.ToString(reader["state"]);
                            info[12] = Convert.ToString(reader["city"]);
                            info[13] = Convert.ToString(reader["postal_code"]);
                            info[14] = Convert.ToString(reader["company_name"]);
                            info[15] = Convert.ToString(reader["ad_line1"]);
                            info[16] = Convert.ToString(reader["ad_line2"]);

                        }
                    }
                    connection.Close();
                }

                dCN.Text = info[10];
                dSN.Text = info[11];
                dCY.Text = info[12];
                dPC.Text = info[13];
                dCP.Text = info[14];
                dA1.Text = info[15];
                dA2.Text = info[16];

                pCN.Text = info[10];
                pSN.Text = info[11];
                pCY.Text = info[12];
                pPC.Text = info[13];
                pCP.Text = info[14];
                pA1.Text = info[15];
                pA2.Text = info[16];


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching user data: " + ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Info()
        {

            try
            {
                string commandText = "SELECT * FROM USERS WHERE username = '" + info[0] + "' OR email = '" + info[0] + "' AND password = '" + info[1] + "'";
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(commandText, connection);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            info[0] = Convert.ToString(reader["user_id"]);
                            info[1] = Convert.ToString(reader["lastname"]);
                            info[2] = Convert.ToString(reader["firstname"]);
                            info[3] = Convert.ToString(reader["username"]);
                            info[4] = Convert.ToString(reader["gender"]);
                            info[5] = Convert.ToString(reader["email"]);
                            info[6] = Convert.ToString(reader["phone_number"]);
                            info[7] = Convert.ToString(reader["address_id"]);
                            info[8] = Convert.ToString(reader["password"]);

                        }
                    }
                    connection.Close();
                }

                pFN.Text = info[2];
                pLN.Text = info[1];
                pUN.Text = info[3];
                pGN.Text = info[4];
                pEM.Text = info[5];
                pPN.Text = info[6];

                dLN.Text = info[2];
                dFN.Text = info[1];
                dUN.Text = info[3];
                dGN.Text = info[4];
                dEM.Text = info[5];
                dPN.Text = info[6];

                welcome.Text = "Welcome " + info[1] + " " + info[2] + "!";

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching user data: " + ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profile(true);
        }

        public void edit(bool set)
        {
            if (set == true)
            {
                estates(false);
                address(false);
                profile(false);
                editaddress(false);
                addestate(false);
                mystates(false);
                addlisting(false);
                listings(false);
                mylistings(false);
                Homito(false);

                pLN.Visible = true;
                fie.Visible = true;
                pFN.Visible = true;
                ejnf.Visible = true;
                pUN.Visible = true;
                label1.Visible = true;
                pGN.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                pEM.Visible = true;
                pPN.Visible = true;
                label2.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                cPwd.Visible = true;
                nPwd.Visible = true;
                nPwdC.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
            }
            else
            {
                pLN.Visible = false;
                fie.Visible = false;
                pFN.Visible = false;
                ejnf.Visible = false;
                pUN.Visible = false;
                label1.Visible = false;
                pGN.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                pEM.Visible = false;
                pPN.Visible = false;
                label2.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                cPwd.Visible = false;
                nPwd.Visible = false;
                nPwdC.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
            }

        }

        public void profile(bool set)
        {
            if (set == true)
            {
                estates(false);
                address(false);
                edit(false);
                editaddress(false);
                addestate(false);
                mystates(false);
                addlisting(false);
                listings(false);
                mylistings(false);
                Homito(false);

                dLN.Visible = true;
                dFN.Visible = true;
                dUN.Visible = true;
                dGN.Visible = true;
                dEM.Visible = true;
                dPN.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
            }
            else
            {
                dLN.Visible = false;
                dFN.Visible = false;
                dUN.Visible = false;
                dGN.Visible = false;
                dEM.Visible = false;
                dPN.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
            }

        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit(true);
        }

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete your account?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string commandText = "DELETE FROM USERS WHERE user_id ='" + info[0] + "' AND password ='" + info[8] + "' ";
                    using (SqlConnection connection = new SqlConnection(connString))
                    {
                        connection.Open();

                        SqlCommand command = new SqlCommand(commandText, connection);
                        // Open the connection to the database

                        int rowsAffected = command.ExecuteNonQuery();

                        // Display a success message if the user was added to the database
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Successfuly deleted account: ", "Deletion successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        connection.Close();

                    }
                    this.Hide();

                    foreach (int i in Enumerable.Range(0, info.Length))
                    {
                        info[i] = null;
                    }

                    Login Login = new Login();
                    Login.ShowDialog();

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting user data: " + ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        public void filltables()
        {
            this.estate_viewTableAdapter1.Fill(this.dolinceDataSet2.estate_view);
            this.eSTATESTableAdapter.Fill(this.dolinceDataSet.ESTATES);
            this.estate_viewTableAdapter.Fill(this.dolinceDataSet1.estate_view);


            string par = info[2] + " " + info[1];
            try
            {
                string query = "SELECT * FROM estate_view WHERE owner_name = '" + par + "'";

                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching table: " + ex.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {


                string query = "SELECT * FROM listings_view";

                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView2.DataSource = table;
                    connection.Close();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching table: " + ex.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {


                string query = "SELECT * FROM listings_view WHERE manager ='"+par+"'";

                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView3.DataSource = table;
                    connection.Close();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching table: " + ex.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Home_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dolinceDataSet3.listings_view' table. You can move, or remove it, as needed.
            this.listings_viewTableAdapter.Fill(this.dolinceDataSet3.listings_view);
            mystates(false);
            edit(false);
            profile(false);
            address(false);
            editaddress(false);
            estates(false);
            addestate(false);
            addlisting(false);
            listings(false);
            mylistings(false);
            Homito(false);
            Info();
            Trydress();

            filltables();

            this.menuStrip1.Items.OfType<ToolStripMenuItem>().ToList().ForEach(x =>
            {
                x.MouseHover += (obj, arg) => ((ToolStripDropDownItem)obj).ShowDropDown();
            });


            peaceoffuckingshit.ColumnHeadersDefaultCellStyle.BackColor = Color.Thistle;
            peaceoffuckingshit.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Thistle;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.Thistle;
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.Thistle;
            dataGridView3.EnableHeadersVisualStyles = false;

            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new TestColorTable());
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            foreach (int i in Enumerable.Range(0, info.Length))
            {
                info[i] = null;
            }

            Login Login = new Login();
            Login.ShowDialog();

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pPN.Text) || string.IsNullOrEmpty(pEM.Text) || string.IsNullOrEmpty(pFN.Text) || string.IsNullOrEmpty(pLN.Text) || string.IsNullOrEmpty(pUN.Text) || string.IsNullOrEmpty(pGN.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string commandText = "UPDATE USERS SET lastname ='" + pLN.Text + "', firstname = '" + pFN.Text + "', username = '" + pUN.Text + "', gender = '" + pGN.Text + "', email = '" + pEM.Text + "', phone_number = '" + pPN.Text + "' WHERE user_id ='" + info[0] + "' AND password ='" + info[8] + "' ";
                    using (SqlConnection connection = new SqlConnection(connString))
                    {
                        connection.Open();

                        SqlCommand command = new SqlCommand(commandText, connection);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Successfuly updated account: ", "Update successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        connection.Close();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating user data: " + ex.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Info();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cPwd.Text) || string.IsNullOrEmpty(nPwd.Text) || string.IsNullOrEmpty(nPwdC.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Update password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (cPwd.Text == info[8])
                {
                    if (nPwd.Text != nPwdC.Text)
                    {
                        MessageBox.Show("New passwords do not match.", "Update password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            string commandText = "UPDATE USERS SET password ='" + nPwd.Text + "' WHERE user_id ='" + info[0] + "' AND username ='" + info[3] + "'";
                            using (SqlConnection connection = new SqlConnection(connString))
                            {
                                connection.Open();

                                SqlCommand command = new SqlCommand(commandText, connection);

                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Successfuly updated password: ", "Update successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                                connection.Close();

                                info[8] = nPwd.Text;
                                cPwd.Text = "";
                                nPwd.Text = "";
                                nPwdC.Text = "";
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating user password: " + ex.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Inputed current password dose not match password", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            address(true);
        }

        public void editaddress(bool set)
        {

            if (set == true)
            {
                mystates(false);
                estates(false);
                address(false);
                edit(false);
                profile(false);
                addestate(false);
                addlisting(false);
                listings(false);
                mylistings(false);
                Homito(false);

                pCN.Visible = true;
                pSN.Visible = true;
                pCY.Visible = true;
                pPC.Visible = true;
                pA1.Visible = true;
                pA2.Visible = true;
                pCP.Visible = true;
                label20.Visible = true;
                label21.Visible = true;
                label22.Visible = true;
                label23.Visible = true;
                label24.Visible = true;
                label25.Visible = true;
                label15.Visible = true;
                Sendo.Visible = true;

            }
            else
            {
                pCN.Visible = false;
                pSN.Visible = false;
                pCY.Visible = false;
                pPC.Visible = false;
                pA1.Visible = false;
                pA2.Visible = false;
                pCP.Visible = false;
                label20.Visible = false;
                label21.Visible = false;
                label22.Visible = false;
                label23.Visible = false;
                label24.Visible = false;
                label25.Visible = false;
                label15.Visible = false;
                Sendo.Visible = false;
            }

        }
        public void address(bool set)
        {
            if (set == true)
            {
                mystates(false);
                estates(false);
                edit(false);
                profile(false);
                editaddress(false);
                addestate(false);
                addlisting(false);
                listings(false);
                mylistings(false);
                Homito(false);

                AddADR.Visible = true;
                UpdateADR.Visible = true;
                DelADR.Visible = true;
                dCN.Visible = true;
                dSN.Visible = true;
                dCY.Visible = true;
                dPC.Visible = true;
                dA1.Visible = true;
                dA2.Visible = true;
                dCP.Visible = true;
                label20.Visible = true;
                label21.Visible = true;
                label22.Visible = true;
                label23.Visible = true;
                label24.Visible = true;
                label25.Visible = true;
                label15.Visible = true;
                updaito.Visible = false;
            }
            else
            {
                AddADR.Visible = false;
                UpdateADR.Visible = false;
                DelADR.Visible = false;
                dCN.Visible = false;
                dSN.Visible = false;
                dCY.Visible = false;
                dPC.Visible = false;
                dA1.Visible = false;
                dA2.Visible = false;
                dCP.Visible = false;
                label20.Visible = false;
                label21.Visible = false;
                label22.Visible = false;
                label23.Visible = false;
                label24.Visible = false;
                label25.Visible = false;
                label15.Visible = false;
                updaito.Visible = false;
            }

        }

        private void AddADR_Click(object sender, EventArgs e)
        {
            editaddress(true);
            carrier = ("A");
        }

        private void Sendo_Click(object sender, EventArgs e)
        {
            if (carrier == "A")
            {
                if (string.IsNullOrEmpty(pCN.Text) || string.IsNullOrEmpty(pCY.Text) || string.IsNullOrEmpty(pPC.Text) || string.IsNullOrEmpty(pA1.Text))
                {
                    MessageBox.Show("Please fill in all required fields.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        string commandText = "INSERT INTO ADDRESSES (country, state, city, postal_code, company_name, ad_line1, ad_line2) VALUES (@Country, @State, @City, @Postal_code, @Company_name, @Ad_line1, @Ad_line2)";
                        using (SqlConnection connection = new SqlConnection(connString))
                        using (SqlCommand command = new SqlCommand(commandText, connection))
                        {
                            command.Parameters.AddWithValue("@Country", pCN.Text);
                            command.Parameters.AddWithValue("@State", pSN.Text);
                            command.Parameters.AddWithValue("@City", pCY.Text);
                            command.Parameters.AddWithValue("@Postal_code", pPC.Text);
                            command.Parameters.AddWithValue("@Company_name", pCP.Text);
                            command.Parameters.AddWithValue("@Ad_line1", pA1.Text);
                            command.Parameters.AddWithValue("@Ad_line2", pA2.Text);

                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Added address successfully!", "Address Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                string commandText2 = "SELECT address_id FROM ADDRESSES WHERE country = '" + pCN.Text + "' AND state = '" + pSN.Text + "' AND city = '" + pCY.Text + "' AND postal_code = '" + pPC.Text + "' AND company_name = '" + pCP.Text + "' AND ad_line1 = '" + pA1.Text + "' AND ad_line2 = '" + pA2.Text + "'";
                                using (SqlCommand command2 = new SqlCommand(commandText2, connection))
                                {

                                    using (var reader = command2.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            info[9] = Convert.ToString(reader["address_id"]);
                                        }
                                    }
                                }

                                string commandText3 = "UPDATE USERS SET address_id = " + info[9] + " WHERE user_id = " + info[0] + " AND username = '" + info[3] + "'";
                                using (SqlCommand command3 = new SqlCommand(commandText3, connection))
                                {
                                    int rowsAffected2 = command3.ExecuteNonQuery();

                                    if (rowsAffected2 > 0)
                                    {
                                        MessageBox.Show("Successfuly updated user data: ", "Update successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }
                                    else
                                    {
                                        MessageBox.Show("Error adding address to user data.", "Address Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                }

                                pCN.Text = "";
                                pSN.Text = "";
                                pCY.Text = "";
                                pPC.Text = "";
                                pCP.Text = "";
                                pA1.Text = "";
                                pA2.Text = "";
                                Trydress();
                                address(true);
                            }
                            else
                            {
                                MessageBox.Show("Error adding address.", "Address Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            connection.Close();
                        }



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error adding address data: " + ex.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(pCN.Text) || string.IsNullOrEmpty(pCY.Text) || string.IsNullOrEmpty(pPC.Text) || string.IsNullOrEmpty(pA1.Text))
                {
                    MessageBox.Show("Please fill in all required fields.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        string commandText = "INSERT INTO ADDRESSES (country, state, city, postal_code, company_name, ad_line1, ad_line2) VALUES (@Country, @State, @City, @Postal_code, @Company_name, @Ad_line1, @Ad_line2)";
                        using (SqlConnection connection = new SqlConnection(connString))
                        using (SqlCommand command = new SqlCommand(commandText, connection))
                        {
                            command.Parameters.AddWithValue("@Country", pCN.Text);
                            command.Parameters.AddWithValue("@State", pSN.Text);
                            command.Parameters.AddWithValue("@City", pCY.Text);
                            command.Parameters.AddWithValue("@Postal_code", pPC.Text);
                            command.Parameters.AddWithValue("@Company_name", pCP.Text);
                            command.Parameters.AddWithValue("@Ad_line1", pA1.Text);
                            command.Parameters.AddWithValue("@Ad_line2", pA2.Text);

                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Added address successfully!", "Address Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                string commandText2 = "SELECT address_id FROM ADDRESSES WHERE country = '" + pCN.Text + "' AND state = '" + pSN.Text + "' AND city = '" + pCY.Text + "' AND postal_code = '" + pPC.Text + "' AND company_name = '" + pCP.Text + "' AND ad_line1 = '" + pA1.Text + "' AND ad_line2 = '" + pA2.Text + "'";
                                using (SqlCommand command2 = new SqlCommand(commandText2, connection))
                                {

                                    using (var reader = command2.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            carrier = Convert.ToString(reader["address_id"]);
                                        }
                                    }
                                }

                                pCN.Text = "";
                                pSN.Text = "";
                                pCY.Text = "";
                                pPC.Text = "";
                                pCP.Text = "";
                                pA1.Text = "";
                                pA2.Text = "";

                                addestate(true);
                            }
                            else
                            {
                                MessageBox.Show("Error adding address.", "Address Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            connection.Close();
                        }



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error adding address data: " + ex.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


        }

        private void DelADR_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete your address?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {

                    string commandText = "UPDATE ADDRESSES SET country = '', state = '', city = '', postal_code = '', company_name = '', ad_line1 = '', ad_line2 = '' WHERE address_id = " + info[9];

                    using (SqlConnection connection = new SqlConnection(connString))
                    {
                        connection.Open();

                        SqlCommand command = new SqlCommand(commandText, connection);

                        int rowsAffected = command.ExecuteNonQuery();
                        // Display a success message if the user was added to the database
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Successfuly deleted account: ", "Deletion successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                        connection.Close();

                    }
                    Trydress();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting user data: " + ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void UpdateADR_Click(object sender, EventArgs e)
        {
            editaddress(true);
            Sendo.Visible = false;
            updaito.Visible = true;
        }

        private void updaito_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pCN.Text) || string.IsNullOrEmpty(pCY.Text) || string.IsNullOrEmpty(pPC.Text) || string.IsNullOrEmpty(pA1.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string commandText = "UPDATE ADDRESSES SET country = '" + pCN.Text + "', state = '" + pSN.Text + "', city = '" + pCY.Text + "', postal_code = '" + pPC.Text + "', company_name = '" + pCP.Text + "', ad_line1 = '" + pA1.Text + "', ad_line2 = '" + pA2.Text + "' WHERE address_id = " + info[9];
                    using (SqlConnection connection = new SqlConnection(connString))
                    {
                        connection.Open();

                        SqlCommand command = new SqlCommand(commandText, connection);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Successfuly updated address.", "Update successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        connection.Close();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating address: " + ex.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Trydress();
            address(true);
        }

        public void estates(bool set)
        {
            if (set == true)
            {
                address(false);
                editaddress(false);
                edit(false);
                profile(false);
                addestate(false);
                mystates(false);
                addlisting(false);
                listings(false);
                mylistings(false);
                Homito(false);
                peaceoffuckingshit.Visible = true;
            }
            else
            {
                peaceoffuckingshit.Visible = false;
            }
        }

        public void addestate(bool set)
        {
            if (set == true)
            {
                mystates(false);
                address(false);
                editaddress(false);
                edit(false);
                profile(false);
                estates(false);
                addlisting(false);
                listings(false);
                mylistings(false);
                Homito(false);
                label16.Visible = true;
                label17.Visible = true;
                label18.Visible = true;
                label19.Visible = true;
                label26.Visible = true;
                label27.Visible = true;
                label14.Visible = true;
                pEA.Visible = true;
                pEC.Visible = true;
                pEG.Visible = true;
                pED.Visible = true;
                pEN.Visible = true;
                pEST.Visible = true;
                pES.Visible = true;
                addestadr.Visible = true;
                postest.Visible = true;
            }
            else
            {
                label16.Visible = false;
                label17.Visible = false;
                label18.Visible = false;
                label19.Visible = false;
                label26.Visible = false;
                label27.Visible = false;
                label14.Visible = false;
                pEA.Visible = false;
                pEC.Visible = false;
                pEG.Visible = false;
                pED.Visible = false;
                pEN.Visible = false;
                pEST.Visible = false;
                pES.Visible = false;
                addestadr.Visible = false;
                postest.Visible = false;
            }
        }
        private void estatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            estates(true);

            string query = "SELECT * FROM estate_view";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                peaceoffuckingshit.DataSource = table;
                connection.Close();
            }
        }

        private void postAnEstateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addestate(true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pEN.Text) || string.IsNullOrEmpty(pEST.Text) || string.IsNullOrEmpty(pES.Text) || carrier == "A" || carrier == "E")
            {
                MessageBox.Show("Please fill in all required fields and make an address." + carrier, "Post Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string commandText = "INSERT INTO ESTATES (type, name, description, size, avalibility, contact, address_id, owner_id, manager_id) VALUES (@Type, @Name, @Desc, @Size, @Aval, @Cont, " + carrier + ", " + info[0] + ", @Mg_id)";

                    string commandText2 = "SELECT * FROM USERS WHERE username = '" + pEG.Text + "'";

                    using (SqlConnection connection = new SqlConnection(connString))
                    {
                        int managerid = 0;
                        connection.Open();

                        SqlCommand command01 = new SqlCommand(commandText2, connection);

                        using (var reader = command01.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                managerid = Convert.ToInt32(reader["user_id"]);
                            }
                        }




                        using (SqlCommand command = new SqlCommand(commandText, connection))
                        {
                            command.Parameters.AddWithValue("@Type", pEST.Text);
                            command.Parameters.AddWithValue("@Name", pEN.Text);
                            command.Parameters.AddWithValue("@Desc", pED.Text);
                            command.Parameters.AddWithValue("@Size", pES.Text);
                            command.Parameters.AddWithValue("@Aval", pEA.Text);
                            command.Parameters.AddWithValue("@Cont", pEC.Text);
                            command.Parameters.AddWithValue("@Ad_id", carrier); //inputed as null, added later
                            if (managerid != 0)
                            {
                                command.Parameters.AddWithValue("@Mg_id", managerid);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@Mg_id", info[0]);
                            }

                            int rowsAffected = command.ExecuteNonQuery();


                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Estate added successfully!", "Estate Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                pEST.Text = "";
                                pEN.Text = "";
                                pED.Text = "";
                                pES.Text = "";
                                pEC.Text = "";
                                pEG.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("Error adding estate.", "Estate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            connection.Close();
                        }

                    }

                    this.estate_viewTableAdapter1.Fill(this.dolinceDataSet2.estate_view);
                    this.eSTATESTableAdapter.Fill(this.dolinceDataSet.ESTATES);
                    this.estate_viewTableAdapter.Fill(this.dolinceDataSet1.estate_view);
                    carrier = "A";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding estate data: " + ex.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                filltables();
            }
        }

        private void addestadr_Click(object sender, EventArgs e)
        {
            carrier = "E";
            editaddress(true);
            pCN.Text = "";
            pSN.Text = "";
            pCY.Text = "";
            pPC.Text = "";
            pCP.Text = "";
            pA1.Text = "";
            pA2.Text = "";
        }

        public void mystates(bool set)
        {
            if (set == true)
            {
                address(false);
                editaddress(false);
                edit(false);
                profile(false);
                estates(false);
                addestate(false);
                addlisting(false);
                listings(false);
                mylistings(false);
                Homito(false);
                dataGridView1.Visible = true;
                button3.Visible = true;
            }
            else
            {
                button3.Visible = false;
                dataGridView1.Visible = false;
            }
        }

        private void myEstatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mystates(true);
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            string name = (string)selectedRow.Cells[1].Value;
            string type = (string)selectedRow.Cells[0].Value;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM ESTATES WHERE name = '" + name + "' AND type = '" + type + "'", conn);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Row updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating row: " + ex.Message);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            addestate(true);
        }

        public void addlisting(bool set)
        {

            if (set == true)
            {
                address(false);
                editaddress(false);
                edit(false);
                profile(false);
                estates(false);
                addestate(false);
                addlisting(false);
                mystates(false);
                listings(false);
                mylistings(false);
                Homito(false);
                pLPh.Visible = true;
                pLD.Visible = true;
                pLPr.Visible = true;
                pLTy.Visible = true;
                pLTi.Visible = true;
                pESN.Visible = true;
                pEST.Visible = true;
                label28.Visible = true;
                label29.Visible = true;
                label30.Visible = true;
                label31.Visible = true;
                label32.Visible = true;
                label33.Visible = true;
                label34.Visible = true;
                posterito.Visible = true;
            }
            else
            {
                pLPh.Visible = false;
                pLD.Visible = false;
                pLPr.Visible = false;
                pLTy.Visible = false;
                pLTi.Visible = false;
                pESN.Visible = false;
                pEST.Visible = false;
                label28.Visible = false;
                label29.Visible = false;
                label30.Visible = false;
                label31.Visible = false;
                label32.Visible = false;
                label33.Visible = false;
                label34.Visible = false;
                posterito.Visible = false;
            }
        }

        private void postAListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addlisting(true);
        }

        private void toolStripTextBox3_Enter(object sender, EventArgs e)
        {
            estates(true);
            string searchCriteria = toolStripTextBox3.Text;
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM estate_view WHERE name LIKE '%" + searchCriteria + "%' OR type LIKE '%" + searchCriteria + "%'";
                    SqlCommand command = new SqlCommand(sql, connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    peaceoffuckingshit.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting data: " + ex, "Error searching", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pLPh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            openFileDialog1.Title = "Select an Image File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pLPh.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void toolStripTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (e.KeyChar == (char)Keys.Return)
            {
                estates(true);
                string searchCriteria = toolStripTextBox3.Text;
                try
                {
                    using (SqlConnection connection = new SqlConnection(connString))
                    {
                        connection.Open();

                        string sql = "SELECT * FROM estate_view WHERE name LIKE '%" + searchCriteria + "%' OR type LIKE '%" + searchCriteria + "%'";
                        SqlCommand command = new SqlCommand(sql, connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        peaceoffuckingshit.DataSource = table;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error selecting data: " + ex, "Error searching", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void posterito_Click(object sender, EventArgs e)
        {
            int estateid = 0;
            if (string.IsNullOrEmpty(pESN.Text) || string.IsNullOrEmpty(pEST.Text))
            {
                MessageBox.Show("Error fetching estate id, please fill in all of the required fields.", "Listing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string commandText = "SELECT estate_id FROM ESTATES WHERE name = '" + pESN.Text + "' AND type = '" + pEST.Text + "' AND owner_id =" + info[0];
                    using (SqlConnection connection = new SqlConnection(connString))
                    {
                        connection.Open();

                        SqlCommand command = new SqlCommand(commandText, connection);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                estateid = Convert.ToInt32(reader["estate_id"]);
                            }
                        }
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching estate id: " + ex, "Listing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (estateid == 0)
            {
                MessageBox.Show("Error fetching estate id, you are not the owner.", "Listing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (string.IsNullOrEmpty(pLTi.Text) || string.IsNullOrEmpty(pLTy.Text) || string.IsNullOrEmpty(pLPr.Text) || pLPh.Image == null || string.IsNullOrEmpty(pLD.Text))
                {
                    MessageBox.Show("Please fill in all of the required fields.", "Listing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        Image image = pLPh.Image;
                        byte[] imageData;

                        if (image == null)
                        {
                            imageData = null;
                        }
                        else
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                image.Save(ms, ImageFormat.Jpeg);
                                imageData = ms.ToArray();
                            }
                        }

                        string insertSql = "INSERT INTO LISTINGS (estate_id, title, type, price, status, date_listed, description, photo) VALUES (@Estate_id, @Title, @Type, @Price, @Status, @Date_listed, @Description, @ImageData)";

                        using (SqlConnection connection = new SqlConnection(connString))
                        {
                            connection.Open();

                            SqlCommand command = new SqlCommand(insertSql, connection);

                            command.Parameters.AddWithValue("@Estate_id", estateid);
                            command.Parameters.AddWithValue("@Title", pLTi.Text);
                            command.Parameters.AddWithValue("@Type", pLTy.Text);
                            command.Parameters.AddWithValue("@Price", pLPr.Text);
                            command.Parameters.AddWithValue("@Status", "Active");
                            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            command.Parameters.AddWithValue("@Date_listed", timestamp);
                            command.Parameters.AddWithValue("@Description", pLD.Text);
                            SqlParameter imageParameter = new SqlParameter("@ImageData", SqlDbType.VarBinary);
                            imageParameter.Value = imageData;
                            command.Parameters.Add(imageParameter);

                            command.ExecuteNonQuery();
                        }
                        MessageBox.Show("Successfuly uploaded listing", "Successful upload", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pLTi.Text = "";
                        pLTy.Text = "";
                        pLPr.Text = "";
                        pESN.Text = "";
                        pEST.Text = "";
                        pLPh.Image = null;
                        pLD.Text = "";
                        listings(true);
                        filltables();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error fetching estate id: " + ex, "Listing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        public void listings(bool set)
        {
            if (set == true)
            {
                estates(false);
                address(false);
                editaddress(false);
                edit(false);
                profile(false);
                addestate(false);
                mystates(false);
                addlisting(false);
                mylistings(false);
                Homito(false);

                dataGridView2.Visible = true;
            }
            else
            {
                dataGridView2.Visible = false;
            }
        }

        private void marketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listings(true);
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listings(true);
                string searchCriteria = toolStripTextBox2.Text;
                try
                {
                    using (SqlConnection connection = new SqlConnection(connString))
                    {
                        connection.Open();

                        string sql = "SELECT * FROM listings_view WHERE estate_name LIKE '%" + searchCriteria + "%' OR estate_type LIKE '%" + searchCriteria + "%'OR type LIKE '%" + searchCriteria + "%'";
                        SqlCommand command = new SqlCommand(sql, connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dataGridView2.DataSource = table;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error selecting data: " + ex, "Error searching", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripTextBox2_Enter(object sender, EventArgs e)
        {
            listings(true);
            string searchCriteria = toolStripTextBox2.Text;
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM listings_view WHERE name LIKE '%" + searchCriteria + "%' OR type LIKE '%" + searchCriteria + "%'";
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView2.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting data: " + ex, "Error searching", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            addlisting(true);
        }

        public void mylistings(bool set)
        {
            if(set == true)
            {
                estates(false);
                address(false);
                editaddress(false);
                edit(false);
                profile(false);
                addestate(false);
                mystates(false);
                addlisting(false);
                listings(false);
                Homito(false);
                dataGridView3.Visible = true;
                button4.Visible = true;
            }
            else
            {
                dataGridView3.Visible = false;
                button4.Visible= false;
            }
        }

        private void myListingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mylistings(true);
        }

        private void dataGridView3_UserDeletingRow_1(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView3.SelectedRows[0];

            string title = (string)selectedRow.Cells[0].Value;
            string type = (string)selectedRow.Cells[1].Value;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE TOP (1) FROM LISTINGS WHERE title = '" + title + "' AND type = '" + type + "'", conn);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Row updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating row: " + ex.Message);
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string Info = selectionito.Text;

            if(Info == "Estate revenue")
            {
                try
                {
                    string query = "SELECT * FROM estate_revenue";

                    using (SqlConnection connection = new SqlConnection(connString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        daallthing.DataSource = table;
                        connection.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching table: " + ex.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (Info == "Top 5 estates by price")
            {
                try
                {
                    string query = "SELECT * FROM top_5_estates_by_avg_price";

                    using (SqlConnection connection = new SqlConnection(connString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        daallthing.DataSource = table;
                        connection.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching table: " + ex.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(Info == "Properties by location" )
            {
                try
                {
                    string query = "SELECT * FROM available_properties_by_location_view ORDER BY country, state, city";

                    using (SqlConnection connection = new SqlConnection(connString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        daallthing.DataSource = table;
                        connection.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching table: " + ex.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    string query = "SELECT * FROM user_properties_view U1 JOIN ESTATES E ON U1.estate_id = E.estate_id WHERE E.owner_id = " + info[0];

                    using (SqlConnection connection = new SqlConnection(connString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        daallthing.DataSource = table;
                        connection.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching table: " + ex.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Homito(bool set)
        {
            if (set== true)
            {
                estates(false);
                address(false);
                editaddress(false);
                edit(false);
                profile(false);
                addestate(false);
                mystates(false);
                addlisting(false);
                listings(false);
                mylistings(false);
                daallthing.Visible = true;
                selectionito.Visible = true;
            }
            else
            {
                daallthing.Visible = false;
                selectionito.Visible = false;
            }
        }
        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Homito(true);
        }
    }
    public class TestColorTable : ProfessionalColorTable
    {
    public override Color MenuItemSelected
    {
        get { return Color.MediumSlateBlue; }
    }

    public override Color MenuBorder  //added for changing the menu border
    {
        get { return Color.Empty; }
    }

    public override Color MenuItemBorder
    {
            get { return Color.SlateBlue; }
    }

    public override Color MenuItemSelectedGradientBegin
    {
        get { return Color.MediumSlateBlue; }
    }
    public override Color ToolStripDropDownBackground
    {
        get { return Color.SlateBlue; }
    }

        public override Color MenuItemSelectedGradientEnd
    {
        get { return Color.MediumSlateBlue; }
    }

    public override Color MenuItemPressedGradientBegin
    {
        get { return Color.MediumSlateBlue; }
    }

    public override Color MenuItemPressedGradientEnd
    {
        get { return Color.MediumSlateBlue; }
    }

    }
}
