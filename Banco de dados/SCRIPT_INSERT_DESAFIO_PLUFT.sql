
USE Desafio_Pluft

INSERT INTO TIPO_ESTABELECIMENTO(Tipo)
VALUES('Restaurante A'),('Festa B'),('Outros C');

INSERT INTO TIPO_USUARIO(Tipo)
VALUES('Administrador'),('Cliente'),('Lojista');

INSERT INTO STATUS_AGENDAMENTO(Nome)
VALUES('Agendado'),('Cancelado'),('Em Espera');

INSERT INTO ESTABELECIMENTOS(Nome, CNPJ, Id_Tipo_Estabelec, Endereco, Horario_Funcionamento, Vagas)
VALUES ('Restaurante A','009998880001-9','1','Rua Segunda, 77','12h00 até 18h00','115'), 
('Festa B', '998889990001-8','2','Rua Segunda, 88','20h00 até 06h00','200'),
('Evento A','880009990001-0','3','Rua Terceira, 99','10h00 até 06h00','1200')

INSERT INTO USUARIOS(Nome, Email, Senha, Telefone, Data_Criacao, Id_Tipo_Usuario, Id_Estabelecimento)
VALUES('Gabriela Moretto','gabriela@gmail.com','senha1','40028922','8/8/2019','1','3'),
('Alan Dias','alan@gmail.com','senha2','+55(11)40028922','8/8/2019','2',null),
('Felipe Souza','felipe@gmail.com','senha3','4002-8922','8/8/2019','3',null)

INSERT INTO CLIENTES(CPF, Data_Nascimento, RG, Endereco, Id_Usuario)
VALUES('00000000000','10/07/1990','999999999','Rua Décima, 55','2')

INSERT INTO LOJISTAS(CPF, Data_Nascimento, RG, Endereco, Id_Usuario)
VALUES('00000000000','12/09/1989','999999999','Rua Quatro, 55','3')

INSERT INTO PRODUTOS(Titulo, Descricao, Preco, QtdEstoque, Id_Estabelec)VALUES
					('Prato A','Produto de um restaurante','12.99','10','6'),
					('Prato B','Produto de um restaurante','15.99','10','6'),
					('VIP','Produto de uma festa','100.00','50','2'),
					('Prato A','Produto de um outro restaurante','25.00','999','1')


INSERT INTO AGENDAMENTOS(Id_Cliente, Id_Estabelecimento, Id_Status, Id_Lojista, Data_Criacao,Data_Agendamento) VALUES ('1','1','1','1','09/05/2019','09/05/2020')
