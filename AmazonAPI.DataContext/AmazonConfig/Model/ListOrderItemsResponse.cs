/*******************************************************************************
 * Copyright 2009-2018 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License");
 *
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * List Order Items Response
 * API Version: 2013-09-01
 * Library Version: 2018-10-31
 * Generated: Mon Oct 22 22:40:35 UTC 2018
 */

using MWSClientCsRuntime;

namespace MarketplaceWebServiceOrders.Model
{
    public class ListOrderItemsResponse : AbstractMwsObject, IMWSResponse
    {
        private ListOrderItemsResult _listOrderItemsResult;
        private ResponseMetadata _responseMetadata;
        private ResponseHeaderMetadata _responseHeaderMetadata;

        /// <summary>
        /// Gets and sets the ListOrderItemsResult property.
        /// </summary>
        public ListOrderItemsResult ListOrderItemsResult
        {
            get { return _listOrderItemsResult; }
            set { _listOrderItemsResult = value; }
        }

        /// <summary>
        /// Sets the ListOrderItemsResult property.
        /// </summary>
        /// <param name="listOrderItemsResult">ListOrderItemsResult property.</param>
        /// <returns>this instance.</returns>
        public ListOrderItemsResponse WithListOrderItemsResult(ListOrderItemsResult listOrderItemsResult)
        {
            _listOrderItemsResult = listOrderItemsResult;
            return this;
        }

        /// <summary>
        /// Checks if ListOrderItemsResult property is set.
        /// </summary>
        /// <returns>true if ListOrderItemsResult property is set.</returns>
        public bool IsSetListOrderItemsResult()
        {
            return _listOrderItemsResult != null;
        }

        /// <summary>
        /// Gets and sets the ResponseMetadata property.
        /// </summary>
        public ResponseMetadata ResponseMetadata
        {
            get { return _responseMetadata; }
            set { _responseMetadata = value; }
        }

        /// <summary>
        /// Sets the ResponseMetadata property.
        /// </summary>
        /// <param name="responseMetadata">ResponseMetadata property.</param>
        /// <returns>this instance.</returns>
        public ListOrderItemsResponse WithResponseMetadata(ResponseMetadata responseMetadata)
        {
            _responseMetadata = responseMetadata;
            return this;
        }

        /// <summary>
        /// Checks if ResponseMetadata property is set.
        /// </summary>
        /// <returns>true if ResponseMetadata property is set.</returns>
        public bool IsSetResponseMetadata()
        {
            return _responseMetadata != null;
        }

        /// <summary>
        /// Gets and sets the ResponseHeaderMetadata property.
        /// </summary>
        public ResponseHeaderMetadata ResponseHeaderMetadata
        {
            get { return _responseHeaderMetadata; }
            set { _responseHeaderMetadata = value; }
        }

        /// <summary>
        /// Sets the ResponseHeaderMetadata property.
        /// </summary>
        /// <param name="responseHeaderMetadata">ResponseHeaderMetadata property.</param>
        /// <returns>this instance.</returns>
        public ListOrderItemsResponse WithResponseHeaderMetadata(ResponseHeaderMetadata responseHeaderMetadata)
        {
            _responseHeaderMetadata = responseHeaderMetadata;
            return this;
        }

        /// <summary>
        /// Checks if ResponseHeaderMetadata property is set.
        /// </summary>
        /// <returns>true if ResponseHeaderMetadata property is set.</returns>
        public bool IsSetResponseHeaderMetadata()
        {
            return _responseHeaderMetadata != null;
        }

        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _listOrderItemsResult = reader.Read<ListOrderItemsResult>("ListOrderItemsResult");
            _responseMetadata = reader.Read<ResponseMetadata>("ResponseMetadata");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("ListOrderItemsResult", _listOrderItemsResult);
            writer.Write("ResponseMetadata", _responseMetadata);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2013-09-01", "ListOrderItemsResponse", this);
        }

        public ListOrderItemsResponse() : base()
        {
        }

        public override string ToString()
        {
            return $"{{{nameof(ListOrderItemsResult)}={ListOrderItemsResult}, {nameof(ResponseMetadata)}={ResponseMetadata}, {nameof(ResponseHeaderMetadata)}={ResponseHeaderMetadata}}}";
        }
    }
}