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
    public partial class Modificar_Lista : Form
    {
        DataClasses1DataContext dt = new DataClasses1DataContext();
        int id = 0;
        public Modificar_Lista()
        {
            InitializeComponent();
            listBox4.DisplayMember = "Nombre_Cancion";
            listBox4.ValueMember = "Id";
            label6.Text = "";
        }

        private void Modificar_Lista_Load(object sender, EventArgs e)
        {

            var listas = from t in dt.PlayLists
                         select t;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = listas.OrderBy(a => a.Nombre);
            if (comboBox1.Items.Count > 0)
            {
                id = Convert.ToInt16(comboBox1.SelectedValue);
                var musica_de_lista = from t in dt.PlayList_Musicas
                                      where t.Id_PlayList == Convert.ToInt16(comboBox1.SelectedValue)
                                      select t.Musica;

                textBox1.Text = musica_de_lista.First().PlayList_Musicas.First().PlayList.Nombre;




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
                label8.Text = listBox4.Items.Count + " canciones.";
            }
            else
                if (MessageBox.Show("No hay listas registradas.") == DialogResult.OK)
            {
                this.Close();
            }



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
            button1.Enabled = false;
            for (int i = 0; i < listBox3.SelectedItems.Count; i++)
            {
                if (!listBox4.Items.Contains(listBox3.SelectedItems[i]))
                    listBox4.Items.Add(listBox3.SelectedItems[i]);
            }
            label8.Text = listBox4.Items.Count + " canciones.";
            button1.Enabled = true;

        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            listBox4.Items.RemoveAt(listBox4.SelectedIndex);
            label8.Text = listBox4.Items.Count + " canciones.";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    backgroundWorker1.RunWorkerAsync();

                   
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                label6.Text = "Debe nombrar la nueva lista de reproducción";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
            var musica_de_lista = from t in dt.PlayList_Musicas
                                  where t.Id_PlayList == Convert.ToInt16(comboBox1.SelectedValue)
                                  select t.Musica;
            textBox1.Text = (comboBox1.SelectedItem as PlayList).Nombre;
            listBox4.DisplayMember = "Nombre_Cancion";
            listBox4.ValueMember = "Id";
            foreach (Musica m in musica_de_lista)
            {
                listBox4.Items.Add(m);
            }
            id = Convert.ToInt16(comboBox1.SelectedValue);
        }

       bool Ya_Esta(object o1, ListBox list2)
        {
            bool result = false;

            foreach (object o2 in list2.Items)
            {
                if (o1.Equals(o2))
                {
                    result = true;
                    break;
                }
            }
              
     
            return result;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var lista_musica = from t in dt.PlayLists
                               where t.Id == id
                               select t;

            var musica_de_lista = from t in dt.PlayList_Musicas
                                  where t.Id_PlayList == id
                                  select t;
            dt.PlayList_Musicas.DeleteAllOnSubmit(musica_de_lista);


            lista_musica.First().Nombre = textBox1.Text;


            PlayList_Musica musica_de_playList;
            foreach (Musica m in listBox4.Items)
            {
                musica_de_playList = new PlayList_Musica();
                musica_de_playList.Id_Musica = m.Id;
                musica_de_playList.Id_PlayList = lista_musica.First().Id;
                musica_de_playList.De_Cliente = false;
                musica_de_playList.Fecha_Insertada = DateTime.Now;

                dt.PlayList_Musicas.InsertOnSubmit(musica_de_playList);
            }
            dt.SubmitChanges();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                var musica = from t in dt.PlayList_Musicas
                             where t.Id_PlayList == Convert.ToInt16(comboBox1.SelectedValue)
                             select t.Musica;
                button1.Enabled = true;
                button2.Enabled = true;
                LaVitrola.needed = true;
                LaVitrola.lista_musica = musica.ToList();
                if (MessageBox.Show("Lista Modificada Exitosamente") == DialogResult.OK)
                {
                    //this.Close();
                }
            }
        }
    }
}
