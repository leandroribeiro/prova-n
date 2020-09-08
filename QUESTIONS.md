1 - Observe a função recursiva a seguir, desenvolvida na linguagem Pascal.

function Prova (N : integer) : integer;
begin
    if N=0 then 
        Prova:= 0
    else 
        Prova := N * 2 - 1 + Prova (N - 1);
end;

Considerando-se que essa função sempre será chamada com variável N contendo inteiros positivos, o seu valor de retorno será:

a) O fatorial do valor armazenado em N.
b) O valor armazenado em N elevado ao quadrado.
c) O somatório dos N primeiros números inteiros positivos.
d) O somatório dos N primeiros números pares positivos.
e) 2 elevado ao valor armazenado em N.



2 - Considere a relação a seguir, definida em linguagem SQL padrão.

CREATE TABLE EMPREGADO
(
CODIGO NUMBER(4) PRIMARY KEY,
NOME VARCHAR2(10),
SALARIO NUMBER(7,2)
)
Considere também as queries (C1, C2, C3 e C4) a seguir, expressas em linguagem SQL.
C1:
select NOME from EMPREGADO
where CODIGO in ((select CODIGO from EMPREGADO)
minus
(select E1.CODIGO from EMPREGADO E1, EMPREGADO E2
where E1.SALARIO < E2.SALARIO)
)
Obs: o operador minus realiza a operação de subtração entre relações.
C2:
select NOME from EMPREGADO
where SALARIO = (select max(SALARIO) from EMPREGADO)
C3:
select NOME from EMPREGADO
where SALARIO >= all (select SALARIO from EMPREGADO)
C4:
select NOME from EMPREGADO
where CODIGO in ( select E1.CODIGO from EMPREGADO E1, EMPREGADO E2
where E1.SALARIO > E2.SALARIO
)
Com relação às queries, assinale a alternativa correta.
a) Apenas as queries C2 e C3 são equivalentes.
b) Todas as queries são equivalentes.
c) Apenas as queries C1 e C3 são equivalentes.
d) Apenas as queries C1 e C4 são equivalentes.
e) Apenas as queries C1, C2 e C3 são equivalentes.





3 - A sua tarefa é, dado um número positivo N, determinar se
ele é um múltiplo de onze.
Construa uma API REST que seja capaz de receber uma requisição em formato JSON contendo uma lista de
números. A resposta deverá informar para cada número se ele é ou não múltiplo de 11. Preferivelmente, a
solução deverá ser publicada em um repositório público do GitHub juntamente com as instruções de execução e
utilização.
Entrada
Uma requisição que receba um JSON contendo uma lista de números. Exemplo de entrada:
{
"numbers": [
"112233",
"30800",
"2937",
"323455693",
"5038297",
"112234"
]
}
Saída
A API deve indicar, para cada número da entrada, se ele é um múltiplo de onze ou não. Exemplo de saída:
{
"result": [
{
"number": "112233",
"isMultiple": true
},
{
"number": "30800",
"isMultiple": true
},
{
"number": "2937",
"isMultiple": true
},
{
"number": "323455693",
"isMultiple": true

NPF - Processo de seleção - Exercícios Técnicos

Página 4 de 5

},
{
"number": "5038297",
"isMultiple": true
},
{
"number": "112234",
"isMultiple": false
}
]
}

Para auxiliar nesta tarefa observe as regras de divisibilidade do número 11:
http://pt.wikipedia.org/wiki/Criterios_de_divisibilidade#Divisibilidade_por_11
Divisibilidade por 11
Um número é divisível por 11 caso a diferença entre o último algarismo (o algarismo da unidade) e o no formado
pelos demais algarismos, de forma sucessiva até que reste um número com 2 algarismos, resultar em um
múltiplo de 11. Como a regra mais imediata, todas as dezenas duplas (11, 22, 33, 55, etc.) são múltiplos de 11.
● 286 → 28 - 6 = 22 → 22 (por ser uma dezena dupla) é múltiplo de 11
● 1331 → 133 - 1 = 132 → 13 - 2 = 11
● 14641 → 1464 - 1 = 1463 → 146 - 3 = 143 → 14 - 3 = 11
● 24350 → 2435 - 0 = 2435 → 243 - 5 = 238 → 23 - 8 = 15 → não é múltiplo de 11
Temos ainda outro método: Soma-se o 1o, o 3o, ao 5o, ao 7o algarismo; se a diferença da soma do
2o, o 4o, ao 6o, ao 8o algarismo; for múltiplo de 11 (incluindo o zero) então o número é divisível por
11
● 94186565 → 9 + 1 + 6 + 6 = 22 → 4 + 8 + 5 + 5 = 22 → 22 - 22 = 0
● 56568143 → 5 + 5 + 8 + 4 = 22 → 6 + 6 + 1 + 3 = 16 → 22 - 16 = 6
Ou então se a soma dos algarismos de posições pares e a soma dos algarismos de posições ímpares tiverem o
mesmo resto da divisão por onze, então o número tomado é divisível por onze.
● 4611686018427387901307445734561825860123058430092136939501844674407370
955160 → 168 = 148 (mod 11) OK
● 4611686018427387903307445734561825860223058430092136939511844674407370
955161 → 171 <> 148 (mod 11) Nao OK