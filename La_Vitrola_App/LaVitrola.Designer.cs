namespace La_Vitrola_App
{
    partial class LaVitrola
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaVitrola));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.indexarMúsicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearListaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaListaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarListaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarListaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Reproductor = new AxWMPLib.AxWindowsMediaPlayer();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Reproductor)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.indexarMúsicaToolStripMenuItem,
            this.crearListaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(855, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // indexarMúsicaToolStripMenuItem
            // 
            this.indexarMúsicaToolStripMenuItem.Name = "indexarMúsicaToolStripMenuItem";
            this.indexarMúsicaToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.indexarMúsicaToolStripMenuItem.Text = "Indexar Música";
            this.indexarMúsicaToolStripMenuItem.Click += new System.EventHandler(this.indexarMúsicaToolStripMenuItem_Click);
            // 
            // crearListaToolStripMenuItem
            // 
            this.crearListaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaListaToolStripMenuItem,
            this.modificarListaToolStripMenuItem,
            this.eliminarListaToolStripMenuItem});
            this.crearListaToolStripMenuItem.Name = "crearListaToolStripMenuItem";
            this.crearListaToolStripMenuItem.Size = new System.Drawing.Size(141, 20);
            this.crearListaToolStripMenuItem.Text = "Listas de Reproducción";
            // 
            // nuevaListaToolStripMenuItem
            // 
            this.nuevaListaToolStripMenuItem.Name = "nuevaListaToolStripMenuItem";
            this.nuevaListaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevaListaToolStripMenuItem.Text = "Nueva Lista";
            this.nuevaListaToolStripMenuItem.Click += new System.EventHandler(this.nuevaListaToolStripMenuItem_Click);
            // 
            // modificarListaToolStripMenuItem
            // 
            this.modificarListaToolStripMenuItem.Name = "modificarListaToolStripMenuItem";
            this.modificarListaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.modificarListaToolStripMenuItem.Text = "Modificar Lista";
            this.modificarListaToolStripMenuItem.Click += new System.EventHandler(this.modificarListaToolStripMenuItem_Click);
            // 
            // eliminarListaToolStripMenuItem
            // 
            this.eliminarListaToolStripMenuItem.Name = "eliminarListaToolStripMenuItem";
            this.eliminarListaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.eliminarListaToolStripMenuItem.Text = "Eliminar Lista";
            this.eliminarListaToolStripMenuItem.Click += new System.EventHandler(this.eliminarListaToolStripMenuItem_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 21;
            this.listBox1.Location = new System.Drawing.Point(572, 56);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(274, 403);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Mp3|*.mp3";
            this.openFileDialog1.Multiselect = true;
            // 
            // Reproductor
            // 
            this.Reproductor.Enabled = true;
            this.Reproductor.Location = new System.Drawing.Point(-2, 56);
            this.Reproductor.Name = "Reproductor";
            this.Reproductor.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Reproductor.OcxState")));
            this.Reproductor.Size = new System.Drawing.Size(568, 403);
            this.Reproductor.TabIndex = 1;
            this.Reproductor.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.Reproductor_PlayStateChange);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Abrir Lista";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(104, 27);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Añadir Canción";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(312, 31);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(101, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Repetir Siempre";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(208, 27);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(98, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Eliminar Canción";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 465);
            this.progressBar1.Maximum = 200;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(855, 29);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 8;
            // 
            // LaVitrola
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 500);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.Reproductor);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "LaVitrola";
            this.Text = "La Vitrola";
            this.Activated += new System.EventHandler(this.LaVitrola_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LaVitrola_FormClosed);
            this.Load += new System.EventHandler(this.LaVitrola_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Reproductor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem indexarMúsicaToolStripMenuItem;
        private AxWMPLib.AxWindowsMediaPlayer Reproductor;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem crearListaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaListaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarListaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarListaToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

