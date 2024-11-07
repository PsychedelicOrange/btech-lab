create table PERSON(driver_id varchar(5),name varchar(50),address varchar(100), PRIMARY KEY (driver_id));
create table CAR(regno varchar(20),model varchar(30),Year int,PRIMARY KEY (regno));
create table ACCIDENT(report_number varchar(20),accd_date date,location varchar(50),PRIMARY KEY (report_number));
create table OWNS(driver_id varchar(5),regno varchar(20),FOREIGN KEY (driver_id) REFERENCES PERSON(driver_id),FOREIGN KEY (regno) REFERENCES CAR(regno));
create table PARTICIPATED(driver_id varchar(5),regno varchar(20),report_number int,damage_amount int,FOREIGN KEY (driver_id) REFERENCES PERSON(driver_id),FOREIGN KEY (regno) REFERENCES CAR(regno),FOREIGN KEY (report_number) REFERENCES ACCIDENT(report_number),PRIMARY KEY (driver_id,regno,report_number));
insert into PERSON values(42069,'elon','texas');
insert into PERSON values(0,'riddhi','newyork');
insert into PERSON values(1,'noddy','toyland');
insert into PERSON values(2,'doraemon','tokyo');
insert into PERSON values(3,'kimjongun','northkorea');
insert into CAR values(42,'tesla',2013);
insert into CAR values(2,'timemachine',0000);
insert into CAR values(1,'rarefiat',1969);
insert into CAR values(3,'maybach',2015);
insert into CAR values(0,'wagnor',2017);
insert into ACCIDENT values(0,'18-MAR-2022','toyland');
insert into ACCIDENT values(1,'18-APR-2020','pyangyong');
insert into ACCIDENT values(2,'21-JAN-0015','wormhole');
insert into ACCIDENT values(3,'20-MAR-2013','texas');
insert into ACCIDENT values(5,'19-APR-2020','pyangyong');
insert into OWNS values(42069,42);
insert into OWNS values(0,0);
insert into OWNS values(1,1);
insert into OWNS values(2,2);
insert into OWNS values(3,3);
insert into PARTICIPATED values(42069,0,3,10000);
insert into PARTICIPATED values(3,3,1,9000);
insert into PARTICIPATED values(3,3,5,18000);
insert into PARTICIPATED values(2,2,2,10);
insert into PARTICIPATED values(1,1,0,20);