namespace Trucks.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Client
    {
        public Client()
        {
            ClientsTrucks = new List<ClientTruck>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40,MinimumLength = 3)]
        public string Name{ get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Nationality  { get; set; }

        [Required]
        public string Type { get; set; }

        public ICollection<ClientTruck> ClientsTrucks { get; set; }

    }
}
