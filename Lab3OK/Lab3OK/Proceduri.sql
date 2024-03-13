USE GestionaCheltuieli;
GO

CREATE PROCEDURE AdaugaUtilizator
    @nume_u VARCHAR(100),
    @parola VARCHAR(100)
AS
BEGIN
    -- Validare parametri
    IF LEN(@nume_u) = 0 OR LEN(@parola) = 0
    BEGIN
        THROW 50000, 'Parametrii incorecti.', 1;
        RETURN;
    END;

    INSERT INTO Utilizator (nume_u, parola)
    VALUES (@nume_u, @parola);
END;

CREATE PROCEDURE AdaugaCheltuiala
    @id_u INT,
    @suma_cheltuita INT,
    @data_cheltuiala DATETIME
AS
BEGIN
    -- Validare parametri
    IF @id_u IS NULL OR @suma_cheltuita IS NULL OR @data_cheltuiala IS NULL
    BEGIN
        THROW 50000, 'Parametrii incorecti.', 1;
        RETURN;
    END;

    INSERT INTO Cheltuiala (id_u, suma_cheltuita, data_cheltuiala)
    VALUES (@id_u, @suma_cheltuita, @data_cheltuiala);
END;

CREATE PROCEDURE AdaugaOrganizare
    @id_ch INT,
    @id_cat INT,
    @tip_organizare VARCHAR(100)
AS
BEGIN
    -- Validare parametri
    IF @id_ch IS NULL OR @id_cat IS NULL OR LEN(@tip_organizare) = 0
    BEGIN
        THROW 50000, 'Parametrii incorecti.', 1;
        RETURN;
    END;

    -- Verificare dacã id_ch ?i id_cat existã în tabelele respective
    IF NOT EXISTS (SELECT 1 FROM Cheltuiala WHERE id_ch = @id_ch)
        OR NOT EXISTS (SELECT 1 FROM Categorie WHERE id_cat = @id_cat)
    BEGIN
        THROW 50000, 'id_ch sau id_cat inexistent.', 1;
        RETURN;
    END;

    INSERT INTO Organizare (id_ch, id_cat, tip_organizare)
    VALUES (@id_ch, @id_cat, @tip_organizare);
END;

CREATE VIEW View_UtilizatorCheltuiala
AS
SELECT U.*, C.suma_cheltuita, C.data_cheltuiala
FROM Utilizator U
JOIN Cheltuiala C ON U.id_u = C.id_u;