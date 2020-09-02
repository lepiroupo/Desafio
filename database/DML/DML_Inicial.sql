use Desafio
go

BEGIN TRAN
--ROLLBACK
--COMMIT

INSERT INTO Segmento VALUES
(1, 'Varejo', 1),
(2, 'Personnalite', 1),
(3, 'Private', 1)
GO

INSERT INTO Cliente VALUES
('45143720052', 'Cliente Varejo', 1),
('89595836001', 'Cliente Personnalite', 2),
('69764697020', 'Cliente Private', 3)
GO

INSERT INTO TaxaCambio VALUES
(1, 0.1),
(2, 0.08),
(3, 0.05)
GO