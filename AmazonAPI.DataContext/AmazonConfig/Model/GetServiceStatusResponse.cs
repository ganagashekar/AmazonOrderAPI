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
 * Get Service Status Response
 * API Version: 2013-09-01
 * Library Version: 2018-10-31
 * Generated: Mon Oct 22 22:40:35 UTC 2018
 */

using MWSClientCsRuntime;

namespace MarketplaceWebServiceOrders.Model
{
    public class GetServiceStatusResponse : AbstractMwsObject, IMWSResponse
    {
        private GetServiceStatusResult _getServiceStatusResult;
        private ResponseMetadata _responseMetadata;
        private ResponseHeaderMetadata _responseHeaderMetadata;

        /// <summary>
        /// Gets and sets the GetServiceStatusResult property.
        /// </summary>
        public GetServiceStatusResult GetServiceStatusResult
        {
            get { return _getServiceStatusResult; }
            set { _getServiceStatusResult = value; }
        }

        /// <summary>
        /// Sets the GetServiceStatusResult property.
        /// </summary>
        /// <param name="getServiceStatusResult">GetServiceStatusResult property.</param>
        /// <returns>this instance.</returns>
        public GetServiceStatusResponse WithGetServiceStatusResult(GetServiceStatusResult getServiceStatusResult)
        {
            _getServiceStatusResult = getServiceStatusResult;
            return this;
        }

        /// <summary>
        /// Checks if GetServiceStatusResult property is set.
        /// </summary>
        /// <returns>true if GetServiceStatusResult property is set.</returns>
        public bool IsSetGetServiceStatusResult()
        {
            return _getServiceStatusResult != null;
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
        public GetServiceStatusResponse WithResponseMetadata(ResponseMetadata responseMetadata)
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
        public GetServiceStatusResponse WithResponseHeaderMetadata(ResponseHeaderMetadata responseHeaderMetadata)
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
            _getServiceStatusResult = reader.Read<GetServiceStatusResult>("GetServiceStatusResult");
            _responseMetadata = reader.Read<ResponseMetadata>("ResponseMetadata");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("GetServiceStatusResult", _getServiceStatusResult);
            writer.Write("ResponseMetadata", _responseMetadata);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2013-09-01", "GetServiceStatusResponse", this);
        }

        public GetServiceStatusResponse() : base()
        {
        }
    }
}