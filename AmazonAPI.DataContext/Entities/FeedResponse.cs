using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AmazonOrderAPI.DataContext.Entities
{

    [Obsolete]
    [Table("FeedResponse", Schema = "amz")]
    public class FeedResponse :IEntity
    {
        [Key]
        public long Id { get; set; }
        public string AmazonOrderId { get; set; }
        public string Response { get; set; }
        public int FeedTypeId { get; set; }
        public int FeedProcessingStatusId { get; set; }
        public string FeedSubmissionId { get; set; }
        public string OrderItemId { get; set; }
        public DateTime? CompletedProcessingDate { get; set; }
        
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
