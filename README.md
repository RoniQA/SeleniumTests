# Selenium Test Automation with LightBDD

Este projeto utiliza **Selenium**, **LightBDD**, e **xUnit** para realizar automa��o de testes de login em um site de demonstra��o. Ele foi projetado para testar o fluxo de login de um usu�rio com credenciais v�lidas.

## Tecnologias Usadas

- **Selenium**: Para automa��o de navega��o no navegador.
- **LightBDD**: Para escrever testes em estilo BDD (Behavior-Driven Development).
- **xUnit**: Framework de testes unit�rios.
- **WebDriverManager**: Para gerenciar o driver do navegador automaticamente.
- **ChromeDriver**: Para utilizar o Google Chrome no ambiente de testes.
- **NUnit (opcional)**: Para relat�rios de testes (caso decida reverter a implementa��o de relat�rios).

## Pr�-requisitos

Antes de executar este projeto, voc� precisa ter as seguintes ferramentas instaladas:

- **.NET SDK** (8.0 ou superior)
- **Chrome** e **ChromeDriver** ou **WebDriverManager**

## Configura��o do Projeto

1. Clone o reposit�rio:
    ```bash
    git clone https://github.com/seu-usuario/SeleniumTests.git
    cd SeleniumTests
    ```

2. Restaure as depend�ncias do projeto:
    ```bash
    dotnet restore
    ```

3. **Build do Projeto**:
    Para compilar o projeto e garantir que tudo est� configurado corretamente, execute:
    ```bash
    dotnet build --configuration Release
    ```

4. Para rodar os testes, basta executar o comando:
    ```bash
    dotnet test
    ```

## Estrutura de Diret�rios

- **StepDefinitions**: Cont�m os arquivos de defini��o de passos para os testes.
- **Drivers**: Cont�m configura��es globais, como inicializa��o e finaliza��o dos testes.
- **Pages**: Cont�m as paginas que ser�o utilizadas.

## Executando os Testes

Este projeto possui um teste simples de login, no qual o **Selenium** realiza a navega��o para a p�gina de login, insere as credenciais e valida se o login foi bem-sucedido.

O cen�rio de teste � escrito em **C#** com o framework **LightBDD** e est� estruturado da seguinte forma:

- **Given**: Inicializa o navegador e acessa a p�gina de login.
- **When**: Insere as credenciais v�lidas e clica no bot�o de login.
- **Then**: Verifica se a p�gina de invent�rio � exibida, indicando que o login foi realizado com sucesso.

## Execu��o no GitHub Actions (CI/CD)

Este projeto tamb�m pode ser executado no GitHub Actions para integra��o cont�nua.

### Configura��o no GitHub Actions:

1. O arquivo `.yml` no diret�rio `.github/workflows` foi configurado para:

   - Configurar o ambiente com .NET SDK.
   - Instalar depend�ncias.
   - Executar os testes.
   - Gerar relat�rios de execu��o dos testes (se estiver configurado).
   
2. O processo de execu��o � automatizado e garante que todos os testes sejam executados sempre que um commit for enviado para o reposit�rio.

## Licen�a

Este projeto � licenciado sob a licen�a MIT - consulte o arquivo [LICENSE](LICENSE) para mais informa��es.