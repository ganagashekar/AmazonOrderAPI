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
    /// Information about withheld taxes.
    /// </summary>
    [DataContract]
        public partial class TaxCollection :  IEquatable<TaxCollection>, IValidatableObject
    {
        /// <summary>
        /// The tax collection model applied to the item.
        /// </summary>
        /// <value>The tax collection model applied to the item.</value>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum ModelEnum
        {
            /// <summary>
            /// Enum MarketplaceFacilitator for value: MarketplaceFacilitator
            /// </summary>
            [EnumMember(Value = "MarketplaceFacilitator")]
            MarketplaceFacilitator = 1        }
        /// <summary>
        /// The tax collection model applied to the item.
        /// </summary>
        /// <value>The tax collection model applied to the item.</value>
        [DataMember(Name="Model", EmitDefaultValue=false)]
        public ModelEnum? Model { get; set; }
        /// <summary>
        /// The party responsible for withholding the taxes and remitting them to the taxing authority.
        /// </summary>
        /// <value>The party responsible for withholding the taxes and remitting them to the taxing authority.</value>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum ResponsiblePartyEnum
        {
            /// <summary>
            /// Enum AmazonServicesInc for value: Amazon Services, Inc.
            /// </summary>
            [EnumMember(Value = "Amazon Services, Inc.")]
            AmazonServicesInc = 1        }
        /// <summary>
        /// The party responsible for withholding the taxes and remitting them to the taxing authority.
        /// </summary>
        /// <value>The party responsible for withholding the taxes and remitting them to the taxing authority.</value>
        [DataMember(Name="ResponsibleParty", EmitDefaultValue=false)]
        public ResponsiblePartyEnum? ResponsibleParty { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxCollection" /> class.
        /// </summary>
        /// <param name="model">The tax collection model applied to the item..</param>
        /// <param name="responsibleParty">The party responsible for withholding the taxes and remitting them to the taxing authority..</param>
        public TaxCollection(ModelEnum? model = default(ModelEnum?), ResponsiblePartyEnum? responsibleParty = default(ResponsiblePartyEnum?))
        {
            this.Model = model;
            this.ResponsibleParty = responsibleParty;
        }
        


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TaxCollection {\n");
            sb.Append("  Model: ").Append(Model).Append("\n");
            sb.Append("  ResponsibleParty: ").Append(ResponsibleParty).Append("\n");
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
            return this.Equals(input as TaxCollection);
        }

        /// <summary>
        /// Returns true if TaxCollection instances are equal
        /// </summary>
        /// <param name="input">Instance of TaxCollection to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TaxCollection input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Model == input.Model ||
                    (this.Model != null &&
                    this.Model.Equals(input.Model))
                ) && 
                (
                    this.ResponsibleParty == input.ResponsibleParty ||
                    (this.ResponsibleParty != null &&
                    this.ResponsibleParty.Equals(input.ResponsibleParty))
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
                if (this.Model != null)
                    hashCode = hashCode * 59 + this.Model.GetHashCode();
                if (this.ResponsibleParty != null)
                    hashCode = hashCode * 59 + this.ResponsibleParty.GetHashCode();
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
