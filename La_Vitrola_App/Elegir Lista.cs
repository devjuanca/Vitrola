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
   
    public partial class Elegir_Lista : Form
    {
        DataClasses1DataContext dt = new DataClasses1DataContext();
        List<Musica> musica_Lista = new List<Musica>();
        public Elegir_Lista()
        {
            InitializeComponent();
        }

        private void Elegir_Lista_Load(object sender, EventArgs e)
        {
            listBox1.DisplayMember = "Nombre";
            listBox1.ValueMember = "Id";
            listBox1.DataSource = dt.PlayLists.OrderBy(a=>a.Nombre);

           
            if (dt.PlayLists.Count()>0)
            {
                var musica_de_lista = from t in dt.PlayList_Musicas
                                      where t.Id_PlayList == (listBox1.SelectedItem as PlayList).Id
                                      select t.Musica;
                musica_Lista = musica_de_lista.ToList();
                progressBar1.Maximum = musica_de_lista.Count();
            }
            else
            {
                if (MessageBox.Show("Aún no hay listas creadas") == DialogResult.OK)
                {
                    this.Close();
                }
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var musica_de_lista = from t in dt.PlayList_Musicas
                                  where t.Id_PlayList == Convert.ToInt16(listBox1.SelectedValue)
                                  select t.Musica;

            listBox2.DisplayMember = "Nombre_Cancion";
            listBox2.ValueMember = "Id";
            listBox2.DataSource = musica_de_lista;
            musica_Lista = musica_de_lista.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
           
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Formar_Lista_de_Musica();
        }
        void Formar_Lista_de_Musica()
        {

            bool rep_aleatoria = checkBox1.Checked;


            if (rep_aleatoria)
            {
                List<Musica> musica = new List<Musica>();
                List<bool> indices = new List<bool>();
                for (int i = 0; i < musica_Lista.Count(); i++)
                {
                    indices.Add(false);
                }
                int var_aleatoria = new Random().Next(0, musica_Lista.Count);
                int p = 0;
                while (musica.Count < musica_Lista.Count)
                {
                    if (!indices[var_aleatoria])
                    {
                        musica.Add(musica_Lista.ElementAt(var_aleatoria));
                        indices[var_aleatoria] = true;p++;
                        backgroundWorker1.ReportProgress(p);
                        
                        if (musica.Count < musica_Lista.Count())
                            while (indices[var_aleatoria])
                                var_aleatoria = new Random().Next(0, musica_Lista.Count);
                    }

                }
                LaVitrola.lista_musica =musica;
            }
            else
            {
                LaVitrola.lista_musica = musica_Lista ;
            }

          
            
            LaVitrola.needed = true;
       
        }


        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                button1.Enabled = true;

                foreach (PlayList l in dt.PlayLists.Where(a => a.Id != (listBox1.SelectedItem as PlayList as PlayList).Id))
                {
                    l.Activa = false;
                }

                dt.PlayLists.Where(a => a.Id == (listBox1.SelectedItem as PlayList).Id).First().Activa = true;
                dt.SubmitChanges();
                this.Close();

            }
        }
    }
}
