drop table if exists agendamentos;
create table if not exists agendamentos(
	id serial primary key,
	name varchar(50),
	profissional varchar(100),
	tempo integer,
	data date,
	consulta bool
);
select * from agendamentos;