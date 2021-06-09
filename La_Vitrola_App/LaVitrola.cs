using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
namespace La_Vitrola_App
{
    public partial class LaVitrola : Form
    {
        public static bool needed = false;
        public static List<Musica> lista_musica;
        public static bool rep_aleatoria = false;

        bool cambiar_URL = true;
        int index = 0;
        int index2 = 0;
        DataClasses1DataContext dt;
        public LaVitrola()
        {
            InitializeComponent();
            dt = new DataClasses1DataContext();
            lista_musica = new List<Musica>();
       
          
            
        }
      
        private void indexarCarpetasDeMúsicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void indexarMúsicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Indexar f1 = new Indexar();
            f1.ShowDialog();
        }

       

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cambiar_URL)
            {

                Reproductor.URL = (listBox1.Items[listBox1.SelectedIndex] as Musica).Direccion;
                index = listBox1.SelectedIndex;
                if(index==index2)
                index2 = listBox1.SelectedIndex;
                dt.Settings.First(a => a.Id == 1).Valor = "1";
                dt.SubmitChanges();
            }
            else
                cambiar_URL = true;
     
            
        }

        private void nuevaListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nueva_Lista nueva_lista_reproduccion = new Nueva_Lista();
            nueva_lista_reproduccion.ShowDialog();
        }

        private void modificarListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modificar_Lista modificar_lista = new Modificar_Lista();
            modificar_lista.ShowDialog();
        }

        private void eliminarListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Eliminar_Lista eliminar_lista = new Eliminar_Lista();
            eliminar_lista.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            rep_aleatoria = false;
            Elegir_Lista elegir_lista = new Elegir_Lista();
            elegir_lista.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            rep_aleatoria = true;
            Elegir_Lista elegir_lista = new Elegir_Lista();
            elegir_lista.ShowDialog();
        }
        private void LaVitrola_Load(object sender, EventArgs e)
        {
            listBox1.DisplayMember = "Nombre_Cancion";
            listBox1.ValueMember = "Id";
            if (dt.PlayLists.Where(a => a.Activa.Value).Count() > 0)
            {
                //foreach (PlayList_Musica pm in dt.PlayLists.Where(a => a.Activa.Value).First().PlayList_Musicas)
                //{
                //    listBox1.Items.Add(pm.Musica);
                //}

                progressBar1.Maximum = dt.PlayLists.Where(a => a.Activa.Value).First().PlayList_Musicas.Count();

                backgroundWorker1.RunWorkerAsync();

                

            }
            else
            {
                this.Text = "La Vitrola";
            }
            timer2.Enabled = true;
        }

        private void CargarLista()
        {
            var musica_de_lista = from t in dt.PlayList_Musicas
                                  where t.PlayList.Activa.Value
                                  select t.Musica;

            foreach (PlayList_Musica pm in dt.PlayList_Musicas)
            {
                pm.Activo = false;
            }
            dt.SubmitChanges();

            List<Musica> musica_Lista = new List<Musica>();
            musica_Lista = musica_de_lista.ToList();
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
                   
                    indices[var_aleatoria] = true; p++;
                    backgroundWorker1.ReportProgress(p);

                    if (musica.Count < musica_Lista.Count())
                        while (indices[var_aleatoria])
                            var_aleatoria = new Random().Next(0, musica_Lista.Count);
                }

            }
            lista_musica = musica;
        }
    

        private void LaVitrola_Activated(object sender, EventArgs e)
        {
            if (needed)
            {
                if (lista_musica.Count > 0)
                {
                   
                  
                    listBox1.DisplayMember = "Nombre_Cancion";
                    listBox1.ValueMember = "Id";
                    listBox1.Items.Clear();
                    foreach (Musica m in lista_musica)
                    {
                        listBox1.Items.Add(m);
                    }
                    listBox1.SelectedIndex = 0;
                   
                   
                }
                else
                {
                    listBox1.Items.Clear();
                    lista_musica = new List<Musica>();
                    timer1.Enabled = false;
                    Reproductor.Ctlcontrols.stop();
                   
                    this.Text = "La Vitrola";
                    dt.Settings.First(a => a.Id == 1).Valor = "0";
                    dt.SubmitChanges();

                }
                this.Text = "La Vitrola (" + listBox1.Items.Count + " canciones" + ")";
                needed = false;
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] nombres_archivos = openFileDialog1.SafeFileNames;
                string[] direcciones= openFileDialog1.FileNames;
                Musica nueva_musica;
                for (int i = 0; i < nombres_archivos.Length; i++)
                {
                    nueva_musica = new Musica();
                    nueva_musica.Nombre_Cancion = nombres_archivos[i];
                    nueva_musica.Direccion = direcciones[i];
                    listBox1.Items.Add(nueva_musica);
                }
                this.Text = "La Vitrola (" + listBox1.Items.Count + " canciones" + ")";
            }
        }
        bool end = false;
        private void Reproductor_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (Reproductor.playState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                if (index < listBox1.Items.Count - 1)
                {
                    index++;

                    if (index == index2)
                    {
                        index2++;
                    }

                    listBox1.SelectedIndex = index;

                    timer1.Enabled = true;
                    timer1.Start();
                }
                else
                    if (checkBox1.Checked)
                {
                    index = 0;
                    index2 = 0;
                    listBox1.SelectedIndex = index;

                    timer1.Enabled = true;
                    timer1.Start();
                }
                else
                {
                    end = true;

                }
               

            }
            else
                if (Reproductor.playState == WMPLib.WMPPlayState.wmppsStopped || Reproductor.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                timer1.Stop();
            }
            else if (Reproductor.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                Reproductor.fullScreen = true;
            }
          
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!end)
            {
                Reproductor.Ctlcontrols.play();
               
            }
            else
            {
                index = 0;
                index2 = 0;
                listBox1.SelectedIndex = index;
                timer1.Stop();
                Reproductor.Ctlcontrols.stop();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            List<Musica> reproduciendo = new List<Musica>();



            if (dt.PlayList_Musicas.Count(a => a.Activo.Value) > 0)//hay peticiones
            {
              
                foreach (var t in listBox1.Items)
                {
                    reproduciendo.Add(t as Musica);
                }

                var peticiones_activas = from t in dt.PlayList_Musicas
                                         where  t.Activo.Value
                                         select t;

                
                foreach (PlayList_Musica pm in peticiones_activas)
                {
                    if (reproduciendo.Contains(pm.Musica))
                    {
                        reproduciendo.Remove(pm.Musica);
                    }

                    index2 = index2 + 1;
                    reproduciendo.Insert(index2, pm.Musica);
                    listBox1.Text += "DC" + listBox1.Text;
                    dt.D_DesactivarMusica(pm.Id_Musica);
                }

                dt.SubmitChanges();
                listBox1.DisplayMember = "Nombre_Cancion";
                listBox1.ValueMember = "Id";
                listBox1.Items.Clear();
               
                foreach (Musica pm in reproduciendo)
                {
                    listBox1.Items.Add(pm);
                  
                }
                cambiar_URL = false;
                listBox1.SelectedIndex = index;
                this.Text = "La Vitrola (" + listBox1.Items.Count + " canciones" + ")";
                

            }

            timer2.Start();
        }

        private void LaVitrola_FormClosed(object sender, FormClosedEventArgs e)
        {
            dt.Settings.First(a => a.Id == 1).Valor = "0";
            dt.SubmitChanges();
        }

        private void button4_Click(object sender, EventArgs e) //Eliminar Cancion
        {
            if (listBox1.SelectedItem != null)
            {
                int i = listBox1.SelectedIndex;
                listBox1.SelectedIndex = i + 1;
                listBox1.Items.RemoveAt(i);
                this.Text = "La Vitrola (" + listBox1.Items.Count + " canciones" + ")";
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           
            CargarLista();
           
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                
                foreach (Musica m in lista_musica)
                {
                    listBox1.Items.Add(m);
                }
                this.Text = "La Vitrola (" + listBox1.Items.Count + " canciones" + ")";
            }
        }
    }
}
