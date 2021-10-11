# Projeto DIO - API de Catálogo de Jogos
![.NET](https://img.shields.io/badge/.NET-5C2D91?style=plastic&logo=.net&logoColor=white)
![CSharp](https://img.shields.io/badge/C%23-239120?style=plastic&logo=c-sharp&logoColor=white)
![Swagger](https://img.shields.io/badge/-Swagger-%23Clojure?style=plastic&logo=swagger&logoColor=white)

## Descrição

Arquitetura base de uma API Rest de Jogos criada em .NET5.0. O projeto base foi desenvolvido utilizando algumas boas práticas como, por exemplo, **Documentação** feita com o ***swagger***, utilização do **Padrão de Projeto** ***Repository***, **GET** com paginação. Algumas melhorias foram propostas e desenvolvidas neste projeto.

- Especialista: Thiago Campos de Oliveira
- Projeto base: https://github.com/ThiagoAcam/ApiCatalogoJogos

## Conceitos abordados

- **Cliente**: Quem utiliza a API realizando requisições (requests). Pode ser uma outra API, uma Aplicação Front-end, etc.

- **Middleware**: São componentes de software que tratam as requisições (requests) e as respostas (responses).

- **Controller**: É o componente que recebe requests e produz responses.

- **Services**: É responsável pela lógica de negócio, orquestra chamadas ao banco de dados ou até mesmo outros serviços.

- **Repository**: É responsável pelo acesso ao banco de dados.

- **Data Transfer Object (DTO)**: É a representação do dado trafegado, comumente é utilizado para representar o JSON do request e response.

- **Entity**: É a representação da tabela no banco de dados.

## Verbos HTTP - Para mais informação [clique aqui](https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Methods)
- **GET**
    > O método GET solicita a representação de um recurso específico. Requisições utilizando o método GET devem retornar apenas dados. 
    > - Em caso de sucesso, retorna o código HTTP  200 (OK). 
    > - Em caso de erro, ele geralmente retorna um código HTTP 400 (Bad Request) ou 404 (Not Found).

- **POST**
    > O método POST envia dados ao servidor. O tipo do corpo da solicitação é indicado pelo cabeçalho *Content-Type*.
    > - Na criação bem-sucedida, retorna o status HTTP 201 (Created).

- **PUT**
    > O método HTTP PUT cria um novo recurso ou subsititui uma representação do recurso de destino com os novos dados.
    > - Retorna status 200 (OK) ou 204 (No Content) se o recurso tem uma representação atual e essa representação é modificada.
    > - Retorna status 201 (Created) se o recurso de destino não tem uma representação atual e foi criado.

- **PATCH**
    > O método HTTP PATCH aplica modificações parciais a um recurso. 
    > - Uma resposta bem-sucedida é indicada pelo status 204 (No Content), visto que a resposta não carrega um corpo de mensagem.

- **DELETE**
    > O método HTTP DELETE remove o recurso especificado.
    > - Retorna um código de status 200 (OK) se a ação foi realizada e a mensagem de resposta inclui uma representação descrevendo o status.
    > - Retorna um código de status 202 (Accepted) se a ação provavelmente teve sucesso, porém ainda não foi realizada.
    > - Retorna um código de status 204 (No Content) se a ação foi realizada e nenhuma outra informação deve ser fornecida.

## Comandos da CLI

Para iniciar a criação deste aplicativo utilizando a CLI:

```shell
dotnet new webapi -o ApiCatalogoDeJogos
```

Para executar o aplicativo utilizando a CLI:

```shell
dotnet run --project ApiCatalogoDejogos
```

## Melhorias

- Inclusão de novos atributos na entidade ``Jogo``
- Personalização da ***Documentação***
- Personalização das ***mensagens de erros de validação***
- Implementação de ***filtros***:
  > Os Filtros no ASP.NET Core permitem a execução de código antes ou depois de determinados estágios do pipeline de processamento de solicitações. ([documentação](https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-5.0))