using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Std
{   

    public partial class Login : MaterialForm
    {
        
        public Login()
        {
            InitializeComponent();
            MaterialSkinManager material = MaterialSkinManager.Instance;
            material.AddFormToManage(this);
            material.Theme = MaterialSkinManager.Themes.LIGHT;

            material.ColorScheme = new ColorScheme(Primary.Yellow700, Primary.Yellow700, Primary.Yellow700, Accent.LightGreen100, TextShade.WHITE);
        
        }


        private string ExecuteReader()
        {
            throw new NotImplementedException();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            acConnection ac = new acConnection();
            OleDbCommand command = new OleDbCommand();
            command.Connection = acConnection.con;

            String name = txtName.Text;
            String pwd = txtPwd.Text;
            String dbName = "";
            String dbPwd = "";
            try
            {
                command.CommandText = "SELECT * FROM pwd2 WHERE name='" + name + "'";
                ac.connect();
                command.ExecuteNonQuery();
                OleDbDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    dbName = read[0].ToString();
                    dbPwd = read[1].ToString();

                 }
                if (name == dbName && pwd == dbPwd)
                {
                    if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPwd.Text))
                    {
                        this.Hide();
                        student newStudent = new student();
                        newStudent.Show();
                    }
                    else 
                    {
                        MessageBox.Show("Please Enter User Name And Password");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid User Name Or Password!");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            finally
            {
                ac.close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
