# Desafio
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=lepiroupo_Desafio&metric=alert_status)](https://sonarcloud.io/dashboard?id=lepiroupo_Desafio)
Para a execução da solution é necessário:

  - Visual Studio 2019
  - Docker Desktop

Serão criados os containers abaixo:
  - Sql Server 2017
    - Usuário: sa
    - Senha: desafio123
  - Redis
    - Senha: desafio123

Selecionar o docker-compose da solution e iniciar o projeto. Após o container SQL estar pronto, executar os scripts listados abaixo para inclusão dos dados inciais para teste:
  - database/DDL/DDL_Inicial.sql
  - database/DML/DML_Inicial.sql
