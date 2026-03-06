namespace EcoTrackDesktop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transaction
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? CategoryId { get; set; }

        public decimal? Weight { get; set; }
        public string WeightKG => Weight?.ToString("0.00 KG") ?? "0 KG"; 

        public decimal? TotalPrice { get; set; }
        public string TotalPriceRp => TotalPrice?.ToString("Rp#,##0;(Rp#,##0);Rp0") ?? "Rp0";

        public DateTime? Date { get; set; }

        public virtual Category Category { get; set; }
        public string CategoryName => Category?.Name ?? "";

        public virtual User User { get; set; }
        public string CustomerName => User?.Username ?? "";
    }
}
