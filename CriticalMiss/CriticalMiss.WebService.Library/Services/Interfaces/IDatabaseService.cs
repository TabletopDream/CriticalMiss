using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CriticalMiss.WebService.Library.Services.Interfaces
{
    interface IDatabaseService<IModel>
    {
        void ReadById(int id);
        void Create(IModel model);
        void Update(IModel model);
        void DeleteById(int id);
        IEnumerable<IModel> ReadAll();
    }
}
