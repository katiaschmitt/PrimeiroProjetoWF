namespace PrimeiroProjetoWF
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Conectar com o banco de dados
            Conexao db = new Conexao();
            db.Conectar();

            UsuarioBanco usuario = new UsuarioBanco();
            usuario.Usuario = textBox1.Text;
            usuario.Senha = textBox2.Text;

            //Buscar usuário e senha do banco de dados
            var retorno = db.BuscarUsuario(usuario.Usuario, usuario.Senha);

            if (!retorno)
                MessageBox.Show("Senha incorreta!");


            if (retorno)
            {
                MessageBox.Show("Bem Vindo");

                TelaAluno telaaluno = new TelaAluno();
                telaaluno.Show();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}