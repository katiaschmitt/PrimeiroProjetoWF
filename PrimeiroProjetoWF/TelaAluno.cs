using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeiroProjetoWF
{
    public partial class TelaAluno : Form
    {
        public TelaAluno()
        {
            InitializeComponent();

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            Conexao db = new Conexao();
            db.Conectar();

            var resultado = db.ExcluirAluno(id);
            db.Desconectar();

            dataGridView1.DataSource = "";

            db.Conectar();
            var alunos = db.BuscarAlunos();
            foreach (var aluno in alunos)
            {
                // Adiciona a linha no DataGridView
                dataGridView1.Rows.Add(
                    aluno.Id,
                     aluno.Nome,
                     aluno.Idade
                  );
            }

        }

        private void TelaAluno_Load(object sender, EventArgs e)
        {
            Conexao db = new Conexao();
            db.Conectar();
            var alunos = db.BuscarAlunos();
            //dataGridView1.DataSource = alunos;

            foreach (var aluno in alunos)
            {
                // Adiciona a linha no DataGridView
                dataGridView1.Rows.Add(
                    aluno.Id,
                     aluno.Nome,
                     aluno.Idade
                  );
            }



        }

    }
}
