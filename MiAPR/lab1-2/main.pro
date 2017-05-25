implement main

    open core

constants

    className = "main".
    classVersion = "".

domains

    str=symbol.
	s=string.
	int=real.

class facts

	 yes:(s,int).
 	 no:(s,int).

class predicates

 	consulting:().
 	ask:(s, int) determ(i,o).
	ill_is:(s, int) determ(o,o).
	positive:(s,int) determ(i,o).
 	negative:(s,int) determ(i,o).
 	remember:(s,s,int) determ.
 	min:(int,int,int) nondeterm(i,i,o).
 	getku:(int,int,int) determ(i,i,o).
 	askku:(int) determ(o).
 	clear_facts:() nondeterm .

clauses

    consulting():-ill_is(X, KU),!,console::nl,console::write("Скорее всего у вас ",X,"(",KU,"%)","."),console::nl,_=console::readChar().
    consulting():-console::nl,console::write("Наш эксперт в замешательстве, извините, либо вы абсолютно здоровы, либо мы вам не успеем уже помочь!"),_=console::readChar().

    askku(KU):-stdio::write("Точность ответа по симптому?(%)- "),KU=stdio::read(),console::clearInput.
    ask(Y,KU):-stdio::write("Имеется ли у вас ",Y,"? ответ: 'y'(yes) или 'n'(no)\n"),Answer=stdio::readLine(),askku(KU),remember(Y,Answer,KU),console::clearInput.


    getku(KU1,KU2,KUres):- KUres=KU1*KU2/100.
    min(KU1,KU2,KU1):-KU1 <= KU2.
    min(KU1,KU2,KU2):-KU1 > KU2.

    positive(Y,KU):-yes(Y,KU),!.
    positive(Y,KU):-not(no(Y,_)),!,ask(Y,KU).
    negative(Y,KU):-yes(Y,KU),!.


    remember(Y,"y",KU):-asserta(yes(Y,KU)).
    remember(Y,"n",KU):-asserta(no(Y,KU)),fail.

    clear_facts():-retract(yes(_,_KU)).


    ill_is("Похмелье.  Рекомендуем стакан рассола и минеральную водичку.", KUres):-
    positive("Тошнота ", KU1),
    positive("Головная боль ", KU2),min(KU1, KU2, KU3),
    positive("Жажда ", KU4),min(KU3, KU4, KU5),
    positive("Сильная реакция на свет ", KU6),min(KU5, KU6, KU7),
    positive("Сильная реакция на звуки ", KU8),min(KU7, KU8, KU9),
    getku(KU9,100,KUres), !.

    ill_is("ОРВ. Рекомендуем постель, покой.", KUres):-
    positive("Слабость и озноб ", KU1),
    positive("Насморк ", KU2),min(KU1, KU2, KU3),
    positive("Кашель ", KU4),min(KU3, KU4, KU5),
    positive("Температура ", KU6),min(KU5, KU6, KU7),
    positive("Головная боль ", KU8),min(KU7, KU8, KU9),
    getku(KU9,60,KUres), !.

    ill_is("Грипп. Рекомендуем горячее питье и витамины", KUres):-
    positive("Температура ", KU1),
    positive("Головная боль ", KU2),min(KU1, KU2, KU3),
    positive("Боли в мышцах ", KU4),min(KU3, KU4, KU5),
    positive("Насморк ", KU6),min(KU5, KU6, KU7),
    getku(KU7,85,KUres), !.

    ill_is("Ангина. Рекомендуем геплое питье и регулярное полоскание горла.", KUres):-
    positive("Боли в горле ", KU1),
    positive("Температура ", KU2),min(KU1, KU2, KU3),
    positive("Озноб ", KU4),min(KU3, KU4, KU5),
    positive("Боли при глотании ", KU6),min(KU5, KU6, KU7),
    getku(KU7,90,KUres), !.


    ill_is("Гайморит. Рекомендуем капли в нос и витамины.", KUres):-
    positive("Насморк ", KU1),
    positive("Головная боль ", KU2),min(KU1, KU2, KU3),
    positive("Слабость и озноб ", KU4),min(KU3, KU4, KU5),
    positive("Сильная реакция на звуки ", KU6),min(KU5, KU6, KU7),
    getku(KU7,100,KUres), !.


    ill_is("Алергия. Рекомендуем алерон(диазолин, лоратодин) и витамины", KUres):-
    positive("Насморк ", KU1),
    positive("Сильная реакция на свет ", KU2),min(KU1, KU2, KU3),
    positive("Головокружение ", KU4),min(KU3, KU4, KU5),
    positive("Озноб ", KU6),min(KU5, KU6, KU7),
    getku(KU7,100,KUres), !.


    ill_is("Пневмония. Врач и курс антибиотиков.", KUres):-
    positive("Кашель ", KU1),
    positive("Температура ", KU2),min(KU1, KU2, KU3),
    positive("Озноб ", KU4),min(KU3, KU4, KU5),
    positive("Боли в груди ", KU6),min(KU5, KU6, KU7),
    getku(KU7,95,KUres), !.


    ill_is("Ринит. Рекомендуем антигистоминное и капли в нос", KUres):-
    positive("Сухость зуд в носу ", KU1),
    positive("Насморк ", KU2),min(KU1, KU2, KU3),
    positive("Головная боль ", KU4),min(KU3, KU4, KU5),
    positive("Слабость ", KU6),min(KU5, KU6, KU7),
    getku(KU7,95,KUres), !.

    ill_is("Бронхит. Рекомендуем Антибиотики, отхарькивающее и гарчичники.", KUres):-
    positive("Кашель ", KU1),
    positive("Тошнота ", KU2),min(KU1, KU2, KU3),
    positive("Боли в мышцах ", KU4),min(KU3, KU4, KU5),
    positive("Слабость ", KU6),min(KU5, KU6, KU7),
    getku(KU7,90,KUres), !.


clauses

    run():- console::init(),consulting(),fail().
    run():-

        succeed().


end implement main

goal
    mainExe::run(main::run).

