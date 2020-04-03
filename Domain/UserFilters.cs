
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Domain
{
    [ExcludeFromCodeCoverage]
    public class UserFilters
    {
        public LocationDTO Location { get; set; } = new LocationDTO();

        public int Category { get; set; } = 0;

        public int  Range { get; set; } = 0;
    }
}
