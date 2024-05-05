DECLARE @sql NVARCHAR(MAX) = N'';

-- Construct the dynamic SQL to drop all foreign key constraints
SELECT @sql += 'ALTER TABLE ' + QUOTENAME(TABLE_SCHEMA) + '.' + QUOTENAME(TABLE_NAME) 
               + ' DROP CONSTRAINT ' + QUOTENAME(CONSTRAINT_NAME) + ';'
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE CONSTRAINT_TYPE = 'FOREIGN KEY';

-- Execute the dynamic SQL to drop all foreign key constraints
EXEC sp_executesql @sql;

SET @sql = N'';

-- Construct the dynamic SQL to drop all tables
SELECT @sql += 'DROP TABLE ' + QUOTENAME(TABLE_SCHEMA) + '.' + QUOTENAME(TABLE_NAME) + ';'
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE';

-- Execute the dynamic SQL to drop all tables
EXEC sp_executesql @sql;