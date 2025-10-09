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
create table transitivity_group(
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	transitivity_group TEXT NOT NULL
);
create table conjugation_group(
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	conjugation_group TEXT NOT NULL
);
create table gender_group(
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	gender_group TEXT NOT NULL
);

create table word_types(
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	word_type TEXT not null );

create table words(
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	word TEXT not null,
	word_type_id integer not null,
	conjugation_group_id integer,
	gender_group_id integer,
	transitivity_group_id integer,
	constraint fk_type foreign key (word_type_id) references word_types(id),
	constraint fk_conjugation foreign key (conjugation_group_id) references conjugation_group(id),
	constraint fk_gender foreign key (gender_group_id) references gender_group(id),
	constraint fk_transitivity foreign key (transitivity_group_id) references transitivity_group(id)
);
insert into transitivity_group(transitivity_group) values ('transitivo direto'), ('transitivo indireto'), ('intransitivo');
insert into conjugation_group(conjugation_group) values ('primeira_singular'), ('primeira_plural'), ('terceira_singular'), ('terceira_plural');
insert into gender_group(gender_group) values ('neutro'), ('feminino'), ('masculino');
insert into word_types(word_type) values ('pronome'),('substantivo'), ('verbo'), ('adjetivo'), ('adverbio');

insert into words(word, word_type_id, conjugation_group_id, gender_group_id)
values ('eu', 1, 1, 1), ('você', 1, 3, 1), ('vocês', 1, 4, 1),('nós', 1, 2, 1), ('elu', 1, 3, 1),('ele', 1, 3, 3), ('ela', 1, 3, 2), ('elus', 1, 4, 1),('eles', 1, 4, 3), ('elas', 1, 4, 2);
insert into words(word, word_type_id) 
values ('água', 2), ('máquinas', 2), ('humanos', 2), ('matemática', 2), ('computação', 2), ('ciência', 2), ('engenharia', 2), ('vida', 2), ('morte', 2);
insert into words(word, word_type_id,  conjugation_group_id, transitivity_group_id)
values 
('amo', 3, 1, 1), ('amamos', 3, 2, 1),  ('ama', 3, 3, 1),   ('amam', 3, 4, 1), 
('estudo', 3, 1, 1), ('estudamos', 3, 2, 1), ('estuda', 3, 3, 1), ('estudam', 3, 4, 1), 
('odeio', 3, 1, 1), ('odiamos', 3, 2, 1), ('odeia', 3, 3, 1), ('odeiam', 3, 4, 1),
('vivo', 3, 1, 3), ('vivemos', 3, 2, 3), ('vive', 3, 3, 3), ('vivem', 3, 4, 3),
('escolho', 3, 1, 1), ('escolhemos', 3, 2, 1), ('escolhe', 3, 3, 1), ('escolhem', 3, 4, 1),
('venço', 3, 1, 1), ('vencemos', 3, 2, 1), ('vence', 3, 3, 1), ('vencem', 3, 4, 1),
('morro', 3, 1, 3), ('morremos', 3, 2, 3), ('morre', 3, 3, 3), ('morrem', 3, 4, 3),
('destruo', 3, 1, 1), ('destruímos', 3, 2, 1), ('destrói', 3, 3, 1), ('destroem', 3, 4, 1),
('penso', 3, 1, 3), ('pensamos', 3, 2, 3), ('pensa', 3, 3, 3), ('pensam', 3, 4, 3),
('engano', 3, 1, 1), ('enganamos', 3, 2, 1), ('engana', 3, 3, 1), ('enganam', 3, 4, 1),
('ajudo', 3, 1, 1), ('ajudamos', 3, 2, 1), ('ajuda', 3, 3, 1), ('ajudam', 3, 4, 1),
('sou', 3, 1, 3), ('somos', 3, 2, 3), ('é', 3, 3, 3), ('são', 3, 4, 3);


