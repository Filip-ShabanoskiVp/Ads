using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class ENadredenNa
    {
        public string IdVrabotenNareden { get; set; }
        public string IdVrabotenPodreden { get; set; }

        public virtual Administrator IdVrabotenNaredenNavigation { get; set; }
        public virtual Administrator IdVrabotenPodredenNavigation { get; set; }
    }
}
