/*******************************************************************************
 * Copyright 2009-2013 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License");
 *
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * Fulfillment Channel List
 * API Version: 2011-01-01
 * Library Version: 2013-11-01
 * Generated: Fri Nov 08 21:29:21 GMT 2013
 */

using MWSClientCsRuntime;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MarketplaceWebServiceOrders.Model
{
    [XmlTypeAttribute(Namespace = "https://mws.amazonservices.com/Orders/2011-01-01")]
    [XmlRootAttribute(Namespace = "https://mws.amazonservices.com/Orders/2011-01-01", IsNullable = false)]
    public class FulfillmentChannelList : AbstractMwsObject
    {
        private List<string> _channel;

        /// <summary>
        /// Gets and sets the Channel property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Channel")]
        public List<string> Channel
        {
            get
            {
                if (_channel == null)
                {
                    _channel = new List<string>();
                }
                return _channel;
            }
            set { _channel = value; }
        }

        /// <summary>
        /// Sets the Channel property.
        /// </summary>
        /// <param name="channel">Channel property.</param>
        /// <returns>this instance.</returns>
        public FulfillmentChannelList WithChannel(string[] channel)
        {
            _channel.AddRange(channel);
            return this;
        }

        /// <summary>
        /// Checks if Channel property is set.
        /// </summary>
        /// <returns>true if Channel property is set.</returns>
        public bool IsSetChannel()
        {
            return Channel.Count > 0;
        }

        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _channel = reader.ReadList<string>("Channel");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.WriteList("Channel", _channel);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2011-01-01", "FulfillmentChannelList", this);
        }

        public FulfillmentChannelList() : base()
        {
        }
    }
}