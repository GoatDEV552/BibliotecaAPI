CREATE TABLE Livros (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Titulo VARCHAR(255) NOT NULL,
    Autor VARCHAR(255) NOT NULL,
    AnoPublicacao INT,
    Genero VARCHAR(100),
    Disponivel BOOLEAN DEFAULT TRUE
);

CREATE TABLE Usuarios (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Nome VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL
);

CREATE TABLE Emprestimos (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    LivroId INT,
    UsuarioId INT,
    DataEmprestimo DATE,
    DataDevolucao DATE,
    FOREIGN KEY (LivroId) REFERENCES Livros(Id),
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
);


