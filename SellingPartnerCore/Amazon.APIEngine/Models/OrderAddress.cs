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
    /// The shipping address for the order.
    /// </summary>
    [DataContract]
        public partial class OrderAddress :  IEquatable<OrderAddress>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderAddress" /> class.
        /// </summary>
        /// <param name="amazonOrderId">An Amazon-defined order identifier, in 3-7-7 format. (required).</param>
        /// <param name="shippingAddress">shippingAddress.</param>
        public OrderAddress(string amazonOrderId = default(string), Address shippingAddress = default(Address))
        {
            // to ensure "amazonOrderId" is required (not null)
            if (amazonOrderId == null)
            {
                throw new InvalidDataException("amazonOrderId is a required property for OrderAddress and cannot be null");
            }
            else
            {
                this.AmazonOrderId = amazonOrderId;
            }
            this.ShippingAddress = shippingAddress;
        }
        
        /// <summary>
        /// An Amazon-defined order identifier, in 3-7-7 format.
        /// </summary>
        /// <value>An Amazon-defined order identifier, in 3-7-7 format.</value>
        [DataMember(Name="AmazonOrderId", EmitDefaultValue=false)]
        public string AmazonOrderId { get; set; }

        /// <summary>
        /// Gets or Sets ShippingAddress
        /// </summary>
        [DataMember(Name="ShippingAddress", EmitDefaultValue=false)]
        public Address ShippingAddress { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderAddress {\n");
            sb.Append("  AmazonOrderId: ").Append(AmazonOrderId).Append("\n");
            sb.Append("  ShippingAddress: ").Append(ShippingAddress).Append("\n");
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
            return this.Equals(input as OrderAddress);
        }

        /// <summary>
        /// Returns true if OrderAddress instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderAddress to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderAddress input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.AmazonOrderId == input.AmazonOrderId ||
                    (this.AmazonOrderId != null &&
                    this.AmazonOrderId.Equals(input.AmazonOrderId))
                ) && 
                (
                    this.ShippingAddress == input.ShippingAddress ||
                    (this.ShippingAddress != null &&
                    this.ShippingAddress.Equals(input.ShippingAddress))
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
                if (this.AmazonOrderId != null)
                    hashCode = hashCode * 59 + this.AmazonOrderId.GetHashCode();
                if (this.ShippingAddress != null)
                    hashCode = hashCode * 59 + this.ShippingAddress.GetHashCode();
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
