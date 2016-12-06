 

using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebCenter.Entities;
using Ninject;
using Ninject.Web.Common;
using WebCenter.IServices;
using WebCenter.Services;
namespace WebCenter.Admin.Infrastructure
{

public partial class  NinjectDependencyResolver:IDependencyResolver
{
 
private void AutoAddBinds()
{
	
	   kernel.Bind<IcityService>().To<cityService>().InRequestScope();
	
	   kernel.Bind<IcompanyService>().To<companyService>().InRequestScope();
	
	   kernel.Bind<IfileService>().To<fileService>().InRequestScope();
	
	   kernel.Bind<Ioperate_logService>().To<operate_logService>().InRequestScope();
	
	   kernel.Bind<Iproject_caseService>().To<project_caseService>().InRequestScope();
	
	   kernel.Bind<IsequenceService>().To<sequenceService>().InRequestScope();
	
	   kernel.Bind<Isys_dictionaryService>().To<sys_dictionaryService>().InRequestScope();
	
	   kernel.Bind<Isys_userService>().To<sys_userService>().InRequestScope();
	
	   kernel.Bind<IuserService>().To<userService>().InRequestScope();
  kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

}
  

}
}