DROP TABLE IF EXISTS UserAccount CASCADE;
DROP TABLE IF EXISTS Customers CASCADE;
DROP TABLE IF EXISTS Staff CASCADE;
DROP TABLE IF EXISTS Restaurant CASCADE;
DROP TABLE IF EXISTS FDSManager CASCADE;
DROP TABLE IF EXISTS Rider CASCADE;
DROP TABLE IF EXISTS Schedule CASCADE;
DROP TABLE IF EXISTS Orders CASCADE;
DROP TABLE IF EXISTS FoodItem CASCADE;
DROP TABLE IF EXISTS OrderItemList CASCADE;
DROP TABLE IF EXISTS Promo CASCADE;
DROP TABLE IF EXISTS Review CASCADE;
DROP TABLE IF EXISTS CreditCard CASCADE;
DROP TABLE IF EXISTS MWS CASCADE;
DROP TABLE IF EXISTS WWS CASCADE;
DROP TABLE IF EXISTS PTWWS CASCADE;
DROP TABLE IF EXISTS PTDaySchedule CASCADE;
DROP TABLE IF EXISTS LastAccess CASCADE;

CREATE TABLE Restaurant (
restId		SERIAL PRIMARY KEY,
restName	VARCHAR(100) NOT NULL,
restAddress     VARCHAR(100) NOT NULL,
restArea	VARCHAR(100) NOT NULL,
minAmnt		DECIMAL NOT NULL
);

CREATE TABLE UserAccount (
usersid		SERIAL PRIMARY KEY,
username	VARCHAR(20) UNIQUE NOT NULL,
password	VARCHAR(20) NOT NULL,
userrole	VARCHAR(10) NOT NULL,
status		VARCHAR(2) NOT NULL
);

CREATE TABLE Customers (
cId		INTEGER,
cname		VARCHAR(100) NOT NULL,
rewardpoint	INTEGER NOT NULL,
recentlocation	VARCHAR(100),
PRIMARY KEY (cId),
FOREIGN KEY(cId) REFERENCES UserAccount (usersid)
);

CREATE TABLE Staff (
staffId		INTEGER,
restId		INTEGER NOT NULL,
Staffname	VARCHAR(100) NOT NULL,
PRIMARY KEY (staffId),
FOREIGN KEY (staffId) REFERENCES UserAccount (usersid),
FOREIGN KEY (restId) REFERENCES Restaurant (restId) 
);

CREATE TABLE FDSManager (
managerId			INTEGER,
fdsname		VARCHAR(100) NOT NULL,
PRIMARY KEY (managerId),
FOREIGN KEY (managerId) REFERENCES UserAccount (usersid)
);

CREATE TABLE Rider (
rId			INTEGER,
rname		VARCHAR(100) NOT NULL,
isfulltime	BOOLEAN,
salary		DECIMAL,
PRIMARY KEY (rId),
FOREIGN KEY (rId) REFERENCES UserAccount (usersId)
);

CREATE TABLE MWS (
mwsId			SERIAL PRIMARY KEY,
rId				INTEGER,
FOREIGN KEY (rId) REFERENCES Rider (rId)
);

CREATE TABLE WWS (
wwsId			SERIAL PRIMARY KEY,
mwsId			INTEGER,
wwsDate			DATE,
wwsStartTime	TIMESTAMP,
wwsEndTime		TIMESTAMP,
wwsStartTimeTwo	TIMESTAMP,
wwsEndTimeTwo	TIMESTAMP,
FOREIGN KEY (mwsId) REFERENCES MWS (mwsId)
);

CREATE TABLE PTWWS (
ptwwsId			SERIAL PRIMARY KEY,
rId				INTEGER,
FOREIGN KEY (rId) REFERENCES Rider (rId)
);

