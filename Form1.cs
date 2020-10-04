using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace DBConnectedCURD
{
    public partial class Form1 : Form
    {
        //string constring = @"server=127.0.0.1;user id=root;database=collage;password=PG@123";
        string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\parth\Documents\Collage.mdf;Integrated Security=True;Connect Timeout=30";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GirdDisplay();
        }
        public void GirdDisplay()
        {
            //MySqlConnection con = new MySqlConnection(constring);
            SqlConnection con = new SqlConnection(constring);
            try
            {
                string query = "Select * from student";
                //MySqlCommand cmd = new MySqlCommand(query, con);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                //MySqlDataReader dr = cmd.ExecuteReader();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            txtEmail.Text = row.Cells[2].Value.ToString();
            txtPhone.Text = row.Cells[3].Value.ToString();
            txtBranch.Text = row.Cells[4].Value.ToString();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            //MySqlConnection con = new MySqlConnection(constring);
            SqlConnection con = new SqlConnection(constring);
            try
            {
                String insertQuery = "Insert into student (Name,Email,Phone,Branch) values(@Name,@Email,@Phone,@Branch)";
                //MySqlCommand cmd = new MySqlCommand(insertQuery, con);
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Branch", txtBranch.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            GirdDisplay();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            //MySqlConnection con = new MySqlConnection(constring);
            SqlConnection con = new SqlConnection(constring);
            try
            {
                String updateQuery = "Update student SET Name=@Name,Email=@Email,Phone=@Phone,Branch=@Branch where Id=@Id";
                //MySqlCommand cmd = new MySqlCommand(updateQuery, con);
                SqlCommand cmd = new SqlCommand(updateQuery, con);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Branch", txtBranch.Text);
                cmd.Parameters.AddWithValue("@Id", txtId.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            GirdDisplay();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //MySqlConnection con = new MySqlConnection(constring);
            SqlConnection con = new SqlConnection(constring);
            try
            {
                String deleteQuery = "Delete from student where Id=@Id";
                //MySqlCommand cmd = new MySqlCommand(deleteQuery, con);
                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                cmd.Parameters.AddWithValue("@Id", txtId.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            GirdDisplay();
        }
    }
}
