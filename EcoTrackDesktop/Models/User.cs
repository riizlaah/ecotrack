namespace EcoTrackDesktop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(255)]
        public string Password { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(20)]
        public string Role { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }
        public string PhoneWName => $"{Phone} - {FullName}";

        public decimal? Balance { get; set; } = 0m;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
