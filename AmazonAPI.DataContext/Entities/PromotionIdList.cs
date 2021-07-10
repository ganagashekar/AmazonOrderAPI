using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace AmazonOrderAPI.DataContext.Entities
{
   
    [Table("PromotionIds", Schema = "amz")]
    public  class PromotionIdList : List<string>, IEquatable<PromotionIdList>, IValidatableObject,IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PromotionIdList" /> class.
        /// </summary>
        public PromotionIdList() : base()
        {
        }
        [Key]
        public long Id { get; set; }

       
        [DataMember(Name = "OrderItemId", EmitDefaultValue = false)]
        public string OrderItemId { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        ///  [IgnoreDataMember]
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
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PromotionIdList {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
        public string AmazonOrderId { get; set; }
        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as PromotionIdList);
        }

        /// <summary>
        /// Returns true if PromotionIdList instances are equal
        /// </summary>
        /// <param name="input">Instance of PromotionIdList to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PromotionIdList input)
        {
            if (input == null)
                return false;

            return base.Equals(input);
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = base.GetHashCode();
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
