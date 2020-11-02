CREATE OR REPLACE FUNCTION checkRiderSalary()
RETURNS TRIGGER AS $$
BEGIN
	IF NEW.salary < 0 THEN
    	RAISE EXCEPTION 'Salary must not be negative !';
END IF;
RETURN NEW;
END;
$$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS check_RiderSalary ON Rider CASCADE;
CREATE TRIGGER check_RiderSalary
BEFORE UPDATE OR INSERT ON Rider
FOR EACH ROW
EXECUTE PROCEDURE checkRiderSalary();

CREATE OR REPLACE FUNCTION checkRestaurantMinAmnt()
RETURNS TRIGGER AS $$
BEGIN
	IF NEW.minAmnt < 0 THEN
    	RAISE EXCEPTION 'Min amount must not be negative !';
END IF;
RETURN NEW;
END;
$$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS check_RestaurantMinAmnt ON Restaurant CASCADE;
CREATE TRIGGER check_RestaurantMinAmnt
BEFORE UPDATE OR INSERT ON Restaurant
FOR EACH ROW
EXECUTE PROCEDURE checkRestaurantMinAmnt();


CREATE OR REPLACE FUNCTION checkPromoDate()
RETURNS TRIGGER AS $$
BEGIN
	IF NEW.promoEndDate < NEW.promoStartDate THEN
    	RAISE EXCEPTION 'Promo end date cannot be before promo start date !';
	END IF;
	IF NEW.promotype = 'Percentage' AND NEW.promovalue > 100 THEN
		RAISE EXCEPTION 'Promo Percentage cannot exceed 100 percent!!';
	END IF;
	
RETURN NEW;
END;
$$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS check_PromoDate ON Promo CASCADE;
CREATE TRIGGER check_PromoDate
BEFORE UPDATE OR INSERT ON Promo
FOR EACH ROW
EXECUTE PROCEDURE checkPromoDate();


CREATE OR REPLACE FUNCTION checkOrderItemListQuantity()
RETURNS TRIGGER AS $$
BEGIN
	IF NEW.orderQuantity <= 0 THEN
    	RAISE EXCEPTION 'Order quantity cannot be negative or zero !';
	END IF;
	
RETURN NEW;
END;
$$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS check_OrderItemListQuantity ON OrderItemList CASCADE;
CREATE TRIGGER check_OrderItemListQuantity
BEFORE UPDATE OR INSERT ON OrderItemList
FOR EACH ROW
EXECUTE PROCEDURE checkOrderItemListQuantity();

CREATE OR REPLACE FUNCTION checkReviewRating()
RETURNS TRIGGER AS $$
BEGIN
	IF NEW.riderRating < 1 OR New.riderRating > 5 THEN
    	RAISE EXCEPTION 'Rating must be within 1 to 5!';
	END IF;
	IF NEW.restaurantRating < 1 OR New.restaurantRating > 5 THEN
    	RAISE EXCEPTION 'Rating must be within 1 to 5!';
	END IF;
RETURN NEW;
END;
$$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS check_ReviewRating ON Review CASCADE;
CREATE TRIGGER check_ReviewRating
BEFORE UPDATE OR INSERT ON Review
FOR EACH ROW
EXECUTE PROCEDURE checkReviewRating();


CREATE OR REPLACE FUNCTION checkFTWWSDate()
RETURNS TRIGGER AS $$
BEGIN
	IF NEW.wwsEndTime < NEW.wwsStartTime THEN
    	RAISE EXCEPTION '% is before % !', NEW.wwsEndTime , NEW.wwsStartTime;
	ELSIF NEW.wwsEndTimeTwo < NEW.wwsStartTimeTwo THEN
    	RAISE EXCEPTION '% is before % !', NEW.wwsEndTimeTwo , NEW.wwsStartTimeTwo;
	ELSIF NEW.wwsStartTimeTwo < NEW.wwsEndTime THEN
    	RAISE EXCEPTION '% is before % !', NEW.wwsEndTime , NEW.wwsStartTimeTwo;
END IF;
RETURN NEW;
END;
$$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS check_FTWWSDATE ON WWS CASCADE;
CREATE TRIGGER check_FTWWSDATE
BEFORE UPDATE OR INSERT ON WWS
FOR EACH ROW
EXECUTE PROCEDURE checkFTWWSDate();


CREATE OR REPLACE FUNCTION checkFTWWSLimit()
RETURNS TRIGGER AS $$
DECLARE counter integer;
BEGIN
	SELECT count(*) INTO counter
	FROM WWS w1
	WHERE w1.mwsid = NEW.mwsid;
	IF counter >= 20 THEN
		RAISE EXCEPTION 'mwsid % already have 20 wws!', NEW.mwsid;
	END IF;
	RETURN NEW;
