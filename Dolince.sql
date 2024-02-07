CREATE TABLE ADDRESSES(
address_id int PRIMARY KEY IDENTITY(1,1),
country varchar(64) NOT NULL,
state nvarchar(45) NULL,
city nvarchar(85) NOT NULL,
postal_code nvarchar(16) NOT NULL,
company_name nvarchar(64) NULL,
ad_line1 nvarchar(128) NOT NULL,
ad_line2 nvarchar(128) NOT NULL);

CREATE TABLE USERS(
user_id int PRIMARY KEY IDENTITY(1,1),
lastname nvarchar(128) NOT NULL,
firstname nvarchar(128) NOT NULL,
username nvarchar(24) NOT NULL,
gender char(1) NOT NULL,
email nvarchar(256) NOT NULL,
phone_number int NOT NULL,
address_id int NOT NULL FOREIGN KEY (address_id) REFERENCES ADDRESSES (address_id));

CREATE TABLE ESTATES(
estate_id int PRIMARY KEY IDENTITY(1,1),
type nvarchar(24) NOT NULL,
name nvarchar(128) NOT NULL ,
description ntext NULL ,
size nvarchar(16) NOT NULL ,
availability nvarchar(16) NULL ,
contact nvarchar(128) NULL ,
address_id int NOT NULL FOREIGN KEY (address_id) REFERENCES ADDRESSES (address_id),
owner_id int NOT NULL FOREIGN KEY (owner_id) REFERENCES USERS (user_id),
manager_id int NOT NULL FOREIGN KEY (manager_id) REFERENCES USERS (user_id));

CREATE TABLE AMENETIES(
amenetie_id int PRIMARY KEY IDENTITY(1,1),
name nvarchar(128) NOT NULL,
description nvarchar(512) NULL,
photo varbinary(MAX) NULL,
estate_id int NOT NULL FOREIGN KEY (estate_id) REFERENCES ESTATES (estate_id));

CREATE TABLE LISTINGS(
listing_id int PRIMARY KEY IDENTITY(1,1),
estate_id int NOT NULL FOREIGN KEY (estate_id) REFERENCES ESTATES (estate_id),
type nvarchar(24) NOT NULL,
price money NOT NULL,
status nvarchar(16) NOT NULL,
date_listed datetime2(0) NOT NULL);

CREATE TABLE INQUERYS(
inquiry_id int PRIMARY KEY IDENTITY(1,1),
type nvarchar(24) NOT NULL,
date date NOT NULL,
status nvarchar(16) NULL DEFAULT 'CREATED',
details ntext NOT NULL,
user_id int NOT NULL FOREIGN KEY (user_id) REFERENCES USERS (user_id),
listing_id int NOT NULL FOREIGN KEY (listing_id) REFERENCES LISTINGS (listing_id));

-------------------------------------------------------------------------------------------------------

INSERT INTO ADDRESSES(country, state, city, postal_code, company_name, ad_line1, ad_line2) 
VALUES
('United States', 'California', 'Los Angeles', '90001', NULL, '123 Main St', 'Apt 4'),
('Canada', 'Ontario', 'Toronto', 'M5V 2L7', 'ABC Corporation', '456 Bay St', 'Suite 800'),
('United Kingdom', 'England', 'London', 'WC2N 5DU', 'XYZ Inc', '10 Downing St', NULL),
('Australia', 'Victoria', 'Melbourne', '3000', '123 Pty Ltd', '111 Collins St', 'Level 27'),
('New Zealand', 'Auckland', 'Auckland City', '1010', NULL, '1 Queen St', 'Level 4'),
('France', 'Île-de-France', 'Paris', '75001', 'Acme SA', '1 Rue de Rivoli', NULL),
('Japan', 'Tokyo', 'Shinjuku City', '160-0022', 'GHI Corporation', '2 Chome-2-1 Yoyogi', 'Shibuya City'),
('Brazil', 'São Paulo', 'São Paulo', '04578-000', 'JKL Ltd', 'Av. Eng. Luís Carlos Berrini, 105', 'Sala 1601'),
('South Africa', 'Gauteng', 'Johannesburg', '2000', 'MNO Holdings', '1 Sandton Dr', NULL),
('India', 'Maharashtra', 'Mumbai', '400001', 'PQR Solutions', 'Chhatrapati Shivaji Terminus Area', 'Maharshi Karve Rd'),
('Russia', 'Moscow', 'Moscow', '101000', 'STU Corp', 'Red Square', NULL),
('China', 'Beijing', 'Dongcheng', '100000', 'VWX Corporation', 'Tiananmen Square', NULL),
('Germany', 'Berlin', 'Berlin', '10115', 'YZA GmbH', 'Unter den Linden 77', NULL),
('Spain', 'Madrid', 'Madrid', '28014', 'BCD S.L.', 'Calle Gran Vía, 1', NULL),
('Italy', 'Lazio', 'Rome', '00118', 'EFG SpA', 'Piazza del Colosseo, 1', NULL);

