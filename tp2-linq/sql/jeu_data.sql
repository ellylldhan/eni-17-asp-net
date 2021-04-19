-- SQLITE
-- CREATE DATABASE tp2-linq;
-- USE tp2-linq;
-- drop table Facture;
-- drop table Livre;
-- drop table Auteur;

CREATE TABLE Auteur
(
    id     INTEGER   NOT NULL PRIMARY KEY AUTOINCREMENT,
    nom    TEXT(100) NOT NULL,
    prenom TEXT(100) NOT NULL
);

CREATE TABLE Facture
(
    id        INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    montant   float   NOT NULL,
    id_auteur int     NOT NULL,
    FOREIGN KEY (id_auteur) REFERENCES auteur (id)
);
CREATE TABLE Livre
(
    id        INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    titre     TEXT    NOT NULL,
    synopsis  TEXT,
    id_auteur int     NOT NULL,
    nb_pages  integer NOT NULL,
    FOREIGN KEY (id_auteur) REFERENCES auteur (id)
);

insert into auteur (nom, prenom)
values ('GROUSSARD', 'Thierry');
insert into auteur (nom, prenom)
values ('GABILLAUD', 'Jérôme');
insert into auteur (nom, prenom)
values ('HUGON', 'Jérôme');
insert into auteur (nom, prenom)
values ('ALESSANDRI', 'Olivier');
insert into auteur (nom, prenom)
values ('de QUAJOUX', 'Benoit');

insert into Livre (id, titre, synopsis, id_auteur, nb_pages)
values (1, 'C# 4', 'Les fondamentaux du langage', 1, 533);
insert into Livre (id, titre, synopsis, id_auteur, nb_pages)
values (2, 'VB.NET', 'Les fondamentaux du langage', 1, 539);
insert into Livre (id, titre, synopsis, id_auteur, nb_pages)
values (3, 'SQL Server 2008', 'SQL, Transact SQL', 2, 311);
insert into Livre (id, titre, synopsis, id_auteur, nb_pages)
values (4, 'ASP.NET 4.0 et C#', 'Sous visual studio 2010', 4, 544);
insert into Livre (id, titre, synopsis, id_auteur, nb_pages)
values (5, 'C# 4', 'Développez des applications windows avec visual studio 2010', 3, 452);
insert into Livre (id, titre, synopsis, id_auteur, nb_pages)
values (6, 'Java 7', 'les fondamentaux du langage', 1, 416);
insert into Livre (id, titre, synopsis, id_auteur, nb_pages)
values (7, 'SQL et Algèbre relationnelle', 'Notions de base', 2, 216);

insert into facture (montant, id_auteur)
values (3500, 1);
insert into facture (montant, id_auteur)
values (3200, 1);
insert into facture (montant, id_auteur)
values (4000, 2);
insert into facture (montant, id_auteur)
values (4200, 3);
insert into facture (montant, id_auteur)
values (3700, 4);