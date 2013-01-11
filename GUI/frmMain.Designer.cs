namespace GUI {
	partial class frmMain {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.comOpen = new System.Windows.Forms.Button();
			this.comClasify = new System.Windows.Forms.Button();
			this.dialogFolders = new System.Windows.Forms.FolderBrowserDialog();
			this.listView = new System.Windows.Forms.ListView();
			this.path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.category = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.pbFaca = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.programBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pbFaca)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// comOpen
			// 
			this.comOpen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.comOpen.Location = new System.Drawing.Point(685, 12);
			this.comOpen.Name = "comOpen";
			this.comOpen.Size = new System.Drawing.Size(159, 40);
			this.comOpen.TabIndex = 1;
			this.comOpen.Text = "Otvori direktorij";
			this.comOpen.UseVisualStyleBackColor = true;
			this.comOpen.Click += new System.EventHandler(this.button1_Click);
			// 
			// comClasify
			// 
			this.comClasify.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.comClasify.Location = new System.Drawing.Point(685, 76);
			this.comClasify.Name = "comClasify";
			this.comClasify.Size = new System.Drawing.Size(158, 41);
			this.comClasify.TabIndex = 2;
			this.comClasify.Text = "Klasificiraj";
			this.comClasify.UseVisualStyleBackColor = true;
			this.comClasify.Click += new System.EventHandler(this.comClasify_Click);
			// 
			// dialogFolders
			// 
			this.dialogFolders.RootFolder = System.Environment.SpecialFolder.MyComputer;
			// 
			// listView
			// 
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.path,
            this.category});
			this.listView.Location = new System.Drawing.Point(12, 12);
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(657, 615);
			this.listView.TabIndex = 3;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
			// 
			// path
			// 
			this.path.Text = "Slika";
			this.path.Width = 500;
			// 
			// category
			// 
			this.category.Text = "Klasifikacija";
			this.category.Width = 120;
			// 
			// pbFaca
			// 
			this.pbFaca.Location = new System.Drawing.Point(685, 145);
			this.pbFaca.Name = "pbFaca";
			this.pbFaca.Size = new System.Drawing.Size(492, 482);
			this.pbFaca.TabIndex = 4;
			this.pbFaca.TabStop = false;
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.button1.Location = new System.Drawing.Point(1077, 15);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(99, 36);
			this.button1.TabIndex = 5;
			this.button1.Text = "Autori";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// programBindingSource
			// 
			this.programBindingSource.DataSource = typeof(GUI.Program);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1189, 639);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pbFaca);
			this.Controls.Add(this.listView);
			this.Controls.Add(this.comClasify);
			this.Controls.Add(this.comOpen);
			this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "frmMain";
			this.Text = "Klasifikacija osoba na temelju rase ili pripadnosti skupinama";
			((System.ComponentModel.ISupportInitialize)(this.pbFaca)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button comOpen;
		private System.Windows.Forms.Button comClasify;
		private System.Windows.Forms.FolderBrowserDialog dialogFolders;
		private System.Windows.Forms.BindingSource programBindingSource;
		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.ColumnHeader path;
		private System.Windows.Forms.ColumnHeader category;
		private System.Windows.Forms.PictureBox pbFaca;
		private System.Windows.Forms.Button button1;
	}
}

