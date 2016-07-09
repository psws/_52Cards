using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using Shiftwise._52cards.mvc.resolver.mef.Interfaces;
using Shiftwise._52cards.mvc.repository;




namespace Shiftwise._52cards.mvc.repository
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {

            registerComponent.RegisterType<IRuleRepository, RuleRepository>();



        }
    }

}
