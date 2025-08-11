-- 1. Create the database
CREATE DATABASE ClubMember;
GO

-- 2. Switch to the new database
USE ;
GO

-- 3. Create the ClubMembership table
CREATE TABLE ClubMembership (
    Id INT IDENTITY(1,1) PRIMARY KEY,  -- auto-increment primary key
    FullName NVARCHAR(100) NOT NULL,   -- student's full name
    ClubName NVARCHAR(20) NOT NULL CHECK (ClubName IN ('Blue Sky', 'Rotary', 'Red Hat', 'Spicy')), -- only these options allowed
    Age INT NOT NULL CHECK (Age BETWEEN 16 AND 120), -- sensible age range
    MembershipFee DECIMAL(10,2) NOT NULL CHECK (MembershipFee >= 0) -- positive fee
);
GO

