using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AmazonOrderAPI.DataContext.Entities
{
    [Table("ReferenceRecords", Schema = "amz")]
    public class ReferenceRecord 
    {
        [Key]
        public long Id { set; get; }
        public string Name { set; get; }
        public bool IsActive { set; get; }
        public long ReferenceRecordTypeId { set; get; }
        public string Displaytext { set; get; }
        public virtual ReferenceRecordType ReferenceRecordTypes { set; get; }

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