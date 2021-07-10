using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using static Amazon.APIEngine.Models.Order;

namespace AmazonOrderAPI.DataContext.Entities
{
    [Table("Orders", Schema = "amz")]
    public class Order : IEquatable<Order>, IValidatableObject
    {
        public Order(List<string> __paymentMethodDetails)
        {
            _paymentMethodDetails = __paymentMethodDetails;
           
        }

        public Order()
        {
        }

        [Key]
        public long Id { get; set; }

        

        public long SellerId { set; get; }
        [ForeignKey("SellerId")]
        public virtual Seller Seller { set; get; }
        [DataMember(Name = "OrderStatus", EmitDefaultValue = false)]
        public OrderStatusEnum OrderStatus { get; set; }

        public long FulfillmentChannelId { set; get; }
        [ForeignKey("FulfillmentChannelId")]
        [DataMember(Name = "FulfillmentChannel", EmitDefaultValue = false)]
        public FulfillmentChannelEnum? FulfillmentChannel { get; set; }


        [DataMember(Name = "PaymentMethod", EmitDefaultValue = false)]
        public PaymentMethodEnum? PaymentMethod { get; set; }

        [DataMember(Name = "OrderType", EmitDefaultValue = false)]
        public OrderTypeEnum? OrderType { get; set; }


        [DataMember(Name = "AmazonOrderId", EmitDefaultValue = false)]
        public string AmazonOrderId { get; set; }

        [DataMember(Name = "SellerOrderId", EmitDefaultValue = false)]
        public string SellerOrderId { get; set; }

        [DataMember(Name = "PurchaseDate", EmitDefaultValue = false)]
        public string PurchaseDate { get; set; }

        [DataMember(Name = "LastUpdateDate", EmitDefaultValue = false)]
        public string LastUpdateDate { get; set; }



        [DataMember(Name = "SalesChannel", EmitDefaultValue = false)]
        public string SalesChannel { get; set; }

        [DataMember(Name = "OrderChannel", EmitDefaultValue = false)]
        public string OrderChannel { get; set; }

        [DataMember(Name = "ShipServiceLevel", EmitDefaultValue = false)]
        public string ShipServiceLevel { get; set; }

        public long OrderTotalId { set; get; }
        [ForeignKey("OrderTotalId")]
        [DataMember(Name = "OrderTotal", EmitDefaultValue = false)]
        public virtual Money OrderTotal { get; set; }

        [DataMember(Name = "NumberOfItemsShipped", EmitDefaultValue = false)]
        public int? NumberOfItemsShipped { get; set; }

        [DataMember(Name = "NumberOfItemsUnshipped", EmitDefaultValue = false)]
        public int? NumberOfItemsUnshipped { get; set; }
       

        private List<string> _paymentMethodDetails;
        public string PaymentMethodDetails
        {
            get { return String.Join(',', _paymentMethodDetails); }
            set { _paymentMethodDetails = value.Split(',').ToList(); }
        }
        public long PaymentExecutionDetailId { set; get; }
        [ForeignKey("PaymentExecutionDetailId")]
        [DataMember(Name = "PaymentExecutionDetail", EmitDefaultValue = false)]
        public virtual List<PaymentExecutionDetailItem> PaymentExecutionDetail { get; set; }

        //public long PaymentMethodDetailsId { set; get; }
        //[ForeignKey("PaymentMethodDetailsId")]
        //[DataMember(Name = "PaymentMethodDetails", EmitDefaultValue = false)]
        //public virtual List<string> PaymentMethodDetails { get; set; }

        [DataMember(Name = "MarketplaceId", EmitDefaultValue = false)]
        public string MarketplaceId { get; set; }

        [DataMember(Name = "ShipmentServiceLevelCategory", EmitDefaultValue = false)]
        public string ShipmentServiceLevelCategory { get; set; }

        [DataMember(Name = "EasyShipShipmentStatus", EmitDefaultValue = false)]
        public string EasyShipShipmentStatus { get; set; }

