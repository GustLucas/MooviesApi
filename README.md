# MooviesApi
Durante esse projeto, aprendi como abrir comunicação para o mundo externo, a partir da nossa aplicação, com os Controllers.

Aprendi também a definir uma rota, como definir um controller da nossa API, as extensões que devemos fazer, a utilização do construtor para fazer injeção de dependência, a criação das actions, usei com diferentes verbos HTTP: HttpPost para criar recursos dentro do sistema; HttpGet para recuperar dados e para passar alguma informação.

Além disso, aprendi a fazer a paginação para não retornar muitas informações de uma só vez. Também como atualizar um recurso dentro do nosso sistema, com o verbo HttpPut vi que posso fazer uma busca a partir de um ID e alterar esse recurso dentro do nosso sistema.

Também vimos como fazer uma atualização de maneira parcial com o verbo HttpPatch, passando um ID e utilizando um JSON para fazer a alteração da maneira que precisarmos, sem passar outras informações que talvez não devam ser atualizadas nesse caso.

Por fim, como deletar com o verbo HttpDelete. Fiz a parte de recuperar a informação e deletar usando o Entity Framework para fazer comunicação com o banco de dados que utilizamos localmente.

Aprendi também boas práticas de como usar DTOs. Como criar DTOs para criação, para leitura, consegui utilizar informações que não necessariamente estarão no banco de dados, mas conseguiremos informar esses dados em tempo de execução.

Aprendi a configurar a aplicação através do appsettings.json. Como informações que serão carregadas em tempo de execução ou no momento de inicialização da aplicação.

Este foi o projeto feito duranto o Curso ".Net 6: Criando uma web API" da Alura!
