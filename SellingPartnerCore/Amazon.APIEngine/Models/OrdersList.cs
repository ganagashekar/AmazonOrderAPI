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
    /// A list of orders along with additional information to make subsequent API calls.
    /// </summary>
    [DataContract]
        public partial class OrdersList :  IEquatable<OrdersList>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersList" /> class.
        /// </summary>
        /// <param name="orders">orders (required).</param>
        /// <param name="nextToken">When present and not empty, pass this string token in the next request to return the next response page..</param>
        /// <param name="lastUpdatedBefore">A date used for selecting orders that were last updated before (or at) a specified time. An update is defined as any change in order status, including the creation of a new order. Includes updates made by Amazon and by the seller. All dates must be in ISO 8601 format..</param>
        /// <param name="createdBefore">A date used for selecting orders created before (or at) a specified time. Only orders placed before the specified time are returned. The date must be in ISO 8601 format..</param>
        public OrdersList(OrderList orders = default(OrderList), string nextToken = default(string), string lastUpdatedBefore = default(string), string createdBefore = default(string))
        {
            // to ensure "orders" is required (not null)
            if (orders == null)
            {
                throw new InvalidDataException("orders is a required property for OrdersList and cannot be null");
            }
            else
            {
                this.Orders = orders;
            }
            this.NextToken = nextToken;
            this.LastUpdatedBefore = lastUpdatedBefore;
            this.CreatedBefore = createdBefore;
        }
        
        /// <summary>
        /// Gets or Sets Orders
        /// </summary>
        [DataMember(Name="Orders", EmitDefaultValue=false)]
        public OrderList Orders { get; set; }

        /// <summary>
        /// When present and not empty, pass this string token in the next request to return the next response page.
        /// </summary>
        /// <value>When present and not empty, pass this string token in the next request to return the next response page.</value>
        [DataMember(Name="NextToken", EmitDefaultValue=false)]
        public string NextToken { get; set; }

        /// <summary>
        /// A date used for selecting orders that were last updated before (or at) a specified time. An update is defined as any change in order status, including the creation of a new order. Includes updates made by Amazon and by the seller. All dates must be in ISO 8601 format.
        /// </summary>
        /// <value>A date used for selecting orders that were last updated before (or at) a specified time. An update is defined as any change in order status, including the creation of a new order. Includes updates made by Amazon and by the seller. All dates must be in ISO 8601 format.</value>
        [DataMember(Name="LastUpdatedBefore", EmitDefaultValue=false)]
        public string LastUpdatedBefore { get; set; }

        /// <summary>
        /// A date used for selecting orders created before (or at) a specified time. Only orders placed before the specified time are returned. The date must be in ISO 8601 format.
        /// </summary>
        /// <value>A date used for selecting orders created before (or at) a specified time. Only orders placed before the specified time are returned. The date must be in ISO 8601 format.</value>
        [DataMember(Name="CreatedBefore", EmitDefaultValue=false)]
        public string CreatedBefore { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrdersList {\n");
            sb.Append("  Orders: ").Append(Orders).Append("\n");
            sb.Append("  NextToken: ").Append(NextToken).Append("\n");
            sb.Append("  LastUpdatedBefore: ").Append(LastUpdatedBefore).Append("\n");
            sb.Append("  CreatedBefore: ").Append(CreatedBefore).Append("\n");
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
            return this.Equals(input as OrdersList);
        }

        /// <summary>
        /// Returns true if OrdersList instances are equal
        /// </summary>
        /// <param name="input">Instance of OrdersList to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrdersList input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Orders == input.Orders ||
                    (this.Orders != null &&
                    this.Orders.Equals(input.Orders))
                ) && 
                (
                    this.NextToken == input.NextToken ||
                    (this.NextToken != null &&
                    this.NextToken.Equals(input.NextToken))
                ) && 
                (
                    this.LastUpdatedBefore == input.LastUpdatedBefore ||
                    (this.LastUpdatedBefore != null &&
                    this.LastUpdatedBefore.Equals(input.LastUpdatedBefore))
                ) && 
                (
                    this.CreatedBefore == input.CreatedBefore ||
                    (this.CreatedBefore != null &&
                    this.CreatedBefore.Equals(input.CreatedBefore))
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
                if (this.Orders != null)
                    hashCode = hashCode * 59 + this.Orders.GetHashCode();
                if (this.NextToken != null)
                    hashCode = hashCode * 59 + this.NextToken.GetHashCode();
                if (this.LastUpdatedBefore != null)
                    hashCode = hashCode * 59 + this.LastUpdatedBefore.GetHashCode();
                if (this.CreatedBefore != null)
                    hashCode = hashCode * 59 + this.CreatedBefore.GetHashCode();
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
