CREATE TABLE User(
   Id 			INT 	PRIMARY KEY	,
   Username		TEXT    NOT NULL,
   Password		TEXT    NOT NULL,
   Address		TEXT,
   Email		TEXT,
   AssociationName TEXT,
   OIB			TEXT
);

CREATE TABLE Expenditure(
   Id 							INT PRIMARY KEY	NOT NULL,
   Date							NUMERIC,
   JournalEntryNum				TEXT,
   AmountCash					NUMERIC,
   AmountTransferAccount		NUMERIC,
   AmountNonCashBenefit 		NUMERIC,
   Article22					NUMERIC,
   Total						NUMERIC,
   UserId						INT NOT NULL,
   ValueAddedTaxId				INT NOT NULL,
   FOREIGN KEY(UserId) REFERENCES User(Id),
   FOREIGN KEY(ValueAddedTaxId) REFERENCES VAT(Id)
);

CREATE TABLE Receipt(
   Id 							INT PRIMARY KEY	NOT NULL,
   Date							NUMERIC,
   JournalEntryNum				TEXT,
   AmountCash					NUMERIC,
   AmountTransferAccount		NUMERIC,
   AmountNonCashBenefit 		NUMERIC,
   Total						NUMERIC,
   UserId						INT NOT NULL,
   ValueAddedTaxId				INT NOT NULL,
   FOREIGN KEY(UserId) REFERENCES User(Id),
   FOREIGN KEY(ValueAddedTaxId) REFERENCES VAT(Id)
);

CREATE TABLE IngoingInvoice(
   Id 							INT PRIMARY KEY	NOT NULL,
   Date							NUMERIC,    
   InvoiceClassNum				TEXT,    
   SupplierInfo					TEXT,
   Amount						NUMERIC,
   UserId						INT NOT NULL,
   FOREIGN KEY(UserId) REFERENCES User(Id)
);

CREATE TABLE OutgoingInvoice(
   Id 							INT PRIMARY KEY	NOT NULL,
   Date							NUMERIC,    
   InvoiceClassNum				TEXT,    
   CustomerInfo					TEXT,
   Amount						NUMERIC,
   UserId						INT NOT NULL,
   FOREIGN KEY(UserId) REFERENCES User(Id)
);

CREATE TABLE VAT(
   Id 			INT PRIMARY KEY	NOT NULL,
   Name 		TEXT NOT NULL,
   Percentage 	NUMERIC NOT NULL
);