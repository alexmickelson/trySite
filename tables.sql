CREATE DATABASE testdb;
CREATE USER admin WITH PASSWORD 'admin';
GRANT ALL PRIVILEGES ON DATABASE testdb TO admin;
CREATE SCHEMA zharbor;

create table zharbor.buyer (
    id numeric(18,0) primary key not null ,
    buyerName varchar(50),
    buyerAddress varchar(50),
    phone varchar(12),
    email varchar(50)
    );

--id, displayName, taxid, legalName, phone, email, sellerAddress
create table zharbor.seller (
    id numeric(18,0) primary key not null ,
    displayName varchar(50),
    taxid numeric(18,0),
    legalName varchar(50),
    phone varchar(12),
    email varchar(50),
    sellerAddress varchar(50)
    );

--id, sellerid, itemid, startDate, endDate, minBid, buyout
create table zharbor.auction (
    id numeric(18,0) primary key not null,
    sellerid numeric (18,0) references zharbor.seller(id) not null,
    item text not null,
    startDate timestamp,
    endDate timestamp,
    minBid numeric(18,2),
    buyout numeric (18,2),
    currentStatus varchar(20) not null,
    topBuyerid numeric(18,0) references zharbor.buyer(id),
    topEffBid numeric (18,2)
    );

--auctionid, buyerid, bid, bidDate
create table zharbor.maxUserBid (
    auctionid numeric (18,0) references zharbor.auction(id) not null,
    buyerid numeric (18,0) references zharbor.buyer(id) not null,
    bid numeric (18,2) not null,
    bidDate timestamp not null
    );

--id, auctionid, buyerid, bid, bidDate
create table zharbor.effectiveBidHistory (
    id numeric(18,0) primary key not null,
    auctionid numeric(18,0) references zharbor.auction(id) not null,
    buyerid numeric (18,0) references zharbor.buyer(id) not null,
    bid numeric (18,2) not null,
    bidDate timestamp not null
    );


create table zharbor.sellerFee (
    id numeric(18,0) primary key not null,
    sellerid numeric(18,0) references zharbor.seller(id) not null,
    amount numeric(18,2) not null,
    feeType varchar(20) not null,
    auctionid numeric(18,0) references zharbor.auction(id) not null,
    chargeDate timestamp
    );


insert into zharbor.buyer values (1, "tom");
insert into zharbor.buyer values (2, "tom");
insert into zharbor.buyer values (3, "tom");
insert into zharbor.buyer values (4, "tom");
insert into zharbor.buyer values (5, "tom");
insert into zharbor.buyer values (7, "tom");

    commit;