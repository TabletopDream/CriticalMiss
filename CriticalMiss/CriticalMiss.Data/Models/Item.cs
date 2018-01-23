using CriticalMiss.Common.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CriticalMiss.Data.Models
{
    [Table("Items", Schema = "CM")]
    public class Item : IBoardItem
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [BindNever]
        public int ItemId { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [ForeignKey("Boards")]
        [Column("BoardId")]
        public int GameBoardId { get; set; }

        [BindNever]
        public Boards Boards { get; set; }

        [ForeignKey("ImageAssetNavigable")]
        [Column("ImageAssetId")]
        public int ImageAssetId { get; set; }

        [BindNever]
        public ImageAssetDBO ImageAssetNavigable { get; set; }

        [Column("IsToken")]
        public bool IsToken { get; set; }

        [Column("XPosition")]
        public int XPos { get; set; }

        [Column("YPosition")]
        public int YPos { get; set; }

        [Column("PixelWidth")]
        public double Width { get; set; }

        [Column("PixelHeight")]
        public double Height { get; set; }

        [Column("LocalId")]
        public int LocalId { get; set; }
        
        [NotMapped]
        [BindNever]
        public IImageAsset ImageAsset
        {
            get => ImageAssetNavigable;
            set => ImageAssetNavigable = (value as ImageAssetDBO);
        }

        public bool ShouldSerializeImageAssetNavigable() => false;
        public bool ShouldSerializeImageAssetId() => false;
        public bool ShouldSerializeBoards() => false;
    }
}
