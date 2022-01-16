namespace WeAreTheChampions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ColorId = c.Int(nullable: false, identity: true),
                        ColorName = c.String(),
                        Red = c.Int(nullable: false),
                        Green = c.Int(nullable: false),
                        Blue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ColorId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        TeamName = c.String(nullable: false, maxLength: 250),
                        Match_MatchId = c.Int(),
                    })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.Matches", t => t.Match_MatchId)
                .Index(t => t.Match_MatchId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        PlayerName = c.String(nullable: false, maxLength: 250),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.Teams", t => t.TeamId)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        MatchTime = c.DateTime(nullable: false),
                        Team1Id = c.Int(nullable: false),
                        Team2Id = c.Int(nullable: false),
                        Team1Score = c.Int(),
                        Team2Score = c.Int(),
                        Result = c.Int(),
                        Team1Name_TeamId = c.Int(),
                        Team2Name_TeamId = c.Int(),
                        Team_TeamId = c.Int(),
                        Team_TeamId1 = c.Int(),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.Teams", t => t.Team1Name_TeamId)
                .ForeignKey("dbo.Teams", t => t.Team2Name_TeamId)
                .ForeignKey("dbo.Teams", t => t.Team_TeamId)
                .ForeignKey("dbo.Teams", t => t.Team_TeamId1)
                .Index(t => t.Team1Name_TeamId)
                .Index(t => t.Team2Name_TeamId)
                .Index(t => t.Team_TeamId)
                .Index(t => t.Team_TeamId1);
            
            CreateTable(
                "dbo.TeamColors",
                c => new
                    {
                        Team_TeamId = c.Int(nullable: false),
                        Color_ColorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Team_TeamId, t.Color_ColorId })
                .ForeignKey("dbo.Teams", t => t.Team_TeamId, cascadeDelete: true)
                .ForeignKey("dbo.Colors", t => t.Color_ColorId, cascadeDelete: true)
                .Index(t => t.Team_TeamId)
                .Index(t => t.Color_ColorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "Team_TeamId1", "dbo.Teams");
            DropForeignKey("dbo.Matches", "Team_TeamId", "dbo.Teams");
            DropForeignKey("dbo.Teams", "Match_MatchId", "dbo.Matches");
            DropForeignKey("dbo.Matches", "Team2Name_TeamId", "dbo.Teams");
            DropForeignKey("dbo.Matches", "Team1Name_TeamId", "dbo.Teams");
            DropForeignKey("dbo.Players", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.TeamColors", "Color_ColorId", "dbo.Colors");
            DropForeignKey("dbo.TeamColors", "Team_TeamId", "dbo.Teams");
            DropIndex("dbo.TeamColors", new[] { "Color_ColorId" });
            DropIndex("dbo.TeamColors", new[] { "Team_TeamId" });
            DropIndex("dbo.Matches", new[] { "Team_TeamId1" });
            DropIndex("dbo.Matches", new[] { "Team_TeamId" });
            DropIndex("dbo.Matches", new[] { "Team2Name_TeamId" });
            DropIndex("dbo.Matches", new[] { "Team1Name_TeamId" });
            DropIndex("dbo.Players", new[] { "TeamId" });
            DropIndex("dbo.Teams", new[] { "Match_MatchId" });
            DropTable("dbo.TeamColors");
            DropTable("dbo.Matches");
            DropTable("dbo.Players");
            DropTable("dbo.Teams");
            DropTable("dbo.Colors");
        }
    }
}
