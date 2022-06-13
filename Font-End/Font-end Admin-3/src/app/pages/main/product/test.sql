IF (NOT EXISTS(SELECT TOP 1 * FROM vB00PermisionData WHERE UserId = 1 AND TableName= 'B10Product' AND Permission = 0000020000))        
      BEGIN         
	  SELECT N'MESSAGE.Không có quyền thêm dữ liệu  B10Product'       
	  return;           
	  END   BEGIN TRY   IF( 1 = 1)   BEGIN              IF(EXISTS(SELECT TOP 1 * FROM B10Product WHERE LOWER(Code) = LOWER('code1234142'))) BEGIN SELECT 'MESSEAGE.Code IS EXISTED ' RETURN; END 	   END         INSERT INTO B10Product         (  IsGroup, ParentId, Code, Name, Alias, Unit0, ConvertRate0, Unit, ManufacturerCode, ProductCategoryCode, UnitCost, UnitPrice, MinCloseQty, MaxCloseQty, Warranty, Description, Content, Information, CreatedBy)         VALUES         ( N'False', 0, N'code1234142', 123, N'', N'', 0, N'', N'', N'LTG', 123, 0, 0, 0, 123, 123, 123, N'', 1);                                                                                                                
      
 INSERT INTO  B10ProductInformation ( IsGroup, ParentId, ProductCode, Name, Description, DisplayOrder, CreatedBy) 
VALUES ( N'False', 0, 'code1234142', N'', N'', 0, 1), 
( N'False', 0, 'code1234142', N'', N'', 0, 1), 
( N'False', 0, 'code1234142', N'', N'', 0, 1), 
( N'False', 0, 'code1234142', N'', N'', 0, 1), 
( N'False', 0, 'code1234142', N'', N'', 0, 1), 
( N'False', 0, 'code1234142', N'', N'', 0, 1), 
( N'False', 0, 'code1234142', N' Bộ vi xử lý (CPU)  Tên bộ vi xử lý Intel® Core™ i7-1165G7 Processor Tốc độ 2.80GHz up to 4.70GHz, 4 nhân 8 luồng Bộ nhớ đệm 12MB Intel® Smart Cache Bộ nhớ trong (RAM Laptop) Dung lượng 16GB LPDR4x 4266MHz on board Số khe cắm', N'-', 0, 1), 
( N'False', 0, 'code1234142', N' Bộ vi xử lý (CPU)  T123', N'-', 0, 1), 
( N'False', 0, 'code1234142', N' Bộ vi xử lý (CPU) ', N'-', 0, 1);
INSERT INTO  B10ProductImg ( IsGroup, ParentId, ProductCode, ImagePath, Caption, SortOrder, ImglengthSize, CreatedBy, ImageDefault) 
VALUES ( N'False', 0, 'code1234142', N'/user-content/3f95f20d-bdfb-49ab-bbfc-80fa60097417.jpg', N'', 0, 0, 1, N'True'), 
( N'False', 0, 'code1234142', N'/user-content/5b9801e5-a444-4ed7-a3b5-8a626f68d7c1.jpg', N'', 0, 0, 1, N'False'), 
( N'False', 0, 'code1234142', N'/user-content/a4263385-3a57-41ad-bd81-498b0bed46d7.jpg', N'', 0, 0, 1, N'False'), 
( N'False', 0, 'code1234142', N'/user-content/e39acb84-7dbb-45ee-a996-dba2428b3ba8.jpg', N'', 0, 0, 1, N'False'), 
( N'False', 0, 'code1234142', N'/user-content/093bbb25-f6db-425d-8a6d-5742c7003e7b.jpg', N'', 0, 0, 1, N'False');
     END TRY     BEGIN CATCH         SELECT ERROR_MESSAGE() + '--' + CAST(ERROR_LINE() AS NVARCHAR) AS MESSAGE;     END CATCH