using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiftwise._52cards.mvc.resolver.mef.Interfaces
{
    public interface IRegisterComponent
    {
        /// <summary>
        /// Register type method
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="withInterception"></param>
        void RegisterType<TFrom, TTo>(bool withInterception = false) where TTo : TFrom;

        /// <summary>
        /// Register type with container controlled life time manager
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="withInterception"></param>
        void RegisterTypeWithControlledLifeTime<TFrom, TTo>(bool withInterception = false) where TTo : TFrom;

        void RegisterInstance<Tobj>(Tobj Tobject) where Tobj : class;
        void RegisterTypeWithInjectionTypes<TFrom, TTo>(Object[] parms, bool withInterception = false) where TTo : TFrom;
    }
}
