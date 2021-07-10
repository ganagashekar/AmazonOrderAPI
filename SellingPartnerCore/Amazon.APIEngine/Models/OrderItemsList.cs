/* 
 * 
 *
 
 *

 * 

 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;


namespace Amazon.APIEngine.Models
{
    /// <summary>
    /// The order items list along with the order ID.
    /// </summary>
    [DataContract]
        public partial class OrderItemsList :  IEquatable<OrderItemsList>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItemsList" /> class.
        /// </summary>
        /// <param name="orderItems">orderItems (required).</param>
        /// <param name="nextToken">When present and not empty, pass this string token in the next request to return the next response page..</param>
        /// <param name="amazonOrderId">An Amazon-defined order identifier, in 3-7-7 format. (required).</param>
        public OrderItemsList(OrderItemList orderItems = default(OrderItemList), string nextToken = default(string), string amazonOrderId = default(string))
        {
            // to ensure "orderItems" is required (not null)
            if (orderItems == null)
            {
                throw new InvalidDataException("orderItems is a required property for OrderItemsList and cannot be null");
            }
            else
            {
                this.OrderItems = orderItems;
            }
            // to ensure "amazonOrderId" is required (not null)
            if (amazonOrderId == null)
            {
                throw new InvalidDataException("amazonOrderId is a required property for OrderItemsList and cannot be null");
            }
            else
            {
                this.AmazonOrderId = amazonOrderId;
            }
            this.NextToken = nextToken;
        }
        
        /// <summary>
        /// Gets or Sets OrderItems
        /// </summary>
        [DataMember(Name="OrderItems", EmitDefaultValue=false)]
        public OrderItemList OrderItems { get; set; }

        /// <summary>
        /// When present and not empty, pass this string token in the next request to return the next response page.
        /// </summary>
        /// <value>When present and not empty, pass this string token in the next request to return the next response page.</value>
        [DataMember(Name="NextToken", EmitDefaultValue=false)]
        public string NextToken { get; set; }

        /// <summary>
        /// An Amazon-defined order identifier, in 3-7-7 format.
        /// </summary>
        /// <value>An Amazon-defined order identifier, in 3-7-7 format.</value>
        [DataMember(Name="AmazonOrderId", EmitDefaultValue=false)]
        public string AmazonOrderId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderItemsList {\n");
            sb.Append("  OrderItems: ").Append(OrderItems).Append("\n");
            sb.Append("  NextToken: ").Append(NextToken).Append("\n");
            sb.Append("  AmazonOrderId: ").Append(AmazonOrderId).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as OrderItemsList);
        }

        /// <summary>
        /// Returns true if OrderItemsList instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderItemsList to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderItemsList input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.OrderItems == input.OrderItems ||
                    (this.OrderItems != null &&
                    this.OrderItems.Equals(input.OrderItems))
                ) && 
                (
                    this.NextToken == input.NextToken ||
                    (this.NextToken != null &&
                    this.NextToken.Equals(input.NextToken))
                ) && 
                (
                    this.AmazonOrderId == input.AmazonOrderId ||
                    (this.AmazonOrderId != null &&
                    this.AmazonOrderId.Equals(input.AmazonOrderId))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.OrderItems != null)
                    hashCode = hashCode * 59 + this.OrderItems.GetHashCode();
                if (this.NextToken != null)
                    hashCode = hashCode * 59 + this.NextToken.GetHashCode();
                if (this.AmazonOrderId != null)
                    hashCode = hashCode * 59 + this.AmazonOrderId.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
