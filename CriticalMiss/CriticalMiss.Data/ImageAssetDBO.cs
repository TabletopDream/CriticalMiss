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

        [Column("AssetURI")]
        public string AssetURI { get; set; }
    }
}