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
    public partial class Change_Password : MaterialForm
    {
        public Change_Password()
        {
            InitializeComponent();
            MaterialSkinManager material = MaterialSkinManager.Instance;
            material.AddFormToManage(this);
            material.Theme = MaterialSkinManager.Themes.LIGHT;

            material.ColorScheme = new ColorScheme(Primary.Yellow700, Primary.Yellow700, Primary.Yellow700, Accent.LightGreen100, TextShade.WHITE);
        }
        private void btnChange1_Click(object sender, EventArgs e)
        {
            acConnection ac = new acConnection();
            OleDbCommand command = new OleDbCommand();
            command.Connection = acConnection.con;

            String oldUser = txtUser.Text;
            String oldPwd = txtCurrent.Text;
            String newPwd = txtNew.Text;
            String conPwd = txtConfirm.Text;

            String dbName="";
            String dbPwd = "";

            try
            {
                command.CommandText = "select * from pwd2 where name='" + oldUser + "'";
                ac.connect();
                command.ExecuteNonQuery();
                OleDbDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    dbName = read[0].ToString();
                    dbPwd = read[1].ToString();
                }
                ac.close();

                if (oldUser == dbName && oldPwd == dbPwd)
                {

                    if (newPwd == conPwd && oldPwd == dbPwd)
                    {
                        if (!string.IsNullOrEmpty(txtUser.Text) && !string.IsNullOrEmpty(txtCurrent.Text))
                        {
                            command.CommandText = "update pwd2 set pwd='" + newPwd + "' where name='" + oldUser + "'";
                            ac.connect();
                            command.ExecuteNonQuery();
                            MessageBox.Show("Password Update for" + " " + dbName);
                        }
                        else 
                        {
                            MessageBox.Show("Please Enter Current User Name And Password!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("New Passwords Does Not Mtach!");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid User Name Or Password!");
                }
               
            }
            catch (OleDbException) 
            {
                MessageBox.Show("New Password Can Not Be Null!");
            }
            finally
            {
                ac.close();
            }

        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            this.Close();
            student newstudent = new student();
            newstudent.Show();
        }


    }
}
