using CriticalMiss.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.Library.Models
{
    public class ImageAsset : IImageAsset
    {
        int IImageAsset.ImageAssetId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IImageAsset.AssetURI { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IImageAsset.AssetDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTime IImageAsset.DateTimeCreated { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
