namespace TraitementDimage
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seuillageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.additionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soustractionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erosionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erosionWhiteBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.ErosionBlackBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.dillatationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DillatationWhiteBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.DilationBlackBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.ouvertureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fermetureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.amincissementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.epaississementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fonctionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squeletisationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lantuejoulToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.amincissementHomothopiqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.operationToolStripMenuItem,
            this.fonctionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1134, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // operationToolStripMenuItem
            // 
            this.operationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seuillageToolStripMenuItem,
            this.additionToolStripMenuItem,
            this.soustractionToolStripMenuItem,
            this.erosionToolStripMenuItem,
            this.dillatationToolStripMenuItem,
            this.ouvertureToolStripMenuItem,
            this.fermetureToolStripMenuItem,
            this.amincissementToolStripMenuItem,
            this.epaississementToolStripMenuItem,
            this.grisToolStripMenuItem});
            this.operationToolStripMenuItem.Name = "operationToolStripMenuItem";
            this.operationToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.operationToolStripMenuItem.Text = "Operation";
            // 
            // seuillageToolStripMenuItem
            // 
            this.seuillageToolStripMenuItem.Name = "seuillageToolStripMenuItem";
            this.seuillageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.seuillageToolStripMenuItem.Text = "Seuillage...";
            this.seuillageToolStripMenuItem.Click += new System.EventHandler(this.seuillageToolStripMenuItem_Click);
            // 
            // additionToolStripMenuItem
            // 
            this.additionToolStripMenuItem.Name = "additionToolStripMenuItem";
            this.additionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.additionToolStripMenuItem.Text = "Addition";
            this.additionToolStripMenuItem.Click += new System.EventHandler(this.additionToolStripMenuItem_Click);
            // 
            // soustractionToolStripMenuItem
            // 
            this.soustractionToolStripMenuItem.Name = "soustractionToolStripMenuItem";
            this.soustractionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.soustractionToolStripMenuItem.Text = "Soustraction";
            this.soustractionToolStripMenuItem.Click += new System.EventHandler(this.soustractionToolStripMenuItem_Click);
            // 
            // erosionToolStripMenuItem
            // 
            this.erosionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.erosionWhiteBackground,
            this.ErosionBlackBackground});
            this.erosionToolStripMenuItem.Name = "erosionToolStripMenuItem";
            this.erosionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.erosionToolStripMenuItem.Text = "Erosion...";
            // 
            // erosionWhiteBackground
            // 
            this.erosionWhiteBackground.Name = "erosionWhiteBackground";
            this.erosionWhiteBackground.Size = new System.Drawing.Size(180, 22);
            this.erosionWhiteBackground.Text = "White background";
            this.erosionWhiteBackground.Click += new System.EventHandler(this.ErosionWhiteBackground_Click);
            // 
            // ErosionBlackBackground
            // 
            this.ErosionBlackBackground.Name = "ErosionBlackBackground";
            this.ErosionBlackBackground.Size = new System.Drawing.Size(180, 22);
            this.ErosionBlackBackground.Text = "Black background";
            this.ErosionBlackBackground.Click += new System.EventHandler(this.ErosionBlackBackground_Click);
            // 
            // dillatationToolStripMenuItem
            // 
            this.dillatationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DillatationWhiteBackground,
            this.DilationBlackBackground});
            this.dillatationToolStripMenuItem.Name = "dillatationToolStripMenuItem";
            this.dillatationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dillatationToolStripMenuItem.Text = "Dillatation...";
            // 
            // DillatationWhiteBackground
            // 
            this.DillatationWhiteBackground.Name = "DillatationWhiteBackground";
            this.DillatationWhiteBackground.Size = new System.Drawing.Size(180, 22);
            this.DillatationWhiteBackground.Text = "White background";
            this.DillatationWhiteBackground.Click += new System.EventHandler(this.DillatationWhiteBackground_Click);
            // 
            // DilationBlackBackground
            // 
            this.DilationBlackBackground.Name = "DilationBlackBackground";
            this.DilationBlackBackground.Size = new System.Drawing.Size(180, 22);
            this.DilationBlackBackground.Text = "Black background";
            this.DilationBlackBackground.Click += new System.EventHandler(this.DilatationBlackBackground_Click);
            // 
            // ouvertureToolStripMenuItem
            // 
            this.ouvertureToolStripMenuItem.Name = "ouvertureToolStripMenuItem";
            this.ouvertureToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ouvertureToolStripMenuItem.Text = "Ouverture...";
            this.ouvertureToolStripMenuItem.Click += new System.EventHandler(this.ouvertureToolStripMenuItem_Click);
            // 
            // fermetureToolStripMenuItem
            // 
            this.fermetureToolStripMenuItem.Name = "fermetureToolStripMenuItem";
            this.fermetureToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fermetureToolStripMenuItem.Text = "Fermeture...";
            // 
            // amincissementToolStripMenuItem
            // 
            this.amincissementToolStripMenuItem.Name = "amincissementToolStripMenuItem";
            this.amincissementToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.amincissementToolStripMenuItem.Text = "Amincissement...";
            // 
            // epaississementToolStripMenuItem
            // 
            this.epaississementToolStripMenuItem.Name = "epaississementToolStripMenuItem";
            this.epaississementToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.epaississementToolStripMenuItem.Text = "Epaississement...";
            // 
            // grisToolStripMenuItem
            // 
            this.grisToolStripMenuItem.Name = "grisToolStripMenuItem";
            this.grisToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.grisToolStripMenuItem.Text = "Gris";
            this.grisToolStripMenuItem.Click += new System.EventHandler(this.grisToolStripMenuItem_Click);
            // 
            // fonctionToolStripMenuItem
            // 
            this.fonctionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.squeletisationToolStripMenuItem});
            this.fonctionToolStripMenuItem.Name = "fonctionToolStripMenuItem";
            this.fonctionToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.fonctionToolStripMenuItem.Text = "Fonction";
            // 
            // squeletisationToolStripMenuItem
            // 
            this.squeletisationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lantuejoulToolStripMenuItem,
            this.amincissementHomothopiqueToolStripMenuItem});
            this.squeletisationToolStripMenuItem.Name = "squeletisationToolStripMenuItem";
            this.squeletisationToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.squeletisationToolStripMenuItem.Text = "Squelettisation";
            // 
            // lantuejoulToolStripMenuItem
            // 
            this.lantuejoulToolStripMenuItem.Name = "lantuejoulToolStripMenuItem";
            this.lantuejoulToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.lantuejoulToolStripMenuItem.Text = "Lantuejoul";
            // 
            // amincissementHomothopiqueToolStripMenuItem
            // 
            this.amincissementHomothopiqueToolStripMenuItem.Name = "amincissementHomothopiqueToolStripMenuItem";
            this.amincissementHomothopiqueToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.amincissementHomothopiqueToolStripMenuItem.Text = "Amincissement homothopique";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(87, 87);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 250);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(434, 87);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(250, 250);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(792, 87);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(250, 250);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(173, 371);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(63, 17);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Image 1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(525, 371);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(63, 17);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Image 2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(872, 371);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(87, 17);
            this.radioButton3.TabIndex = 7;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Result Image";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 450);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seuillageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem additionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soustractionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erosionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dillatationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ouvertureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fermetureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem amincissementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem epaississementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fonctionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem squeletisationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lantuejoulToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem amincissementHomothopiqueToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.ToolStripMenuItem grisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erosionWhiteBackground;
        private System.Windows.Forms.ToolStripMenuItem ErosionBlackBackground;
        private System.Windows.Forms.ToolStripMenuItem DillatationWhiteBackground;
        private System.Windows.Forms.ToolStripMenuItem DilationBlackBackground;
    }
}

