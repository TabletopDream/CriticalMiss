using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CriticalMiss.Data
{
    [Table("GameBoardItem", Schema = "CM")]
    public class GameBoardItemDBO
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

        [Column("XPosition")]
        public int XPosition { get; set; }

        [Column("YPosition")]
        public int YPosition { get; set; }

        [Column("PixelWidth")]
        public int PixelWidth { get; set; }

        [Column("PixelHeight")]
        public int PixelHeight { get; set; }
    }
}