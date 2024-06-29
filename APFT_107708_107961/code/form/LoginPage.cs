using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace form
{
    public partial class LoginPage : Form
    {
        private readonly SqlConnection connection;

        public LoginPage()
        {
            InitializeComponent();
            connection = new SqlConnection(DatabaseConnection.connectionString);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("dbo.VerifyGerente", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NIF", utilizador.Text);
                        cmd.Parameters.AddWithValue("@Senha", passe.Text);

                        int count = (int)cmd.ExecuteScalar();

                        if (count == 1)
                        {
                            AreaServicoPage areaServicoPage = new AreaServicoPage(int.Parse(utilizador.Text));
                            this.Hide();
                            areaServicoPage.Show();
                        }
                        else
                        {
                            MessageBox.Show("Credenciais inválidas. Tente novamente.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("FAILED TO OPEN CONNECTION TO DATABASE! " + ex.Message);
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterPage registerPage = new RegisterPage();
            registerPage.Show();
        }
    }
}
