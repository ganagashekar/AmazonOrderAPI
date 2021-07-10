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
    /// The tax classification for the order.
    /// </summary>
    [DataContract]
        public partial class TaxClassification :  IEquatable<TaxClassification>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxClassification" /> class.
        /// </summary>
        /// <param name="name">The type of tax..</param>
        /// <param name="value">The buyer&#x27;s tax identifier..</param>
        public TaxClassification(string name = default(string), string value = default(string))
        {
            this.Name = name;
            this.Value = value;
        }
        
        /// <summary>
        /// The type of tax.
        /// </summary>
        /// <value>The type of tax.</value>
        [DataMember(Name="Name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// The buyer&#x27;s tax identifier.
        /// </summary>
        /// <value>The buyer&#x27;s tax identifier.</value>
        [DataMember(Name="Value", EmitDefaultValue=false)]
        public string Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TaxClassification {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
            return this.Equals(input as TaxClassification);
        }

        /// <summary>
        /// Returns true if TaxClassification instances are equal
        /// </summary>
        /// <param name="input">Instance of TaxClassification to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TaxClassification input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Value == input.Value ||
                    (this.Value != null &&
                    this.Value.Equals(input.Value))
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Value != null)
                    hashCode = hashCode * 59 + this.Value.GetHashCode();
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
