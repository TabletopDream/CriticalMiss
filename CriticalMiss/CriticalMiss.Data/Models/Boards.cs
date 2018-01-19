using CriticalMiss.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CriticalMiss.Data.Models
{
    public class Boards : IBoard
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BoardId { get; set; }

        [Column("BoardName")]
        public string BoardName { get; set; }

        [ForeignKey("Game")]
        [Column("GameId")]
        public int GameId { get; set; }

        [Column("Width")]
        public int Width { get; set; }

        [Column("Height")]
        public int Height { get; set; }

        [Column("Pixel")]
        public int Pixel { get; set; }

        [Column("LocalId")]
        public int LocalId { get; set; }

        [Column("ItemCount")]
        public int ItemCount { get; set; }
    }
}
