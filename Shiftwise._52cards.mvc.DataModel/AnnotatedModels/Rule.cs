using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shiftwise._52cards.mvc.DataModel.AnnotatedModels
{
    public class Rule
    {
        [Key]
        [Column(Order = 1, TypeName = "varchar")]
        [MaxLength(20)]
        [Required]
        public string DeckId { get; set; }
        [Key]
        [Column(Order = 2, TypeName = "varchar")]
        [MaxLength(35)]
        [Required]
        public string GameName { get; set; }
        public short Value { get; set; }
        //FK
        public virtual Deck Deck { get; set; }

    }
}