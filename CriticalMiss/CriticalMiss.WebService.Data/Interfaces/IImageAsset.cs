using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CriticalMiss.WebService.Data.Interfaces
{
    public class IImageAsset
    {
        int ImageAssetId { get; set; }

        string AssetURI { get; set; }

        string AssetDescription { get; set; }

        DateTime DateTimeCreated { get; set; }
    }
}
