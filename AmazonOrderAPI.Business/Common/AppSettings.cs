namespace AmazonOrderAPI.Business.Common
{
    public class ProxySetting
    {
        public bool IsProxyEnabled { get; set; }
        public string ProxyHost { get; set; }
        public int ProxyPortNumber { get; set; }
    }

    public class PickupRequestConstants
    {
        public int HostId { get; set; }
        public string Length { get; set; }
        public string Breadth { get; set; }
        public string Height { get; set; }
        public string ConsType { get; set; }
        public string CarrierId { get; set; }
        public string ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ezShipServiceId { get; set; }
        public string InvoiceValue { get; set; }
        public string PaymentType { get; set; }
        public string IsAmountPaid { get; set; }
        public string Status { get; set; }
        public string SalesChannel { get; set; }
        public string IsConfirm { get; set; }
        public string PickUpRequestNo { get; set; }
        public string PickUpRequestFrom { get; set; }
        public string CompanyId { set; get; }
        public bool IsSave { get; set; }
    }

    public class AppSetting
    {
        public ProxySetting ProxySetting { get; set; }
        public PickupRequestConstants PickupRequestConstants { get; set; }
        public GlobalConstants GlobalConstants { set; get; }
        public AppConstants AppConstants { set; get; }
        public NewSellerDefaults NewSellerDefaults { set; get; }
        public ServiceURL ServiceURL { get; set; }
        public string SellerId { set; get; }
        public string ClientId { set; get; }
        public Default Default { set; get; }

    }

    public class GlobalConstants
    {
        public string InitialDate { set; get; }
        public int RetryDaysBefore { set; get; }
        public int ArchiveDaysbefore { set; get; }
        public int SellerOrderStartDateBefore { set; get; }
        public int AcknowledgeOrdersBefore { set; get; }
        public int FulfillOrdersBefore { set; get; }
    }

    public class NewSellerDefaults
    {
        public string MarketplaceURL { set; get; }
        public string Country { set; get; }
        public string MarketplaceId { set; get; }
    }

    public class AppConstants
    {
        public string AccessKey { set; get; }
        public string ClientId { set; get; }
        public string SecretKey { set; get; }
        public string CourierCompanyName { set; get; }
    }

    public class ServiceURL
    {
        public string eZtrackerURL { set; get; }
        public string ServiceVersion { set; get; }
        public string ServiceAction { set; get; }
    }

    public class Default
    {
        public string WarehouseLocationCode { get; set; }

    }
}