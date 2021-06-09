using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace La_Vitrola_App
{
    public partial class Nueva_Lista : Form
    {
        DataClasses1DataContext dt = new DataClasses1DataContext();
        public Nueva_Lista()
        {
            InitializeComponent();
            listBox4.DisplayMember = "Nombre_Cancion";
            listBox4.ValueMember = "Id";
            label6.Text = "";
            label7.Text = "";
        }

        private void Nueva_Lista_Load(object sender, EventArgs e)
        {
            var autores = from t in dt.Autors
                          select t;

            listBox1.DataSource = autores.OrderBy(a => a.Nombre);
            listBox1.DisplayMember = "Nombre";
            listBox1.ValueMember = "Id";

            var albums = from t in dt.Albums
                         where t.Id_Autor == Convert.ToInt16(listBox1.SelectedValue)
                         select t;
            listBox2.DataSource = albums.OrderBy(a => a.Nombre);
            listBox2.DisplayMember = "Nombre";
            listBox2.ValueMember = "Id";

            var canciones = from t in dt.Musicas
                          where t.Id_Album == Convert.ToInt16(listBox2.SelectedValue)
                          select t;
            listBox3.DataSource = canciones.OrderBy(a => a.Nombre_Cancion);
            listBox3.DisplayMember = "Nombre_Cancion";
            listBox3.ValueMember = "Id";

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var albums = from t in dt.Albums
                         where t.Id_Autor == Convert.ToInt16(listBox1.SelectedValue)
                         select t;
            listBox2.DisplayMember = "Nombre";
            listBox2.ValueMember = "Id";
            listBox2.DataSource = albums.OrderBy(a => a.Nombre);
            
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var canciones = from t in dt.Musicas
                            where t.Id_Album == Convert.ToInt16(listBox2.SelectedValue)
                            select t;
            listBox3.DisplayMember = "Nombre_Cancion";
            listBox3.ValueMember = "Id";
            listBox3.DataSource = canciones.OrderBy(a => a.Nombre_Cancion);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox3.SelectedItems.Count; i++)
            {
                if (!listBox4.Items.Contains(listBox3.SelectedItems[i]))
                    listBox4.Items.Add(listBox3.SelectedItems[i]);
            }
            label7.Text = listBox4.Items.Count + " canciones.";
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            listBox4.Items.RemoveAt(listBox4.SelectedIndex);
            label7.Text = listBox4.Items.Count + " canciones.";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (listBox4.Items.Count > 0)
                {
                    try
                    {
                        button2.Enabled = false;
                        button1.Enabled = false;
                        backgroundWorker1.RunWorkerAsync();


                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Debe añadir canciones a la lista");
                }
                
            }
            else
            {
                MessageBox.Show("Debe nombrar la nueva lista de reproducción");
            }
        }

        void CrearLista()
        {
            PlayList nueva_lista = new PlayList();
            nueva_lista.Nombre = textBox1.Text;
            dt.PlayLists.InsertOnSubmit(nueva_lista);

            for (int i = 0; i < listBox4.Items.Count; i++)
            {
                PlayList_Musica list_musica = new PlayList_Musica();
                list_musica.Id_Musica = (listBox4.Items[i] as Musica).Id;
                list_musica.Id_PlayList = nueva_lista.Id;
                list_musica.De_Cliente = false;
                list_musica.Activo = false;
                list_musica.Fecha_Insertada = DateTime.Now;
                nueva_lista.PlayList_Musicas.Add(list_musica);
            }
            dt.SubmitChanges();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            CrearLista();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                button2.Enabled = true;
                button1.Enabled = true;
                if (MessageBox.Show("Lista Registrada Exitosamente") == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }
    }
}
