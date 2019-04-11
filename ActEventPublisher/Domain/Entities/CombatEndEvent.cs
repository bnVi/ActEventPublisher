using System;

namespace ActEventPublisher.Domain.Entities
{
    public class CombatEndEvent : Event
    {
        public string ZoneName { get; set; }
        public DateTime EndTime { get; set; }
    }
}
