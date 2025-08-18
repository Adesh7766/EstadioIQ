namespace EstadioIQ.Entity.DTO.APIResponseDTO
{
    public class SeasonDto
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int CurrentMatchday { get; set; }
        public string Winner { get; set; }  // Can be null
    }
}
