using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace NgCooking.ViewModels
{
    public class CommunauteRecetteViewModel
    {
        public string recetteId { get; set; }
        public int communauteId { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Il faut un vrai titre")]
        [MaxLength(50, ErrorMessage = "C'est titre qui est demandé pas le commentaire au complet.")]
        public string title { get; set; }
        [Required]
        [MinLength(20, ErrorMessage = "Un commentaire plus precise ne serait pas de refus.")]
        [MaxLength(400, ErrorMessage = "Un commentaire n'est pas un roman.")]
        public string comment { get; set; }
        [Required]
        [Range(0, 5)]
        public double mark { get; set; }
        public SelectList markPossible = new SelectList(new List<Object>
                                        {
                                        new { value = 5 , text = "5"  },
                                        new { value = 4 , text = "4" },
                                        new { value = 3 , text = "3"},
                                        new { value = 2 , text = "2"},
                                        new { value = 1 , text = "1"},
                                        new { value = 0 , text = "0"}
                                        },
                                        "value",
                                        "text",
                                        2);
    }
}