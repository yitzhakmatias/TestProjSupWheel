using System;
using System.Collections.Generic;
using System.Linq;
using BL.CORE;
using BL.Services.Repositories;
using DAL.DataContext;
using DAL.DataContext.Ctx;

namespace BL.Services.Rules
{
    public class TaskRule : ITaskRule
    {
        private static Random _random;
        public IEnumerable<TaskEngineer> TaskEngineers { get; set; }
        private readonly IEngineerRepository _engineerRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IShiftRepository _shiftReporsitory;
        private readonly IUnitOfWork _unitOfWork;

        public static HashSet<int> Exclude { get; set; }

        public TaskRule(IEngineerRepository engineerRepository, ITaskRepository taskRepository, IShiftRepository shiftReporsitory, IUnitOfWork unitOfWork)
        {
            _engineerRepository = engineerRepository;
            _taskRepository = taskRepository;
            _shiftReporsitory = shiftReporsitory;
            _unitOfWork = unitOfWork;
            Exclude = new HashSet<int>();
        }

        public IEnumerable<TaskEngineer> UpdateShiftToEmployee()
        {
            //rules

            var employee = _engineerRepository.GetById(Random(1, 10));

            var shifts = _shiftReporsitory.GetById(Random(1, 2));

            var tasks = _taskRepository.GetMany(t => t.EngineerId == employee.EngineerId);

            TaskEngineers = _taskRepository.GetAll();

            foreach (var enginner in TaskEngineers)
            {
                enginner.Day = 0;
            }
            _unitOfWork.Commit();

            foreach (var enginner in TaskEngineers)
            {
                AssignShift(enginner);
                _unitOfWork.Commit();
            }

            return TaskEngineers.ToList();

        }


        private bool IsDayAvailable(int day)
        {
            var tasks = _taskRepository.GetMany(p => p.Day == day).Count();

            var isAvailable = tasks != 2;
            if (tasks == 2)
            {
                Exclude.Add(day);
            }
            return isAvailable;
        }

        private void AssignShift(TaskEngineer taskeEngineer)
        {

            if (taskeEngineer.ShiftId == 1)
            {
                var response = false;

                while (response == false)
                {
                    var randomDay = Random(1, 10);
                    response = IsDayAvailable(randomDay);

                    if (response)
                    {
                        taskeEngineer.Day = randomDay;
                        //  Exclude.Add(randomDay);
                    }
                }


            }

            if (taskeEngineer.ShiftId != 2) return;
            {
                var enginner = TaskEngineers.First(p => p.EngineerId == taskeEngineer.EngineerId && p.ShiftId == 1);

                var response = false;

                do
                {
                    var day = Random(1, 10);

                    var isDayAvailable = IsDayAvailable(day);

                    if (isDayAvailable == false) continue;

                    if (day == (enginner.Day - 1)) continue;

                    taskeEngineer.Day = day;
                    response = true;
                    // Exclude.Add(day);

                } while (response == false);
            }
            // var taskEngineer = taskemEngineers.First(p => p.EngineerId == enginnerId && p.ShiftId == 1);


            // taskEngineer

            //   return taskEngineer;
        }

        private bool IsTheAssignedDayNextToTheLastOne(Engineer engineer)
        {


            return false;
        }
        private static void Init()
        {
            if (_random == null) _random = new Random();
        }
        public static int Random(int min, int max)
        {
            Init();

            return _random.Next(min, max - Exclude.Count);
        }
    }
}