INSERT INTO USERS (lastname, firstname, username, gender, email, phone_number, address_id)
VALUES
('Smith', 'John', 'j.smith', 'M', 'j.smith@email.com', 1234567890, 1),
('Doe', 'Jane', 'j.doe', 'F', 'j.doe@email.com', 2345678901, 2),
('Johnson', 'Alex', 'a.johnson', 'M', 'a.johnson@email.com', 3456789012, 3),
('Williams', 'Emily', 'e.williams', 'F', 'e.williams@email.com', 4567890123, 4),
('Brown', 'William', 'w.brown', 'M', 'w.brown@email.com', 5678901234, 5),
('Garcia', 'Isabella', 'i.garcia', 'F', 'i.garcia@email.com', 6789012345, 6),
('Lee', 'David', 'd.lee', 'M', 'd.lee@email.com', 7890123456, 7),
('Jones', 'Ava', 'a.jones', 'F', 'a.jones@email.com', 8901234567, 8),
('Davis', 'Oliver', 'o.davis', 'M', 'o.davis@email.com', 9012345678, 9),
('Wilson', 'Sophia', 's.wilson', 'F', 's.wilson@email.com', 1234567890, 10),
('Anderson', 'Ethan', 'e.anderson', 'M', 'e.anderson@email.com', 2345678901, 11),
('Thomas', 'Emma', 'e.thomas', 'F', 'e.thomas@email.com', 3456789012, 12),
('Jackson', 'Noah', 'n.jackson', 'M', 'n.jackson@email.com', 4567890123, 13),
('White', 'Avery', 'a.white', 'F', 'a.white@email.com', 5678901234, 14),
('Harris', 'Elijah', 'e.harris', 'M', 'e.harris@email.com', 6789012345, 15);

INSERT INTO ESTATES (type, name, description, size, avalibility, contact, address_id, owner_id, manager_id)
VALUES 
('Apartment', 'Luxury Apartment in LA', 'Spacious and modern apartment with great views', '1500 sqft', 'Available', 'John Smith', 1, 2, 3),
('House', 'Beautiful House in New York', 'Charming house with garden in the heart of the city', '2000 sqft', 'Available', 'Jane Doe', 2, 3, 4),
('Apartment', 'Cozy Apartment in Toronto', 'Comfortable and affordable apartment in a great location', '1000 sqft', 'Not Available', 'Bob Johnson', 3, 1, 5),
('House', 'Mansion in London', 'Grand mansion with spacious rooms and beautiful gardens', '8000 sqft', 'Available', 'Kate Wilson', 4, 5, 2),
('Townhouse', 'Modern Townhouse in Melbourne', 'Stylish and contemporary townhouse in a popular neighborhood', '1800 sqft', 'Available', 'Alex Wong', 5, 4, 1),
('Apartment', 'Spacious Apartment in LA', 'Large and comfortable apartment with great amenities', '2000 sqft', 'Not Available', 'Maria Perez', 1, 5, 2),
('House', 'Beautiful House in New York', 'Lovely house with plenty of character and natural light', '1500 sqft', 'Available', 'David Lee', 2, 1, 4),
('Apartment', 'Modern Apartment in Toronto', 'Sleek and contemporary apartment in a new building', '1200 sqft', 'Available', 'Samantha Smith', 3, 2, 5),
('Villa', 'Luxury Villa in London', 'Gorgeous villa with stunning views and luxurious amenities', '10000 sqft', 'Not Available', 'Mark Johnson', 4, 3, 1),
('Apartment', 'Cosy Apartment in Melbourne', 'Warm and inviting apartment in a quiet street', '800 sqft', 'Available', 'Emily Brown', 5, 4, 2),
('Apartment', 'Luxury Apartment in the Heart of New York', 'This beautiful apartment is located in the heart of New York City and offers stunning views of Central Park.', '150 sqm', 'Available', 'john.doe@email.com', 2, 5, 3),
('House', 'Spacious Family Home in a Quiet Neighborhood', 'This lovely family home is located in a quiet neighborhood and has plenty of space for a growing family.', '300 sqm', 'Available', 'jane.doe@email.com', 1, 4, 3),
('Apartment', 'Charming Studio in Downtown Paris', 'This cozy studio is located in the heart of Paris and is perfect for a single person or a couple.', '50 sqm', 'Available', 'marie.curie@email.com', 7, 6, 8),
('Villa', 'Luxurious Beachfront Villa in Bali', 'This stunning beachfront villa in Bali offers breathtaking views of the ocean and is perfect for a tropical getaway.', '500 sqm', 'Not Available', NULL, 10, 9, 7),
('Apartment', 'Modern Apartment in the Heart of Shanghai', 'This stylish apartment in Shanghai is located in the bustling city center and offers all the amenities for a comfortable stay.', '100 sqm', 'Available', 'wei.zhang@email.com', 11, 12, 13);

