using CriticalMiss.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.Library.Models
{
    public class ImageAsset : IImageAsset
    {
        public int ImageAssetId { get; set; }
        public string AssetURI { get; set; }
        public string AssetDescription { get; set; }
        public DateTime DateTimeCreated { get; set; }
    }
}
