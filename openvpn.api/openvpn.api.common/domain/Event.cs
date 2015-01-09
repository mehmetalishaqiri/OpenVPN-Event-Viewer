/*
    The MIT License (MIT)

    Copyright (c) 2014 Mehmetali Shaqiri (mehmetalishaqiri@gmail.com)

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE. 
 */

using System;
using openvpn.api.shared;

namespace openvpn.api.common.domain
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

        public string TypeDescription
        {
            get { return Type.GetEnumDescription(); }
        }

        /// <summary>
        /// 
        /// </summary>
        public string VpnServer { get; set; }

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