END;
$$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS check_FTWWSLIMIT ON WWS CASCADE;
CREATE TRIGGER check_FTWWSLIMIT
BEFORE INSERT ON WWS
FOR EACH ROW
EXECUTE PROCEDURE checkFTWWSLimit();


CREATE OR REPLACE FUNCTION checkPTWWSDate()
RETURNS TRIGGER AS $$
BEGIN
	IF NEW.ptwwsEndTime < NEW.ptwwsStartTime THEN
    	RAISE EXCEPTION '% is before % !', NEW.ptwwsEndTime , NEW.ptwwsStartTime;
	ELSIF NEW.ptwwsEndTimeTwo < NEW.ptwwsStartTimeTwo THEN
    	RAISE EXCEPTION '% is before % !', NEW.ptwwsEndTimeTwo , NEW.ptwwsStartTimeTwo;
	ELSIF NEW.ptwwsEndTimeThree < NEW.ptwwsStartTimeThree THEN
    	RAISE EXCEPTION '% is before % !', NEW.ptwwsEndTimeThree , NEW.ptwwsStartTimeThree;
	ELSIF (NEW.ptwwsEndTime IS NOT NULL) AND (NEW.ptwwsStartTime IS NULL) THEN
		RAISE EXCEPTION 'start time value is not entered!';
	ELSIF (NEW.ptwwsStartTime IS NOT NULL) AND (NEW.ptwwsEndTime IS NULL) THEN
		RAISE EXCEPTION 'end time value is not entered!';
	ELSIF (NEW.ptwwsEndTimeTwo IS NOT NULL) AND (NEW.ptwwsStartTimeTwo IS NULL) THEN
		RAISE EXCEPTION 'start time value is not entered!';
	ELSIF (NEW.ptwwsStartTimeTwo IS NOT NULL) AND (NEW.ptwwsEndTimeTwo IS NULL) THEN
		RAISE EXCEPTION 'end time value is not entered!';
	ELSIF (NEW.ptwwsEndTimeThree IS NOT NULL) AND (NEW.ptwwsStartTimeThree IS NULL) THEN
		RAISE EXCEPTION 'start time value is not entered!';
	ELSIF (NEW.ptwwsStartTimeThree IS NOT NULL) AND (NEW.ptwwsEndTimeThree IS NULL) THEN
		RAISE EXCEPTION 'end time value is not entered!';
	ELSIF (NEW.ptwwsStartTimeTwo < NEW.ptwwsEndTime) THEN
		RAISE EXCEPTION 'start time two is before end time one';
	ELSIF (NEW.ptwwsStartTimeThree < NEW.ptwwsEndTime) THEN
		RAISE EXCEPTION 'start time three is before end time one';
	ELSIF (NEW.ptwwsStartTimeThree < NEW.ptwwsEndTimeTwo) THEN
		RAISE EXCEPTION 'start time three is before end time two';		
	ELSIF (NEW.ptwwsStartTime = NEW.ptwwsEndTime) THEN
		RAISE EXCEPTION 'Start time cannot be end time!';
	ELSIF (NEW.ptwwsStartTimeTwo = NEW.ptwwsEndTimeTwo) THEN
		RAISE EXCEPTION 'Start time cannot be end time!';
	ELSIF (NEW.ptwwsStartTimeThree = NEW.ptwwsEndTimeThree) THEN
		RAISE EXCEPTION 'Start time cannot be end time!';
END IF;
RETURN NEW;
END;
$$ LANGUAGE plpgsql;


DROP TRIGGER IF EXISTS check_PTWWSDate ON PTDaySchedule CASCADE;
CREATE TRIGGER check_PTWWSDate
BEFORE UPDATE OR INSERT ON PTDaySchedule
FOR EACH ROW
EXECUTE PROCEDURE checkPTWWSDate();


CREATE OR REPLACE FUNCTION checkPTWWSLimit()
RETURNS TRIGGER AS $$
DECLARE counter integer;
BEGIN
	SELECT count(*) INTO counter
	FROM PTDaySchedule w1
	WHERE w1.ptwwsId = NEW.ptwwsId;
	IF counter >= 7 THEN
		RAISE EXCEPTION 'ptwwsid % already have 7 days!', NEW.ptwwsid;
	END IF;
	RETURN NEW;
END;
$$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS check_PTWWSLIMIT ON PTDaySchedule CASCADE;
CREATE TRIGGER check_PTWWSLIMIT
BEFORE INSERT ON PTDaySchedule
FOR EACH ROW
EXECUTE PROCEDURE checkPTWWSLimit();


