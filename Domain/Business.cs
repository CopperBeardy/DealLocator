using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Domain
{
    [ExcludeFromCodeCoverage]
    public class Business
    {
        public Business()
        {
            Deals = new List<Deal>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Location Location { get; set; }

        public virtual ICollection<Deal> Deals { get; set; }
    }
}
