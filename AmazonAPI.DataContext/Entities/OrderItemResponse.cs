using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AmazonOrderAPI.DataContext.Entities
{
    [Table("OrderItemResponse", Schema = "amz")]
    public class OrderItemResponse : IEntity
    {
        [Key]
        public long Id { get; set; }
        public string Response { get; set; }
        public string AmazonOrderId { get; set; }
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
    }
}