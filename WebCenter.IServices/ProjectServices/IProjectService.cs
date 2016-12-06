using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCenter.Entities;
using WebCenter.IServices;
using Common;

namespace IServices.ProjectServices
{
    public partial interface Iproject_caseService : IBaseService<project_case>
    {
            //PagedList<project_case> GetPage(int pageIndex,int pageSize,string keyword="",int companyId=0);
        
    }
}