INSERT INTO AMENETIES (name, description, photo, estate_id) 
VALUES
('Swimming Pool', 'Large swimming pool for residents to enjoy', NULL, 2),
('Fitness Center', 'State-of-the-art gym with personal trainers', NULL, 2),
('Community Garden', 'Beautifully landscaped garden with outdoor seating', NULL, 1),
('Pet Park', 'Fenced area for dogs to run and play', NULL, 3),
('Game Room', 'Fun game room with pool tables, arcade games, and more', NULL, 4),
('Rooftop Lounge', 'Spectacular views from the rooftop lounge', NULL, 5),
('Theater Room', 'Private theater room for residents to enjoy movies', NULL, 6),
('Conference Room', 'Fully-equipped conference room for business meetings', NULL, 7),
('Wine Cellar', 'Temperature-controlled wine cellar for storing and tasting wine', NULL, 8),
('Dog Wash Station', 'Convenient dog wash station for residents with pets', NULL, 9),
('Bike Storage', 'Secure bike storage for residents who commute by bike', NULL, 10),
('Sauna', 'Relaxing sauna for residents to unwind after a long day', NULL, 11),
('Yoga Studio', 'On-site yoga studio with daily classes', NULL, 12),
('Basketball Court', 'Full-sized basketball court for residents to play pick-up games', NULL, 13),
('24-Hour Concierge', 'Friendly and attentive staff available around the clock to assist residents', NULL, 14);

INSERT INTO LISTINGS (type, price, status, date_listed) 
VALUES
('Sale', 400000, 'Available', '2023-05-06 12:30:00'),
('Rent', 2000, 'Occupied', '2023-04-28 09:45:00'),
('Sale', 350000, 'Available', '2023-05-01 14:15:00'),
('Rent', 1200, 'Available', '2023-05-04 11:00:00'),
('Sale', 250000, 'Sold', '2023-04-15 16:20:00'),
('Rent', 1500, 'Occupied', '2023-05-02 08:00:00'),
('Sale', 500000, 'Available', '2023-05-06 10:00:00'),
('Rent', 1800, 'Available', '2023-05-05 15:30:00'),
('Sale', 450000, 'Available', '2023-05-03 13:00:00'),
('Sale', 700000, 'Available', '2023-05-01 11:30:00'),
('Rent', 2500, 'Occupied', '2023-04-29 12:00:00'),
('Sale', 600000, 'Available', '2023-04-30 10:45:00'),
('Rent', 1700, 'Occupied', '2023-05-05 09:00:00'),
('Sale', 350000, 'Available', '2023-05-02 16:15:00'),
('Rent', 2200, 'Available', '2023-05-01 09:30:00');

