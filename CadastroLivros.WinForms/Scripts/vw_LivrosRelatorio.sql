CREATE VIEW vw_LivrosRelatorio AS
SELECT 
    l.Id AS LivroId,
    l.Titulo AS LivroTitulo,
    l.DataPublicacao,
    l.Valor,
    l.FormaCompra,
    a.Id AS AutorId,
    a.Nome AS AutorNome,
    s.Id AS AssuntoId,
    s.Descricao AS AssuntoDescricao
FROM 
    Livros l
JOIN 
    LivroAutores la ON la.LivroId = l.Id
JOIN 
    Autores a ON a.Id = la.AutorId
JOIN 
    LivroAssuntos ls ON ls.LivroId = l.Id
JOIN 
    Assuntos s ON s.Id = ls.AssuntoId;


	SELECT * FROM vw_LivrosRelatorio