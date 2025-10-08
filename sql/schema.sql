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

create table conjugation_group(
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	conjugation_group TEXT NOT NULL
);

create table word_types(
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	word_type TEXT not null );

create table words(
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	word TEXT not null,
	word_type_id integer not null,
	conjugation_group_id integer,
	constraint fk_type foreign key (word_type_id) references word_types(id),
	constraint fk_conjugation foreign key (conjugation_group_id) references conjugation_group(id)
);

insert into conjugation_group(conjugation_group) values ('primeira_singular'), ('primeira plural'), ('terceira_singular'), ('terceira_plural');
insert into word_types(word_type) values ('pronome'),('substantivo'), ('verbo'), ('adjetivo'), ('adverbio');

insert into words(word, word_type_id, conjugation_group_id)
values ('eu', 1, 1), ('você', 1, 3), ('vocês', 1, 4),('nós', 1, 2), ('ele', 1, 3), ('ela', 1, 3), ('eles', 1, 4), ('elas', 1, 4);
insert into words(word, word_type_id) 
values ('água', 2), ('máquinas', 2), ('humanos', 2), ('matemática', 2), ('computação', 2), ('ciência', 2), ('engenharia', 2), ('vida', 2), ('morte', 2);
insert into words(word, word_type_id,  conjugation_group_id)
values 
('amo', 3, 1), ('amamos', 3, 2),  ('ama', 3, 3),   ('amam', 3, 4), 
('estudo', 3, 1), ('estudamos', 3, 2), ('estuda', 3, 3), ('estudam', 3, 4), 
('odeio', 3, 1), ('odiamos', 3, 2), ('odeia', 3, 3), ('odeiam', 3, 4),
('vivo', 3, 1), ('vivemos', 3, 2), ('vive', 3, 3), ('vivem', 3, 4),
('escolho', 3, 1), ('escolhemos', 3, 2), ('escolhe', 3, 3), ('escolhem', 3, 4),
('venço', 3, 1), ('vencemos', 3, 2), ('vence', 3, 3), ('vencem', 3, 4),
('morro', 3, 1), ('morremos', 3, 2), ('morre', 3, 3), ('morrem', 3, 4),
('destruo', 3, 1), ('destruímos', 3, 2), ('destrói', 3, 3), ('destroem', 3, 4),
('penso', 3, 1), ('pensamos', 3, 2), ('pensa', 3, 3), ('pensam', 3, 4),
('engano', 3, 1), ('enganamos', 3, 2), ('engana', 3, 3), ('enganam', 3, 4),
('ajudo', 3, 1), ('ajudamos', 3, 2), ('ajuda', 3, 3), ('ajudam', 3, 4),
('sou', 3, 1), ('somos', 3, 2), ('é', 3, 3), ('são', 3, 4);


