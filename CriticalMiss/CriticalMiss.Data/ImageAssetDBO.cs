using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CriticalMiss.Data
{
    [Table("ImageAsset", Schema = "CM")]
    public class ImageAssetDBO
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageAssetId { get; set; }

        [Column("DateTimeCreated")]
        public DateTime DateTimeCreated { get; set; }

        [Column("Description")]
        public string AssetDescription { get; set; }

        [Column("AssetURI")]
        [Required]
        public string AssetURI { get; set; }
    }
}