        [DataMember(Name = "CbaDisplayableShippingLabel", EmitDefaultValue = false)]
        public string CbaDisplayableShippingLabel { get; set; }


        [DataMember(Name = "EarliestShipDate", EmitDefaultValue = false)]
        public string EarliestShipDate { get; set; }

        [DataMember(Name = "LatestShipDate", EmitDefaultValue = false)]
        public string LatestShipDate { get; set; }

        [DataMember(Name = "EarliestDeliveryDate", EmitDefaultValue = false)]
        public string EarliestDeliveryDate { get; set; }

        [DataMember(Name = "LatestDeliveryDate", EmitDefaultValue = false)]
        public string LatestDeliveryDate { get; set; }

        [DataMember(Name = "IsBusinessOrder", EmitDefaultValue = false)]
        public bool? IsBusinessOrder { get; set; }

        [DataMember(Name = "IsPrime", EmitDefaultValue = false)]
        public bool? IsPrime { get; set; }

        [DataMember(Name = "IsPremiumOrder", EmitDefaultValue = false)]
        public bool? IsPremiumOrder { get; set; }


        [DataMember(Name = "IsGlobalExpressEnabled", EmitDefaultValue = false)]
        public bool? IsGlobalExpressEnabled { get; set; }


        [DataMember(Name = "ReplacedOrderId", EmitDefaultValue = false)]
        public string ReplacedOrderId { get; set; }


        [DataMember(Name = "IsReplacementOrder", EmitDefaultValue = false)]
        public bool? IsReplacementOrder { get; set; }

        [DataMember(Name = "PromiseResponseDueDate", EmitDefaultValue = false)]
        public string PromiseResponseDueDate { get; set; }


        [DataMember(Name = "IsEstimatedShipDateSet", EmitDefaultValue = false)]
        public bool? IsEstimatedShipDateSet { get; set; }

        [DataMember(Name = "IsSoldByAB", EmitDefaultValue = false)]
        public bool? IsSoldByAB { get; set; }


        public long DefaultShipFromLocationAddressId { set; get; }
        [ForeignKey("DefaultShipFromLocationAddressId")]
        [DataMember(Name = "DefaultShipFromLocationAddress", EmitDefaultValue = false)]
        public virtual Address DefaultShipFromLocationAddress { get; set; }


        public long FulfillmentInstructionId { set; get; }
        [ForeignKey("FulfillmentInstructionId")]
        [DataMember(Name = "FulfillmentInstruction", EmitDefaultValue = false)]
        public virtual FulfillmentInstruction FulfillmentInstruction { get; set; }


        public bool? IsISPU { get; set; }

        private int? _shippingAddressStatusId { set; get; }
        private long? _listOrderItemStatusId { set; get; }

        public int? ShippingAddressStatusId
        {
            get { return _shippingAddressStatusId; }
            set { _shippingAddressStatusId = value; }
        }

