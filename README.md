## Funcionarios APIS (EmploysControl)

Está aplicação está disponibilizando uma API para a realização do CRUD de funcionarios

## Começando!!

#### Pré-Requisitos
- ASP.NET Core 6
- Docker

É necessário ter o serviço `postgres` rodando no host. Para levantar o serviço via docker é necessário executar o seguinte comando:

```bash
$ docker-compose up -d
```

Após termos o banco rodando, é necessário executar as migrations do Entity Framework, para isso executar o seguinte comando:
```bash
$ dotnet ef database update
```

O ultimo passo é colocar a nossa aplicação para rodar através do seguinte comando:

```bash
dotnet run employesControl-V2.csproj 
```

Ao rodar a aplicação, sera gerado um `Swagger` com todas as as rodas e informações necessárias para poder utilizar a api na segiunte url: http://localhost:7036/swagger/index.html






