namespace DAL.DataContext.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.DataContext.WheelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.DataContext.WheelContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            context.Engineers.AddOrUpdate(
                p => p.Name,
                new Engineer { Name = "Jon" },
                new Engineer { Name = "Peter" },
                new Engineer { Name = "Matt" },
                new Engineer { Name = "Kris" },
                new Engineer { Name = "Steve" },
                new Engineer { Name = "Bob" },
                new Engineer { Name = "Bryan" },
                new Engineer { Name = "Javier" },
                new Engineer { Name = "George" },
                new Engineer { Name = "Scott" }
                );

            context.Shifts.AddOrUpdate(p => p.Name,
                new Shift() { Name = "Shift1" },
                new Shift() { Name = "Shift2" }
                );
            context.SaveChanges();
            if (context.Tasks.Any()) return;
            {
                context.Tasks.AddOrUpdate(
                    p => p.EngineerId,
                    new TaskEngineer { Engineers = context.Engineers.First(x => x.Name.Contains("Jon")), Shifts = context.Shifts.First(y => y.Name.Contains("Shift1")), Day = 0 },
                    new TaskEngineer { Engineers = context.Engineers.First(x => x.Name.Contains("Jon")), Shifts = context.Shifts.First(y => y.Name.Contains("Shift2")), Day = 0 },

                    new TaskEngineer { Engineers = context.Engineers.First(x => x.Name.Contains("Peter")), Shifts = context.Shifts.First(y => y.Name.Contains("Shift1")), Day = 0 },
                    new TaskEngineer { Engineers = context.Engineers.First(x => x.Name.Contains("Peter")), Shifts = context.Shifts.First(y => y.Name.Contains("Shift2")), Day = 0 },

                    new TaskEngineer { Engineers = context.Engineers.First(x => x.Name.Contains("Matt")), Shifts = context.Shifts.First(y => y.Name.Contains("Shift1")), Day = 0 },
                    new TaskEngineer { Engineers = context.Engineers.First(x => x.Name.Contains("Matt")), Shifts = context.Shifts.First(y => y.Name.Contains("Shift2")), Day = 0 },

                    new TaskEngineer { Engineers = context.Engineers.First(x => x.Name.Contains("Kris")), Shifts = context.Shifts.First(y => y.Name.Contains("Shift1")), Day = 0 },
                    new TaskEngineer { Engineers = context.Engineers.First(x => x.Name.Contains("Kris")), Shifts = context.Shifts.First(y => y.Name.Contains("Shift2")), Day = 0 },

                    new TaskEngineer { Engineers = context.Engineers.First(x => x.Name.Contains("Bob")), Shifts = context.Shifts.First(y => y.Name.Contains("Shift1")), Day = 0 },
                    new TaskEngineer { Engineers = context.Engineers.First(x => x.Name.Contains("Bob")), Shifts = context.Shifts.First(y => y.Name.Contains("Shift2")), Day = 0 },

                    new TaskEngineer { Engineers = context.Engineers.First(x => x.Name.Contains("Bryan")), Shifts = context.Shifts.First(y => y.Name.Contains("Shift1")), Day = 0 },
                    new TaskEngineer { Engineers = context.Engineers.First(x => x.Name.Contains("Bryan")), Shifts = context.Shifts.First(y => y.Name.Contains("Shift2")), Day = 0 },

                    new TaskEngineer { Engineers = context.Engineers.First(x => x.Name.Contains("Javier")), Shifts = context.Shifts.First(y => y.Name.Contains("Shift1")), Day = 0 },
                    new TaskEngineer { Engineers = context.Engineers.First(x => x.Name.Contains("Javier")), Shifts = context.Shifts.First(y => y.Name.Contains("Shift2")), Day = 0 },

                    new TaskEngineer { Engineers = context.Engineers.First(x => x.Name.Contains("George")), Shifts = context.Shifts.First(y => y.Name.Contains("Shift1")), Day = 0 },
                    new TaskEngineer { Engineers = context.Engineers.First(x => x.Name.Contains("George")), Shifts = context.Shifts.First(y => y.Name.Contains("Shift2")), Day = 0 },

                    new TaskEngineer { Engineers = context.Engineers.First(x => x.Name.Contains("Scott")), Shifts = context.Shifts.First(y => y.Name.Contains("Shift1")), Day = 0 },
                    new TaskEngineer { Engineers = context.Engineers.First(x => x.Name.Contains("Scott")), Shifts = context.Shifts.First(y => y.Name.Contains("Shift2")), Day = 0 },

                    new TaskEngineer { Engineers = context.Engineers.First(x => x.Name.Contains("Steve")), Shifts = context.Shifts.First(y => y.Name.Contains("Shift1")), Day = 0 },
                    new TaskEngineer { Engineers = context.Engineers.First(x => x.Name.Contains("Steve")), Shifts = context.Shifts.First(y => y.Name.Contains("Shift2")), Day = 0 }


                );
                context.SaveChanges();
            }


        }

    }
}