CREATE TABLE PTDaySchedule (
ptDayScheduleId			SERIAL PRIMARY KEY,
ptwwsId			INTEGER,
ptwwsDate			DATE,
ptwwsStartTime	TIMESTAMP,
ptwwsEndTime		TIMESTAMP,
ptwwsStartTimeTwo	TIMESTAMP,
ptwwsEndTimeTwo	TIMESTAMP,
ptwwsStartTimeThree	TIMESTAMP,
ptwwsEndTimeThree	TIMESTAMP,
FOREIGN KEY (ptwwsId) REFERENCES PTWWS (ptwwsId)
);

CREATE TABLE CreditCard (
ccId		SERIAL PRIMARY KEY,
cId		INTEGER NOT NULL,
ccNum		VARCHAR(16) NOT NULL,
ccv		VARCHAR(3) NOT NULL,
ccExpiry	VARCHAR(5) NOT NULL,
FOREIGN KEY (cId) REFERENCES Customers (cId)
);


CREATE TABLE Orders (
orderId			SERIAL PRIMARY KEY,
cId 			INTEGER NOT NULL,
transactionId		VARCHAR(10) NOT NULL,
rId			INTEGER,
paymentType 		VARCHAR(10) NOT NULL,
cardNum			VARCHAR(16),
deliverAddress		VARCHAR(100) NOT NULL,
contactNo		VARCHAR(10) NOT NULL,
deliveryFee		DECIMAL,
totalCost		DECIMAL,
orderCreated		TIMESTAMP,
arriveTime     		TIMESTAMP,
departTime 		TIMESTAMP,
deliverTime 		TIMESTAMP,
isPaid			VARCHAR(2),
status			VARCHAR(20),
FOREIGN KEY (cId) REFERENCES Customers (cId),
FOREIGN KEY (rId) REFERENCES Rider (rId)
);

CREATE TABLE FoodItem (
foodId				SERIAL PRIMARY KEY,
restId				INTEGER NOT NULL,
foodCategory			VARCHAR(50),
foodTitle			VARCHAR(100),
orderCounter			INTEGER DEFAULT 0,
price				DECIMAL NOT NULL,
dailyLimit			INTEGER NOT NULL,
FOREIGN KEY (restId) REFERENCES Restaurant (restId)
);

CREATE TABLE OrderItemList (
lineId			SERIAL PRIMARY KEY,
transactionId		VARCHAR(10) NOT NULL,
cId			INTEGER NOT NULL,
foodId			INTEGER NOT NULL,
orderQuantity		INTEGER NOT NULL,
checkOut		VARCHAR(2) NOT NULL,
FOREIGN KEY (cId) REFERENCES Customers(cId),
FOREIGN KEY (foodId) REFERENCES FoodItem (foodId)
);

CREATE TABLE Promo (
promoId				SERIAL PRIMARY KEY,
restId				INTEGER,
promoDesc			VARCHAR(100),
promoValue			DECIMAL NOT NULL,
promoType			VARCHAR(20) NOT NULL,
promoStartDate		TIMESTAMP,
promoEndDate		TIMESTAMP,
promoCode 			VARCHAR(15) UNIQUE NOT NULL,
FOREIGN KEY (restId) REFERENCES Restaurant (restId)
);

CREATE TABLE Review (	
reviewId			SERIAL PRIMARY KEY,
orderId				INTEGER NOT NULL,
cId					INTEGER NOT NULL,
rId					INTEGER NOT NULL,
restId				INTEGER NOT NULL,
riderRating			INTEGER NOT NULL,
restaurantRating	INTEGER NOT NULL,
reviewTxt			VARCHAR(500),
FOREIGN KEY (orderId) REFERENCES Orders (orderId),
FOREIGN KEY (cId) REFERENCES Customers (cId),
FOREIGN KEY (rId) REFERENCES Rider (rId),
FOREIGN KEY (restId) REFERENCES Restaurant (restId)
);

CREATE TABLE LastAccess (
accessId	SERIAL PRIMARY KEY,
accessDate 	DATE
);