CREATE OR REPLACE FUNCTION checkPTWWSMAXWORKTIME()
RETURNS TRIGGER AS $$
DECLARE maxhour integer = 48;
DECLARE totalhour integer;
BEGIN
SELECT CAST(EXTRACT(HOUR FROM SUM(pt1.ptwwsEndTime - pt1.ptwwsStartTime) + SUM(pt1.ptwwsEndTimeTwo - pt1.ptwwsStartTimeTwo) + SUM(pt1.ptwwsEndTimeThree - pt1.ptwwsStartTimeThree)) AS INTEGER) INTO totalhour
	FROM PTDaySchedule pt1
	WHERE pt1.ptwwsid = NEW.ptwwsid;
	IF totalhour > maxhour THEN
		RAISE EXCEPTION '% is more than %', totalhour, maxhour;
	END IF;
	RETURN NEW;
END;
$$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS check_PTWWSMAXWORKTIME ON PTDaySchedule CASCADE;
CREATE TRIGGER check_PTWWSMAXWORKTIME
AFTER UPDATE OR INSERT ON PTDaySchedule
FOR EACH ROW
EXECUTE PROCEDURE checkPTWWSMAXWORKTIME();


CREATE OR REPLACE FUNCTION checkPTWWSMAXWORKTIMEINTERVAL()
RETURNS TRIGGER AS $$
DECLARE maxhour integer = 4;
DECLARE breaktime integer = 1;
DECLARE totalbreak integer;
DECLARE totalhour integer;
BEGIN
	SELECT CAST(EXTRACT(HOUR FROM SUM(pt1.ptwwsEndTime - pt1.ptwwsStartTime)) AS INTEGER) INTO totalhour
	FROM PTDaySchedule pt1
	WHERE pt1.ptDayScheduleId = NEW.ptDayScheduleId;
	IF totalhour > maxhour THEN
		RAISE EXCEPTION '% is more than % at shift 1', totalhour, maxhour;
	END IF;
	SELECT CAST(EXTRACT(HOUR FROM SUM(pt1.ptwwsEndTimeTwo - pt1.ptwwsStartTimeTwo)) AS INTEGER) INTO totalhour
	FROM PTDaySchedule pt1
	WHERE pt1.ptDayScheduleId = NEW.ptDayScheduleId;
	IF totalhour > maxhour THEN
		RAISE EXCEPTION '% is more than % at shift two', totalhour, maxhour;
	END IF;
	SELECT CAST(EXTRACT(HOUR FROM SUM(pt1.ptwwsEndTimeThree - pt1.ptwwsStartTimeThree)) AS INTEGER) INTO totalhour
	FROM PTDaySchedule pt1
	WHERE pt1.ptDayScheduleId = NEW.ptDayScheduleId;
	IF totalhour > maxhour THEN
		RAISE EXCEPTION '% is more than % at shift 3', totalhour, maxhour;
	END IF;
	SELECT CAST(EXTRACT(HOUR FROM SUM(pt1.ptwwsStartTimeTwo - pt1.ptwwsEndTime)) AS INTEGER) INTO totalbreak
	FROM PTDaySchedule pt1
	WHERE pt1.ptDayScheduleId = NEW.ptDayScheduleId;
	IF totalbreak < breaktime THEN
		RAISE EXCEPTION 'Please ensure there is minimum break of % hour', breaktime;
	END IF;
		SELECT CAST(EXTRACT(HOUR FROM SUM(pt1.ptwwsStartTimeThree - pt1.ptwwsEndTimeTwo)) AS INTEGER) INTO totalbreak
	FROM PTDaySchedule pt1
	WHERE pt1.ptDayScheduleId = NEW.ptDayScheduleId;
	IF totalbreak < breaktime THEN
		RAISE EXCEPTION 'Please ensure there is minimum break of % hour', breaktime;
	END IF;	
	RETURN NEW;
END;
$$ LANGUAGE plpgsql;


DROP TRIGGER IF EXISTS check_PTWWSMAXWORKTIMEINTERVAL ON PTDaySchedule CASCADE;
CREATE TRIGGER check_PTWWSMAXWORKTIMEINTERVAL
AFTER UPDATE OR INSERT ON PTDaySchedule
FOR EACH ROW
EXECUTE PROCEDURE checkPTWWSMAXWORKTIMEINTERVAL();