        public long? ListOrderItemStatusId
        {
            get { return _listOrderItemStatusId; }
            set { _listOrderItemStatusId = value; }
        }
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
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Order {\n");
            sb.Append("  AmazonOrderId: ").Append(AmazonOrderId).Append("\n");
            sb.Append("  SellerOrderId: ").Append(SellerOrderId).Append("\n");
            sb.Append("  PurchaseDate: ").Append(PurchaseDate).Append("\n");
            sb.Append("  LastUpdateDate: ").Append(LastUpdateDate).Append("\n");
            sb.Append("  OrderStatus: ").Append(OrderStatus).Append("\n");
            sb.Append("  FulfillmentChannel: ").Append(FulfillmentChannel).Append("\n");
            sb.Append("  SalesChannel: ").Append(SalesChannel).Append("\n");
            sb.Append("  OrderChannel: ").Append(OrderChannel).Append("\n");
            sb.Append("  ShipServiceLevel: ").Append(ShipServiceLevel).Append("\n");
            sb.Append("  OrderTotal: ").Append(OrderTotal).Append("\n");
            sb.Append("  NumberOfItemsShipped: ").Append(NumberOfItemsShipped).Append("\n");
            sb.Append("  NumberOfItemsUnshipped: ").Append(NumberOfItemsUnshipped).Append("\n");
            //   sb.Append("  PaymentExecutionDetail: ").Append(PaymentExecutionDetail).Append("\n");
            sb.Append("  PaymentMethod: ").Append(PaymentMethod).Append("\n");
            // sb.Append("  PaymentMethodDetails: ").Append(PaymentMethodDetails).Append("\n");
            sb.Append("  MarketplaceId: ").Append(MarketplaceId).Append("\n");
            sb.Append("  ShipmentServiceLevelCategory: ").Append(ShipmentServiceLevelCategory).Append("\n");
            sb.Append("  EasyShipShipmentStatus: ").Append(EasyShipShipmentStatus).Append("\n");
            sb.Append("  CbaDisplayableShippingLabel: ").Append(CbaDisplayableShippingLabel).Append("\n");
            sb.Append("  OrderType: ").Append(OrderType).Append("\n");
            sb.Append("  EarliestShipDate: ").Append(EarliestShipDate).Append("\n");
            sb.Append("  LatestShipDate: ").Append(LatestShipDate).Append("\n");
            sb.Append("  EarliestDeliveryDate: ").Append(EarliestDeliveryDate).Append("\n");
            sb.Append("  LatestDeliveryDate: ").Append(LatestDeliveryDate).Append("\n");
            sb.Append("  IsBusinessOrder: ").Append(IsBusinessOrder).Append("\n");
            sb.Append("  IsPrime: ").Append(IsPrime).Append("\n");
            sb.Append("  IsPremiumOrder: ").Append(IsPremiumOrder).Append("\n");
            sb.Append("  IsGlobalExpressEnabled: ").Append(IsGlobalExpressEnabled).Append("\n");
            sb.Append("  ReplacedOrderId: ").Append(ReplacedOrderId).Append("\n");
            sb.Append("  IsReplacementOrder: ").Append(IsReplacementOrder).Append("\n");
            sb.Append("  PromiseResponseDueDate: ").Append(PromiseResponseDueDate).Append("\n");
            sb.Append("  IsEstimatedShipDateSet: ").Append(IsEstimatedShipDateSet).Append("\n");
            sb.Append("  IsSoldByAB: ").Append(IsSoldByAB).Append("\n");
            sb.Append("  DefaultShipFromLocationAddress: ").Append(DefaultShipFromLocationAddress).Append("\n");
            sb.Append("  FulfillmentInstruction: ").Append(FulfillmentInstruction).Append("\n");
            sb.Append("  IsISPU: ").Append(IsISPU).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Order);
        }

