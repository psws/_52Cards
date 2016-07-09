using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shiftwise._52cards.mvc.common.Enum;

namespace Shiftwise._52cards.mvc.DataModel
{
    public class Deck
    {
        [Key]
        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        [Required]
        public string DeckId { get; set; } //SpadeJack...

        public Shiftwise._52cards.mvc.common.Enum.CardSuitEnum CardSuitEnum { get; set; }

    }
}