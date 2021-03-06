﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MZrepo
{
    public class Bruger
    {
        public int ID { get; set; }
        [Required]
        public string Email { get; set; }

        public string Navn { get; set; }

        public string Adgangskode { get; set; }

        public string Transfer { get; set; }

        public int Level { get; set; }
    }
}
