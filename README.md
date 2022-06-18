# Api para cadastro de empresas
Api desenvolvida com o objetivo de cadastrar e controlar o acesso de usuarios não autorizados aos dados salvos no sistema

## Tecnologias utilizadas
- C#;
- Asp.Net Core;
- Entityframework ORM;
- Swagger;
- JWT Token;
- Sql Server

Para testar o projeto é necessário adicionar a migration e depois dar um update-Database na sua máquina para que o próprio entityframework crie 
as tabelas do banco de dados. Depois atualize a connectionString e o nome do banco de dados no appsettings e na program e pronto.
