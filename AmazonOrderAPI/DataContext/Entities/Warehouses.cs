using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmazonOrderAPI.DataContext.Entities
{
    [Table("Warehouses", Schema = "Master")]
    public class Warehouses:Entity
    {
       
        public string WarehouseName { get; set; }

        public string WarehouseLocationName { get; set; }

        public string WarehouseLocationCode { get; set; }

        public string WarehouseLocationAddress { get; set; }

        public string WarehouseDescription { get; set; }

        public bool IsActive { get; set; }

       



    }

}
