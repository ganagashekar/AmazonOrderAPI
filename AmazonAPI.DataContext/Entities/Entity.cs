using System;
using System.ComponentModel.DataAnnotations;

namespace AmazonOrderAPI.DataContext.Entities
{

    public interface IEntity
    {
        long Id { set; get; }
        DateTime? CreatedDate { set; get; }
         string AmazonOrderId { get; set; }

    }
    [Obsolete]
    public class Entity 
    {
        public Entity()
        {
            dateCreated = DateTime.Now;
        }

       // [Key]
       // [AutoMapper.IgnoreMap()]
        public long Id { set; get; }
        public string AmazonOrderId { get; set; }
        [AutoMapper.IgnoreMap()]
        private DateTime? dateCreated { set; get; }

        [AutoMapper.IgnoreMap()]
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

        //public string Get8Digits()
        //{
        //    var bytes = new byte[4];
        //    var rng = RandomNumberGenerator.Create();
        //    rng.GetBytes(bytes);
        //    uint random = BitConverter.ToUInt32(bytes, 0) % 100000000;
        //    return String.Format("{0:D8}", random);
        //}
    }
}