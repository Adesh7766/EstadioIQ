namespace EstadioIQ.Entity.Model
{
    public class Coach
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Nationality { get; set; }

        public Club Club { get; set; }

        public DateTime ContractStartDate { get; set; }

        public DateTime ContractEndDate { get; set; }

        public bool IsActive { get; set; }
    }
}
