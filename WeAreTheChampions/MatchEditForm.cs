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
    public partial class MatchEditForm : Form
    {
        private readonly ApplicationDbContext db;
        private readonly Match editedMatch;

        public MatchEditForm(ApplicationDbContext db, Match editedMatch)
        {
            InitializeComponent();
            this.db = db;
            this.editedMatch = editedMatch;
            GetValues();
        }

        private void GetValues()
        {
            cboTeam1.DataSource = db.Teams.ToList();
            cboTeam2.DataSource = db.Teams.ToList();

            editedMatch.Team1Name = (Team)cboTeam1.SelectedItem;
            editedMatch.Team2Name = (Team)cboTeam2.SelectedItem;
            editedMatch.Team1Score = (int)nudTeam1Score.Value;
            editedMatch.Team2Score = (int)nudTeam2Score.Value;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dtpMatchTime.Value < DateTime.Now)
            {
                MessageBox.Show("Date is invalid.");
                return;
            }
            editedMatch.MatchTime = dtpMatchTime.Value;
            if (cboTeam1.SelectedItem == cboTeam2.SelectedItem)
            {
                MessageBox.Show("The same 2 teams cannot play a match.");
                return;
            }
            editedMatch.Team1Name = (Team)cboTeam1.SelectedItem;
            editedMatch.Team2Name = (Team)cboTeam2.SelectedItem;
            editedMatch.Team1Score = (int)nudTeam1Score.Value;
            editedMatch.Team2Score = (int)nudTeam2Score.Value;
            
            db.SaveChanges();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
