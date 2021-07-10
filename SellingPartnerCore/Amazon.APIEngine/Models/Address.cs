
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
        public partial class Address :  IEquatable<Address>, IValidatableObject
    {
        /// <summary>
        /// The address type of the shipping address.
        /// </summary>
        /// <value>The address type of the shipping address.</value>
        [JsonConverter(typeof(StringEnumConverter))]
                public enum AddressTypeEnum
        {
            /// <summary>
            /// Enum Residential for value: Residential
            /// </summary>
            [EnumMember(Value = "Residential")]
            Residential = 1,
            /// <summary>
            /// Enum Commercial for value: Commercial
            /// </summary>
            [EnumMember(Value = "Commercial")]
            Commercial = 2        }
        /// <summary>
        /// The address type of the shipping address.
        /// </summary>
        /// <value>The address type of the shipping address.</value>
        [DataMember(Name="AddressType", EmitDefaultValue=false)]
        public AddressTypeEnum? AddressType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Address" /> class.
        /// </summary>
        /// <param name="name">The name. (required).</param>
        /// <param name="addressLine1">The street address..</param>
        /// <param name="addressLine2">Additional street address information, if required..</param>
        /// <param name="addressLine3">Additional street address information, if required..</param>
        /// <param name="city">The city .</param>
        /// <param name="county">The county..</param>
        /// <param name="district">The district..</param>
        /// <param name="stateOrRegion">The state or region..</param>
        /// <param name="municipality">The municipality..</param>
        /// <param name="postalCode">The postal code..</param>
        /// <param name="countryCode">The country code. A two-character country code, in ISO 3166-1 alpha-2 format..</param>
        /// <param name="phone">The phone number. Not returned for Fulfillment by Amazon (FBA) orders..</param>
        /// <param name="addressType">The address type of the shipping address..</param>
        public Address(string name = default(string), string addressLine1 = default(string), string addressLine2 = default(string), string addressLine3 = default(string), string city = default(string), string county = default(string), string district = default(string), string stateOrRegion = default(string), string municipality = default(string), string postalCode = default(string), string countryCode = default(string), string phone = default(string), AddressTypeEnum? addressType = default(AddressTypeEnum?))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for Address and cannot be null");
            }
            else
            {
                this.Name = name;
            }
            this.AddressLine1 = addressLine1;
            this.AddressLine2 = addressLine2;
            this.AddressLine3 = addressLine3;
            this.City = city;
            this.County = county;
            this.District = district;
            this.StateOrRegion = stateOrRegion;
            this.Municipality = municipality;
            this.PostalCode = postalCode;
            this.CountryCode = countryCode;
            this.Phone = phone;
            this.AddressType = addressType;
        }
        
        /// <summary>
        /// The name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name="Name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// The street address.
        /// </summary>
        /// <value>The street address.</value>
        [DataMember(Name="AddressLine1", EmitDefaultValue=false)]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Additional street address information, if required.
        /// </summary>
        /// <value>Additional street address information, if required.</value>
        [DataMember(Name="AddressLine2", EmitDefaultValue=false)]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Additional street address information, if required.
        /// </summary>
        /// <value>Additional street address information, if required.</value>
        [DataMember(Name="AddressLine3", EmitDefaultValue=false)]
        public string AddressLine3 { get; set; }

        /// <summary>
        /// The city 
        /// </summary>
        /// <value>The city </value>
        [DataMember(Name="City", EmitDefaultValue=false)]
        public string City { get; set; }

        /// <summary>
        /// The county.
        /// </summary>
        /// <value>The county.</value>
        [DataMember(Name="County", EmitDefaultValue=false)]
        public string County { get; set; }

        /// <summary>
        /// The district.
        /// </summary>
        /// <value>The district.</value>
        [DataMember(Name="District", EmitDefaultValue=false)]
        public string District { get; set; }

        /// <summary>
        /// The state or region.
        /// </summary>
        /// <value>The state or region.</value>
        [DataMember(Name="StateOrRegion", EmitDefaultValue=false)]
        public string StateOrRegion { get; set; }

        /// <summary>
        /// The municipality.
        /// </summary>
        /// <value>The municipality.</value>
        [DataMember(Name="Municipality", EmitDefaultValue=false)]
        public string Municipality { get; set; }

        /// <summary>
        /// The postal code.
        /// </summary>
        /// <value>The postal code.</value>
        [DataMember(Name="PostalCode", EmitDefaultValue=false)]
        public string PostalCode { get; set; }

        /// <summary>
        /// The country code. A two-character country code, in ISO 3166-1 alpha-2 format.
        /// </summary>
        /// <value>The country code. A two-character country code, in ISO 3166-1 alpha-2 format.</value>
        [DataMember(Name="CountryCode", EmitDefaultValue=false)]
        public string CountryCode { get; set; }

        /// <summary>
        /// The phone number. Not returned for Fulfillment by Amazon (FBA) orders.
        /// </summary>
        /// <value>The phone number. Not returned for Fulfillment by Amazon (FBA) orders.</value>
        [DataMember(Name="Phone", EmitDefaultValue=false)]
        public string Phone { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Address {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  AddressLine1: ").Append(AddressLine1).Append("\n");
            sb.Append("  AddressLine2: ").Append(AddressLine2).Append("\n");
            sb.Append("  AddressLine3: ").Append(AddressLine3).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  County: ").Append(County).Append("\n");
            sb.Append("  District: ").Append(District).Append("\n");
            sb.Append("  StateOrRegion: ").Append(StateOrRegion).Append("\n");
            sb.Append("  Municipality: ").Append(Municipality).Append("\n");
            sb.Append("  PostalCode: ").Append(PostalCode).Append("\n");
            sb.Append("  CountryCode: ").Append(CountryCode).Append("\n");
            sb.Append("  Phone: ").Append(Phone).Append("\n");
            sb.Append("  AddressType: ").Append(AddressType).Append("\n");
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
            return this.Equals(input as Address);
        }

        /// <summary>
        /// Returns true if Address instances are equal
        /// </summary>
        /// <param name="input">Instance of Address to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Address input)
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
                    this.AddressLine1 == input.AddressLine1 ||
                    (this.AddressLine1 != null &&
                    this.AddressLine1.Equals(input.AddressLine1))
                ) && 
                (
                    this.AddressLine2 == input.AddressLine2 ||
                    (this.AddressLine2 != null &&
                    this.AddressLine2.Equals(input.AddressLine2))
                ) && 
                (
                    this.AddressLine3 == input.AddressLine3 ||
                    (this.AddressLine3 != null &&
                    this.AddressLine3.Equals(input.AddressLine3))
                ) && 
                (
                    this.City == input.City ||
                    (this.City != null &&
                    this.City.Equals(input.City))
                ) && 
                (
                    this.County == input.County ||
                    (this.County != null &&
                    this.County.Equals(input.County))
                ) && 
                (
                    this.District == input.District ||
                    (this.District != null &&
                    this.District.Equals(input.District))
                ) && 
                (
                    this.StateOrRegion == input.StateOrRegion ||
                    (this.StateOrRegion != null &&
                    this.StateOrRegion.Equals(input.StateOrRegion))
                ) && 
                (
                    this.Municipality == input.Municipality ||
                    (this.Municipality != null &&
                    this.Municipality.Equals(input.Municipality))
                ) && 
                (
                    this.PostalCode == input.PostalCode ||
                    (this.PostalCode != null &&
                    this.PostalCode.Equals(input.PostalCode))
                ) && 
                (
                    this.CountryCode == input.CountryCode ||
                    (this.CountryCode != null &&
                    this.CountryCode.Equals(input.CountryCode))
                ) && 
                (
                    this.Phone == input.Phone ||
                    (this.Phone != null &&
                    this.Phone.Equals(input.Phone))
                ) && 
                (
                    this.AddressType == input.AddressType ||
                    (this.AddressType != null &&
                    this.AddressType.Equals(input.AddressType))
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
                if (this.AddressLine1 != null)
                    hashCode = hashCode * 59 + this.AddressLine1.GetHashCode();
                if (this.AddressLine2 != null)
                    hashCode = hashCode * 59 + this.AddressLine2.GetHashCode();
                if (this.AddressLine3 != null)
                    hashCode = hashCode * 59 + this.AddressLine3.GetHashCode();
                if (this.City != null)
                    hashCode = hashCode * 59 + this.City.GetHashCode();
                if (this.County != null)
                    hashCode = hashCode * 59 + this.County.GetHashCode();
                if (this.District != null)
                    hashCode = hashCode * 59 + this.District.GetHashCode();
                if (this.StateOrRegion != null)
                    hashCode = hashCode * 59 + this.StateOrRegion.GetHashCode();
                if (this.Municipality != null)
                    hashCode = hashCode * 59 + this.Municipality.GetHashCode();
                if (this.PostalCode != null)
                    hashCode = hashCode * 59 + this.PostalCode.GetHashCode();
                if (this.CountryCode != null)
                    hashCode = hashCode * 59 + this.CountryCode.GetHashCode();
                if (this.Phone != null)
                    hashCode = hashCode * 59 + this.Phone.GetHashCode();
                if (this.AddressType != null)
                    hashCode = hashCode * 59 + this.AddressType.GetHashCode();
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
