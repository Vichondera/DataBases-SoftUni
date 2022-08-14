namespace Artillery.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class CountryGun
    {
        public int CountryId { get; set; }
       
        public int GunId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; }

        [ForeignKey(nameof(GunId))]
        public Gun Gun { get; set; }

    }
}
