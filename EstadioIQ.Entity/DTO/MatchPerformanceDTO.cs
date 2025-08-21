using System.ComponentModel.DataAnnotations;

namespace EstadioIQ.Entity.DTO
{
    public class MatchPerformanceDto
    {
        public int Id { get; set; }

        [Required]
        public int MatchId { get; set; }

        [Required]
        public int PlayerId { get; set; }

        public int Goals { get; set; }
        public int Assists { get; set; }
        public int PassesCompleted { get; set; }

        [Required]
        public double Rating { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public bool IsStarter { get; set; }
        public int MinutesPlayed { get; set; }
    }


}
