# API_To_Do_List
API CRUD para gestão de tarefas

O projeto foi criado em .NET 6
# Banco de dados
Para gerar o banco de dados é necessário executar um UPDATE-DATABASE a partir das migrações criadas na solução do projeto API_To_Do_List.Infra dentro do package manager console, fornecendo a conexão com o banco de dados em que será criada a tabela, caso necessário alterar a string de conexão com o banco de dados no arquivo appsettings.json no projeto API_To_Do_List, ou executar o arquivo DataBaseScript.sql em uma instância de SQL Server para gerar o banco de dados.

# Build
Para o Build é necessário instalar as dependências e adicionar as bibliotecas.
Para teste de rotas e verificação das mesma utilize o swagger no navegador, na seguinte rota: "/swagger/index.html"