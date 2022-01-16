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
    public partial class PlayerForm : Form
    {
        private readonly ApplicationDbContext db;
        Player editedPlayer, deletedPlayer;

        public PlayerForm(ApplicationDbContext db)
        {
            InitializeComponent();
            this.db = db;
            LoadTeams();
            ListPlayer();
        }

        private void LoadTeams()
        {
            cboPlayerTeam.DataSource = db.Teams.ToList();
            cboPlayerTeam.DisplayMember = "TeamName";
            cboPlayerTeam.SelectedIndex = -1;
        }

        private void ListPlayer()
        {
            dgvPlayers.DataSource = db.Players
                .Select(x => new
                {
                    Id = x.PlayerId,
                    Name = x.PlayerName,
                    TeamName = x.Team.TeamName
                }).ToList();
            dgvPlayers.Columns[0].Visible = false;
        }
        private void btnPlayerAdd_Click(object sender, EventArgs e)
        {
            if (txtPlayerName.Text == "")
            {
                MessageBox.Show("The field can't be empty. Please enter player name");
                return;
            }
            if (btnPlayerAdd.Text == "Add")
            {
                Player player = new Player();
                player.PlayerName = txtPlayerName.Text;
                if(cboPlayerTeam.SelectedIndex != 1)
                {
                    player.Team = (Team)cboPlayerTeam.SelectedItem;
                }
                cboPlayerTeam.SelectedIndex = -1;
                db.Players.Add(player);
            }
            else if(btnPlayerAdd.Text == "Edit")
            {
                editedPlayer.PlayerName = txtPlayerName.Text;
                if (cboPlayerTeam.SelectedIndex != -1)
                {
                    editedPlayer.Team = (Team)cboPlayerTeam.SelectedItem;
                }
            }
            db.SaveChanges();
            ListPlayer();
            LoadTeams();
            Clean();
        }

        private void Clean()
        {
            txtPlayerName.Text = "";
            cboPlayerTeam.SelectedIndex = -1;
        }

        private void txtPlayerTeam_TextChanged(object sender, EventArgs e)
        {
            if(txtPlayerTeam.Text.Trim() == "")
            {
                ListPlayer();
            }
            else
            {
                dgvPlayers.DataSource = db.Players
                    .Where(x => x.Team.TeamName
                    .Contains(txtPlayerTeam.Text.Trim()))
                    .Select(x => new
                    {
                        Name = x.PlayerName,
                        TeamName = x.Team.TeamName
                    }).ToList();
            }
        }

        private void dgvPlayers_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                int id = (int)dgvPlayers.SelectedRows[0].Cells[0].Value;
                deletedPlayer = db.Players.Find(id);
                db.Players.Remove(deletedPlayer);
                db.SaveChanges();
            }
            ListPlayer();
        }

        private void btnPlayerEdit_Click(object sender, EventArgs e)
        {
            if (btnPlayerEdit.Text == "Edit")
            {
                if (dgvPlayers.SelectedRows.Count == 0) return;
                int id = (int)dgvPlayers.SelectedRows[0].Cells[0].Value;
                editedPlayer = db.Players.ToList().FirstOrDefault(x => x.PlayerId == id);
                txtPlayerName.Text = editedPlayer.PlayerName;
                cboPlayerTeam.SelectedItem = editedPlayer.Team;
                btnPlayerAdd.Text = "Edit";
                btnPlayerEdit.Text = "Cancel";
            }

            else if (btnPlayerEdit.Text == "Cancel")
            {
                btnPlayerEdit.Text = "Edit";
                btnPlayerAdd.Text = "Add";
                txtPlayerName.Text = "";
                cboPlayerTeam.SelectedItem = -1;
                return;
            }
        }
    }
}
