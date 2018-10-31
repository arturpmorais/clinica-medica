select * from secretaria
select * from consulta
select * from especialidade
select * from paciente
select * from medico
select * from exame
select * from exameConsulta

-- PACIENTES QUE PRECISAM SER AVISADOS DA CONSULTA --
SELECT p.nome_completo, p.email, c.id, c.data FROM paciente p, consulta c
WHERE
p.id = c.idPaciente AND
c.status != 'CANCELADA' AND
DATEDIFF(DAY, GETDATE(), CONVERT(DATE, c.data, 103)) <= 2 AND
DATEDIFF(DAY, GETDATE(), CONVERT(DATE, c.data, 103)) >= 0 AND
c.pacienteAvisado = 0

---- RELATORIOS ----

-- PACIENTES POR MÉDICO --
SELECT m.nome_completo as Medico, count(pm.idPaciente) as Pacientes
FROM ( SELECT idMedico, idPaciente FROM consulta WHERE status != 'CANCELADA' GROUP BY idMedico, idPaciente ) AS pm, medico AS m
WHERE pm.idMedico = m.id
GROUP BY m.nome_completo

-- CONSULTAS MENSAIS POR MÉDICO --
SELECT m.nome_completo AS Medico, count(c.id) AS Consultas
FROM medico m, consulta c
WHERE 
m.id = c.idMedico AND
c.status = 'CANCELADA' AND
MONTH(CONVERT(DATE, c.data, 103)) = MONTH(GETDATE())
GROUP BY m.nome_completo


-- CONSULTAS CANCELADAS MENSALMENTE POR MÉDICO --
SELECT m.nome_completo AS Medico, count(c.id) AS Consultas
FROM medico m, consulta c
WHERE 
m.id = c.idMedico AND
c.status != 'CANCELADA' AND
MONTH(CONVERT(DATE, c.data, 103)) = MONTH(GETDATE())
GROUP BY m.nome_completo


-- ATENDIMENTO DIÁRIO POR ESPECIALIDADE --
SELECT e.especialidade as Especialidade, count(c.id) as Consultas
FROM especialidade e, consulta c, medico m
WHERE
e.id = m.especialidade AND
m.id = c.idMedico AND
c.status != 'CANCELADA' AND
DAY(CONVERT(DATE, c.data, 103)) = DAY(GETDATE())
GROUP BY e.especialidade