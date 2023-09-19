
using Microsoft.VisualBasic.Logging;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace WF1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string mysqlCon = "server=127.0.0.1; user=root; database=sampleconnecrtion; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon);

            try
            {
                mySqlConnection.Open();
                //MessageBox.Show("Connection success");

                string qry = "select * from user";

                MySqlCommand mySqlCommand = new MySqlCommand(qry);
                mySqlCommand.Connection = mySqlConnection;

                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = mySqlCommand;
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }

            Login login = new Login();
            this.AddOwnedForm(login);
            login.Show();

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string mysqlCon = "server=127.0.0.1; user=root; database=sampleconnecrtion; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon);

            try
            {
                mySqlConnection.Open();

                string qry = "select * from user where username='" + txtusername.Text + "' and password='" + txtpwd.Text + "';";

                MySqlCommand mySqlCommand = new MySqlCommand(qry);
                mySqlCommand.Connection = mySqlConnection;

                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = mySqlCommand;
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Welcome!");
                }
                else
                {
                    MessageBox.Show("Invalid Login");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}