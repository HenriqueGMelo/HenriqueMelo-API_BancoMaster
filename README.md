# API Banco Master

## Criação de uma API!

## Índice
- <a href="#-tecnologias-utilizadas"> Tecnologias Utilizadas </a>
- <a href="#-funcionalidades-da-API"> Funcionalidades da API </a>

## Tecnologias Utilizadas
- C#
- .NET
- ASP.NET CORE
- LiteDB
- Swagger
- Visual Studio 

## Funcionalidades da API 
- <a href="#Cadastrar-Cliente"> Cadastrar Cliente <a/>
- <a href="#Consultar-Cliente"> Consultar Cliente <a/>
- <a href="#Transferencia-Pix "> Transferência Pix <a/>
- <a href="#Depositar-Valor"> Depositar Valor <a/>

## 
- Cadastrar Cliente: 

Cadastre um cliente utilizando Documento / Nome / Chave Pix 
(existe a escolha de inserir uma informação para chave pix 
ou gerar gera-la automaticamente). 

- Consultar Cliente: 

Consulte o cliente cadastrado através do seu documento!

(O saldo do cliente aparecerá somente a partir do momento 
em que o mesmo passar a ter um valor, logo ao criar e consuta-lo
na sequência não apresentará nenhum saldo, após realizar um deposito
"passo explicado a seguir", e realizar nova consulta, o saldo aparecerá).

- Depositar Valor: 

Este metodo foi criado para que possa ser depositado um valor 
para o cliente cadastrado e assim posteriormente pode-se realizar
uma transferencia pix.

- Transferência Pix:

Para realizar a transferência pix é preciso inserir a chave pix de quem 
vai realizar a ação, a chave pix de quem vai receber o valor e informar a 
valor que deseja tranferir

### LiteDB 
Foi utilizado este banco de dados pensando na questão de que todos possam 
rodar esta aplicação em sua maquina e de modo que o banco será gerado na mesma
sem a necessidade de que realize algumas ações caso utiliza-se um outro banco 
(obs. apenas por este motivo, porém também é possivel criarmos o mesmo projeto  
utilizando por exemplo o banco de dados SQL Server ao invés do LiteDB)

## Autor
[Henrique Melo]

[Linkedin](https://www.linkedin.com/in/henriquemelo05/)
