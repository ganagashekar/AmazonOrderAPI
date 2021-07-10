﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace AmazonOrderAPI.DataContext.Entities
{
    [Table("PointsGranted", Schema = "amz")]
    public  class PointsGrantedDetail : IEquatable<PointsGrantedDetail>, IValidatableObject,IEntity
    {
        [Key]
        public long Id { get; set; }
        public string AmazonOrderId { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="PointsGrantedDetail" /> class.
        /// </summary>
        /// <param name="pointsNumber">The number of Amazon Points granted with the purchase of an item..</param>
        /// <param name="pointsMonetaryValue">pointsMonetaryValue.</param>
        public PointsGrantedDetail(int? pointsNumber = default(int?), Money pointsMonetaryValue = default(Money))
        {
            this.PointsNumber = pointsNumber;
            this.PointsMonetaryValue = pointsMonetaryValue;
        }

        public PointsGrantedDetail()
        {
        }

        /// <summary>
        /// The number of Amazon Points granted with the purchase of an item.
        /// </summary>
        /// <value>The number of Amazon Points granted with the purchase of an item.</value>
        [DataMember(Name = "PointsNumber", EmitDefaultValue = false)]
        public int? PointsNumber { get; set; }


        [IgnoreDataMember]
        private DateTime? dateCreated { set; get; }
        public DateTime? CreatedDate
        {
            get
            {
                return dateCreated.HasValue
                   ? dateCreated.Value
                   : DateTime.Now;
            }

            set { dateCreated = value; }
        }

        public long PointsMonetaryValueId { set; get; }
        [ForeignKey("PointsMonetaryValueId")]
        /// <summary>
        /// Gets or Sets PointsMonetaryValue
        /// </summary>
        [DataMember(Name = "PointsMonetaryValue", EmitDefaultValue = false)]
        public virtual Money PointsMonetaryValue { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PointsGrantedDetail {\n");
            sb.Append("  PointsNumber: ").Append(PointsNumber).Append("\n");
            sb.Append("  PointsMonetaryValue: ").Append(PointsMonetaryValue).Append("\n");
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
            return this.Equals(input as PointsGrantedDetail);
        }

        /// <summary>
        /// Returns true if PointsGrantedDetail instances are equal
        /// </summary>
        /// <param name="input">Instance of PointsGrantedDetail to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PointsGrantedDetail input)
        {
            if (input == null)
                return false;

            return
                (
                    this.PointsNumber == input.PointsNumber ||
                    (this.PointsNumber != null &&
                    this.PointsNumber.Equals(input.PointsNumber))
                ) &&
                (
                    this.PointsMonetaryValue == input.PointsMonetaryValue ||
                    (this.PointsMonetaryValue != null &&
                    this.PointsMonetaryValue.Equals(input.PointsMonetaryValue))
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
                if (this.PointsNumber != null)
                    hashCode = hashCode * 59 + this.PointsNumber.GetHashCode();
                if (this.PointsMonetaryValue != null)
                    hashCode = hashCode * 59 + this.PointsMonetaryValue.GetHashCode();
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
