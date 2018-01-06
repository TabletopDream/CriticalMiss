using System;

namespace CriticalMiss.Library.Interfaces
{
    public interface IImageAsset
    {
        int ImageAssetId { get; set; }

        string AssetURI { get; set; }

        string AssetDescription { get; set; }

        DateTime DateTimeCreated { get; set; }
    }
}