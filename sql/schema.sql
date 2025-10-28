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
create table person_group(
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	person_group TEXT NOT NULL
);
create table number_group(
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	number_group TEXT NOT NULL
);
create table gender_group(
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	gender_group TEXT NOT NULL
);
create table predicative_group(
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	predicative_group TEXT NOT NULL
	);

create table adverb_function_type(
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	adverb_function_type TEXT not null );

create table word_types(
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	word_type TEXT not null );

create table words(
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	word TEXT not null,
	word_type_id integer not null default 2,
	person_group_id integer default 1,
	number_group_id integer default 1,
	gender_group_id integer,
	transitivity_group_id integer default 1,
	predicative_group_id integer,
	artigo_definido boolean,
	adverb_function_type_id integer,
	implicit_object boolean,
	constraint fk_type foreign key (word_type_id) references word_types(id),
	constraint fk_person foreign key (person_group_id) references person_group(id),
	constraint fk_number foreign key (number_group_id) references number_group(id),
	constraint fk_gender foreign key (gender_group_id) references gender_group(id),
	constraint fk_transitivity foreign key (transitivity_group_id) references transitivity_group(id),
	constraint fk_predicative foreign key (predicative_group_id) references predicative_group(id),
	constraint fk_adverd_function foreign key (adverb_function_type_id) references adverb_function_type(id)
);

create table patterns (
	id INT generated always as identity primary key,
	name TEXT not null,
	description text
);

create table pattern_elements(
	id int generated always as identity primary key,
	element_type int not null
);

insert into predicative_group(predicative_group) values ('nenhum'),('verbal'), ('nominal'), ('verbo-nominal');
insert into transitivity_group(transitivity_group) values ('transitivo direto'), ('transitivo indireto'), ('intransitivo');
insert into person_group(person_group) values ('primeira'), ('terceira');
insert into number_group(number_group) values ('singular'), ('plural');
insert into gender_group(gender_group) values ('neutro'), ('feminino'), ('masculino');
insert into adverb_function_type(adverb_function_type) values ('lugar'), ('tempo'), ('afirmacao'), ('intensidade'), ('modo'), ('negacao'), ('duvida');
insert into word_types(word_type) values ('pronome'),('substantivo'), ('verbo'), ('adjetivo'), ('adverbio'), ('preposicao'), ('artigo');

insert into words(word, word_type_id, person_group_id, number_group_id, gender_group_id)
values ('eu', 1, 1, 1, null), ('você', 1, 2, 1, null), ('vocês', 1, 2, 2, null),('nós', 1, 1, 2, null), ('elu', 1, 2, 1, 1),('ele', 1, 2, 1, 3), ('ela', 1, 2, 1, 2), ('elus', 1, 2, 2, 1),('eles', 1, 2, 2, 3), ('elas', 1, 2, 2, 2);
insert into words(word, word_type_id, number_group_id, gender_group_id) 
values ('água', 2, 1, 2), ('máquinas', 2, 2, 2), ('humanos', 2, 2, 3), ('matemática', 2, 1, 2), ('computação', 2, 1, 2), ('ciência', 2, 1, 2), ('engenharia', 2, 1, 2), ('vida', 2, 1, 2), ('morte', 2, 1, 2),
('morango', 2, 1, 3), ('morangos', 2, 2, 3),('uva', 2, 1, 2), ('uvas', 2, 2, 2),('goiaba', 2, 1, 2), ('goiabas', 2, 2, 2),('manga', 2, 1, 2), ('mangas', 2, 2, 2),
('filme', 2, 1, 3), ('filmes', 2, 2, 3), ('série', 2, 1, 2), ('séries', 2, 2, 2), ('cinema', 2, 1, 3), ('folhas', 2, 2, 2);
insert into words(word, word_type_id, person_group_id, number_group_id, transitivity_group_id, predicative_group_id)
values 
('amo', 3, 1, 1, 1, 1), ('amamos', 3, 1, 2, 1, 1),  ('ama', 3, 2, 1, 1, 1),   ('amam', 3, 2, 2, 1, 1), 
('estudo', 3, 1, 1, 1, 1), ('estudamos', 3, 1, 2, 1, 1), ('estuda', 3, 2, 1, 1, 1), ('estudam', 3, 2, 2, 1, 1), 
('odeio', 3, 1, 1, 1, 1), ('odiamos', 3, 1, 2, 1, 1), ('odeia', 3, 2, 1, 1, 1), ('odeiam', 3, 2, 2, 1, 1),
('vivo', 3, 1, 1, 3, 1), ('vivemos', 3, 1, 2, 3, 1), ('vive', 3, 2, 1, 3, 1), ('vivem', 3, 2, 2, 3, 1),
('escolho', 3, 1, 1, 1, 1), ('escolhemos', 3, 1, 2, 1, 1), ('escolhe', 3, 2, 1, 1, 1), ('escolhem', 3, 2, 2, 1, 1),
('venço', 3, 1, 1, 1, 1), ('vencemos', 3, 1, 2, 1, 1), ('vence', 3, 2, 1, 1, 1), ('vencem', 3, 2, 2, 1, 1),
('morro', 3, 1, 1, 3, 1), ('morremos', 3, 1, 2, 3, 1), ('morre', 3, 2, 1, 3, 1), ('morrem', 3, 2, 2, 3, 1),
('destruo', 3, 1, 1, 1, 1), ('destruímos', 3, 1, 2, 1, 1), ('destrói', 3, 2, 1, 1, 1), ('destroem', 3, 2, 2, 1, 1),
('penso', 3, 1, 1, 1, 1), ('pensamos', 3, 1, 2, 1, 1), ('pensa', 3, 2, 1, 1, 1), ('pensam', 3, 2, 2, 1, 1),
('engano', 3, 1, 1, 1, 1), ('enganamos', 3, 1, 2, 1, 1), ('engana', 3, 2, 1, 1, 1), ('enganam', 3, 2, 2, 1, 1),
('ajudo', 3, 1, 1, 1, 1), ('ajudamos', 3, 1, 2, 1, 1), ('ajuda', 3, 2, 1, 1, 1), ('ajudam', 3, 2, 2, 1, 1),
('sou', 3, 1, 1, 3, 3), ('somos', 3, 1, 2, 3, 3), ('é', 3, 2, 1, 3, 3), ('são', 3,  2, 2, 3, 3),
('como', 3, 1, 1, 1, 1), ('comemos', 3, 1, 2, 1, 1), ('come', 3, 2, 1, 1, 1), ('comem', 3, 2, 2, 1, 1),
('gosto', 3, 1, 1, 2, 1), ('gostamos', 3, 1, 2, 2, 1), ('gosta', 3, 2, 1, 2, 1), ('gostam', 3, 2, 2, 2, 1),
('assisto', 3, 1, 1, 2, 1), ('assistimos', 3, 1, 2, 2, 1), ('assiste', 3, 2, 1, 2, 1), ('assistem', 3, 2, 2, 2, 1),
('faço', 3, 1, 1, 1, 1), ('fazemos', 3, 1, 2, 1, 1), ('faz', 3, 2, 1, 1, 1), ('fazem', 3, 2, 2, 1, 1),
('colho', 3, 1, 1, 1, 1), ('colhemos', 3, 1, 2, 1, 1), ('colhe', 3, 2, 1, 1, 1), ('colhem', 3, 2, 2, 1, 1);



