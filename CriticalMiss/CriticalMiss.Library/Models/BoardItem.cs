using CriticalMiss.Common.Interfaces;
using CriticalMiss.Common.Util;
using Newtonsoft.Json;

namespace CriticalMiss.Library.Models
{
    public class BoardItem : IBoardItem
    {
        public int ImageAssetId { get; set; }
        public int GameBoardId { get; set; }
        public string Name { get; set; }
        public bool IsToken { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
        public int LocalId { get; set; }

        [JsonConverter(typeof(InterfaceConverter<ImageAsset>))]
        public IImageAsset ImageAsset { get; set; }

        public void PluckImageId()
        {
            ImageAssetId = ImageAsset.ImageAssetId;
        }

        public bool ShouldSerializeImageAsset() => ImageAsset != null;
    }
}
