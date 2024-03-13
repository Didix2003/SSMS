USE GestionaCheltuieli;
/*delete from Buget;
delete from Organizare;
delete from Cheltuiala;
delete from Categorie;
delete from Utilizator;*/

delete Cheltuiala where suma_cheltuita=500 and id_u=5;
delete Categorie where nume_cat is null;
delete Buget where anul<=2019;
delete buget where luna is not null;