# ChallengeCoodesh  

O ChallengeCoodesh é um projeto desenvolvido como desafio da [Coodesh](https://coodesh.com/). Ela se divide em duas aplicações web:  
- ChallengeCoodesh_CROM - resposavel por ler dados de uma API é gravar esses dados em um banco de dados MongoDB. Esses dados são atualizado todos os dias
as 09:00h  
- ChallengeCoodesh_API - Reponsavel por prover uma API-Rest para Ler, Gravar, Editar e Excluir Dados do Banco.

## Instruções

### Todo o processo de execução pode ser feito usando Docker e Docker Compose;
- Clone o repositorio
- Acesse o diretório `challengeCoodesh\ChallengeCoodesh_API\challengeCoodesh`
- Execute o comando `docker-compose up -d --build` 

### Executar em modo de Desenvolvimento
- Clone o repositorio
- Acesse o diretório `challengeCoodesh\ChallengeCoodesh_API\challengeCoodesh`
- Execute o comando `dotnet run --project challengeCoodesh.csproj` para executar a API;
- Para executar o CRON acesse o diretorio `challengeCoodesh\ChallengeCoodesh_CROM\ChallengeCoodesh_CROM`  
- Execute o comando `dotnet run --project ChallengeCoodesh_CROM.csproj`

## Tecnologias e Ferramentas
 - Dotnet Core 3.1
 - MongoDB
 - Swagger
 - Docker 
 - Docker Compose


>  This is a challenge by [Coodesh](https://coodesh.com/)
