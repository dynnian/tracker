namespace Tracker.Domain.Entities
{
    public class Color
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Hex { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string CreatedBy { get; private set; }

        private Color() { }

        public Color(
            string name,
            string hex,
            string createdBy)
        {
            Id = Guid.NewGuid();
            Name = name;
            Hex = hex;
            CreatedBy = createdBy;
            CreatedAt = DateTime.Now;
        }

        public static Color Load(
            Guid Id,
            string name,
            string hex,
            string createdBy,
            DateTime createdAt
        )
        {
            return new Color
            {
                Id = Id,
                Name = name,
                Hex = hex,
                CreatedBy = createdBy,
                CreatedAt = createdAt
            };
        }
    }
}
