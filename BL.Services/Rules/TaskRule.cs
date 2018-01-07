using System;
using BL.CORE;
using BL.Services.Repositories;
using DAL.DataContext;

namespace BL.Services.Rules
{
    public class TaskRule
    {
        private static Random _random;
        private readonly IEngineerRepository _engineerRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IShiftRepository _shiftReporsitory;
        private readonly IUnitOfWork _unitOfWork;

        public TaskRule(IEngineerRepository engineerRepository, ITaskRepository taskRepository, IShiftRepository shiftReporsitory, IUnitOfWork unitOfWork)
        {
            _engineerRepository = engineerRepository;
            _taskRepository = taskRepository;
            _shiftReporsitory = shiftReporsitory;
            _unitOfWork = unitOfWork;
        }

        public void AddTShiftToEmployee()
        {
            //rules

            var employee = _engineerRepository.GetById(Random(1, 10));

            var shifts = _shiftReporsitory.GetById(Random(1, 2));

            var tasks = _taskRepository.GetMany(t => t.EngineerId == employee.EngineerId);

            if (tasks != null)
            {
                var taskEngineer = new TaskEngineer()
                {
                    Engineers = employee,
                    Shifts = shifts
                };


                _taskRepository.Add(taskEngineer);
            }

            _unitOfWork.Commit();

        }

        private bool IsEnginnerAssigned(int id)
        {
            var task = _taskRepository.Get(p => p.EngineerId == id);
            return task != null;
        }

        private bool IsTheAssignedDayNextToTheLastOne()
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
            return _random.Next(min, max);
        }
    }
}
