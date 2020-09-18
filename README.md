Prova N**
============
Exercícios propostos para prova da empresa N, utilizando:

- .NET Core 3.1;
- Swagger Tools;
- XUnit;
- MSSQL Server 2019 Linux;
- Docker + Docker Compose;
- Redis;
- HealthChecks;
- Fluent Assertions;

## Questão 1)

R: Ao Quadrado, vide testes

## Questão 2)

Console App

<p align="center">
<img src="./assets/questao2_app.png" alt="Console App Output" width="338">
</p>

### Instruções para execução

```
docker-compose up --build exercicio02.app
```

R: C1 + C2 + C3

## Questão 3)

Web API
 
<p align="center">
<img src="./assets/questao3_api_doc.png" alt="Swagger UI" width="738">
</p>
<p align="center">
 <img src="./assets/questao3_api_healthcheck_ui.png" alt="Health Check UI" width="738">
</p>

### Instruções para execução

```
docker-compose up --build exercicio03.api
```

Para obter o IP do container

```
docker inspect --format='{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' exercicio03_api
```

Copie o endereço de IP obtido no comando acima e cole no navegador :)