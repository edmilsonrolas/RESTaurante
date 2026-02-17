
INSERT INTO Clientes (Nome, Telefone, Email, Endereco)
VALUES
('João Matola', '841234567', 'joao@email.com', 'Av. Samora Machel'),
('Ana Mucavele', '823456789', 'ana@email.com', 'Bairro Hulene'),
('Carlos Nhampule', '841112233', NULL, 'Matola Rio'),
('João Manuel', '841234567', 'jm@email.com', 'Mussumbuluco'),
('Ana Silva', '861112233', 'as@email.com', 'Polana Canico A'),
('Carlos Matusse', '879998877', 'cm@email.com', 'Intaka');


INSERT INTO Trabalhadores (Nome, Cargo, Telefone, Email, DataContratacao, Activo)
VALUES
('Maria João', 'Empregada de Mesa', '849876543', 'maria@restaurante.com', GETDATE(), 1),
('Paulo Ernesto', 'Cozinheiro', '823334455', 'paulo@restaurante.com', GETDATE(), 1),
('Rui Almeida', 'Gerente', '841998877', 'rui@restaurante.com', GETDATE(), 1),
('Maria Lopes', 'Atendente', '8798654973', 'ml@restaurante.com', GETDATE(), 1),
('Paulo Nhantumbo', 'Caixa', '863823455', 'pn@restaurante.com', GETDATE(), 0);


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
(1, 1, GETDATE(), 1, 1150.00),
(2, 2, GETDATE(), 3, 750.00),
(3, 3, GETDATE(), 4, 350),
(4, 4, GETDATE(), 3, 700);


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
UPDATE Trabalhadores
SET Activo = 0  -- 0(false) ou 1(true)
WHERE TrabalhadorId = 5;



----------------DELETES----------------------------------
-- Apagar um pedido (ordem correta!)
DELETE FROM PratosPedido WHERE PedidoId = 1;
DELETE FROM Pedidos WHERE PedidoId = 1;

-- Apagar um prato
DELETE FROM PratosPedido WHERE PratoId = 3;
DELETE FROM Pratos WHERE PratoId = 3;
