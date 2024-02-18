﻿using System.ComponentModel.DataAnnotations;

namespace Empathy.Data.Entities
{
    public class SedeProfessional
    {
        [Key]
        public int Id { get; set; }
        public int SedeId { get; set; }
        public Sede Sede { get; set; }

        public int ProfessionalId { get; set; }
        public Professional Professional { get; set; }

    }
}
