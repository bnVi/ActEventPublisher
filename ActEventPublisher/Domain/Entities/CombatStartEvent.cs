using System;

namespace ActEventPublisher.Domain.Entities
{
    public class CombatStartEvent : Event
    {
        public string ZoneName { get; set; }
    }
}
