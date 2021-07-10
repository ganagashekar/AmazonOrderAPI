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
    /// Product information on the number of items.
    /// </summary>
    [DataContract]
        public partial class ProductInfoDetail :  IEquatable<ProductInfoDetail>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductInfoDetail" /> class.
        /// </summary>
        /// <param name="numberOfItems">The total number of items that are included in the ASIN..</param>
        public ProductInfoDetail(int? numberOfItems = default(int?))
        {
            this.NumberOfItems = numberOfItems;
        }
        
        /// <summary>
        /// The total number of items that are included in the ASIN.
        /// </summary>
        /// <value>The total number of items that are included in the ASIN.</value>
        [DataMember(Name="NumberOfItems", EmitDefaultValue=false)]
        public int? NumberOfItems { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProductInfoDetail {\n");
            sb.Append("  NumberOfItems: ").Append(NumberOfItems).Append("\n");
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
            return this.Equals(input as ProductInfoDetail);
        }

        /// <summary>
        /// Returns true if ProductInfoDetail instances are equal
        /// </summary>
        /// <param name="input">Instance of ProductInfoDetail to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProductInfoDetail input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.NumberOfItems == input.NumberOfItems ||
                    (this.NumberOfItems != null &&
                    this.NumberOfItems.Equals(input.NumberOfItems))
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
                if (this.NumberOfItems != null)
                    hashCode = hashCode * 59 + this.NumberOfItems.GetHashCode();
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
