select * from secretaria
select * from consulta
select * from especialidade
select * from paciente
select * from medico
select * from exame
select * from exameConsulta

SELECT p.nome_completo, p.email, c.id, c.data FROM paciente p, consulta c
WHERE
p.id = c.idPaciente AND
c.status != 'CANCELADA' AND
DATEDIFF(DAY, GETDATE(), CONVERT(DATE, c.data, 103)) <= 2 AND
DATEDIFF(DAY, GETDATE(), CONVERT(DATE, c.data, 103)) >= 0 AND
c.pacienteAvisado = 0