using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Interfaces
{
    public interface IQuestionAccessService
    {
        Task<bool> CanResolveQuestionAsync(Guid userId);
        Task IncrementResolutionCountAsync(Guid userId);
    }

}
