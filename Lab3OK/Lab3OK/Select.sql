USE GestionaCheltuieli;
select * from Cheltuiala;
select *from Buget;
select * from Utilizator;
select * from Categorie;
select * from Organizare;
select * from Locatie;
select * from Detalii_CheltuialaLocatie;

SELECT Distinct nume_cat FROM Categorie UNION SELECT nume_u from Utilizator;

SELECT id_u, nume_u FROM Utilizator u EXCEPT SELECT u.id_u, u.nume_u FROM Utilizator u
INNER JOIN Cheltuiala c ON u.id_u = c.id_u;

select c.suma_cheltuita, cat.nume_cat from Cheltuiala c inner join Organizare o on c.id_ch=o.id_ch
inner join Categorie cat on o.id_cat=cat.id_cat;

select c.suma_cheltuita, l.nume_locatie from Cheltuiala c inner join Detalii_CheltuialaLocatie dcl on c.id_ch=dcl.id_ch
inner join Locatie l on l.id_locatie=dcl.id_locatie;

SELECT suma_cheltuita
FROM Cheltuiala
Left JOIN Organizare
ON Cheltuiala.id_ch < Organizare.id_ch;

SELECT suma_cheltuita
FROM Cheltuiala
Right JOIN Organizare
ON Cheltuiala.id_ch < Organizare.id_ch;

SELECT suma_cheltuita
FROM Cheltuiala
Full JOIN Organizare
ON Cheltuiala.id_ch = Organizare.id_ch;

select u.id_u, min(b.anul) as bugete from Utilizator u left join Buget b on u.id_u=b.id_u
group by u.id_u
having sum(b.anul)>2030;

select u.id_u, avg(c.suma_cheltuita) as suma from Utilizator u full join Cheltuiala c on u.id_u=c.id_u
group by u.id_u
having avg(c.suma_cheltuita)<800;

select o.id_cat, count(c.nume_cat) as nume from Categorie c full join Organizare o on o.id_cat=c.id_cat
group by o.id_cat
having count(c.nume_cat)<5;

select nume_u from Utilizator where id_u in (select id_u from Buget where id_buget=6 and luna='noiembrie');

select nume_u from Utilizator u where exists(select b.id_u from Buget b where b.id_u=u.id_u and anul=2018);