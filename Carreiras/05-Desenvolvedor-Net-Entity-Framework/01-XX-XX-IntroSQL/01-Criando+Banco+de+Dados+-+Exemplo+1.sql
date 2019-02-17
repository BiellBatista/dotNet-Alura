CREATE DATABASE SUCOS_VENDAS_01

CREATE DATABASE SALES_VENDAS_02
ON ( NAME = SUCO_VENDAS_DAT,  // nome da particao do banco
    FILENAME = 'C:\TEMP\DATA\SALES_VENDAS_02.mdf', // criando o banco de dados nesse diret�rio 
    SIZE = 10,  // tamanho inicial de 10 MB
    MAXSIZE = 50,  // tamanho m�ximo de 50 MB
    FILEGROWTH = 5 )  // o banco ir� crescer de 5 em 5 MB
LOG ON  // logs
( NAME = SUCOS_VENDAS_LOG,  // nome da particao do log
    FILENAME = 'C:\TEMP\DATA\SALES_VENDAS_02.ldf',  // criando o arquivo log do banco
    SIZE = 5MB,  // tamanho inicial de 5 MB
    MAXSIZE = 25MB,  // tamanho m�ximo de 25 MB
    FILEGROWTH = 5MB ) // o banco ir� crescer de 5 em 5 MB
