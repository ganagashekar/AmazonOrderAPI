ALTER TABLE amz.Orders
DROP column  SellerId 


ALTER TABLE amz.Orders
add  SellerId BIGINT

ALTER TABLE amz.OrderItems
DROP column  SellerId	


ALTER TABLE amz.OrderItems
add  SellerId BIGINT

ALTER TABLE amz.Address Add Createdate Datetime 

--UPDATE amz.Orders SET SellerId=3

--UPDATE amz.OrderItems SET sellerId=3
