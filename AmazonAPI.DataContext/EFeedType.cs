using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonAPI
{
    public enum EFeedType
    {
        Product = 1,
        Inventory = 2,
        Overrides = 3,
        Pricing = 4,
        ProductImages = 5,
        Relationships = 6,
        FlatInventory = 7,
        FlatListing = 8,
        FlatBook = 9,
        FlatMusic = 10,
        FlatVideo = 11,
        FlatPriceAndQuantity = 12,
        UIEEInventory = 13,
        ACESData = 14,
        OrderAcknowledgement = 15,
        OrderAdjustments = 16,
        OrderFulfillment = 17,
        FlatOrderAcknowledgement = 18,
        FlatOrderAdjustments = 19,
        FlatOrderFulfillment = 20,
        FBAFulfillmentOrder = 21,
        FBAFulfillmentCancellation = 22,
        FBAInboundShipmentCartonInformation = 23,
        FBAFlatFulfillmentOrder = 24,
        FBAFlatOrderCancellation = 25,
        FBAFlatCreateInboundShipmentPlan = 26,
        FBAFlatUpdateInboundShipmentPlan = 27,
        FBACreateRemoval = 28,
    }
}
