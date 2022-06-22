## Funcionarios APIS (EmploysControll)

Está aplicação está disponibilizando uma API para a realização do CRUD de funcionarios

## Começando!!

#### Pré-Requisitos
- ASP.NET Core 6
- Docker


Ao Baixar a aplicação é necessário inicializar o projeto com o comando...

```bash
$ npm start
```

Sera necessário criar um container para o banco de dados "postgre", utilizado o seguinte comando.

```bash
$ docker-compose up -d
```

Será necessario criar o banco de dados após a criação do container. 


Ao rodar a aplicação, sera gerado um Swagger com todas as as rodas e informações necessárias para poder utilizar a api em 
 
http://localhost:7036/swagger/index.html






