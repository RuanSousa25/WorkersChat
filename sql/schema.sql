
create schema workers_chat;
set search_path to workers_chat;

create table chat(
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	message TEXT not null,
	prev_message INTEGER,
	next_message INTEGER,
	constraint fk_prev foreign key (prev_message) references chat(id),
	constraint fk_next foreign key (next_message) references chat(id)
);

create table worker(
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	message_id integer,
	born_date TIMESTAMP default CURRENT_TIMESTAMP,
	death_date TIMESTAMP,
	constraint fk_message foreign key (message_id) references chat(id)
);

create table word_types(
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	word_type TEXT not null
);

create table words(
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	word TEXT not null,
	word_type_id integer not null,
	constraint fk_type foreign key (word_type_id) references word_types(id)
);

insert into word_types(word_type) values ('pronome'),('substantivo'), ('verbo'), ('adjetivo'), ('adverbio');