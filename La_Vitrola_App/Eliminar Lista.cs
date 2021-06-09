using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace La_Vitrola_App
{
    public partial class Eliminar_Lista : Form
    {
        DataClasses1DataContext dt = new DataClasses1DataContext();
        public Eliminar_Lista()
        {
            InitializeComponent();
        }

        private void Eliminar_Lista_Load(object sender, EventArgs e)
        {
            var listas = from t in dt.PlayLists
                         select t;
            listBox1.DisplayMember = "Nombre";
            listBox1.ValueMember = "Id";
            listBox1.DataSource = listas.OrderBy(a => a.Nombre);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedValue != null)
            {
                try
                {
                    button1.Enabled = false;
                    PlayList lista = (listBox1.SelectedItem as PlayList);
                    backgroundWorker1.RunWorkerAsync(lista);
           
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        void Eliminar_Lista_Musica(PlayList lista)
        {
            dt.PlayList_Musicas.DeleteAllOnSubmit(lista.PlayList_Musicas);
            dt.PlayLists.DeleteOnSubmit(lista);
            dt.SubmitChanges();
            var listas = from t in dt.PlayLists
                         select t;
  
            LaVitrola.needed = true;
            LaVitrola.lista_musica = new List<Musica>();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Eliminar_Lista_Musica(e.Argument as PlayList);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                var listas = from t in dt.PlayLists
                             select t;
                listBox1.DisplayMember = "Nombre";
                listBox1.ValueMember = "Id";
                listBox1.DataSource = listas.OrderBy(a => a.Nombre);

                button1.Enabled = true;
            }
        }
    }
}
