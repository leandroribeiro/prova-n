# Prova NPF
Exercícios propostos para prova

## Questão 1)

R: Ao Quadrado, vide testes

## Questão 2)

R: C1 + C2 + C3

## Questão 3)

```
docker-compose up
```

Para obter o IP do container

```
docker inspect --format='{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' exercicio03_api
```

Copie o endereço de IP obtido no comando acima e cole no navegador :)