CREATE OR REPLACE FUNCTION checkPTWWSOPERATIONTIME()
RETURNS TRIGGER AS $$
DECLARE starthour int = 10;
DECLARE endhour int = 22;
DECLARE mincheck int = 0;
DECLARE seccheck int = 0;
BEGIN
	IF(CAST(EXTRACT(HOUR FROM NEW.ptwwsStartTime) AS INTEGER)) < starthour THEN
		RAISE EXCEPTION 'Starting time must be after 10:00:00';
	ELSIF (CAST(EXTRACT(HOUR FROM NEW.ptwwsStartTimeTwo) AS INTEGER)) < starthour THEN
		RAISE EXCEPTION 'Starting time must be after 10:00:00';	
	ELSIF (CAST(EXTRACT(HOUR FROM NEW.ptwwsStartTimeThree) AS INTEGER)) < starthour THEN
		RAISE EXCEPTION 'Starting time must be after 10:00:00';			
	END IF;
	IF(CAST(EXTRACT(HOUR FROM NEW.ptwwsEndTime) AS INTEGER)) > endhour THEN
		RAISE EXCEPTION 'Ending time must be before 22:00:00';
	ELSIF (CAST(EXTRACT(HOUR FROM NEW.ptwwsEndTimeTwo) AS INTEGER)) > endhour THEN
		RAISE EXCEPTION 'Ending time must be before 22:00:00';	
	ELSIF (CAST(EXTRACT(HOUR FROM NEW.ptwwsEndTimeThree) AS INTEGER)) > endhour THEN
		RAISE EXCEPTION 'Ending time must be before 22:00:00';			
	END IF;
	IF(CAST(EXTRACT(MINUTE FROM NEW.ptwwsStartTime) AS INTEGER)) > mincheck THEN
		RAISE EXCEPTION 'Time cannot contain minutes!';
	ELSIF (CAST(EXTRACT(MINUTE FROM NEW.ptwwsStartTimeTwo) AS INTEGER)) > mincheck THEN
		RAISE EXCEPTION 'Time cannot contain minutes!';
	ELSIF (CAST(EXTRACT(MINUTE FROM NEW.ptwwsStartTimeThree) AS INTEGER)) > mincheck THEN
		RAISE EXCEPTION 'Time cannot contain minutes!';		
	END IF;
	IF(CAST(EXTRACT(MINUTE FROM NEW.ptwwsEndTime) AS INTEGER)) > mincheck THEN
		RAISE EXCEPTION 'Time cannot contain minutes!';
	ELSIF (CAST(EXTRACT(MINUTE FROM NEW.ptwwsEndTimeTwo) AS INTEGER)) > mincheck THEN
		RAISE EXCEPTION 'Time cannot contain minutes!';
	ELSIF (CAST(EXTRACT(MINUTE FROM NEW.ptwwsEndTimeThree) AS INTEGER)) > mincheck THEN
		RAISE EXCEPTION 'Time cannot contain minutes!';			
	END IF;		
		IF(CAST(EXTRACT(SECOND FROM NEW.ptwwsStartTime) AS INTEGER)) > seccheck THEN
		RAISE EXCEPTION 'Time cannot contain seconds!';
	ELSIF (CAST(EXTRACT(SECOND FROM NEW.ptwwsStartTimeTwo) AS INTEGER)) > seccheck THEN
		RAISE EXCEPTION 'Time cannot contain seconds!';
	ELSIF (CAST(EXTRACT(SECOND FROM NEW.ptwwsStartTimeThree) AS INTEGER)) > seccheck THEN
		RAISE EXCEPTION 'Time cannot contain seconds!';		
	END IF;
	IF(CAST(EXTRACT(SECOND FROM NEW.ptwwsEndTime) AS INTEGER)) > seccheck THEN
		RAISE EXCEPTION 'Time cannot contain seconds!';
	ELSIF (CAST(EXTRACT(SECOND FROM NEW.ptwwsEndTimeTwo) AS INTEGER)) > seccheck THEN
		RAISE EXCEPTION 'Time cannot contain seconds!';
	ELSIF (CAST(EXTRACT(SECOND FROM NEW.ptwwsEndTimeThree) AS INTEGER)) > seccheck THEN
		RAISE EXCEPTION 'Time cannot contain seconds!';		
	END IF;	
	RETURN NEW;
END;
$$ LANGUAGE plpgsql;


DROP TRIGGER IF EXISTS check_PTWWSOPERATIONTIME ON PTDaySchedule CASCADE;
CREATE TRIGGER check_PTWWSOPERATIONTIME
Before UPDATE OR INSERT ON PTDaySchedule
FOR EACH ROW
EXECUTE PROCEDURE checkPTWWSOPERATIONTIME();


CREATE OR REPLACE FUNCTION checkFoodLimit()
RETURNS TRIGGER AS $$
DECLARE foodlimit integer;
BEGIN
	SELECT f1.dailylimit - f1.ordercounter INTO foodlimit
	FROM FoodItem f1
	WHERE f1.foodid = NEW.foodid;
	IF foodlimit < 0 THEN
		RAISE EXCEPTION 'Exceed food limit!';
	END IF;
	RETURN NEW;
END;
$$ LANGUAGE plpgsql;


DROP TRIGGER IF EXISTS check_FoodLimit ON FoodItem CASCADE;
CREATE TRIGGER check_FoodLimit
AFTER UPDATE OR INSERT ON FoodItem
FOR EACH ROW
EXECUTE PROCEDURE checkFoodLimit();










