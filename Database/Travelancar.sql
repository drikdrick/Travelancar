CREATE DATABASE travelancar
USE  travelancar

CREATE TABLE admin(
id_admin INT PRIMARY KEY,
PASSWORD INT,
username VARCHAR(50)
);

INSERT INTO admin VALUES (01,12345,'admin1');

CREATE TABLE customer(
id_customer INT PRIMARY KEY,
nama VARCHAR(50),
usia INT,
no_tlp INT,
alamat VARCHAR(250),
email VARCHAR(50)
);

INSERT INTO customer VALUES (1,'fitri',19,081211334422,'tarutung','fi@gmail.com');

CREATE TABLE akun(
sandi INT PRIMARY KEY,
nama VARCHAR(50),
alamat VARCHAR(250),
tgl_lahir DATE ,
jenis_kelamin VARCHAR (12)
);

INSERT INTO akun VALUES (020202,'fitri','tarutung','06/05/2000','perempuan');

CREATE TABLE tiket_pesawat(
id_tiket INT PRIMARY KEY,
id_admin INT,
jenis_pesawat VARCHAR(50),
harga INT,
tgl_berangkat DATE,
waktu_tempuh  TIME,
tujuan VARCHAR(250),
no_penerbangan INT,
no_bangku INT,
jlh_penumpang INT,
CONSTRAINT id_admin FOREIGN KEY (id_admin) REFERENCES admin (id_admin)
);

INSERT INTO tiket_pesawat VALUES (101,01,'puyuh air',900000,2020-05-09,01.20,'jakarta',12,23,10);

CREATE TABLE hotel(
id_hotel INT PRIMARY KEY,
id_adm INT,
nama_hotel VARCHAR(50),
harga INT,
alamat VARCHAR(250),
CONSTRAINT id_adm FOREIGN KEY (id_adm) REFERENCES admin (id_admin)
);

INSERT INTO hotel VALUES (009,01,'hotel mawar melati',350000,'medan');


CREATE TABLE bank(
id_bank INT PRIMARY KEY,
sandi INT,
username VARCHAR(50),
jenis_pembayaran VARCHAR(50),
CONSTRAINT sandi FOREIGN KEY (sandi) REFERENCES akun (sandi)
);

INSERT INTO bank VALUES (0101,020202,'fitri','bank bung');


CREATE TABLE booking_tiket(
id_order_tiket INT PRIMARY KEY,
id_tiket INT,
id_customer INT,
id_bank INT,
tgl_order DATE,
CONSTRAINT id_tiket FOREIGN KEY (id_tiket) REFERENCES tiket_pesawat (id_tiket),
CONSTRAINT id_customer FOREIGN KEY (id_customer) REFERENCES customer (id_customer),
CONSTRAINT id_bank FOREIGN KEY (id_bank) REFERENCES bank (id_bank)
);




CREATE TABLE booking_hotel(
id_booking_htl INT PRIMARY KEY,
id_hotel INT,
id_cst INT,
id_bank_htl INT,
tgl_booking DATE,
CONSTRAINT id_hotel FOREIGN KEY (id_hotel) REFERENCES hotel (id_hotel),
CONSTRAINT id_cst FOREIGN KEY (id_cst) REFERENCES customer (id_customer),
CONSTRAINT id_bank_htl FOREIGN KEY (id_bank_htl) REFERENCES bank (id_bank)
);

INSERT INTO booking_tiket VALUES (335,009,1,0101,'2020/05/06');

CREATE TABLE bukti_pembayaran(
id_pembayaran INT PRIMARY KEY,
id_bank_pbyr INT,
id_order_tiket INT,
id_booking_htl INT,
tgl_pembayaran DATE,
CONSTRAINT id_bank_pbyr FOREIGN KEY (id_bank_pbyr) REFERENCES bank (id_bank),
CONSTRAINT id_order_tiket FOREIGN KEY (id_order_tiket) REFERENCES booking_tiket (id_order_tiket),
CONSTRAINT id_booking_htl FOREIGN KEY (id_booking_htl) REFERENCES booking_hotel (id_booking_htl)
);











