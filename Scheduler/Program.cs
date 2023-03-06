using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scheduler.Resources;

namespace Scheduler
{
    static class Program
    {
        /* 
                namespace InsertUpdateDeleteDemo  
{  
    public partial class frmMain : Form  
    {  
        SqlConnection con= new SqlConnection("Data Source=.;Initial Catalog=Sample;Integrated Security=true;");  
        SqlCommand cmd;  
        SqlDataAdapter adapt;  
        //ID variable used in Updating and Deleting Record  
        int ID = 0;  
        public frmMain()  
        {  
            InitializeComponent();  
            DisplayData();  
        }  
        //Insert Data  
        private void btn_Insert_Click(object sender, EventArgs e)  
        {  
            if (txt_Name.Text != "" && txt_State.Text != "")  
            {  
                cmd = new SqlCommand("insert into tbl_Record(Name,State) values(@name,@state)", con);  
                con.Open();  
                cmd.Parameters.AddWithValue("@name", txt_Name.Text);  
                cmd.Parameters.AddWithValue("@state", txt_State.Text);  
                cmd.ExecuteNonQuery();  
                con.Close();  
                MessageBox.Show("Record Inserted Successfully");  
                DisplayData();  
                ClearData();  
            }  
            else  
            {  
                MessageBox.Show("Please Provide Details!");  
            }  
        }  
        //Display Data in DataGridView  
        private void DisplayData()  
        {  
            con.Open();  
            DataTable dt=new DataTable();  
            adapt=new SqlDataAdapter("select * from tbl_Record",con);  
            adapt.Fill(dt);  
            dataGridView1.DataSource = dt;  
            con.Close();  
        }  
        //Clear Data  
        private void ClearData()  
        {  
            txt_Name.Text = "";  
            txt_State.Text = "";  
            ID = 0;  
        }  
        //dataGridView1 RowHeaderMouseClick Event  
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)  
        {  
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());  
            txt_Name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();  
            txt_State.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();  
        }  
        //Update Record  
        private void btn_Update_Click(object sender, EventArgs e)  
        {  
            if (txt_Name.Text != "" && txt_State.Text != "")  
            {  
                cmd = new SqlCommand("update tbl_Record set Name=@name,State=@state where ID=@id", con);  
                con.Open();  
                cmd.Parameters.AddWithValue("@id", ID);  
                cmd.Parameters.AddWithValue("@name", txt_Name.Text);  
                cmd.Parameters.AddWithValue("@state", txt_State.Text);  
                cmd.ExecuteNonQuery();  
                MessageBox.Show("Record Updated Successfully");  
                con.Close();  
                DisplayData();  
                ClearData();  
            }  
            else  
            {  
                MessageBox.Show("Please Select Record to Update");  
            }  
        }  
        //Delete Record  
        private void btn_Delete_Click(object sender, EventArgs e)  
        {  
            if(ID!=0)  
            {  
                cmd = new SqlCommand("delete tbl_Record where ID=@id",con);  
                con.Open();  
                cmd.Parameters.AddWithValue("@id",ID);  
                cmd.ExecuteNonQuery();  
                con.Close();  
                MessageBox.Show("Record Deleted Successfully!");  
                DisplayData();  
                ClearData();  
            }  
            else  
            {  
                MessageBox.Show("Please Select Record to Delete");  
            }  
        } 

        private void buttonDeleteProduct_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to delete?";
            string caption = "Please confirm.";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(this, message, caption, buttons);
            if (result == DialogResult.Yes)
            {
                Product product = (Product)this.dataGridViewProducts.CurrentRow.DataBoundItem;
                if (product.AssociatedParts.Count > 0)
                {
                    MessageBox.Show("Products with associated parts cannot be deleted.");
                    return;
                }
                foreach (DataGridViewRow row in this.dataGridViewProducts.SelectedRows)
                {
                    this.dataGridViewProducts.Rows.RemoveAt(row.Index);
                }
            }
            else return;
        } /*
        



                    */
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DB.startConnection();
            Application.Run(new FormMainMenu());
            DB.closeConnection();
        }
    }
}
