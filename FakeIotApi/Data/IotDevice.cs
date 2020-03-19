using System;
using System.Collections.Generic;

namespace FakeIotApi.Data
{
    public class IotDevice
    {
        public int Id { get; set; }
        public int LatencySeconds { get; set; }
        public string Description { get; set; }
        public IEnumerable<IotData> Readings { get; set; }
    }

    public class IotData
    {
        public DateTime Timestamp { get; set; }
        public int Reading { get; set; }
    }
}