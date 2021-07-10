using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AmazonOrderAPI.DataContext.Entities
{
    public class Entity
    {
        public Entity()
        {
            dateCreated = DateTime.Now;
        }

        [Key]
        [AutoMapper.IgnoreMap()]
        public long Id { set; get; }

        [AutoMapper.IgnoreMap()]
        private DateTime? dateCreated { set; get; }

        [AutoMapper.IgnoreMap()]
        public DateTime CreatedDate
        {
            get
            {
                return this.dateCreated.HasValue
                   ? this.dateCreated.Value
                   : DateTime.Now;
            }

            set { this.dateCreated = value; }
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
