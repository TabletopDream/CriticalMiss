using CriticalMiss.Common.Interfaces;
using CriticalMiss.Library.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.Library.Models
{
    public class BoardItem : IBoardItem
    {
        public int Id { get; set; }
        public int BoardId { get; set; }
        public string Name { get; set; }
        public bool IsToken { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
        public int LocalId { get; set; }
        public int ImageAssetId { get; set; }

        [JsonConverter(typeof(InterfaceConverter<ImageAsset>))]
        public IImageAsset ImageAsset { get; set; }

        public BoardItem(int id)
        {
            LocalId = id;
            Name = "token" + LocalId.ToString();
            IsToken = true;
            Width = 1;
            Height = 1;
            XPos = 0;
            YPos = 0;
        }

        public void MoveItem(int x, int y)
        {
            XPos += x;
            YPos += y;
        }

        public void AdjustSize(int w, int h)
        {
            Width = w;
            Height = h;
        }

        public void PluckImageId()
        {
            ImageAssetId = ImageAsset.ImageAssetId;
        }
    }
}
