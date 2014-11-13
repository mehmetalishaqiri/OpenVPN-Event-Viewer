using System;

namespace openvpn.api.common
{
    public class Event
    {
        /// <summary>
        /// 
        /// </summary>
        public Event()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EventType Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CommonName { get; set; }
        

        /// <summary>
        /// 
        /// </summary>
        public string LocalIp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RemoteIp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string HostName { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public decimal? BytesSent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? BytesReceived { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? Duration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime EnteredOn { get; set; }

    }
}
