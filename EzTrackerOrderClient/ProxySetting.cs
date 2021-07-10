namespace eZTrackerOrderClient
{
    public class Ez_ProxySetting
    {
        public bool IsProxyEnabled { get; set; }
        public string ProxyHost { get; set; }
        public int ProxyPortNumber { get; set; }
    }

    public class Ez_GlobalConstants
    {
        public string InitialDate { set; get; }
        public int RetryDaysBefore { set; get; }
        public int ArchiveDaysbefore { set; get; }
        public int SellerOrderStartDateBefore { set; get; }
        public int AcknowledgeOrdersBefore { set; get; }
        public int FulfillOrdersBefore { set; get; }
    }
    public class Ez_ServiceURL
    {
        public string eZtrackerURL { set; get; }
        public string ServiceVersion { set; get; }
        public string ServiceAction { set; get; }

    }
    public class Ez_PickupRequestConstants
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
        public string CompanyId { get; set; }
        public bool IsSave { get; set; }
    }

    public class Ez_AppSetting
    {
        public Ez_ProxySetting ProxySetting { get; set; }
        public Ez_PickupRequestConstants PickupRequestConstants { get; set; }
        public Ez_GlobalConstants GlobalConstants { set; get; }
        public Ez_ServiceURL ServiceURL { get; set; }
        public Ez_AppConstants AppConstants { set; get; }
        public Ez_NewSellerDefaults NewSellerDefaults { set; get; }
        public Ez_Default Ez_Default { set; get; }
    }

    public class Ez_NewSellerDefaults
    {
        public string MarketplaceURL { set; get; }
        public string Country { set; get; }
        public string MarketplaceId { set; get; }
    }

    public class Ez_AppConstants
    {
        public string AccessKey { set; get; }
        public string ClientId { set; get; }
        public string SecretKey { set; get; }
        public string CourierCompanyName { set; get; }
    }

    public class Ez_Default
    {
        public string WarehouseLocationCode { get; set; }

    }
}