Feature: Login

  Como um usuário
  Eu quero fazer login na aplicação
  Para acessar o sistema

  Cenário: Usuário deve conseguir logar com credenciais válidas
    Dado que eu inicializei o navegador
    E acessei a página de login
    Quando eu inserir credenciais válidas
    E clicar em login
    Então eu devo ser redirecionado para a página inicial