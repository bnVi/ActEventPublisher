using System;

namespace ActEventPublisher.Domain.Entities
{
    public class LogLine
    {
        public DateTime DetectedTime { get; set; }
        public string DetectedZone { get; set; }
        public bool InCombat { get; set; }
        public string Content { get; set; }
        public int DetectedType { get; set; }
    }
}
