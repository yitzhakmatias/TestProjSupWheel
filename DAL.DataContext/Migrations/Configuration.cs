using DAL.DataContext.Ctx;

namespace DAL.DataContext.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DropCreateDatabaseIfModelChanges<DAL.DataContext.Ctx.WheelCtx>
    {
        public Configuration()
        {
            //AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DAL.DataContext.Ctx.WheelCtx context)
        {
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
            if (context.TaskEngineers.Any()) return;
            {
                context.TaskEngineers.AddOrUpdate(
                    p => p.EngineerId,
                    new TaskEngineer { Engineer = context.Engineers.First(x => x.Name.Contains("Jon")), Shift = context.Shifts.First(y => y.Name.Contains("Shift1")), Day = 0 },
                    new TaskEngineer { Engineer = context.Engineers.First(x => x.Name.Contains("Jon")), Shift = context.Shifts.First(y => y.Name.Contains("Shift2")), Day = 0 },

                    new TaskEngineer { Engineer = context.Engineers.First(x => x.Name.Contains("Peter")), Shift = context.Shifts.First(y => y.Name.Contains("Shift1")), Day = 0 },
                    new TaskEngineer { Engineer = context.Engineers.First(x => x.Name.Contains("Peter")), Shift = context.Shifts.First(y => y.Name.Contains("Shift2")), Day = 0 },

                    new TaskEngineer { Engineer = context.Engineers.First(x => x.Name.Contains("Matt")), Shift = context.Shifts.First(y => y.Name.Contains("Shift1")), Day = 0 },
                    new TaskEngineer { Engineer = context.Engineers.First(x => x.Name.Contains("Matt")), Shift = context.Shifts.First(y => y.Name.Contains("Shift2")), Day = 0 },

                    new TaskEngineer { Engineer = context.Engineers.First(x => x.Name.Contains("Kris")), Shift = context.Shifts.First(y => y.Name.Contains("Shift1")), Day = 0 },
                    new TaskEngineer { Engineer = context.Engineers.First(x => x.Name.Contains("Kris")), Shift = context.Shifts.First(y => y.Name.Contains("Shift2")), Day = 0 },

                    new TaskEngineer { Engineer = context.Engineers.First(x => x.Name.Contains("Bob")), Shift = context.Shifts.First(y => y.Name.Contains("Shift1")), Day = 0 },
                    new TaskEngineer { Engineer = context.Engineers.First(x => x.Name.Contains("Bob")), Shift = context.Shifts.First(y => y.Name.Contains("Shift2")), Day = 0 },

                    new TaskEngineer { Engineer = context.Engineers.First(x => x.Name.Contains("Bryan")), Shift = context.Shifts.First(y => y.Name.Contains("Shift1")), Day = 0 },
                    new TaskEngineer { Engineer = context.Engineers.First(x => x.Name.Contains("Bryan")), Shift = context.Shifts.First(y => y.Name.Contains("Shift2")), Day = 0 },

                    new TaskEngineer { Engineer = context.Engineers.First(x => x.Name.Contains("Javier")), Shift = context.Shifts.First(y => y.Name.Contains("Shift1")), Day = 0 },
                    new TaskEngineer { Engineer = context.Engineers.First(x => x.Name.Contains("Javier")), Shift = context.Shifts.First(y => y.Name.Contains("Shift2")), Day = 0 },

                    new TaskEngineer { Engineer = context.Engineers.First(x => x.Name.Contains("George")), Shift = context.Shifts.First(y => y.Name.Contains("Shift1")), Day = 0 },
                    new TaskEngineer { Engineer = context.Engineers.First(x => x.Name.Contains("George")), Shift = context.Shifts.First(y => y.Name.Contains("Shift2")), Day = 0 },

                    new TaskEngineer { Engineer = context.Engineers.First(x => x.Name.Contains("Scott")), Shift = context.Shifts.First(y => y.Name.Contains("Shift1")), Day = 0 },
                    new TaskEngineer { Engineer = context.Engineers.First(x => x.Name.Contains("Scott")), Shift = context.Shifts.First(y => y.Name.Contains("Shift2")), Day = 0 },

                    new TaskEngineer { Engineer = context.Engineers.First(x => x.Name.Contains("Steve")), Shift = context.Shifts.First(y => y.Name.Contains("Shift1")), Day = 0 },
                    new TaskEngineer { Engineer = context.Engineers.First(x => x.Name.Contains("Steve")), Shift = context.Shifts.First(y => y.Name.Contains("Shift2")), Day = 0 }


                );
                context.SaveChanges();
            }
        }
    }
}
