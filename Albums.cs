using System;

namespace JamsRecords
{
    public class Albums
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsExplicit { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int BandId { get; set; }
        public Bands Band { get; set; }

    }
}