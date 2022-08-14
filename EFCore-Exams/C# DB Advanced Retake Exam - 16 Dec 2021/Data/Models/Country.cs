namespace Artillery.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        public Country()
        {
            CountriesGuns = new List<CountryGun>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(60,MinimumLength = 4)]
        public string CountryName { get; set; }

        [Required]
        [Range(50000,10000000)]
        public int ArmySize { get; set; }

        public ICollection<CountryGun> CountriesGuns { get; set; }

    }
}