        /// <summary>
        /// Returns true if Order instances are equal
        /// </summary>
        /// <param name="input">Instance of Order to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Order input)
        {
            if (input == null)
                return false;

            return
                (
                    this.AmazonOrderId == input.AmazonOrderId ||
                    (this.AmazonOrderId != null &&
                    this.AmazonOrderId.Equals(input.AmazonOrderId))
                ) &&
                (
                    this.SellerOrderId == input.SellerOrderId ||
                    (this.SellerOrderId != null &&
                    this.SellerOrderId.Equals(input.SellerOrderId))
                ) &&
                (
                    this.PurchaseDate == input.PurchaseDate ||
                    (this.PurchaseDate != null &&
                    this.PurchaseDate.Equals(input.PurchaseDate))
                ) &&
                (
                    this.LastUpdateDate == input.LastUpdateDate ||
                    (this.LastUpdateDate != null &&
                    this.LastUpdateDate.Equals(input.LastUpdateDate))
                ) &&
                (
                    this.OrderStatus == input.OrderStatus ||
                    (this.OrderStatus != null &&
                    this.OrderStatus.Equals(input.OrderStatus))
                ) &&
                (
                    this.FulfillmentChannel == input.FulfillmentChannel ||
                    (this.FulfillmentChannel != null &&
                    this.FulfillmentChannel.Equals(input.FulfillmentChannel))
                ) &&
                (
                    this.SalesChannel == input.SalesChannel ||
                    (this.SalesChannel != null &&
                    this.SalesChannel.Equals(input.SalesChannel))
                ) &&
                (
                    this.OrderChannel == input.OrderChannel ||
                    (this.OrderChannel != null &&
                    this.OrderChannel.Equals(input.OrderChannel))
                ) &&
                (
                    this.ShipServiceLevel == input.ShipServiceLevel ||
                    (this.ShipServiceLevel != null &&
                    this.ShipServiceLevel.Equals(input.ShipServiceLevel))
                ) &&
                (
                    this.OrderTotal == input.OrderTotal ||
                    (this.OrderTotal != null &&
                    this.OrderTotal.Equals(input.OrderTotal))
                ) &&
                (
                    this.NumberOfItemsShipped == input.NumberOfItemsShipped ||
                    (this.NumberOfItemsShipped != null &&
                    this.NumberOfItemsShipped.Equals(input.NumberOfItemsShipped))
                ) &&
                (
                    this.NumberOfItemsUnshipped == input.NumberOfItemsUnshipped ||
                    (this.NumberOfItemsUnshipped != null &&
                    this.NumberOfItemsUnshipped.Equals(input.NumberOfItemsUnshipped))
                ) &&
                //(
                //    //this.PaymentExecutionDetail == input.PaymentExecutionDetail ||
                //    //(this.PaymentExecutionDetail != null &&
                //    //this.PaymentExecutionDetail.Equals(input.PaymentExecutionDetail))
                //) &&
                (
                    this.PaymentMethod == input.PaymentMethod ||
                    (this.PaymentMethod != null &&
                    this.PaymentMethod.Equals(input.PaymentMethod))
                ) &&
                //(
                //    //this.PaymentMethodDetails == input.PaymentMethodDetails ||
                //    //(this.PaymentMethodDetails != null &&
                //    //this.PaymentMethodDetails.Equals(input.PaymentMethodDetails))
                //) &&
                (
                    this.MarketplaceId == input.MarketplaceId ||
                    (this.MarketplaceId != null &&
                    this.MarketplaceId.Equals(input.MarketplaceId))
                ) &&
                (
                    this.ShipmentServiceLevelCategory == input.ShipmentServiceLevelCategory ||
                    (this.ShipmentServiceLevelCategory != null &&
                    this.ShipmentServiceLevelCategory.Equals(input.ShipmentServiceLevelCategory))
                ) &&
                (
                    this.EasyShipShipmentStatus == input.EasyShipShipmentStatus ||
                    (this.EasyShipShipmentStatus != null &&
                    this.EasyShipShipmentStatus.Equals(input.EasyShipShipmentStatus))
                ) &&
                (
                    this.CbaDisplayableShippingLabel == input.CbaDisplayableShippingLabel ||
                    (this.CbaDisplayableShippingLabel != null &&
                    this.CbaDisplayableShippingLabel.Equals(input.CbaDisplayableShippingLabel))
                ) &&
                (
                    this.OrderType == input.OrderType ||
                    (this.OrderType != null &&
                    this.OrderType.Equals(input.OrderType))
                ) &&
                (
                    this.EarliestShipDate == input.EarliestShipDate ||
                    (this.EarliestShipDate != null &&
                    this.EarliestShipDate.Equals(input.EarliestShipDate))
                ) &&
                (
                    this.LatestShipDate == input.LatestShipDate ||
                    (this.LatestShipDate != null &&
                    this.LatestShipDate.Equals(input.LatestShipDate))
                ) &&
                (
                    this.EarliestDeliveryDate == input.EarliestDeliveryDate ||
                    (this.EarliestDeliveryDate != null &&
                    this.EarliestDeliveryDate.Equals(input.EarliestDeliveryDate))
                ) &&
                (
                    this.LatestDeliveryDate == input.LatestDeliveryDate ||
                    (this.LatestDeliveryDate != null &&
                    this.LatestDeliveryDate.Equals(input.LatestDeliveryDate))
                ) &&
                (
                    this.IsBusinessOrder == input.IsBusinessOrder ||
                    (this.IsBusinessOrder != null &&
                    this.IsBusinessOrder.Equals(input.IsBusinessOrder))
                ) &&
                (
                    this.IsPrime == input.IsPrime ||
                    (this.IsPrime != null &&
                    this.IsPrime.Equals(input.IsPrime))
                ) &&
                (
                    this.IsPremiumOrder == input.IsPremiumOrder ||
                    (this.IsPremiumOrder != null &&
                    this.IsPremiumOrder.Equals(input.IsPremiumOrder))
                ) &&
                (
                    this.IsGlobalExpressEnabled == input.IsGlobalExpressEnabled ||
                    (this.IsGlobalExpressEnabled != null &&
                    this.IsGlobalExpressEnabled.Equals(input.IsGlobalExpressEnabled))
                ) &&
                (
                    this.ReplacedOrderId == input.ReplacedOrderId ||
                    (this.ReplacedOrderId != null &&
                    this.ReplacedOrderId.Equals(input.ReplacedOrderId))
                ) &&
                (
                    this.IsReplacementOrder == input.IsReplacementOrder ||
                    (this.IsReplacementOrder != null &&
                    this.IsReplacementOrder.Equals(input.IsReplacementOrder))
                ) &&
                (
                    this.PromiseResponseDueDate == input.PromiseResponseDueDate ||
                    (this.PromiseResponseDueDate != null &&
                    this.PromiseResponseDueDate.Equals(input.PromiseResponseDueDate))
                ) &&
                (
                    this.IsEstimatedShipDateSet == input.IsEstimatedShipDateSet ||
                    (this.IsEstimatedShipDateSet != null &&
                    this.IsEstimatedShipDateSet.Equals(input.IsEstimatedShipDateSet))
                ) &&
                (
                    this.IsSoldByAB == input.IsSoldByAB ||
                    (this.IsSoldByAB != null &&
                    this.IsSoldByAB.Equals(input.IsSoldByAB))
                ) &&
                (
                    this.DefaultShipFromLocationAddress == input.DefaultShipFromLocationAddress ||
                    (this.DefaultShipFromLocationAddress != null &&
                    this.DefaultShipFromLocationAddress.Equals(input.DefaultShipFromLocationAddress))
                ) &&
                (
                    this.FulfillmentInstruction == input.FulfillmentInstruction ||
                    (this.FulfillmentInstruction != null &&
                    this.FulfillmentInstruction.Equals(input.FulfillmentInstruction))
                ) &&
                (
                    this.IsISPU == input.IsISPU ||
                    (this.IsISPU != null &&
                    this.IsISPU.Equals(input.IsISPU))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.AmazonOrderId != null)
                    hashCode = hashCode * 59 + this.AmazonOrderId.GetHashCode();
                if (this.SellerOrderId != null)
                    hashCode = hashCode * 59 + this.SellerOrderId.GetHashCode();
                if (this.PurchaseDate != null)
                    hashCode = hashCode * 59 + this.PurchaseDate.GetHashCode();
                if (this.LastUpdateDate != null)
                    hashCode = hashCode * 59 + this.LastUpdateDate.GetHashCode();
                if (this.OrderStatus != null)
                    hashCode = hashCode * 59 + this.OrderStatus.GetHashCode();
                if (this.FulfillmentChannel != null)
                    hashCode = hashCode * 59 + this.FulfillmentChannel.GetHashCode();
                if (this.SalesChannel != null)
                    hashCode = hashCode * 59 + this.SalesChannel.GetHashCode();
                if (this.OrderChannel != null)
                    hashCode = hashCode * 59 + this.OrderChannel.GetHashCode();
                if (this.ShipServiceLevel != null)
                    hashCode = hashCode * 59 + this.ShipServiceLevel.GetHashCode();
                if (this.OrderTotal != null)
                    hashCode = hashCode * 59 + this.OrderTotal.GetHashCode();
                if (this.NumberOfItemsShipped != null)
                    hashCode = hashCode * 59 + this.NumberOfItemsShipped.GetHashCode();
                if (this.NumberOfItemsUnshipped != null)
                    hashCode = hashCode * 59 + this.NumberOfItemsUnshipped.GetHashCode();
                //if (this.PaymentExecutionDetail != null)
                //    hashCode = hashCode * 59 + this.PaymentExecutionDetail.GetHashCode();
                //if (this.PaymentMethod != null)
                //    hashCode = hashCode * 59 + this.PaymentMethod.GetHashCode();
                //if (this.PaymentMethodDetails != null)
                //    hashCode = hashCode * 59 + this.PaymentMethodDetails.GetHashCode();
                if (this.MarketplaceId != null)
                    hashCode = hashCode * 59 + this.MarketplaceId.GetHashCode();
                if (this.ShipmentServiceLevelCategory != null)
                    hashCode = hashCode * 59 + this.ShipmentServiceLevelCategory.GetHashCode();
                if (this.EasyShipShipmentStatus != null)
                    hashCode = hashCode * 59 + this.EasyShipShipmentStatus.GetHashCode();
                if (this.CbaDisplayableShippingLabel != null)
                    hashCode = hashCode * 59 + this.CbaDisplayableShippingLabel.GetHashCode();
                if (this.OrderType != null)
                    hashCode = hashCode * 59 + this.OrderType.GetHashCode();
                if (this.EarliestShipDate != null)
                    hashCode = hashCode * 59 + this.EarliestShipDate.GetHashCode();
                if (this.LatestShipDate != null)
                    hashCode = hashCode * 59 + this.LatestShipDate.GetHashCode();
                if (this.EarliestDeliveryDate != null)
                    hashCode = hashCode * 59 + this.EarliestDeliveryDate.GetHashCode();
                if (this.LatestDeliveryDate != null)
                    hashCode = hashCode * 59 + this.LatestDeliveryDate.GetHashCode();
                if (this.IsBusinessOrder != null)
                    hashCode = hashCode * 59 + this.IsBusinessOrder.GetHashCode();
                if (this.IsPrime != null)
                    hashCode = hashCode * 59 + this.IsPrime.GetHashCode();
                if (this.IsPremiumOrder != null)
                    hashCode = hashCode * 59 + this.IsPremiumOrder.GetHashCode();
                if (this.IsGlobalExpressEnabled != null)
                    hashCode = hashCode * 59 + this.IsGlobalExpressEnabled.GetHashCode();
                if (this.ReplacedOrderId != null)
                    hashCode = hashCode * 59 + this.ReplacedOrderId.GetHashCode();
                if (this.IsReplacementOrder != null)
                    hashCode = hashCode * 59 + this.IsReplacementOrder.GetHashCode();
                if (this.PromiseResponseDueDate != null)
                    hashCode = hashCode * 59 + this.PromiseResponseDueDate.GetHashCode();
                if (this.IsEstimatedShipDateSet != null)
                    hashCode = hashCode * 59 + this.IsEstimatedShipDateSet.GetHashCode();
                if (this.IsSoldByAB != null)
                    hashCode = hashCode * 59 + this.IsSoldByAB.GetHashCode();
                if (this.DefaultShipFromLocationAddress != null)
                    hashCode = hashCode * 59 + this.DefaultShipFromLocationAddress.GetHashCode();
                if (this.FulfillmentInstruction != null)
                    hashCode = hashCode * 59 + this.FulfillmentInstruction.GetHashCode();
                if (this.IsISPU != null)
                    hashCode = hashCode * 59 + this.IsISPU.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }

    }
}
