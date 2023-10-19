using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferency.Data.Db
{
    public class AppDbContextInitializer : CreateDatabaseIfNotExists<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            base.Seed(context);
            // Batch insert data into SortingColumns
            var sortingColumns = new List<SortingColumn>
            {
                new SortingColumn { ColumnName = "FullName" },
                new SortingColumn { ColumnName = "Age" },
                new SortingColumn { ColumnName = "RegionName" }
            };
            context.SortingColumns.AddRange(sortingColumns);

            context.SaveChanges();

            // Batch insert data into SortingProperties
            var sortingProperties = new List<SortingProperty>
            {
                new SortingProperty
                {
                    DisplayName = "FullName a-b",
                    IsDescending = false,
                    SortingColumnId = 1 // Assuming the SortingColumnId is 1 for "FullName"
                },
                new SortingProperty
                {
                    DisplayName = "FullName b-a",
                    IsDescending = true,
                    SortingColumnId = 1 // Assuming the SortingColumnId is 1 for "FullName"
                },
                new SortingProperty
                {
                    DisplayName = "Age 0-9",
                    IsDescending = false,
                    SortingColumnId = 2 // Assuming the SortingColumnId is 2 for "Age"
                },
                new SortingProperty
                {
                    DisplayName = "Age 9-0",
                    IsDescending = true,
                    SortingColumnId = 2 // Assuming the SortingColumnId is 2 for "Age"
                },
                new SortingProperty
                {
                    DisplayName = "Region a-b",
                    IsDescending = false,
                    SortingColumnId = 3 // Assuming the SortingColumnId is 3 for "RegionName"
                },
                new SortingProperty
                {
                    DisplayName = "Region b-a",
                    IsDescending = true,
                    SortingColumnId = 3 // Assuming the SortingColumnId is 3 for "RegionName"
                }
            };

            context.SortingProperties.AddRange(sortingProperties);
            context.SaveChanges();

            var regions = new List<Region>
            {
               new  Region { Name = "Poltava" },
               new Region { Name = "Kyiv" },
               new Region { Name = "Lutsk" },
               new Region { Name = "Donetsk" },
               new Region { Name =  "Chernihiv" }
            };

            context.Regions.AddRange(regions);
            context.SaveChanges();

            var users = new List<User>
            {
                new User
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Password = "Password",
                    Email = "emailSample2@gmail.com",
                    Birthday = new DateTime(2000, 3, 11),
                    PhoneNumber = "+380661918722",
                    RegionId = 1
                },
                new User
                {
                    FirstName = "Bob",
                    LastName = "Johnson",
                    Password = "Secret123",
                    Email = "emailSample3@gmail.com",
                    Birthday = new DateTime(1998, 5, 20),
                    PhoneNumber = "+12015559999",
                    RegionId = 1
                },
                new User
                {
                    FirstName = "Emily",
                    LastName = "Davis",
                    Password = "Pass1234",
                    Email = "emailSample4@gmail.com",
                    Birthday = new DateTime(2002, 9, 3),
                    PhoneNumber = "+4402034567890",
                    RegionId = 2
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();           
        }
    }
}
