using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventures.Models
{
    public class EventModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Place is required")]
        public string Place { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "StartDate is required")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "EndDate is required")]
        public DateTime EndDate { get; set; }

        public int TotalTickets { get; set; }

        [Precision(18, 2)]
        public decimal PricePerTicket { get; set; }

        public EventModel(int id, string name, string place, DateTime startDate, DateTime endDate, int totalTickets, decimal pricePerTicket)
        {
            Id = id;
            Name = name;
            Place = place;
            StartDate = startDate;
            EndDate = endDate;
            TotalTickets = totalTickets;
            PricePerTicket = pricePerTicket;
        }

        public EventModel() { }
    }
}
