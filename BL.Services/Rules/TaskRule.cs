using System;
using System.Collections.Generic;
using System.Linq;
using BL.CORE;
using BL.Services.Repositories;
using DAL.DataContext;
using DAL.DataContext.Ctx;

namespace BL.Services.Rules
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BL.Services.Rules.ITaskRule" />
    public class TaskRule : ITaskRule
    {
        /// <summary>
        /// The random
        /// </summary>
        private static Random _random;
        /// <summary>
        /// Gets or sets the shifts by engineers.
        /// </summary>
        /// <value>
        /// The shifts by engineers.
        /// </value>
        public IEnumerable<TaskEngineer> ShiftsByEngineers { get; set; }
        /// <summary>
        /// The engineer repository
        /// </summary>
        private readonly IEngineerRepository _engineerRepository;
        /// <summary>
        /// The task repository
        /// </summary>
        private readonly ITaskRepository _taskRepository;
        /// <summary>
        /// The shift reporsitory
        /// </summary>
        private readonly IShiftRepository _shiftReporsitory;
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// Gets or sets the days.
        /// </summary>
        /// <value>
        /// The days.
        /// </value>
        public static int[] Days { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskRule"/> class.
        /// </summary>
        /// <param name="engineerRepository">The engineer repository.</param>
        /// <param name="taskRepository">The task repository.</param>
        /// <param name="shiftReporsitory">The shift reporsitory.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public TaskRule(IEngineerRepository engineerRepository, ITaskRepository taskRepository, IShiftRepository shiftReporsitory, IUnitOfWork unitOfWork)
        {
            _engineerRepository = engineerRepository;
            _taskRepository = taskRepository;
            _shiftReporsitory = shiftReporsitory;
            _unitOfWork = unitOfWork;


        }

        /// <summary>
        /// Updates the shift to employee.
        /// </summary>
        /// <returns></returns>
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

            return ShiftsByEngineers.OrderBy(p => p.Day).ThenBy(p => p.ShiftId);

        }


        /// <summary>
        /// Determines whether [is day available] [the specified day].
        /// </summary>
        /// <param name="day">The day.</param>
        /// <returns>
        ///   <c>true</c> if [is day available] [the specified day]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsDayAvailable(int day)
        {
            var tasks = _taskRepository.GetMany(p => p.Day == day).Count();

            var isAvailable = tasks != 3;

            if (tasks != 3) return isAvailable;

            var index = Array.IndexOf(Days, day);
            Days = Days.Where((val, idx) => idx != index).ToArray();

            return isAvailable;
        }

        /// <summary>
        /// Assigns the shift.
        /// </summary>
        /// <param name="taskeEngineer">The taske engineer.</param>
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

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private static void Init()
        {
            if (_random == null) _random = new Random();
        }
        /// <summary>
        /// Randoms the specified minimum.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns></returns>
        public static int Random(int min, int max)
        {
            Init();

            return _random.Next(min, max);
        }
    }
}
