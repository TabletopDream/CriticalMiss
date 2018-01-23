using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.Common.Interfaces
{
    public interface IImageAsset
    {
        int ImageAssetId { get; set; }

        string AssetURI { get; set; }

        string AssetDescription { get; set; }

        DateTime DateTimeCreated { get; set; }
    }
}
