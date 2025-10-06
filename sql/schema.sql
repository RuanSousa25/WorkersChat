drop schema workers_chat cascade;
create schema workers_chat;
set search_path to workers_chat;

create table chat_message(
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	message TEXT not null,
	prev_message INTEGER,
	constraint fk_prev foreign key (prev_message) references chat_message(id)
);

create table worker_entity(
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	message_id integer,
	born_date TIMESTAMP default CURRENT_TIMESTAMP,
	death_date TIMESTAMP,
	constraint fk_message foreign key (message_id) references chat_message(id)
);

create table word_types(
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	word_type TEXT not null );

create table words(
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	word TEXT not null,
	word_type_id integer not null,
	constraint fk_type foreign key (word_type_id) references word_types(id)
);

insert into word_types(word_type) values ('pronome'),('substantivo'), ('verbo'), ('adjetivo'), ('adverbio');

insert into words(word, word_type_id)
values ('eu', 1), ('você', 1), ('vocês', 1),('nós', 1), ('eles', 1), ('elas', 1);
insert into words(word, word_type_id) 
values ('água', 2), ('máquinas', 2), ('humanos', 2), ('matemática', 2), ('computação', 2), ('ciência', 2), ('engenharia', 2), ('vida', 2), ('morte', 2);
insert into words(word, word_type_id)
values ('amar', 3), ('estudar', 3), ('odiar', 3), ('viver', 3), ('escolher', 3), ('vencer', 3), ('morrer', 3), ('destruir', 3), ('pensar', 3), ('enganar', 3), ('ajudar', 3), ('ser', 3);