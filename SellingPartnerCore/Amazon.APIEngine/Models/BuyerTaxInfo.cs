
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
    /// Tax information about the buyer.
    /// </summary>
    [DataContract]
        public partial class BuyerTaxInfo :  IEquatable<BuyerTaxInfo>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuyerTaxInfo" /> class.
        /// </summary>
        /// <param name="companyLegalName">The legal name of the company..</param>
        /// <param name="taxingRegion">The country or region imposing the tax..</param>
        /// <param name="taxClassifications">A list of tax classifications that apply to the order..</param>
        public BuyerTaxInfo(string companyLegalName = default(string), string taxingRegion = default(string), List<TaxClassification> taxClassifications = default(List<TaxClassification>))
        {
            this.CompanyLegalName = companyLegalName;
            this.TaxingRegion = taxingRegion;
            this.TaxClassifications = taxClassifications;
        }
        
        /// <summary>
        /// The legal name of the company.
        /// </summary>
        /// <value>The legal name of the company.</value>
        [DataMember(Name="CompanyLegalName", EmitDefaultValue=false)]
        public string CompanyLegalName { get; set; }

        /// <summary>
        /// The country or region imposing the tax.
        /// </summary>
        /// <value>The country or region imposing the tax.</value>
        [DataMember(Name="TaxingRegion", EmitDefaultValue=false)]
        public string TaxingRegion { get; set; }

        /// <summary>
        /// A list of tax classifications that apply to the order.
        /// </summary>
        /// <value>A list of tax classifications that apply to the order.</value>
        [DataMember(Name="TaxClassifications", EmitDefaultValue=false)]
        public List<TaxClassification> TaxClassifications { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BuyerTaxInfo {\n");
            sb.Append("  CompanyLegalName: ").Append(CompanyLegalName).Append("\n");
            sb.Append("  TaxingRegion: ").Append(TaxingRegion).Append("\n");
            sb.Append("  TaxClassifications: ").Append(TaxClassifications).Append("\n");
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
            return this.Equals(input as BuyerTaxInfo);
        }

        /// <summary>
        /// Returns true if BuyerTaxInfo instances are equal
        /// </summary>
        /// <param name="input">Instance of BuyerTaxInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BuyerTaxInfo input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.CompanyLegalName == input.CompanyLegalName ||
                    (this.CompanyLegalName != null &&
                    this.CompanyLegalName.Equals(input.CompanyLegalName))
                ) && 
                (
                    this.TaxingRegion == input.TaxingRegion ||
                    (this.TaxingRegion != null &&
                    this.TaxingRegion.Equals(input.TaxingRegion))
                ) && 
                (
                    this.TaxClassifications == input.TaxClassifications ||
                    this.TaxClassifications != null &&
                    input.TaxClassifications != null &&
                    this.TaxClassifications.SequenceEqual(input.TaxClassifications)
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
                if (this.CompanyLegalName != null)
                    hashCode = hashCode * 59 + this.CompanyLegalName.GetHashCode();
                if (this.TaxingRegion != null)
                    hashCode = hashCode * 59 + this.TaxingRegion.GetHashCode();
                if (this.TaxClassifications != null)
                    hashCode = hashCode * 59 + this.TaxClassifications.GetHashCode();
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
