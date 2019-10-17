namespace VerlofsRegistratieSysteem.Migrations
{
    using System.Data.Entity.Migrations;
    using VerlofsRegistratieSysteem.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<VerlofsRegistratieSysteem.Models.AbsenceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations";
        }

        protected override void Seed(VerlofsRegistratieSysteem.Models.AbsenceContext context)
        {
            context.Employees.AddOrUpdate(new Employee { EmployeeID = 1, FirstName = "Bruce", LastName = "Wayne", ContractType = ContractType.Hours24, EMail = "BruceWayne@WayneEnterprises.com", HoursUsed = 0, Role = "17c56142-bd83-46a3-bca3-b25b6acf4072" });
            context.Employees.AddOrUpdate(new Employee { EmployeeID = 2, FirstName = "Kate", LastName = "Kane", ContractType = ContractType.Hours32, EMail = "KateKane@WayneEnterprises.com", HoursUsed = 0, Role = "9044a6da-87be-4edb-b064-a6c7f7207af5" });
            context.Employees.AddOrUpdate(new Employee { EmployeeID = 3, FirstName = "Dick", LastName = "Grayson", ContractType = ContractType.Hours40, EMail = "DickGrayson@WayneEnterprises.com", HoursUsed = 0, Role = "9044a6da-87be-4edb-b064-a6c7f7207af5" });
            context.Employees.AddOrUpdate(new Employee { EmployeeID = 4, FirstName = "Jason", LastName = "Todd", ContractType = ContractType.Hours40, EMail = "JasonTodd@WayneEnterprises.com", HoursUsed = 0, Role = "9044a6da-87be-4edb-b064-a6c7f7207af5" });
            context.Employees.AddOrUpdate(new Employee { EmployeeID = 5, FirstName = "Tim", LastName = "Drake", ContractType = ContractType.Hours40, EMail = "TimDrake@WayneEnterprises.com", HoursUsed = 0, Role = "9044a6da-87be-4edb-b064-a6c7f7207af5" });



            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
