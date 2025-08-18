namespace EstadioIQ.Entity.DTO.APIResponseDTO
{
    public class CoachFromApiDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public ClubDto Club { get; set; }   
        public Contract Contract { get; set; }
    }

    public class Contract
    {
        public DateTime Start { get; set; }
        public DateTime Until { get; set; }
    }
}
