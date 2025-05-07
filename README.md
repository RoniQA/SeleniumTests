# Selenium Test Automation with LightBDD

Este projeto utiliza **Selenium**, **LightBDD**, e **xUnit** para realizar automação de testes de login em um site de demonstração. Ele foi projetado para testar o fluxo de login de um usuário com credenciais válidas.

## Tecnologias Usadas

- **Selenium**: Para automação de navegação no navegador.
- **LightBDD**: Para escrever testes em estilo BDD (Behavior-Driven Development).
- **xUnit**: Framework de testes unitários.
- **WebDriverManager**: Para gerenciar o driver do navegador automaticamente.
- **ChromeDriver**: Para utilizar o Google Chrome no ambiente de testes.
- **NUnit (opcional)**: Para relatórios de testes (caso decida reverter a implementação de relatórios).

## Pré-requisitos

Antes de executar este projeto, você precisa ter as seguintes ferramentas instaladas:

- **.NET SDK** (8.0 ou superior)
- **Chrome** e **ChromeDriver** ou **WebDriverManager**

## Configuração do Projeto

1. Clone o repositório:
    ```bash
    git clone https://github.com/seu-usuario/SeleniumTests.git
    cd SeleniumTests
    ```

2. Restaure as dependências do projeto:
    ```bash
    dotnet restore
    ```

3. **Build do Projeto**:
    Para compilar o projeto e garantir que tudo está configurado corretamente, execute:
    ```bash
    dotnet build --configuration Release
    ```

4. Para rodar os testes, basta executar o comando:
    ```bash
    dotnet test
    ```

## Estrutura de Diretórios

- **StepDefinitions**: Contém os arquivos de definição de passos para os testes.
- **Drivers**: Contém configurações globais, como inicialização e finalização dos testes.
- **Pages**: Contém as paginas que serão utilizadas.

## Executando os Testes

Este projeto possui um teste simples de login, no qual o **Selenium** realiza a navegação para a página de login, insere as credenciais e valida se o login foi bem-sucedido.

O cenário de teste é escrito em **C#** com o framework **LightBDD** e está estruturado da seguinte forma:

- **Given**: Inicializa o navegador e acessa a página de login.
- **When**: Insere as credenciais válidas e clica no botão de login.
- **Then**: Verifica se a página de inventário é exibida, indicando que o login foi realizado com sucesso.

## Execução no GitHub Actions (CI/CD)

Este projeto também pode ser executado no GitHub Actions para integração contínua.

### Configuração no GitHub Actions:

1. O arquivo `.yml` no diretório `.github/workflows` foi configurado para:

   - Configurar o ambiente com .NET SDK.
   - Instalar dependências.
   - Executar os testes.
   - Gerar relatórios de execução dos testes (se estiver configurado).
   
2. O processo de execução é automatizado e garante que todos os testes sejam executados sempre que um commit for enviado para o repositório.

## Licença

Este projeto é licenciado sob a licença MIT - consulte o arquivo [LICENSE](LICENSE) para mais informações.