INSERT INTO Billboards (Date, StartTime, EndTime, MovieId, RoomId, Status)
VALUES (GETDATE(), '14:00', '16:00', 1, 1, 1);


INSERT INTO Movies (Name, Genre, AllowedAge, LengthMinutes, Status)
VALUES ('Inception', 4, 13, 148, 1);

INSERT INTO Rooms (Name, Number, Status)
VALUES ('Sala 1', 1, 1);




select * from Movies;

select * from Rooms;

select * from Billboards;

SELECT Id FROM Movies;

SELECT Id FROM Rooms;

SELECT * FROM Billboards WHERE Id = 3;

INSERT INTO Movies (Name, Genre, AllowedAge, LengthMinutes, Status)
VALUES 
  ('It', 5, 16, 135, 1),        -- HORROR = 5 en tu enum
  ('Matrix', 9, 13, 136, 1);   

  INSERT INTO Rooms (Name, Number, Status)
VALUES 
  ('Sala A', 1, 1),
  ('Sala B', 2, 1);

  INSERT INTO Seats (Number, RowNumber, RoomId, Status)
VALUES 
(1,1,1,1),
(2,1,1,1),
(1,1,2,1),
(2,1,2,1);

INSERT INTO Customers (DocumentNumber, Name, Lastname, Age, PhoneNumber, Email, Status)
VALUES
('CUST001','Juan','Pérez',30,'0991234567','juanp@mail.com',1),
('CUST002','Ana','Gómez',25,'0997654321','anag@mail.com',1);

INSERT INTO Billboards (Date, StartTime, EndTime, MovieId, RoomId, Status)
VALUES
(GETDATE(), '14:00','16:00', 1, 1, 1),  -- “It” en Sala A
(GETDATE(), '18:00','20:00', 2, 2, 1);

INSERT INTO Bookings (Date, CustomerId, SeatId, BillboardId, Status)
VALUES
(GETDATE(), 1, 1, 3, 1),
(GETDATE(), 2, 3, 4, 1);

SELECT Id FROM Billboards;