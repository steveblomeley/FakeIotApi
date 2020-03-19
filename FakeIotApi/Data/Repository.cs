using System;
using System.Collections.Generic;
using System.Linq;
using FakeIotApi.Data;

namespace FakeIotApi
{
    public class Repository
    {
        private static readonly IList<IotDevice> _data = CreateFakeDevices();

        public IotDevice Read(int id) => _data.Single(x => x.Id == id);

        private static IList<IotDevice> CreateFakeDevices()
            => Enumerable
                .Range(1, 100)
                .Select(CreateFakeDevice)
                .ToList();

        private static IotDevice CreateFakeDevice(int id)
            => new IotDevice
            {
                Id = id,
                Description = $"Device #{id:D3}. Model {ModelNo(id)}",
                LatencySeconds = LatencySeconds(id),
                Readings = new[]
                {
                    new IotData
                    {
                        Timestamp = new DateTime(2020, 12, 12, 22, 00, 00),
                        Reading = 123
                    },
                    new IotData
                    {
                        Timestamp = new DateTime(2020, 12, 12, 23, 00, 00),
                        Reading = 456
                    }
                }
            };

        private static string ModelNo(int id) => $"XYZ-{10 * (id / 10):D2}/A";

        private static int LatencySeconds(int id) => 1 + (id % 10);
    }
}