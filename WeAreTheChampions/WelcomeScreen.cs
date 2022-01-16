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
    public partial class WelcomeScreen : Form
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public WelcomeScreen()
        {
            InitializeComponent();
            LoadMatches();
        }        
        private void LoadMatches()
        {
            var matches = db.Matches.ToList();
            foreach (Match match in matches)
            {
                if (match.Team1Score > match.Team2Score)
                    match.Result = Enum.Result.Team1Won;
                else if (match.Team1Score < match.Team2Score)
                    match.Result = Enum.Result.Team2Won;
                else
                    match.Result = Enum.Result.Draw;
            }
            db.SaveChanges();
            dgvMatches.DataSource = db.Matches
                .Select(x => new
                {
                    Id = x.MatchId,
                    Team1 = x.Team1Name.TeamName,
                    Team2 = x.Team2Name.TeamName,
                    Date = x.MatchTime,
                    Result = x.Result
                }).ToList();
            dgvMatches.Columns[0].Visible = false;
        }


        private void colorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorForm colorForm = new ColorForm(db);
            colorForm.ShowDialog();
        }

        private void teamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeamForm teamForm = new TeamForm(db);
            teamForm.ShowDialog();
        }

        private void playersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayerForm playerForm = new PlayerForm(db);
            playerForm.ShowDialog();
        }

        private void btnNewMatch_Click(object sender, EventArgs e)
        {
            MatchForm matchForm = new MatchForm(db);
            matchForm.ShowDialog();
            LoadMatches();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvMatches.SelectedRows.Count == 0) return;
            int id = (int)dgvMatches.SelectedRows[0].Cells[0].Value;
            Match editedMatch = db.Matches.ToList().FirstOrDefault(x => x.MatchId == id);
            MatchEditForm matchEditForm = new MatchEditForm(db, editedMatch);
            matchEditForm.ShowDialog();
            LoadMatches();
        }
        private void dgvMatches_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                int id = (int)dgvMatches.SelectedRows[0].Cells[0].Value;
                Match deletedMatch = db.Matches.Find(id);
                db.Matches.Remove(deletedMatch);
                db.SaveChanges();
            }
            LoadMatches();
        }
    }
}
