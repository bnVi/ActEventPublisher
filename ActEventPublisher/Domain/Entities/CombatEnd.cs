using System;

namespace ActEventPublisher.Domain.Entities
{
    public class CombatEnd
    {
        public string ZoneName { get; set; }
        public DateTime EndTime { get; set; }
    }
}
