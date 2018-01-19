﻿using CriticalMiss.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CriticalMiss.Data.Models
{
    [Table("Boards", Schema = "CM")]
    public class Boards : IBoard
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BoardId { get; set; }

        [Column("BoardName")]
        public string BoardName { get; set; }

        public string GameName { get; set; }
        public Games Game { get; set; }

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
