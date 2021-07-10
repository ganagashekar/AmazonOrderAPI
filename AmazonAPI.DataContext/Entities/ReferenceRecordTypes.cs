using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AmazonOrderAPI.DataContext.Entities
{
    [Table("ReferenceRecordTypes", Schema = "amz")]
    public class ReferenceRecordType 
    {
        [Key]
        public long Id { set; get; }
        public string Name { set; get; }
        public bool IsActive { set; get; }

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