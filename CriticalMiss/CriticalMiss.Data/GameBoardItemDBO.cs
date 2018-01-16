using CriticalMiss.Common.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CriticalMiss.Data
{
    [Table("GameBoardItem", Schema = "CM")]
    public class GameBoardItemDBO :IBoardItem
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [ForeignKey("GameBoard")]
        [Column("GameBoardId")]
        public int GameBoardId { get; set; }

        public GameBoardDBO GameBoard { get; set; }

        [ForeignKey("ImageAsset")]
        [Column("ImageAssetId")]
        public int ImageAssetId { get; set; }

        public ImageAssetDBO ImageAsset { get; set; }

        [Column("IsToken")]
        public bool IsToken { get; set; }

        [Column("XPosition")]
        public int XPos{ get; set; }

        [Column("YPosition")]
        public int YPos { get; set; }

        [Column("PixelWidth")]
        public int Width { get; set; }

        [Column("PixelHeight")]

        public int Height { get; set; }

        public int Id { get; set; }

        public int LocalId { get;set; }

        IImageAsset IBoardItem.ImageAsset { get; set; }
    }
}