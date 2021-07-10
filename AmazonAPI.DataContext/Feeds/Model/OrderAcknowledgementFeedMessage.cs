using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonAPI.Feeds.MarketplaceWebService.Model
{
    /*
     XSDhttps://images-na.ssl-images-amazon.com/images/G/01/rainier/help/xsd/release_1_9/OrderAcknowledgement.xsd
    
    <?xml version="1.0"?>
    <!--Revision="$Revision: #7 $" -->
    <xsd:schema
        xmlns:xsd="http://www.w3.org/2001/XMLSchema" elementFormDefault="qualified">
        <!--$Date: 2007/03/08 $AMAZON.COM CONFIDENTIAL.  This document and the information contained in it areconfidential and proprietary information of Amazon.com and may not be reproduced, distributed or used, in whole or in part, for any purpose other than as necessaryto list products for sale on the www.amazon.com web site pursuant to an agreement with Amazon.com.-->
        <xsd:include schemaLocation="amzn-base.xsd"/>
        <xsd:element name="OrderAcknowledgement">
            <xsd:complexType>
                <xsd:sequence>
                    <xsd:element ref="AmazonOrderID"/>
                    <xsd:element ref="MerchantOrderID" minOccurs="0"/>
                    <xsd:element name="StatusCode">
                        <xsd:simpleType>
                            <xsd:restriction base="xsd:string">
                                <xsd:enumeration value="Success"/>
                                <xsd:enumeration value="Failure"/>
                            </xsd:restriction>
                        </xsd:simpleType>
                    </xsd:element>
                    <xsd:element name="Item" minOccurs="0" maxOccurs="unbounded">
                        <xsd:complexType>
                            <xsd:sequence>
                                <xsd:element ref="AmazonOrderItemCode"/>
                                <xsd:elementref="MerchantOrderItemID" minOccurs="0"/>
                                <xsd:element name="CancelReason" minOccurs="0">
                                    <xsd:simpleType>
                                        <xsd:restriction base="xsd:string">
                                            <xsd:enumeration value="NoInventory"/>
                                            <xsd:enumeration value="ShippingAddressUndeliverable"/>
                                            <xsd:enumeration value="CustomerExchange"/>
                                            <xsd:enumeration value="BuyerCanceled"/>
                                            <xsd:enumeration value="GeneralAdjustment"/>
                                            <xsd:enumeration value="CarrierCreditDecision"/>
                                            <xsd:enumeration value="RiskAssessmentInformationNotValid"/>
                                            <xsd:enumeration value="CarrierCoverageFailure"/>
                                            <xsd:enumeration value="CustomerReturn"/>
                                            <xsd:enumeration value="MerchandiseNotReceived"/>
                                        </xsd:restriction>
                                    </xsd:simpleType>
                                </xsd:element>
                            </xsd:sequence>
                        </xsd:complexType>
                    </xsd:element>
                </xsd:sequence>
            </xsd:complexType>
        </xsd:element>
    </xsd:schema>

    Example

    <?xml version="1.0"?>
    <AmazonEnvelope
        xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:noNamespaceSchemaLocation="amzn-envelope.xsd">
        <Header>
            <DocumentVersion>1.01</DocumentVersion>
            <MerchantIdentifier> M_IDENTIFIER</MerchantIdentifier>
        </Header>
        <MessageType>OrderAcknowledgement</MessageType>
        <Message>
            <MessageID>1</MessageID>
            <OrderAcknowledgement>
                <AmazonOrderID>050-1234567-1234567</AmazonOrderID>
                <MerchantOrderID>1234567</MerchantOrderID>
                <StatusCode>Success</StatusCode>
                <Item>
                    <AmazonOrderItemCode>12345678901234</AmazonOrderItemCode>
                    <MerchantOrderItemID>1234567</MerchantOrderItemID>
                </Item>
            </OrderAcknowledgement>
        </Message>
    </AmazonEnvelope>
     */
    public class OrderAcknowledgementFeedMessage
    {
        public OrderAcknowledgementFeedMessage()
        {
            acknowledgementItem = new AcknowledgementItem();
        }
        public String AmazonOrderID { get; set; }
        public String StatusCode { get; set; }
        public AcknowledgementItem acknowledgementItem { get; set; }
    }
    public class AcknowledgementItem
    {
        public String AmazonOrderItemCode { get; set; }
    }
}
