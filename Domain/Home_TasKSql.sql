create table courses
(
	id serial primary key,
	name varchar(50) not null,
	description varchar(100),
	fee decimal,
	duration int,
	startdate date,
	enddate date,
	studentlimit int
)

create table groups
(
	id serial primary key,
	name varchar(50) not null,
	description varchar(100),
	course_id int references courses(id)
)
create table mentros
(
	id serial primary key,
	firstname varchar(50) not null,
	lastname varchar(50),
	phone varchar(30) unique,
	address varchar(100),
	city varchar
)

create table students
(
	id serial primary key,
	firstname varchar(50) not null,
	lastname varchar(50),
	phone varchar(50) unique,
	address varchar(100),
	city varchar
)

create table student_group
(
	id serial primary key,
	student_id int references students(id),
	group_id int references groups(id)
)

create table mentor_group
(
	id serial primary key,
	mentor_id int references mentros(id),
	group_id int references groups(id)
)
select * from courses
select * from groups
select * from mentros

alter table students
drop column email