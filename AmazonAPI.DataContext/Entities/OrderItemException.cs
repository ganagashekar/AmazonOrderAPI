using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AmazonOrderAPI.DataContext.Entities
{
    [Table("OrderItemException", Schema = "amz")]
    public class OrderItemException : IEntity
    {
        [Key]
        public long Id { get; set; }
        public string OrderItemId { get; set; }
        public string AmazonOrderId { get; set; }
        public string Response { get; set; }

        public string Exception { get; set; }

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