INSERT INTO INQUERYS (type, date, status, details, user_id, listing_id)
VALUES
('Rental', '2022-01-01', 'CREATED', 'Interested in renting a two-bedroom apartment.', 1, 1),
('Sale', '2022-02-02', 'CREATED', 'Interested in buying a house with a backyard.', 2, 2),
('Rental', '2022-03-03', 'IN PROGRESS', 'Need more information about the amenities included in the apartment complex.', 3, 3),
('Sale', '2022-04-04', 'IN PROGRESS', 'Interested in scheduling a showing of the property.', 4, 4),
('Rental', '2022-05-05', 'CLOSED', 'No longer interested in renting.', 5, 5),
('Sale', '2022-06-06', 'CLOSED', 'Made an offer on the property.', 1, 6),
('Rental', '2022-07-07', 'CREATED', 'Interested in renting a one-bedroom apartment.', 2, 7),
('Sale', '2022-08-08', 'CREATED', 'Looking for a house with a pool.', 3, 8),
('Rental', '2022-09-09', 'IN PROGRESS', 'Need to see pictures of the inside of the apartment.', 4, 9),
('Sale', '2022-10-10', 'IN PROGRESS', 'Interested in knowing the property taxes on the house.', 5, 10),
('Rental', '2022-11-11', 'CLOSED', 'Found a different apartment to rent.', 1, 11),
('Sale', '2022-12-12', 'CLOSED', 'Accepted an offer on the property.', 2, 12),
('Rental', '2023-01-01', 'CREATED', 'Need to know if pets are allowed in the apartment complex.', 3, 13),
('Sale', '2023-02-02', 'CREATED', 'Interested in scheduling a showing of the property.', 4, 14),
('Rental', '2023-03-03', 'IN PROGRESS', 'Need more information about the lease terms.', 5, 15);

-------------------------------------------------------------------------------------------------------

SELECT L.listing_id, E.type 
FROM LISTINGS AS L 
INNER JOIN ESTATES AS E ON L.estate_id = E.estate_id;

SELECT E.estate_id, E.name 
FROM ESTATES E 
WHERE EXISTS (SELECT * FROM AMENETIES	 A WHERE A.estate_id = E.estate_id);

SELECT * 
FROM INQUERYS 
WHERE status = 'CREATED';

SELECT U.* 
FROM USERS U 
WHERE EXISTS (SELECT * FROM ESTATES E WHERE E.owner_id = U.user_id);

SELECT AVG(price) 
FROM LISTINGS;

SELECT TOP 5 * 
FROM ESTATES 
ORDER BY size DESC;

SELECT L.estate_id, COUNT(*) 
FROM LISTINGS L 
INNER JOIN INQUERYS I ON L.listing_id = I.listing_id 
GROUP BY L.estate_id;

SELECT * 
FROM LISTINGS 
WHERE date_listed <= DATEADD(day, -30, GETDATE());

SELECT U.*, COUNT(*) as inquiry_count 
FROM USERS U 
INNER JOIN INQUERYS I ON U.user_id = I.user_id 
GROUP BY U.user_id 
ORDER BY inquiry_count DESC;

SELECT * 
FROM ESTATES 
WHERE address_id IN (SELECT address_id FROM ADDRESSES WHERE country = 'United States');

SELECT U.* 
FROM USERS U 
INNER JOIN INQUERYS I ON U.user_id = I.user_id 
WHERE I.status = 'COMPLETED';

SELECT E.type, COUNT(*) 
FROM ESTATES E 
INNER JOIN LISTINGS L ON E.estate_id = L.estate_id 
GROUP BY E.type;

SELECT L.* 
FROM LISTINGS L 
INNER JOIN AMENETIES A ON L.estate_id = A.estate_id 
WHERE A.name = 'Swimming pool';

SELECT I.* 
FROM INQUERYS I 
INNER JOIN USERS U ON I.user_id = U.user_id 
WHERE U.gender = 'F';

SELECT U.*, COUNT(*) as inquiry_count 
FROM USERS U 
INNER JOIN INQUERYS I ON U.user_id = I.user_id 
GROUP BY U.user_id;

SELECT E.* 
FROM ESTATES E 
WHERE E.manager_id = 1;

SELECT E.name AS estate_name, COUNT(L.listing_id) AS num_listings
FROM ESTATES E
LEFT JOIN LISTINGS L ON E.estate_id = L.estate_id
GROUP BY E.estate_id;

