# Application

WebApi em .Net Core utilizando Dapper com SQL Server, Injeção de Dependências, Testes Unitários e Swagger.

Como utilizar:

Script do banco

```
CREATE DATABASE MyDatabase;

USE MyDatabase;

CREATE TABLE Application (
	ApplicationId INT PRIMARY KEY,
	Url VARCHAR(200) NULL,
	PathLocal VARCHAR(200) NULL,
	DebuggingMode Bit DEFAULT 0
);

```

Também é possível alterar a string de conexão no **appsetting.json** do projeto da WebApi ou no construtor da classe de teste unitário.

Para ver a documentação, rodar a api e acessar o endereço https://localhost:44376/swagger/index.html