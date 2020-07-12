# prova-npf
Exercícios propostas para Prova da NPF

## Questao 1)

Ao Quadrado, vide testes

## Questao 2)

C1 + C2 + C3

### Questao 3)

```
docker-compose up
```

Para obter o IP do container

```
docker inspect --format='{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' exercicio03_api
```

Copie o endereço de IP obtido no comando acima e cole no navegador :)