using System.Data;

namespace AgendaWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DALAgenda.CriarBancoSQLite();
            DALAgenda.CriarTabelaSQLite();
            ExibirDados();
            lbDados.Text = DALAgenda.path;
        }

        private void ExibirDados()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DALAgenda.GetContatos();
                dgvDados.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            try
            {
                Contato contato = new()
                {
                    Id = Convert.ToInt32(txtID.Text),
                    Nome = txtNome.Text,
                    Email = txtEmail.Text
                };

                DALAgenda.Add(contato);
                ExibirDados();

                txtID.Clear();
                txtNome.Clear();
                txtEmail.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                Contato contato = new()
                {
                    Id = Convert.ToInt32(txtID.Text),
                    Nome = txtNome.Text,
                    Email = txtEmail.Text
                };

                DALAgenda.Update(contato);
                ExibirDados();

                txtID.Clear();
                txtNome.Clear();
                txtEmail.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtID.Text);

                DALAgenda.Delete(id);
                ExibirDados();

                txtID.Clear();
                txtNome.Clear();
                txtEmail.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                if (txtID.Text != "")
                {
                    int id = Convert.ToInt32(txtID.Text);
                    dt = DALAgenda.GetContato(id);
                }
                else if (txtNome.Text != "")
                {
                    string nome = txtNome.Text;
                    dt = DALAgenda.GetContatos(nome);
                }
                else
                {
                    string email = txtEmail.Text;
                    dt = DALAgenda.GetEmails(email);
                }
                dgvDados.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }
    }
}
