using System.ComponentModel.DataAnnotations;
namespace AmazonOrderAPI.Business.Model
{
    public class AddressVM
    {
        [AutoMapper.IgnoreMap()]
        public long Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Display(Name = "Address Line 3")]
        public string AddressLine3 { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string District { get; set; }

        [Display(Name = "State/Region")]
        public string StateOrRegion { get; set; }

        public string Municipality { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Display(Name = "Country Code")]
        public string CountryCode { get; set; }

        public string Phone { get; set; }

        [Display(Name = "Address Type")]
        public string AddressType { get; set; }
    }
}