using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;


namespace BusForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string role = textBox3.Text;

            User newUser = new User(username, password, role);

            User_Manager um = new User_Manager();
            Object userObject = new Object();
            userObject.setUser(newUser);
            um.add(userObject);

            string connstring = "server=localhost;port=3306;uid=root;pwd=SQL_2023test;database=db_transport";

            MySqlConnection conn = new MySqlConnection(connstring);

            try
            {
                conn.Open();
                string createTableQuery = "CREATE TABLE IF NOT EXISTS Users (Username VARCHAR(50), Password VARCHAR(50), Role VARCHAR(50))";
                MySqlCommand createTableCmd = new MySqlCommand(createTableQuery, conn);
                createTableCmd.ExecuteNonQuery();

                string insertUserQuery = "INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)";
                MySqlCommand insertUserCmd = new MySqlCommand(insertUserQuery, conn);
                insertUserCmd.Parameters.AddWithValue("@Username", newUser.getUsername());
                insertUserCmd.Parameters.AddWithValue("@Password", newUser.getPassword());
                insertUserCmd.Parameters.AddWithValue("@Role", newUser.getRole());
                insertUserCmd.ExecuteNonQuery();

                MessageBox.Show("User created and persisted to the database.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
