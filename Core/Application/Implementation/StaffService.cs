using ADO_Project.Core.Application.Dtos;
using ADO_Project.Core.Application.Interfaces.Repositories;
using ADO_Project.Core.Application.Interfaces.Service;
using ADO_Project.Core.Domain.Entities;
using ADO_Project.Infrastructure.Repository;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Project.Core.Application.Implementation
{
    public class StaffService : IStaffService
    {
         IStaffRepository _staffRepository = new StaffRepository();
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public StaffDtos Get(string id)
        {
            try
            {
                var staff = _staffRepository.Get(id);

                return new StaffDtos
                {
                    Id = staff.Id,
                    StaffNumber = staff.StaffNumber,
                    TimeIn = staff.TimeIn,
                    TimeOut = staff.TimeOut,

                };
            }
            catch (Exception exp)
            {

                logger.Error(exp);
            }
            return null;
        }

        public List<StaffDtos> GetAll()
        {
            try
            {

                var staff = _staffRepository.GetAll();
                var listOfStaff = staff.Select(x => new StaffDtos
                {
                    Id = x.Id,
                    StaffNumber = x.StaffNumber,
                    TimeIn = x.TimeIn,
                    TimeOut = x.TimeOut,
                }).ToList();
                return listOfStaff;
            }
            catch (Exception exp)
            {

                logger.Error(exp);
            }
            return null;
        }
        public StaffDtos TimeIn(StaffTimeInRequest request)
        {
            try
            {

                var staff = new Staff()
                {
                    TimeIn = request.TimeIn,
                    StaffNumber = request.StaffNumber,
                };
                _staffRepository.Create(staff);

                return new StaffDtos
                {
                    Id = staff.Id,
                    StaffNumber = staff.StaffNumber,
                    TimeIn = staff.TimeIn,
                    TimeOut = staff.TimeOut,
                };
            }
            catch (Exception exp)
            {

                logger.Error(exp);
            }
            return null;
        }

        public StaffDtos TimeOut(StaffTimeOutRequest request)
        {
            try
            {

                var staff = new Staff()
                {
                    TimeOut = request.TimeOut,
                    StaffNumber = request.StaffNumber,
                };
                _staffRepository.Create(staff);

                return new StaffDtos
                {
                    Id = staff.Id,
                    StaffNumber = staff.StaffNumber,
                    TimeIn = staff.TimeIn,
                    TimeOut = staff.TimeOut,
                };
            }
            catch (Exception exp)
            {

                logger.Error(exp);
            }
            return null;
        }

    }
}