insert into words(word, word_type_id, number_group_id, gender_group_id, artigo_definido)
values 
('a', 7, 1, 2, true), ('as', 7, 2, 2, true),
('e', 7, 1, 1, true), ('es', 7, 2, 1, true),
('o', 7, 1, 3, true), ('os', 7, 2, 3, true),
('uma', 7, 1, 2, false), ('umas', 7, 2, 2, false),
('ume', 7, 1, 1, false), ('umes', 7, 2, 1, false),
('um', 7, 1, 3, false), ('uns', 7, 2, 3, false);


insert into words(word, word_type_id, gender_group_id,number_group_id, predicative_group_id)
values
('engenheira',2,2,1,3), ('engenheiras',2,2,2,3),
('engenheire',2,1,1,3), ('engenheires',2,1,2,3),
('engenheiro',2,3,1,3), ('engenheiros',2,3,2,3),
('boa',2,2,1,3), ('boas',2,2,2,3),
('boe',2,1,1,3), ('boes',2,1,2,3),
('bom',2,3,1,3), ('bons',2,3,2,3),
('estudante',2,null,1,3), ('estudantes',2,null,2,3),
('feliz',2,null,1,3), ('felizes',2,null,2,3);
insert into words(word, word_type_id, adverb_function_type_id, implicit_object) values
('aqui', 5, 1, false), ('amanhã', 5, 2, false), (', sim', 5, 3, false), ('demais', 5, 4, false), ('de mansinho', 5, 5, false), (', não', 5, 6, false), (', quem sabe?', 5, 7, false);
insert into words(word, word_type_id, gender_group_id, number_group_id)
values
('bonite', 4, 1, 1), ('bonites', 4, 1, 2), ('bonita', 4, 2, 1), ('bonitas', 4, 2, 2),
('bonito', 4, 3, 1), ('bonitos', 4, 3, 2), ('melhor', 4, null, 1), ('melhores', 4, null, 2),
('pior', 4, null, 1), ('piores', 4, null, 2), ('ruim', 4, null, 1), ('ruins', 4, null, 2),
('rosa', 4, null, null), ('preto', 4, 3, 1), ('pretos', 4, 3, 2),
('prete', 4, 1, 1), ('pretes', 4, 1, 2), ('preta', 4, 3, 1), ('pretas', 4, 2, 2),
('azul', 4, null, 1), ('azuis', 4, null, 2), ('vermelho', 4, 3, 1), ('vermelhos', 4, 3, 2), 
('vermelha', 4, 2, 1), ('vermelhas', 4, 2, 2), ('vermelhe', 4, 1, 1), ('vermelhes', 4, 1, 2);

