-- =====================================================
-- Lab 10 - Database script
-- Run this on your SQL Server database (the same one
-- used in the connection string in the C# code).
-- =====================================================

-- ---------- Part 1 : users table ----------
CREATE TABLE [dbo].[usertable] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [username] VARCHAR (50) NULL,
    [userpass] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

-- Part 1 - Step 2 : sample user records
INSERT INTO usertable (username, userpass) VALUES ('ali',  '123');
INSERT INTO usertable (username, userpass) VALUES ('sara', '123');
INSERT INTO usertable (username, userpass) VALUES ('admin','admin');


-- ---------- Part 2 : book / bookorder / orderline tables ----------
CREATE TABLE [dbo].[book] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [title]        VARCHAR (50)  NULL,
    [description]  VARCHAR (50)  NULL,
    [price]        INT           NULL,
    [bookquantity] INT,
    [cata]         INT           NULL,
    [image]        VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[bookorder] (
    [Id]        INT          NOT NULL IDENTITY,
    [custname]  VARCHAR (50) NOT NULL,
    [orderdate] DATE         NOT NULL DEFAULT (getdate()),
    [total]     INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[orderline] (
    [id]        INT          IDENTITY (1, 1) NOT NULL,
    [itemname]  VARCHAR (50) NOT NULL,
    [itemquant] INT          NOT NULL,
    [itemprice] INT          NOT NULL,
    [orderid]   INT          NOT NULL,
    PRIMARY KEY ([id])
);

-- Part 2 - Step 2 : sample book records
-- cata: 1 = Sience Books, 2 = Programming Books, 3 = Math Books,
--       4 = IT Books,     5 = General Books,     6 = Data Books
INSERT INTO book (title, description, price, bookquantity, cata, image) VALUES
('The Psychology of Money',              'Timeless lessons on wealth, greed, and happiness',   100, 50, 1, 'cover1.jpg'),
('A Beginner Guide To The Stock Market', 'Everything You Need To Start Making Money Today',    100, 50, 1, 'cover2.jpg'),
('book6',                                'A short science book',                               100, 50, 1, 'cover1.jpg'),
('Learn C# Programming',                 'From basics to object oriented programming',         120, 40, 2, 'cover3.jpg'),
('Mobile Apps With MAUI',                'Build apps for Android, iOS and Windows',            150, 40, 2, 'cover4.jpg'),
('Calculus Made Easy',                   'A simple introduction to calculus',                   90, 30, 3, 'cover2.jpg'),
('Linear Algebra Basics',                'Vectors, matrices and their applications',            80, 30, 3, 'cover1.jpg'),
('Computer Networks',                    'How the internet and networks work',                 110, 25, 4, 'cover4.jpg'),
('Information Systems',                  'Managing information in modern business',            105, 25, 4, 'cover3.jpg'),
('Think And Grow Rich',                  'The classic book about success',                      70, 60, 5, 'cover2.jpg'),
('How To Own Your Own Mind',             'Lessons on thinking and self control',                75, 60, 5, 'cover1.jpg'),
('Intro To Databases',                   'SQL Server tables, keys and queries',                130, 35, 6, 'cover3.jpg'),
('Data Science Handbook',                'Working with data step by step',                     140, 35, 6, 'cover4.jpg');


-- ---------- Step 10 : verify data consistency after buying ----------
-- SELECT * FROM bookorder;
-- SELECT * FROM orderline;
-- SELECT * FROM book;
