using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DanBase.Framework
{
    public interface IApplicationService
    {
        Task Handle(object Command);
    }
}
