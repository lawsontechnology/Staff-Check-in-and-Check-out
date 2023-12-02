using ADO_Project.Core.Application.Dtos;
using ADO_Project.Core.Application.Interfaces.Repositories;
using ADO_Project.Core.Application.Interfaces.Service;
using ADO_Project.Core.Domain.Entities;
using ADO_Project.Infrastructure.Repository;
using NLog;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Project.Core.Application.Implementation
{
    public class CompanyService : ICompanyService
    {
        ICompanyRepository _CompanyRepository = new CompanyRepository();
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public CompanyDtos Create(CompanyRequestModel model)
        {
            try
            {
                var companys = _CompanyRepository.GetByRegNum(model.CACRegNumber);
                if (companys != null)
                {
                    Console.WriteLine("Already exists");
                    return null;
                }
                var company = new Company()
                {
                    Name = model.Name,
                    CACRegNumber = model.CACRegNumber,
                    Logo = model.Logo,
                   
                };
                _CompanyRepository.Create(company);
                logger.Info($"{company.Name} Company Created Successfully");
                return new CompanyDtos
                {
                    Id = company.Id,
                    Name = company.Name,
                    CACRegNumber = company.CACRegNumber,
                    Logo = company.Logo,
                    Staffs = company.Staffs.Select(x => new StaffDtos
                    {
                        StaffNumber = x.StaffNumber,
                        TimeIn = x.TimeIn,
                        TimeOut = x.TimeOut,

                    }).ToList(),
                };
            }
            catch (Exception ex)
            {

                logger.Error(ex);
            }
            return null;
        }

       /* public CompanyDtos Get(string Id)
        {
            try
            {
                var company = _CompanyRepository.Get(Id);
                if (company == null) 
                {
                    return null;
                }
                logger.Info($"Getting the value of this Id {company.Id} : Name {company.Name}");
                return new CompanyDtos
                {
                    Id = company.Id,
                    Name = company.Name,
                    CACRegNumber = company.CACRegNumber,
                    Logo = company.Logo,
                    Staffs = company.Staffs.Select(x => new StaffDtos
                    {
                        CompanyId = company.Id,
                        UserId = x.UserId,
                        TimeIn = x.TimeIn,
                        TimeOut = x.TimeOut,

                    }).ToList(),
                };
            }
            catch (Exception ex)
            {

                logger.Error(ex);
            }
            return null;
        }*/

        public List<CompanyDtos> GetAll()
        {
            try
            {
                var company = _CompanyRepository.GetAll();
                var listOfCompany = company.Select(x => new CompanyDtos
                {
                    Id = x.Id,
                    Name = x.Name,
                    CACRegNumber = x.CACRegNumber,
                    Logo = x.Logo,
                    Staffs = x.Staffs.Select(X => new StaffDtos
                    {
                        TimeIn = X.TimeIn,
                        TimeOut = X.TimeOut,

                    }).ToList(),
                }).ToList();
                logger.Info("Getting All List Of Company");
                return listOfCompany;
            }
            catch (Exception ex)
            {

                logger.Error(ex);
            }
            return null;
        }
    }
}