SELECT TOP 5 E.name, COUNT(L.listing_id) AS num_listings
FROM ESTATES AS E
LEFT JOIN LISTINGS AS L ON E.estate_id = L.estate_id
WHERE L.status = 'AVAILABLE'
GROUP BY E.estate_id, E.name
ORDER BY num_listings DESC;

SELECT U.lastname, U.firstname, U.email, COUNT(I.inquiry_id) AS num_inquiries
FROM USERS AS U
JOIN INQUERYS AS I ON U.user_id = I.user_id
JOIN LISTINGS AS L ON I.listing_id = L.listing_id
JOIN ESTATES AS E ON L.estate_id = E.estate_id
WHERE E.manager_id = 1234
GROUP BY U.user_id, U.lastname, U.firstname, U.email
ORDER BY num_inquiries DESC;

SELECT E.name, AVG(L.price) AS avg_price, ((AVG(L.price) / (SELECT AVG(price) FROM LISTINGS) - 1) * 100) AS price_diff_pct
FROM ESTATES AS E
JOIN LISTINGS AS L ON E.estate_id = L.estate_id
GROUP BY E.estate_id, E.name
ORDER BY price_diff_pct DESC;

-------------------------------------------------------------------------------------------------------

CREATE VIEW available_listings_with_amenities AS 
SELECT L.listing_id, L.title, L.description, L.price, A.name AS amenity_name
FROM LISTINGS AS L
LEFT JOIN ESTATES AS E ON L.estate_id = E.estate_id
LEFT JOIN AMENETIES AS A ON E.estate_id = A.estate_id
WHERE L.status = 'AVAILABLE';

CREATE VIEW estates_with_managers_and_listings_count AS
SELECT E.name AS estate_name, U.lastname AS manager_lastname, U.firstname AS manager_firstname, COUNT(L.listing_id) AS num_listings
FROM ESTATES AS E
JOIN USERS AS U ON E.manager_id = U.user_id
JOIN LISTINGS AS L ON E.estate_id = L.estate_id
GROUP BY E.estate_id, U.user_id;

CREATE VIEW estate_revenue AS
SELECT E.name AS estate_name, SUM(L.price) AS total_revenue
FROM ESTATES AS E
JOIN LISTINGS AS L ON E.estate_id = L.estate_id
WHERE L.status = 'SOLD'
GROUP BY E.estate_id;

CREATE VIEW inquiries_with_listing_and_user AS
SELECT I.inquiry_id, L.title, L.price, U.email AS user_email
FROM INQUERYS AS I
JOIN LISTINGS AS L ON I.listing_id = L.listing_id
JOIN USERS AS U ON I.user_id = U.user_id;

CREATE VIEW top_5_estates_by_avg_price AS	
SELECT TOP 5 E.name AS estate_name, AVG(L.price) AS avg_price
FROM ESTATES AS E
JOIN LISTINGS AS L ON E.estate_id = L.estate_id
GROUP BY E.estate_id, E.name
ORDER BY avg_price DESC;

CREATE VIEW estate_view AS
SELECT 
    E.type, 
    E.name, 
    E.description, 
    E.size, 
    E.avalibility, 
    E.contact, 
    CONCAT(A.country, ', ', A.city) AS address, 
    CONCAT(U.firstname, ' ', U.lastname) AS owner_name,
    CONCAT(M.firstname, ' ', M.lastname) AS manager_name
FROM ESTATES AS E
INNER JOIN ADDRESSES AS A ON E.address_id = A.address_id
INNER JOIN USERS AS U ON E.owner_id = U.user_id
INNER JOIN USERS AS M ON E.manager_id = M.user_id

CREATE VIEW listings_view AS
SELECT 
  L.type, 
  L.price, 
  L.status, 
  L.date_listed, 
  E.name AS estate_name,
  E.type AS estate_type,
  E.size AS estate_size,
  E.avalibility AS estate_availability,
  CONCAT(U.firstname, ' ', U.lastname) AS manager
FROM LISTINGS AS L
INNER JOIN ESTATES AS E ON L.estate_id = E.estate_id
INNER JOIN USERS AS U ON E.manager_id = U.user_id;