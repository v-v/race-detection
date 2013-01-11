using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GUI {
	public partial class frmMain : Form {
		public frmMain() {
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e) {
			dialogFolders.ShowDialog();

			listView.BeginUpdate();
			foreach (string file in System.IO.Directory.GetFiles(dialogFolders.SelectedPath, "*", System.IO.SearchOption.TopDirectoryOnly)) {
				if (file.EndsWith(".png") || file.EndsWith(".jpg") || file.EndsWith(".bmp"))
					listView.Items.Add(file);
			}
			listView.EndUpdate();
		}

		private void comClasify_Click(object sender, EventArgs e) {
			foreach (ListViewItem image in listView.SelectedItems) {
				//TODO: Dodati poziv prema klasifikatoru
				//string rezultat = klasificiraj(path);
				//listView.Items[image.Index].SubItems.Add(rezultat);
				listView.Items[image.Index].SubItems.Add("niger");
			}
		}

		private void listView_SelectedIndexChanged(object sender, EventArgs e) {
			if (listView.SelectedItems.Count == 1)
				pbFaca.Load(listView.SelectedItems[0].Text);

		}

		private void button1_Click_1(object sender, EventArgs e) {
			 DialogResult result = MessageBox.Show("Toni Kork\nDamjan Križaić\nSlaven Mišak\nAndrija Stepić\nDomagoj Šalković\nMarko Vrljičak\nPetra Vučković\nVedran Vukotić", "Autori",MessageBoxButtons.OK );
		}
	}
}
