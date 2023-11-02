# Seja bem vindo! Me chamo Clóvis Chakrian

# Desafio Back End BlueTechnology

Estou participando do processo seletivo da Blue Technology e esse repositório contém o Back End da aplicação passada como desafio.
Trata-se de um CRUD para uma agenda de contatos desenvolvido usando a linguagem `C#` com o `.NET` e o framework `Entity Framework` com o banco de dados `Postgresql`.

## Funcionalidade

- Criação de contato
- Busca de contatos por nome + sobrenome
- Buscar todos os contatos
- Atualizar um contato
- Ver detalhes de um contato pelo seu id
- Deleter contato
- Validação de campos
- Tratamento de erros

## 📥 Como baixar e rodar

Antes de começar, é importante ter algumas ferramentas instaladas como o [Git](https://git-scm.com), o [VSCode](https://code.visualstudio.com/) e ter o [.NET](https://dotnet.microsoft.com/pt-br/) também é importante. Necessário também ter algum banco de dados, como o Postgresql e alterar a string de conexão.

### 💻 Setup

```shell
# clonar repo
$ git clone git@github.com:Clovis-Chakrian/Agenda-BackEnd-BlueTechnology.git

# entrar na pasta do projeto
$ cd Agenda-BackEnd-BlueTechnology

# fazer binarios importantes para rodar o projeto
$ dotnet build

# entrar na pasta da api
$ cd Agenda.API

# rodar projeto
$ dotnet run
```

### Acessando

```shell
# A aplicação rodando
- Local: http://localhost:5029

# Para acessar pela Swagger UI
- Local: http://localhost:5029/swagger/index.html
```

## Swagger UI (Docs da API)

Pelo swagger você poderá ver os endpoints da api e saber o que é necessário para acessar cada um, além de poder testar a API.

<img width="900" heigth="900"  src="https://ik.imagekit.io/chakriandev/projetos/agenda_crud/swagger-back.png?updatedAt=1698887701345">


## 🌐 [Aplicação - Front End](https://github.com/Clovis-Chakrian/Agenda-FrontEnd-BlueTechnology)

<img width="900" heigth="900"  src="https://ik.imagekit.io/chakriandev/projetos/agenda_crud/gif-front.gif?updatedAt=1698889840814
">

## 🛠 Tech Stack

Stack utilizada para desenvolver o projeto:

<div align="left">
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg" height="40" alt="dotnetcore logo"  />

  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/postgresql/postgresql-original.svg" height="40" alt="postgresql logo"  />

  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" height="40" alt="csharp logo"  />
</div>

## ✍🏼 Autor do projeto

<div align=left>
  <table>
    <p>Desenvolvido com carinho por:</p>
    <tr align=center>
      <th>
        <strong> Clóvis Chakrian </strong>
      </th>
    </tr>
    <td>
      <a href="https://github.com/clovis-chakrian">
        <img width="168" height="140" src="https://github.com/clovis-chakrian.png" > 
      </a>
    </td>
  </table>
</div>