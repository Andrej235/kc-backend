﻿namespace kc_backend.Models
{
    public class PriceList
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<PriceListItem> Items { get; set; } = null!;
    }
}
