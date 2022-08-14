namespace Artillery.Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Shell
    {
        public Shell()
        {
            Guns = new List<Gun>();
        }
        public int Id { get; set; }

        [Required]
        [Range(1.680,2)]
        public double ShellWeight { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Caliber { get; set; }

        // Guns – a collection of Gun
        public ICollection<Gun> Guns { get; set; }
    }
}
