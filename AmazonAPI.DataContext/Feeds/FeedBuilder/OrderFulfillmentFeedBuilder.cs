using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using AmazonAPI.Feeds.MarketplaceWebService.Model;

namespace AmazonAPI.Feeds.MarketplaceWebService.FeedBuilder
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
    public static class OrderFulfillmentFeedBuilder
    {
        public static XmlDocument BuildOrderFulfillmentFeedXml(List<OrderFulfillmentFeedMessage> orderFulfillmentFeedMessages)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration Declaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDoc.AppendChild(Declaration);
            XmlNode rootNode = xmlDoc.CreateElement("AmazonEnvelope");
            XmlAttribute rootAttribute5 = xmlDoc.CreateAttribute("xmlns:xsi");
            rootAttribute5.Value = "http://www.w3.org/2001/XMLSchema-instance";
            rootNode.Attributes.Append(rootAttribute5);
            //XmlAttribute rootAttribute4 = xmlDoc.CreateAttribute("xsi:noNamespaceSchemaLocation");
            XmlAttribute rootAttribute4 = xmlDoc.CreateAttribute("xsi", "noNamespaceSchemaLocation", "http://www.w3.org/2001/XMLSchema-instance");
            rootAttribute4.Value = "amzn-envelope.xsd";
            rootNode.Attributes.Append(rootAttribute4);
            xmlDoc.AppendChild(rootNode);

            XmlNode headerNode = xmlDoc.CreateElement("Header");
            rootNode.AppendChild(headerNode);

            XmlNode documentVersionNode = xmlDoc.CreateElement("DocumentVersion");
            documentVersionNode.InnerText = "1.01";
            headerNode.AppendChild(documentVersionNode);

            XmlNode merchantIdentifierNode = xmlDoc.CreateElement("MerchantIdentifier");
            //merchantIdentifierNode.InnerText = "M_CARPARTSDE_1214223";
            merchantIdentifierNode.InnerText = "";
            headerNode.AppendChild(merchantIdentifierNode);

            XmlNode messageTypeNode = xmlDoc.CreateElement("MessageType");
            messageTypeNode.InnerText = "OrderFulfillment";
            rootNode.AppendChild(messageTypeNode);

            int messageId = 1;
            foreach (OrderFulfillmentFeedMessage orderFulfillmentFeedMessage in orderFulfillmentFeedMessages)
            {
                XmlNode messageNode = xmlDoc.CreateElement("Message");
                rootNode.AppendChild(messageNode);

                XmlNode messageIdNode = xmlDoc.CreateElement("MessageID");
                messageIdNode.InnerText = messageId.ToString();
                messageNode.AppendChild(messageIdNode);

                XmlNode orderFullfillmentNode = xmlDoc.CreateElement("OrderFulfillment");
                messageNode.AppendChild(orderFullfillmentNode);

                XmlNode AmazonOrderIdNode = xmlDoc.CreateElement("AmazonOrderID");
                string amazonOrderId = orderFulfillmentFeedMessage.AmazonOrderID;
                AmazonOrderIdNode.InnerText = amazonOrderId;
                orderFullfillmentNode.AppendChild(AmazonOrderIdNode);

                XmlNode fulfillmentDateNode = xmlDoc.CreateElement("FulfillmentDate");
                string shipDate = orderFulfillmentFeedMessage.FulfillmentDate.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'sszzz");
                fulfillmentDateNode.InnerText = shipDate;
                orderFullfillmentNode.AppendChild(fulfillmentDateNode);

                XmlNode fulfillmentDataNode = xmlDoc.CreateElement("FulfillmentData");
                orderFullfillmentNode.AppendChild(fulfillmentDataNode);

                XmlNode carrierNameNode = xmlDoc.CreateElement("CarrierName");
                string carrierName = orderFulfillmentFeedMessage.fulfillmentData.CarrierName;
                carrierNameNode.InnerText = carrierName;
                fulfillmentDataNode.AppendChild(carrierNameNode);

                XmlNode shippingMethodNode = xmlDoc.CreateElement("ShippingMethod");
                string shippingMethod = orderFulfillmentFeedMessage.fulfillmentData.ShippingMethod;
                shippingMethodNode.InnerText = shippingMethod;
                fulfillmentDataNode.AppendChild(shippingMethodNode);

                XmlNode trackingNode = xmlDoc.CreateElement("ShipperTrackingNumber");
                string tracking = orderFulfillmentFeedMessage.fulfillmentData.ShipperTrackingNumber;
                trackingNode.InnerText = tracking;
                fulfillmentDataNode.AppendChild(trackingNode);

                XmlNode itemNode = xmlDoc.CreateElement("Item");
                orderFullfillmentNode.AppendChild(itemNode);

                XmlNode amazonOrderItemCodeNode = xmlDoc.CreateElement("AmazonOrderItemCode");
                string amazonOrderItemCode = orderFulfillmentFeedMessage.fulfillmentItem.AmazonOrderItemCode;
                amazonOrderItemCodeNode.InnerText = amazonOrderItemCode;
                itemNode.AppendChild(amazonOrderItemCodeNode);

                XmlNode quantityNode = xmlDoc.CreateElement("Quantity");
                string quantity = orderFulfillmentFeedMessage.fulfillmentItem.Quantity;
                quantityNode.InnerText = quantity;
                itemNode.AppendChild(quantityNode);

                messageId = messageId + 1;
            }
            return xmlDoc;
        }
    }
}
