using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiftwise._52cards.mvc.resolver.mef.Interfaces
{
    /// <summary>
    /// Register underlying types with unity.
    /// </summary>
    public interface IComponent
    {
        void SetUp(IRegisterComponent registerComponent);

    }
}
