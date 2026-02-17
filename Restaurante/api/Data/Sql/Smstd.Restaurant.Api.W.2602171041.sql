
INSERT INTO Pessoas (Nome, Telefone, Email, Endereco, Activo, TipoPessoa)
VALUES
('João Matola', '841234567', 'joao@email.com', 'Av. Samora Machel', 1, 1),
('Ana Mucavele', '823456789', 'ana@email.com', 'Bairro Hulene', 1, 1),
('Carlos Nhampule', '841112233', NULL, 'Matola Rio', 1, 1),
('João Manuel', '841234567', 'jm@email.com', 'Mussumbuluco', 1, 1),
('Ana Silva', '861112233', 'as@email.com', 'Polana Canico A', 1, 1),
('Carlos Matusse', '879998877', 'cm@email.com', 'Intaka', 1, 1);


INSERT INTO Pessoas (Nome, Telefone, Email, Endereco, Activo, Cargo, DataContratacao, TipoPessoa)
VALUES
('Maria João', '849876543', 'maria@restaurante.com', NULL, 1, 'Empregada de Mesa', GETDATE(), 0),
('Paulo Ernesto', '823334455', 'paulo@restaurante.com', NULL, 1, 'Cozinheiro', GETDATE(), 0),
('Rui Almeida', '841998877', 'rui@restaurante.com',NULL, 1, 'Gerente', GETDATE(), 0),
('Maria Lopes', '8798654973', 'ml@restaurante.com', NULL, 1, 'Atendente', GETDATE(), 0),
('Paulo Nhantumbo', '863823455', 'pn@restaurante.com', NULL, 1, 'Caixa', GETDATE(), 0);


INSERT INTO Pratos (Nome, Descricao, Preco, Categoria, Disponivel, DataCriacao)
VALUES
('Sopa de Legumes', 'Sopa caseira de legumes frescos', 250.00, 1, 1, GETDATE()),
('Frango Grelhado', 'Frango grelhado com batata frita', 750.00, 2, 1, GETDATE()),
('Sumo Natural', 'Sumo natural de manga', 150.00, 3, 1, GETDATE()),
('Pudim', 'Pudim de leite condensado', 200.00, 4, 1, GETDATE()),
('Peixe Frito', 'Peixe fresco frito com arroz', 650.00, 2, 0, GETDATE()),
('Sumo Natural', 'Sumo natural de laranja', 250.00, 3, 1, GETDATE());



INSERT INTO Pedidos (ClienteId, TrabalhadorId, DataPedido, Estado, ValorTotal)
VALUES
(1, 7, GETDATE(), 1, 1150.00),
(2, 11, GETDATE(), 3, 750.00),
(3, 9, GETDATE(), 4, 350),
(4, 10, GETDATE(), 3, 700);


INSERT INTO PratosPedido(PedidoId, PratoId, Quantidade, PrecoUnitario, Subtotal)
VALUES
-- Pedido 1
(1, 1, 1, 250.00, 250.00),
(1, 2, 1, 750.00, 750.00),
(1, 3, 1, 150.00, 150.00),

-- Pedido 2
(2, 2, 1, 750.00, 750.00),

-- Pedido 3
(3, 4, 1, 200.00, 200.00),
(3, 3, 1, 150.00, 150.00),

-- Pedido 4
(4, 5, 1, 650.00, 650.00),
(4, 6, 1, 250.00, 250.00);



--------------UPDATES----------------------------
-- Actualizar preço de um prato
UPDATE Pratos
SET Preco = 800.00
WHERE PratoId = 2;

-- Actualizar estado de um pedido
UPDATE Pedidos
SET Estado = 2 -- EmPreparacao
WHERE PedidoId = 1;

-- Desactivar trabalhador
UPDATE Pessoas
SET Activo = 0  -- 0(false) ou 1(true)
WHERE Id = 8 AND TipoPessoa = 0;



----------------DELETES----------------------------------
DELETE FROM Pessoas
WHERE Id = 8 AND TipoPessoa = 0;

-- Apagar um pedido (ordem correta!)
DELETE FROM PratosPedido WHERE PedidoId = 1;
DELETE FROM Pedidos WHERE PedidoId = 1;

-- Apagar um prato
DELETE FROM PratosPedido WHERE PratoId = 3;
DELETE FROM Pratos WHERE PratoId = 3;
