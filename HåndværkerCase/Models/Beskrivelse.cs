namespace HåndværkerCase.Models
{
    public class Beskrivelse
    {
        public int id { get; set; }
        public string? beskrivelse { get; set; }
        public decimal Pris { get; set; }

        public Boolean Status { get; set; }

        public int CaseId { get; set; }

        public Case? Case { get; set; }
    }
}
