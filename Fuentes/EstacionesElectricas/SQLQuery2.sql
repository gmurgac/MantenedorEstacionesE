CREATE TABLE Punto(
id int PRIMARY KEY,
idTipo int NOT NULL,
idEstacion int NOT NULL,

CONSTRAINT fk_punto_estacion FOREIGN KEY (idEstacion)
REFERENCES Estacion(id),

CONSTRAINT fk_punto_tipo FOREIGN KEY(idTipo)
REFERENCES TipoPunto(id)
);




CREATE TABLE TipoPunto(
id int PRIMARY KEY,
nombre VARCHAR(10),

);