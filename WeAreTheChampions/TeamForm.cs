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
    public partial class TeamForm : Form
    {
        private readonly ApplicationDbContext db;
        Team editedTeam, deletedTeam;

        public TeamForm(ApplicationDbContext db)
        {
            InitializeComponent();
            this.db = db;
            LoadColors();
            ListTeams();
        }

        private void ListTeams()
        {
            lstTeams.DataSource = db.Teams.ToList();
            lstTeams.DisplayMember = "TeamName";
        }

        private void LoadColors()
        {
            clbTeamColor.DataSource = db.Colors.ToList();
            clbTeamColor.DisplayMember = "ColorName";
        }

        private void btnTeamAdd_Click(object sender, EventArgs e)
        {
            if (txtTeamName.Text == "")
            {
                MessageBox.Show("The field can't be empty.");
                return;
            }
            if (btnTeamAdd.Text == "Add")
            {
                if (db.Teams.Any(x => x.TeamName == txtTeamName.Text.Trim()))
                {
                    MessageBox.Show("This team name is used.");
                    return;
                }
                Team team = new Team();
                team.TeamName = txtTeamName.Text.Trim();

                if (clbTeamColor.SelectedIndex == -1) return;
                else
                {
                    foreach (Models.Color color in clbTeamColor.CheckedItems)
                    {
                        team.Colors.Add(color);
                    }
                }
                db.Teams.Add(team);
            }
            else if (btnTeamAdd.Text == "Edit")
            {
                editedTeam.TeamName = txtTeamName.Text;
                if (clbTeamColor.SelectedIndex == -1) return;
                else
                {
                    foreach (Models.Color color in clbTeamColor.CheckedItems)
                    {
                        editedTeam.Colors.Add(color);
                    }
                }
                btnTeamAdd.Text = "Add";
            }
            db.SaveChanges();
            ListTeams();
            Clean();
        }

        private void Clean()
        {
            txtTeamName.Text = "";
        }


        private void btnTeamEdit_Click(object sender, EventArgs e)
        {
            if (btnTeamEdit.Text == "Edit")
            {
                if (lstTeams.SelectedItems.Count == 0) return;
                editedTeam = (Team)lstTeams.SelectedItem;
                txtTeamName.Text = editedTeam.TeamName;
                if (clbTeamColor.SelectedIndex == -1) return;
                else
                {
                    foreach (Models.Color color in clbTeamColor.CheckedItems)
                    {
                        editedTeam.Colors.Add(color);
                    }
                }
                for (int i = 0; i < clbTeamColor.Items.Count; i++)
                {
                    if (editedTeam.Colors.Contains(clbTeamColor.Items[i]))
                    {
                        clbTeamColor.SetItemChecked(i, true);
                    }
                }
                btnTeamAdd.Text = "Edit";
                btnTeamEdit.Text = "Cancel";
            }
            else if (btnTeamEdit.Text == "Cancel")
            {
                btnTeamEdit.Text = "Edit";
                btnTeamAdd.Text = "Add";
                txtTeamName.Text = "";
                for (int i = 0; i < clbTeamColor.Items.Count; i++)
                {
                    if (editedTeam.Colors.Contains(clbTeamColor.Items[i]))
                    {
                        clbTeamColor.SetItemChecked(i, false);
                    }
                }
                return;
            }
        }
        private void lstTeams_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                deletedTeam = (Team)lstTeams.SelectedItem;
                db.Teams.Remove(deletedTeam);
                db.SaveChanges();
            }
            ListTeams();
        }
    }
}
