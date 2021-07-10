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
    /// Information about a sub-payment method used to pay for a COD order.
    /// </summary>
    [DataContract]
        public partial class PaymentExecutionDetailItem :  IEquatable<PaymentExecutionDetailItem>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentExecutionDetailItem" /> class.
        /// </summary>
        /// <param name="payment">payment (required).</param>
        /// <param name="paymentMethod">A sub-payment method for a COD order.  Possible values:  * COD - Cash On Delivery.  * GC - Gift Card.  * PointsAccount - Amazon Points. (required).</param>
        public PaymentExecutionDetailItem(Money payment = default(Money), string paymentMethod = default(string))
        {
            // to ensure "payment" is required (not null)
            if (payment == null)
            {
                throw new InvalidDataException("payment is a required property for PaymentExecutionDetailItem and cannot be null");
            }
            else
            {
                this.Payment = payment;
            }
            // to ensure "paymentMethod" is required (not null)
            if (paymentMethod == null)
            {
                throw new InvalidDataException("paymentMethod is a required property for PaymentExecutionDetailItem and cannot be null");
            }
            else
            {
                this.PaymentMethod = paymentMethod;
            }
        }
        
        /// <summary>
        /// Gets or Sets Payment
        /// </summary>
        [DataMember(Name="Payment", EmitDefaultValue=false)]
        public Money Payment { get; set; }

        /// <summary>
        /// A sub-payment method for a COD order.  Possible values:  * COD - Cash On Delivery.  * GC - Gift Card.  * PointsAccount - Amazon Points.
        /// </summary>
        /// <value>A sub-payment method for a COD order.  Possible values:  * COD - Cash On Delivery.  * GC - Gift Card.  * PointsAccount - Amazon Points.</value>
        [DataMember(Name="PaymentMethod", EmitDefaultValue=false)]
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PaymentExecutionDetailItem {\n");
            sb.Append("  Payment: ").Append(Payment).Append("\n");
            sb.Append("  PaymentMethod: ").Append(PaymentMethod).Append("\n");
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
            return this.Equals(input as PaymentExecutionDetailItem);
        }

        /// <summary>
        /// Returns true if PaymentExecutionDetailItem instances are equal
        /// </summary>
        /// <param name="input">Instance of PaymentExecutionDetailItem to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PaymentExecutionDetailItem input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Payment == input.Payment ||
                    (this.Payment != null &&
                    this.Payment.Equals(input.Payment))
                ) && 
                (
                    this.PaymentMethod == input.PaymentMethod ||
                    (this.PaymentMethod != null &&
                    this.PaymentMethod.Equals(input.PaymentMethod))
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
                if (this.Payment != null)
                    hashCode = hashCode * 59 + this.Payment.GetHashCode();
                if (this.PaymentMethod != null)
                    hashCode = hashCode * 59 + this.PaymentMethod.GetHashCode();
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
