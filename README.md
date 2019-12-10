# Repositório de TCCs

[![Build Status](https://netoarthur.visualstudio.com/TCC2019/_apis/build/status/Backend%20Master%20Build?branchName=master)](https://netoarthur.visualstudio.com/TCC2019/_build/latest?definitionId=5&branchName=master)

Um website que utiliza Angular8 e ASP.NET Core 2.2 para cadastrar e pesquisar trabalhos de conclusão de curso.

**Requisitos**

>ASP.NET Core Runtime 2.2.8 e Hosting Bundle:
>>https://dotnet.microsoft.com/download/dotnet-core/2.2

>Elasticsearch 7.x com o plugin Ingest
>>https://artifacts.elastic.co/downloads/elasticsearch/elasticsearch-7.5.0.msi

>MySQL
>>https://dev.mysql.com/downloads/file/?id=490395

**Opcionais**
>IIS Express
>>https://www.microsoft.com/pt-BR/download/details.aspx?id=48264

**Instalação**

1. Abrir o arquivo .sln no Visual Studio e realizar o Publish modo Release da API.
2. Alterar a ConnectionString dentro do arquivo appsettings.json de acordo com o que foi configurado.
3. Deve ser criado um website no IIS ou outro com a porta 8600.
4. Realizar o build do client através do comando npm run build.
5. Criar outro website, número da porta a escolha.
6. Executar o script CREATE_DB_MySql da pasta database no MySQL para criar o banco.
7. Executar o Elasticsearch se foi optado por não criar um serviço ou iniciar o serviço.
