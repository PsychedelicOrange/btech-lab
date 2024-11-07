create table PERSON(driver_id varchar(5),name varchar(50),address varchar(100), PRIMARY KEY (driver_id));
create table CAR(regno varchar(20),model varchar(30),Year int,PRIMARY KEY (regno));
create table ACCIDENT(report_number int,accd_date date,location varchar(50),PRIMARY KEY (report_number));
create table OWNS(driver_id varchar(5),regno varchar(20),FOREIGN KEY (driver_id) REFERENCES PERSON(driver_id),FOREIGN KEY (regno) REFERENCES CAR(regno));
create table PARTICIPATED(driver_id varchar(5),regno varchar(20),report_number int,damage_amount int, FOREIGN KEY (driver_id) REFERENCES PERSON(driver_id), FOREIGN KEY (regno) REFERENCES CAR(regno), FOREIGN KEY (report_number) REFERENCES ACCIDENT(report_number), PRIMARY KEY (driver_id,regno,report_number));
insert into PERSON values(42069,'elon','texas');
insert into PERSON values(0,'riddhi','newyork');
insert into PERSON values(1,'noddy','toyland');
insert into PERSON values(2,'doraemon','tokyo');
insert into PERSON values(3,'kimjongun','northkorea');
insert into CAR values(42,'tesla',2013);
insert into CAR values(2,'timemachine',0000);
insert into CAR values(1,'rarefiat',1969);
insert into CAR values(3,'maybach',1974);
insert into CAR values(0,'wagnor',2017);
insert into ACCIDENT values(0,'18-MAR-2008','toyland');
insert into ACCIDENT values(1,'18-APR-2020','pyangyong');
insert into ACCIDENT values(2,'21-JAN-2008','wormhole');
insert into ACCIDENT values(5,'19-APR-2020','pyangyong');
insert into ACCIDENT values(6,'19-APR-2020','pyangyong');
insert into OWNS values(42069,42);
insert into OWNS values(0,0);
insert into OWNS values(1,1);
insert into OWNS values(2,2);
insert into OWNS values(3,3);
insert into PARTICIPATED values(3,3,1,9000);
insert into PARTICIPATED values(3,3,5,18000);
insert into PARTICIPATED values(3,3,6,8000);
insert into PARTICIPATED values(2,2,2,10);
insert into PARTICIPATED values(1,1,0,20);
--lab4 q1
select count(*) "num_people"
from ACCIDENT NATURAL JOIN PARTICIPATED
where extract(year from accd_date) = '2008';
--lab4 q2
select count(*) "model maybach accidents"
from CAR NATURAL JOIN PARTICIPATED
where model = 'maybach';
--lab4 q3
select name as OWNER_NAME,count(driver_id) as "No. of Accidents",sum(damage_amount) as "Total Damage Amount"
from PERSON NATURAL JOIN PARTICIPATED
group by name,driver_id
order by sum(damage_amount) DESC;
--lab4 q4
select driver_id as "q4"
from PARTICIPATED NATURAL JOIN ACCIDENT
group by driver_id,extract(year from accd_date)
having count(driver_id) > 2;
--lab4 q5 
select name from PERSON
MINUS 
name from PERSON NATURAL JOIN 