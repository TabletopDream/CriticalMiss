﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CriticalMiss.Data.Models
{
    [Table("Games", Schema ="CM")]
    public class Games
    {
        [Key]
        [Column("GameId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameId { get; set; }

        [Column("UserName")]
        [Required]
        public string UserName { get; set; }

        [Column("GameName")]
        [Required]
        public string GameName { get; set; }

        [Column("Password")]
        [Required]
        public string Password { get; set; }


    }
}
