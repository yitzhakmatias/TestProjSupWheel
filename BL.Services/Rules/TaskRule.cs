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
        public IEnumerable<TaskEngineer> ShiftsByEngineers { get; set; }
        private readonly IEngineerRepository _engineerRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IShiftRepository _shiftReporsitory;
        private readonly IUnitOfWork _unitOfWork;
        public static int[] Days { get; set; }

        public TaskRule(IEngineerRepository engineerRepository, ITaskRepository taskRepository, IShiftRepository shiftReporsitory, IUnitOfWork unitOfWork)
        {
            _engineerRepository = engineerRepository;
            _taskRepository = taskRepository;
            _shiftReporsitory = shiftReporsitory;
            _unitOfWork = unitOfWork;


        }

        public IEnumerable<TaskEngineer> UpdateShiftToEmployee()
        {
            //rules
            Days = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            ShiftsByEngineers = _taskRepository.GetAll();

            foreach (var enginner in ShiftsByEngineers)
            {
                enginner.Day = 0;
            }
            _unitOfWork.Commit();

            foreach (var enginner in ShiftsByEngineers)
            {
                AssignShift(enginner);
                _unitOfWork.Commit();
            }
   
            return ShiftsByEngineers.OrderBy(p => p.Day);

        }


        private bool IsDayAvailable(int day)
        {
            var tasks = _taskRepository.GetMany(p => p.Day == day).Count();

            var isAvailable = tasks != 3;

            if (tasks != 3) return isAvailable;

            var index = Array.IndexOf(Days, day);
            Days = Days.Where((val, idx) => idx != index).ToArray();

            return isAvailable;
        }

        private void AssignShift(TaskEngineer taskeEngineer)
        {

            if (taskeEngineer.ShiftId == 1)
            {
                var response = false;

                while (response == false)
                {
                    var index = Random(0, Days.Length - 1);

                    var randomDay = Days[index];

                    response = IsDayAvailable(randomDay);

                    if (response)
                    {
                        taskeEngineer.Day = randomDay;
                    }
                }


            }

            if (taskeEngineer.ShiftId != 2) return;
            {
                var enginner = _taskRepository.Get(p => p.EngineerId == taskeEngineer.EngineerId && p.ShiftId == 1);

                var response = false;

                do
                {

                    var index = Random(0, Days.Length - 1);

                    var day = Days[index];

                    var isDayAvailable = IsDayAvailable(day);

                    if (isDayAvailable == false) continue;

                    if ((enginner.Day + 1) == day || enginner.Day == day) continue;

                    taskeEngineer.Day = day;
                    response = true;

                    if (day == (enginner.Day + 1))
                    {
                        var x = 0;
                    }

                } while (response == false);
            }
        }

        private static void Init()
        {
            if (_random == null) _random = new Random();
        }
        public static int Random(int min, int max)
        {
            Init();

            return _random.Next(min, max);
        }
    }
}
