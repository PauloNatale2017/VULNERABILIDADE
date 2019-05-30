using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DEKRA.VULNERABILIDADE.DOMAIN.CORE.Ninject
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {

        private IKernel ninjectKernnel;

        public NinjectControllerFactory()
        {
            ninjectKernnel = new StandardKernel();
            AdBinding();
        }

        //protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        //{
        //    return controllerType == null ? null : (IController)ninjectKernnel.Get(controllerType);
        //}


        private void AdBinding()
        {
            // injeção da entidade Login
            //ninjectKernnel.Bind<DEKRA.VULNERABILIDADE.DOMAIN.CORE.IREPOSITORY.IRepository<DEKRA.VULNERABILIDADE.DOMAIN.ENTIITES.MODELS.ENTITYMODEL.Login>>().To<DEKRA.VULNERABILIDADE.DOMAIN.CORE.Repository.LoginRepository>();
         
            
        }



    }
}
