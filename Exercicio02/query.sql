-- C1
select Nome
from Empregado
where Codigo in (select Codigo
    from Empregado)
    AND Codigo NOT IN ((select E1.Codigo
    from Empregado E1, Empregado E2
    where E1.Salario < E2.Salario)
)

-- C2
select Nome from Empregado
where Salario = (select max(Salario) from Empregado)

-- C3
select Nome from Empregado
where Salario >= all (select Salario from Empregado)

-- C4
select Nome from Empregado
where Codigo in ( select E1.Codigo from Empregado E1, Empregado E2
where E1.Salario > E2.Salario
)

-- ==============
-- Resposta
-- C1 + C2 + C3
-- ==============