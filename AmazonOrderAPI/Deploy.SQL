--CREATE INDEX OrderItems_CreatedDate
--ON  amz.Address (CreatedDate)

--CREATE INDEX OrderItems_CreatedDate
--ON  amz.Orders (CreatedDate)

--CREATE INDEX OrderItems_CreatedDate
--ON  amz.OrderItems (CreatedDate)

--CREATE INDEX SellerId_Order
--ON  amz.Orders (SellerId)

--CREATE INDEX SellerId_OrderItems
--ON  amz.OrderItems (SellerId)

--CREATE INDEX ItemStatusId_OrderItems
--ON  amz.OrderItems (ItemStatusId)


--CREATE INDEX WarehouserId_OrderItems
--ON  amz.OrderItems (WarehouseId)

--CREATE INDEX OrderId_OrderItems
--ON  amz.OrderItems (orderId)


--CREATE INDEX ShippingAddressId_Orders
--ON  amz.Orders (ShippingAddressId)

--CREATE INDEX ListOrderItemStatusId_Orders
--ON  amz.Orders (ListOrderItemStatusId)

-------------------start-Changes version 1.2  added Few Fields in pickup Request -----


ALTER TABLE amz.Sellers ADD  IsShouldbeGenConsNo BIT,CreatedBy BIGINT 
ALTER TABLE amz.OrderItems ADD ConsignmentNo NVARCHAR(20) 

UPDATE amz.Sellers SET Createdby=571
UPDATE amz.Sellers SET IsShouldbeGenConsNo=1


-------------------End-Changes version 1.2  added Few Fields in pickup Request -----




