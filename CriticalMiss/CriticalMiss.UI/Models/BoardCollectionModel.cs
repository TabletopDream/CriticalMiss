using CriticalMiss.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CriticalMiss.UI.Models
{
    public class BoardCollectionModel
    {
        public IUIGameBoard Board { get; set; }

        public IEnumerable<IUIGameItem> BoardItems { get; set; }
    }
}
