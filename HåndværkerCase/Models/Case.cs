namespace HåndværkerCase.Models
{
    public class Case
    {
        public int Id { get; set; }

        public string Navn { get; set; }

        public string Adresse { get; set; }

        public string Beskrivelse { get; set; }

        public DateTime StartsDato { get; set; }

        public DateTime SlutsDato { get; set; }
    }
}
