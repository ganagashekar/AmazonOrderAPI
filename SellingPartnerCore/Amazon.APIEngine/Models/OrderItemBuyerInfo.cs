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
    /// A single order item&#x27;s buyer information.
    /// </summary>
    [DataContract]
        public partial class OrderItemBuyerInfo :  IEquatable<OrderItemBuyerInfo>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItemBuyerInfo" /> class.
        /// </summary>
        /// <param name="orderItemId">An Amazon-defined order item identifier. (required).</param>
        /// <param name="buyerCustomizedInfo">buyerCustomizedInfo.</param>
        /// <param name="giftWrapPrice">giftWrapPrice.</param>
        /// <param name="giftWrapTax">giftWrapTax.</param>
        /// <param name="giftMessageText">A gift message provided by the buyer..</param>
        /// <param name="giftWrapLevel">The gift wrap level specified by the buyer..</param>
        public OrderItemBuyerInfo(string orderItemId = default(string), BuyerCustomizedInfoDetail buyerCustomizedInfo = default(BuyerCustomizedInfoDetail), Money giftWrapPrice = default(Money), Money giftWrapTax = default(Money), string giftMessageText = default(string), string giftWrapLevel = default(string))
        {
            // to ensure "orderItemId" is required (not null)
            if (orderItemId == null)
            {
                throw new InvalidDataException("orderItemId is a required property for OrderItemBuyerInfo and cannot be null");
            }
            else
            {
                this.OrderItemId = orderItemId;
            }
            this.BuyerCustomizedInfo = buyerCustomizedInfo;
            this.GiftWrapPrice = giftWrapPrice;
            this.GiftWrapTax = giftWrapTax;
            this.GiftMessageText = giftMessageText;
            this.GiftWrapLevel = giftWrapLevel;
        }
        
        /// <summary>
        /// An Amazon-defined order item identifier.
        /// </summary>
        /// <value>An Amazon-defined order item identifier.</value>
        [DataMember(Name="OrderItemId", EmitDefaultValue=false)]
        public string OrderItemId { get; set; }

        /// <summary>
        /// Gets or Sets BuyerCustomizedInfo
        /// </summary>
        [DataMember(Name="BuyerCustomizedInfo", EmitDefaultValue=false)]
        public BuyerCustomizedInfoDetail BuyerCustomizedInfo { get; set; }

        /// <summary>
        /// Gets or Sets GiftWrapPrice
        /// </summary>
        [DataMember(Name="GiftWrapPrice", EmitDefaultValue=false)]
        public Money GiftWrapPrice { get; set; }

        /// <summary>
        /// Gets or Sets GiftWrapTax
        /// </summary>
        [DataMember(Name="GiftWrapTax", EmitDefaultValue=false)]
        public Money GiftWrapTax { get; set; }

        /// <summary>
        /// A gift message provided by the buyer.
        /// </summary>
        /// <value>A gift message provided by the buyer.</value>
        [DataMember(Name="GiftMessageText", EmitDefaultValue=false)]
        public string GiftMessageText { get; set; }

        /// <summary>
        /// The gift wrap level specified by the buyer.
        /// </summary>
        /// <value>The gift wrap level specified by the buyer.</value>
        [DataMember(Name="GiftWrapLevel", EmitDefaultValue=false)]
        public string GiftWrapLevel { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderItemBuyerInfo {\n");
            sb.Append("  OrderItemId: ").Append(OrderItemId).Append("\n");
            sb.Append("  BuyerCustomizedInfo: ").Append(BuyerCustomizedInfo).Append("\n");
            sb.Append("  GiftWrapPrice: ").Append(GiftWrapPrice).Append("\n");
            sb.Append("  GiftWrapTax: ").Append(GiftWrapTax).Append("\n");
            sb.Append("  GiftMessageText: ").Append(GiftMessageText).Append("\n");
            sb.Append("  GiftWrapLevel: ").Append(GiftWrapLevel).Append("\n");
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
            return this.Equals(input as OrderItemBuyerInfo);
        }

        /// <summary>
        /// Returns true if OrderItemBuyerInfo instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderItemBuyerInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderItemBuyerInfo input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.OrderItemId == input.OrderItemId ||
                    (this.OrderItemId != null &&
                    this.OrderItemId.Equals(input.OrderItemId))
                ) && 
                (
                    this.BuyerCustomizedInfo == input.BuyerCustomizedInfo ||
                    (this.BuyerCustomizedInfo != null &&
                    this.BuyerCustomizedInfo.Equals(input.BuyerCustomizedInfo))
                ) && 
                (
                    this.GiftWrapPrice == input.GiftWrapPrice ||
                    (this.GiftWrapPrice != null &&
                    this.GiftWrapPrice.Equals(input.GiftWrapPrice))
                ) && 
                (
                    this.GiftWrapTax == input.GiftWrapTax ||
                    (this.GiftWrapTax != null &&
                    this.GiftWrapTax.Equals(input.GiftWrapTax))
                ) && 
                (
                    this.GiftMessageText == input.GiftMessageText ||
                    (this.GiftMessageText != null &&
                    this.GiftMessageText.Equals(input.GiftMessageText))
                ) && 
                (
                    this.GiftWrapLevel == input.GiftWrapLevel ||
                    (this.GiftWrapLevel != null &&
                    this.GiftWrapLevel.Equals(input.GiftWrapLevel))
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
                if (this.OrderItemId != null)
                    hashCode = hashCode * 59 + this.OrderItemId.GetHashCode();
                if (this.BuyerCustomizedInfo != null)
                    hashCode = hashCode * 59 + this.BuyerCustomizedInfo.GetHashCode();
                if (this.GiftWrapPrice != null)
                    hashCode = hashCode * 59 + this.GiftWrapPrice.GetHashCode();
                if (this.GiftWrapTax != null)
                    hashCode = hashCode * 59 + this.GiftWrapTax.GetHashCode();
                if (this.GiftMessageText != null)
                    hashCode = hashCode * 59 + this.GiftMessageText.GetHashCode();
                if (this.GiftWrapLevel != null)
                    hashCode = hashCode * 59 + this.GiftWrapLevel.GetHashCode();
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
