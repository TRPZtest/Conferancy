using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferency.Data.Db
{
    public partial class UsersView : DbMigration
    {
        public override void Up()
        {
            string script = @"CREATE VIEW dbo.UsersView
                                AS
                                SELECT  
	                                u.Id,
	                                CONCAT(u.FirstName, ' ', u.LastName) AS FullName,
	                                YEAR(u.Birthday) AS Age,
	                                r.Name as RegionName,
	                                u.Email,
	                                u.PhoneNumber
                                FROM Users u
                                JOIN Regions r ON r.Id = u.RegionID";

            AppDbContext ctx = new AppDbContext();
            ctx.Database.ExecuteSqlCommand(script);
        }

        public override void Down()
        {
            AppDbContext ctx = new AppDbContext();
            ctx.Database.ExecuteSqlCommand("DROP VIEW dbo.UsersView");
        }
    }
}
