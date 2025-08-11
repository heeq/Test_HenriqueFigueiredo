SELECT DPT.Nome Departamento, P.Nome Pessoa, P.Salario
FROM Pessoa P
INNER JOIN Departamento DPT ON P.DeptId = DPT.Id
WHERE P.Salario = (SELECT MAX(P2.Salario) FROM Pessoa P2 WHERE P2.DeptId = P.DeptId)
