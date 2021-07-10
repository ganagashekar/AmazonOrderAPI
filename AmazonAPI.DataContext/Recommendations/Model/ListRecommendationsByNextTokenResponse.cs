/*******************************************************************************
 * Copyright 2009-2015 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 *
 * You may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * List Recommendations By Next Token Response
 * API Version: 2013-04-01
 * Library Version: 2015-06-18
 * Generated: Thu Jun 18 19:29:19 GMT 2015
 */


using System;
using System.Xml;
using AmazonAPI.MWSClientRuntime;

namespace AmazonAPI.Recommendations.MWSRecommendationsSectionService.Model
{
    public class ListRecommendationsByNextTokenResponse : AbstractMwsObject, IMWSResponse
    {

        private ListRecommendationsByNextTokenResult _listRecommendationsByNextTokenResult;
        private ResponseMetadata _responseMetadata;
        private ResponseHeaderMetadata _responseHeaderMetadata;

        /// <summary>
        /// Gets and sets the ListRecommendationsByNextTokenResult property.
        /// </summary>
        public ListRecommendationsByNextTokenResult ListRecommendationsByNextTokenResult
        {
            get { return this._listRecommendationsByNextTokenResult; }
            set { this._listRecommendationsByNextTokenResult = value; }
        }

        /// <summary>
        /// Sets the ListRecommendationsByNextTokenResult property.
        /// </summary>
        /// <param name="listRecommendationsByNextTokenResult">ListRecommendationsByNextTokenResult property.</param>
        /// <returns>this instance.</returns>
        public ListRecommendationsByNextTokenResponse WithListRecommendationsByNextTokenResult(ListRecommendationsByNextTokenResult listRecommendationsByNextTokenResult)
        {
            this._listRecommendationsByNextTokenResult = listRecommendationsByNextTokenResult;
            return this;
        }

        /// <summary>
        /// Checks if ListRecommendationsByNextTokenResult property is set.
        /// </summary>
        /// <returns>true if ListRecommendationsByNextTokenResult property is set.</returns>
        public bool IsSetListRecommendationsByNextTokenResult()
        {
            return this._listRecommendationsByNextTokenResult != null;
        }

        /// <summary>
        /// Gets and sets the ResponseMetadata property.
        /// </summary>
        public ResponseMetadata ResponseMetadata
        {
            get { return this._responseMetadata; }
            set { this._responseMetadata = value; }
        }

        /// <summary>
        /// Sets the ResponseMetadata property.
        /// </summary>
        /// <param name="responseMetadata">ResponseMetadata property.</param>
        /// <returns>this instance.</returns>
        public ListRecommendationsByNextTokenResponse WithResponseMetadata(ResponseMetadata responseMetadata)
        {
            this._responseMetadata = responseMetadata;
            return this;
        }

        /// <summary>
        /// Checks if ResponseMetadata property is set.
        /// </summary>
        /// <returns>true if ResponseMetadata property is set.</returns>
        public bool IsSetResponseMetadata()
        {
            return this._responseMetadata != null;
        }

        /// <summary>
        /// Gets and sets the ResponseHeaderMetadata property.
        /// </summary>
        public ResponseHeaderMetadata ResponseHeaderMetadata
        {
            get { return this._responseHeaderMetadata; }
            set { this._responseHeaderMetadata = value; }
        }

        /// <summary>
        /// Sets the ResponseHeaderMetadata property.
        /// </summary>
        /// <param name="responseHeaderMetadata">ResponseHeaderMetadata property.</param>
        /// <returns>this instance.</returns>
        public ListRecommendationsByNextTokenResponse WithResponseHeaderMetadata(ResponseHeaderMetadata responseHeaderMetadata)
        {
            this._responseHeaderMetadata = responseHeaderMetadata;
            return this;
        }

        /// <summary>
        /// Checks if ResponseHeaderMetadata property is set.
        /// </summary>
        /// <returns>true if ResponseHeaderMetadata property is set.</returns>
        public bool IsSetResponseHeaderMetadata()
        {
            return this._responseHeaderMetadata != null;
        }


        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _listRecommendationsByNextTokenResult = reader.Read<ListRecommendationsByNextTokenResult>("ListRecommendationsByNextTokenResult");
            _responseMetadata = reader.Read<ResponseMetadata>("ResponseMetadata");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("ListRecommendationsByNextTokenResult", _listRecommendationsByNextTokenResult);
            writer.Write("ResponseMetadata", _responseMetadata);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Recommendations/2013-04-01", "ListRecommendationsByNextTokenResponse", this);
        }

        public ListRecommendationsByNextTokenResponse() : base()
        {
        }
    }
}
