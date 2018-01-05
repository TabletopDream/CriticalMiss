using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CriticalMiss.Data
{
    [Table("GameBoard", Schema = "CM")]
    public class GameBoardDBO
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameBoardId { get; set; }

        [ForeignKey("Game")]
        [Column("GameId")]
        public int GameId { get; set; }

        //public GameDBO Game { get; set; }

        [Column("Width")]
        public int Width { get; set; }

        [Column("Height")]
        public int Height { get; set; }

        public virtual ICollection<GameBoardItemDBO> BoardItems { get; set; }
    }
}
