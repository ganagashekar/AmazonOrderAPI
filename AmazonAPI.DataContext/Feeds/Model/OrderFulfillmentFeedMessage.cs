using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonAPI.Feeds.MarketplaceWebService.Model
{
    /*
     Selling on Amazon –Guide to XML66XSD https://images-na.ssl-images-amazon.com/images/G/01/rainier/help/xsd/release_1_9/OrderFulfillment.xsd
    
    <?xml version="1.0"?>
    <!--Revision="$Revision: #2 $" -->
    <xsd:schema
        xmlns:xsd="http://www.w3.org/2001/XMLSchema" elementFormDefault="qualified">
        <!--$Date: 2005/04/01 $AMAZON.COM CONFIDENTIAL.  This document and the information contained in it areconfidential and proprietary information of Amazon.com and may not be reproduced, distributed or used, in whole or in part, for any purpose other than as necessary to list products for sale on the www.amazon.com web site pursuant to an agreement with Amazon.com.-->
        <xsd:include schemaLocation="amzn-base.xsd"/>
        <xsd:element name="OrderFulfillment">
            <xsd:complexType>
                <xsd:sequence>
                    <xsd:choice>
                        <xsd:element ref="AmazonOrderID"/>
                        <xsd:element ref="MerchantOrderID"/>
                    </xsd:choice>
                    <xsd:element name="MerchantFulfillmentID" type="IDNumber" minOccurs="0"/>
                    <xsd:element name="FulfillmentDate" type="xsd:dateTime"/>
                    <xsd:element name="FulfillmentData" minOccurs="0">
                        <xsd:complexType>
                            <xsd:sequence>
                                <xsd:choice>
                                    <xsd:element ref="CarrierCode"/>
                                    <xsd:element name="CarrierName" type="String"/>
                                </xsd:choice>
                                <xsd:element name="ShippingMethod" type="String" minOccurs="0"/>
                                <xsd:element name="ShipperTrackingNumber" type="String" minOccurs="0"/>
                            </xsd:sequence>
                        </xsd:complexType>
                    </xsd:element>
                    <xsd:element name="Item" minOccurs="0" maxOccurs="unbounded">
                        <xsd:complexType>
                            <xsd:sequence>
                                <xsd:choice>
                                    <xsd:element ref="AmazonOrderItemCode"/>
                                    <xsd:element ref="MerchantOrderItemID"/>
                                </xsd:choice>
                                <xsd:element name="MerchantFulfillmentItemID" type="IDNumber" minOccurs="0"/>
                                <xsd:element name="Quantity" type="xsd:positiveInteger" minOccurs="0"/>
                            </xsd:sequence>
                        </xsd:complexType>
                    </xsd:element>
                </xsd:sequence>
            </xsd:complexType>
        </xsd:element>
    </xsd:schema>

    Example

    <?xml version="1.0" encoding="UTF-8"?>
    <AmazonEnvelope
        xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:noNamespaceSchemaLocation="amzn-envelope.xsd">
        <Header>
            <DocumentVersion>1.01</DocumentVersion>
            <MerchantIdentifier>My Store</MerchantIdentifier>
        </Header>
        <MessageType>OrderFulfillment</MessageType>
        <Message>
            <MessageID>1</MessageID>
            <OrderFulfillment>
                <MerchantOrderID>1234567</MerchantOrderID>
                <MerchantFulfillmentID>1234567</MerchantFulfillmentID>
                <FulfillmentDate>2002-05-01T15:36:33-08:00</FulfillmentDate>
                <FulfillmentData>
                    <CarrierCode>UPS</CarrierCode>
                    <ShippingMethod>Second Day</ShippingMethod>
                    <ShipperTrackingNumber>1234567890</ShipperTrackingNumber>
                </FulfillmentData>
                <Item>
                    <MerchantOrderItemID>1234567</MerchantOrderItemID>
                    <MerchantFulfillmentItemID>1234567</MerchantFulfillmentItemID>
                    <Quantity>2</Quantity>
                </Item>
            </OrderFulfillment>
        </Message>
    </AmazonEnvelope>
     */
    public class OrderFulfillmentFeedMessage
    {
        public OrderFulfillmentFeedMessage()
        {
            fulfillmentData = new FulfillmentData();
            fulfillmentItem = new FulfillmentItem();
        }
        public String AmazonOrderID { get; set; }
        public DateTime FulfillmentDate { get; set; }
        public FulfillmentData fulfillmentData { get; set; }
        public FulfillmentItem fulfillmentItem { get; set; }
    }

    public class FulfillmentData
    {
        public String CarrierName { get; set; }
        public String ShippingMethod { get; set; }
        public String ShipperTrackingNumber { get; set; }
    }

    public class FulfillmentItem
    {
        public String AmazonOrderItemCode { get; set; }
        public String Quantity { get; set; }
    }
}
