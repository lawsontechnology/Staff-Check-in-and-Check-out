using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADO_Project.Core.Application.Dtos
{
    public class StaffDtos
    {
        public string Id { get; set; } = default!;
        public  string StaffNumber { get; set; }= default!;
        public DateTime TimeIn { get; set; } 
        public DateTime TimeOut { get; set; } 
    }

    public class StaffTimeInRequest
    {
        public string StaffNumber { get; set; }
        public DateTime TimeIn { get; set; }
    }

    public class StaffTimeOutRequest
    {
        public string StaffNumber { get; set;}
        public DateTime TimeOut { get; set; }
    }



}