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
    public partial class MatchForm : Form
    {
        private readonly ApplicationDbContext db;

        public MatchForm(ApplicationDbContext db)
        {
            InitializeComponent();
            dtpMatchTime.Format = DateTimePickerFormat.Custom;
            dtpMatchTime.CustomFormat = "MM/dd/yyyy HH:mm";
            dtpMatchTime.Value = DateTime.Now;
            this.db = db;
            LoadTeams();
            ListMatches();

        }

        private void ListMatches()
        {
            lstMatches.DataSource = db.Matches
                .Select(x => new
                {
                    Time = x.MatchTime,
                    Team1 = x.Team1Name.TeamName,
                    Team2 = x.Team2Name.TeamName
                }).ToList();

        }

        private void LoadTeams()
        {
            cboTeam1.DataSource = db.Teams.ToList();
            cboTeam1.DisplayMember = "TeamName";

            cboTeam2.DataSource = db.Teams.ToList();
            cboTeam2.DisplayMember = "TeamName";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Match newMatch = new Match();
            if (dtpMatchTime.Value < DateTime.Now)
            {
                MessageBox.Show("Date is invalid.");
                return;
            }
            newMatch.MatchTime = dtpMatchTime.Value;
            if(cboTeam1.SelectedItem == cboTeam2.SelectedItem)
            {
                MessageBox.Show("The same 2 teams cannot play a match.");
                return;
            }
            newMatch.Team1Name = (Team)cboTeam1.SelectedItem;
            newMatch.Team2Name = (Team)cboTeam2.SelectedItem;
            newMatch.Team1Score = (int)nudTeam1Score.Value;
            newMatch.Team2Score = (int)nudTeam2Score.Value;
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

            db.Matches.Add(newMatch);
            db.SaveChanges();
            ListMatches();
            ClearForm();
        }

        private void ClearForm()
        {
            cboTeam1.SelectedIndex = -1;
            cboTeam2.SelectedIndex = -1;
            nudTeam1Score.Value = 0;
            nudTeam2Score.Value = 0;
            dtpMatchTime.Value = DateTime.Now;
        }
    }
}
