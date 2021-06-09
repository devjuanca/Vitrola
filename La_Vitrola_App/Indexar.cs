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
namespace La_Vitrola_App
{
    public partial class Indexar : Form
    {
  
        public Indexar()
        {
            InitializeComponent();
        }

        private void Indexar_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            label1.Visible = false;
            result_label.Visible = false;
        }


        void IndexacionRecursiva(DirectoryInfo root)
        {
            DataClasses1DataContext dt = new DataClasses1DataContext();
            if (root.GetDirectories().Length > 0)
            {
                List<Musica> lista = new List<Musica>();
           
             
                foreach (DirectoryInfo autor in root.GetDirectories())
                {
                    Autor newAutor = new Autor();
                    newAutor.Nombre = autor.Name;
                    dt.Autors.InsertOnSubmit(newAutor);
                    foreach (DirectoryInfo album in autor.GetDirectories())
                    {
                        Album newAlbum = new Album();
                        newAlbum.Nombre = album.Name;
                        newAutor.Albums.Add(newAlbum);
                        newAlbum.Id_Autor = newAutor.Id;
                        dt.Albums.InsertOnSubmit(newAlbum);

                        foreach (FileInfo song in album.GetFiles())
                        {
                            if (song.Extension == ".mp3" || song.Extension == ".wma" || song.Extension == ".mp4" || song.Extension == ".avi" || song.Extension == ".mpg" || song.Extension == ".mkv")
                            {
                                Musica cancion = new Musica();

                                cancion.Nombre_Cancion = song.Name;
                                cancion.Direccion = song.FullName;
                                newAlbum.Musicas.Add(cancion);
                                cancion.Id_Album = newAlbum.Id;
                                cancion.Tipo = (song.Extension == ".mp3" || song.Extension == ".wma") ? 0 : 1;
                                dt.Musicas.InsertOnSubmit(cancion);
                            }

                        }
                    }
                    

                }

                dt.SubmitChanges();



            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string root = folderBrowserDialog1.SelectedPath;
                textBox1.Text = root;
                DirectoryInfo rootFolder = new DirectoryInfo(root);
          

           


            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
            DirectoryInfo rootFolder = new DirectoryInfo(textBox1.Text);
            DataClasses1DataContext dt = new DataClasses1DataContext();
            dt.PlayList_Musicas.DeleteAllOnSubmit(dt.PlayList_Musicas);
            dt.Musicas.DeleteAllOnSubmit(dt.Musicas);
            dt.PlayLists.DeleteAllOnSubmit(dt.PlayLists);
            dt.Albums.DeleteAllOnSubmit(dt.Albums);
            dt.Autors.DeleteAllOnSubmit(dt.Autors);
            dt.SubmitChanges();

            IndexacionRecursiva(rootFolder);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                button2.Enabled = false;
                result_label.Visible = true;
                result_label.Text = "Comenzó: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                progressBar1.Visible = true;
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                result_label.Text = "Seleccione Carpeta de Música";
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
            
                button2.Enabled = true;
                progressBar1.Visible = false;
                label1.Visible = true;
                label1.Text = "Termino:   " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            }
            else
                MessageBox.Show(e.Error.Message);
        }
    }
}
