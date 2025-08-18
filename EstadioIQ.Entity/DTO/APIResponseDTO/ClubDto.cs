namespace EstadioIQ.Entity.DTO.APIResponseDTO
{
    public class ClubDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Tla { get; set; }
        public string Crest { get; set; }
        public string website { get; set; }
        public string Venue { get; set; }
        public AreaDto Area { get; set; }
        public List<PlayerDto> Players { get; set; }        
    }
}
