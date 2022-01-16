using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeAreTheChampions.Data;
using WeAreTheChampions.Models;

namespace WeAreTheChampions
{
    public partial class ColorForm : Form
    {
        private readonly ApplicationDbContext db;
        Models.Color editedColor, deletedColor;

        public ColorForm(ApplicationDbContext db)
        {
            InitializeComponent();
            this.db = db;
            ListColors();
        }

        private void ListColors()
        {
            lstColors.DataSource = db.Colors.ToList();
            lstColors.DisplayMember = "ColorName";
        }

        private void btnColorAdd_Click(object sender, EventArgs e)
        {
            if (txtColorName.Text.Trim() == "")
            {
                MessageBox.Show("The field can't be empty.");
                return;
            }
            if (btnColorAdd.Text == "Add")
            {
                if (db.Colors.Any(x => x.ColorName == txtColorName.Text.Trim()))
                {
                    MessageBox.Show("This color taken. Select another one.");
                    return;
                }
                Models.Color color = new Models.Color()
                {
                    ColorName = txtColorName.Text.Trim(),
                    Red = (int)nudColorRed.Value,
                    Green = (int)nudColorGreen.Value,
                    Blue = (int)nudColorBlue.Value
                };
                db.Colors.Add(color);
            }
            else if (btnColorAdd.Text == "Edit")
            {
                editedColor.ColorName = txtColorName.Text;
                editedColor.Red = (int)nudColorRed.Value;
                editedColor.Green = (int)nudColorGreen.Value;
                editedColor.Blue = (int)nudColorBlue.Value;
                btnColorAdd.Text = "Add";
            }

            db.SaveChanges();
            ListColors();
            Clean();
        }

        private void Clean()
        {
            txtColorName.Text = "";
            nudColorRed.Value = 0;
            nudColorBlue.Value = 0;
            nudColorGreen.Value = 0;
        }

        private void btnColorEdit_Click(object sender, EventArgs e)
        {
            
            if (btnColorEdit.Text == "Edit")
            {
                if (lstColors.SelectedItems.Count == 0) return;
                editedColor = (Models.Color)lstColors.SelectedItem;
                txtColorName.Text = editedColor.ColorName;
                nudColorRed.Value = (int)editedColor.Red;
                nudColorGreen.Value = (int)editedColor.Green;
                nudColorBlue.Value = (int)editedColor.Blue;
                btnColorAdd.Text = "Edit";
                btnColorEdit.Text = "Cancel";
            }

            else if (btnColorEdit.Text == "Cancel")
            {
                btnColorEdit.Text = "Edit";
                btnColorAdd.Text = "Add";
                txtColorName.Text = "";
                nudColorRed.Value = 0;
                nudColorGreen.Value = 0;
                nudColorBlue.Value = 0;
                return;
            }
        }

        private void lstColors_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                deletedColor = (Models.Color)lstColors.SelectedItem;
                db.Colors.Remove(deletedColor);
                db.SaveChanges();
            }
            ListColors();
        }
    }
}
