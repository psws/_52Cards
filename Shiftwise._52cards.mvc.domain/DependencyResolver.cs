using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using System.ComponentModel.Composition; //for export
using Shiftwise._52cards.mvc.resolver.mef.Interfaces;
using Shiftwise._52cards.mvc.repository;
using Shiftwise._52cards.mvc.domain.Interface;

namespace Shiftwise._52cards.mvc.domain
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {

            //registerComponent.RegisterType<IService<CatOperator>, Service<CatOperator> >();

            //registerComponent.RegisterType<IControlService, ControlService>();


            var RepoType = typeof(IRuleRepository);

            Object[] Parms1 = new Object[] {
             RepoType
             };

            registerComponent.RegisterTypeWithInjectionTypes<ICardService, CardService>(Parms1, false);

        }
    }

}
