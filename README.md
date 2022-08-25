# Twitter Clone

## Descrição

[... tópico ainda em construção]

## Back-end do projeto
Esse código tem como propósito conectar o front-end do projeto com o banco de dados. O projeto foi desenvolvido utilizando o ASP.NET que é uma plataforma da Microsoft para o desenvolvimento de aplicações Web e é o sucessor da tecnologia ASP. Permite, através de uma linguagem de programação integrada na .NET Framework, criar páginas dinâmicas. Não é nem uma linguagem de programação como VBScript, PHP, nem um servidor web como IIS ou Apache.

O ASP.NET é baseado no Framework .NET herdando todas as suas características, por isso, como qualquer aplicação .NET, as aplicações para essa plataforma podem ser escritas em várias linguagens, a utilizada no projeto foi C# para construção dessa API.

Além disso, foi utilizado o Swagger no qual permite criar a documentação da API. Como mostra a imagem abaixo: 


##### API documentada no Swagger
![](https://media.discordapp.net/attachments/721023119074000897/1012469087059849336/API.png?width=849&height=415)

O banco de dados utilizado foi o **SQL SERVER**, que é um é um sistema gerenciador de Banco de dados relacional. O banco de dados criado possui apenas duas tabelas, uma para armazenar os usuários e outra para armazenar as postagens desses usuários visto que o propósito do projeto é simular apenas o feed do twitter. Pode-se visualizar abaixo a modelagem dos bancos:

##### Modelagem conceitual
![](https://media.discordapp.net/attachments/721023119074000897/1012468204402126878/image_1.png)

##### Modelagem lógica
![](https://media.discordapp.net/attachments/721023119074000897/1012468204058198076/image.png)

##### Código SQL
~~~sql
USE [DB.ProjetoTwitter]

CREATE TABLE T_USUARIOS(
id_usuario INT PRIMARY KEY IDENTITY,
username VARCHAR(20),
nome VARCHAR(30),
senha VARCHAR(20),
email VARCHAR(50),
cidade VARCHAR(20),
biografia VARCHAR(100),
)

CREATE TABLE T_POSTAGENS(
id_post INT PRIMARY KEY IDENTITY,
id_usuario INT,
postagem VARCHAR(150),
data DATETIME,
hora VARCHAR(5),
FOREIGN KEY(id_usuario) REFERENCES T_USUARIOS(id_usuario)
)
~~~

## Sobre a API

Como já se sabe o propósito do projeto é elaborar um clone do feed do twitter, no caso o uauário da aplicação irá criar sua conta e em seguida logar. Com a conta logada o usuário poderá criar tweet e visualizar todos os outros tweets dos outros usuários, porém assim como o twitter o usuário não poderá editar o tweet apenas excluir, a ideia dessa regra não foi pensada pelo desenvolvedor desse clone foi apenas uma cópia do twitter. [... tópico em construção]
