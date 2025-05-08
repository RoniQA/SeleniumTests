# Selenium Test Automation with LightBDD

Este projeto utiliza **Selenium**, **LightBDD**, e **xUnit** para realizar automação de testes de login em um site de demonstração. Ele foi projetado para testar o fluxo de login de um usuário com diferentes cenários.

## Tecnologias Usadas

- **Selenium**: Para automação de navegação no navegador.
- **LightBDD**: Para escrever testes em estilo BDD (Behavior-Driven Development).
- **xUnit**: Framework de testes unitários.
- **WebDriverManager**: Para gerenciar o driver do navegador automaticamente.
- **ChromeDriver**: Para utilizar o Google Chrome no ambiente de testes.

## Pré-requisitos

Antes de executar este projeto, você precisa ter as seguintes ferramentas instaladas:

- **.NET SDK** (8.0 ou superior)
- **Google Chrome** instalado localmente (ou ambiente que suporte o ChromeHeadless)

## Configuração do Projeto

1. Clone o repositório:
    ```bash
    git clone https://github.com/RoniQA/SeleniumTests.git
    cd SeleniumTests
    ```

2. Restaure as dependências do projeto:
    ```bash
    dotnet restore
    ```

3. Compile o projeto:
    ```bash
    dotnet build --configuration Release
    ```

4. Execute os testes:
    ```bash
    dotnet test --configuration Release --no-build
    ```

## Estrutura de Diretórios

- **StepDefinitions**: Contém os arquivos de definição de passos para os testes.
- **Pages**: Contém a implementação da estrutura Page Object Model.
- **Utils**: Pode conter arquivos auxiliares, como métodos comuns ou helpers.
- **TestResults**: Pasta para armazenar os resultados de execução dos testes (caso tenha habilitado relatórios).

## Cenários de Teste Implementados

- ✅ Login com credenciais válidas.
- ❌ Login com credenciais inválidas.
- ❌ Tentativa de login com campos vazios.

> Os cenários ❌ serão implementados gradualmente. A base já está preparada para incluí-los.

## Estilo BDD com LightBDD

Este projeto utiliza **LightBDD** para organizar os testes no estilo **Given-When-Then**. Exemplo:

```csharp
[Scenario]
public void User_logs_in_successfully()
{
    Runner.RunScenario(
        given => GivenIAmOnTheLoginPage(),
        when => WhenIEnterValidCredentials(),
        then => ThenIShouldBeLoggedIn()
    );
}


## 🧪 Cenários de Testes Implementados

### ✅ Cenário 1 – Login com credenciais válidas

- Acessa a página de login
- Insere credenciais válidas
- Verifica que a página de inventário está visível

### 🚫 Cenário 2 – Login com usuário inválido

- Acessa a página de login
- Tenta login com usuário inválido
- Verifica a exibição de mensagem de erro

### 🚫 Cenário 3 – Login com senha inválida

- Acessa a página de login
- Tenta login com senha inválida
- Verifica a exibição de mensagem de erro

### ⚠️ Cenário 4 – Tentativa de login com campos vazios

- Acessa a página de login
- Clica no botão de login com campos vazios
- Verifica que uma mensagem de erro é exibida

## 🔁 CI/CD com GitHub Actions

A pipeline de CI no GitHub executa automaticamente os testes a cada push ou pull request para a branch `master`. Isso garante a validação contínua dos testes.

## 🤝 Contribuição

Sinta-se à vontade para contribuir! Crie uma branch, realize suas melhorias e envie um pull request. Sugestões de novos testes e melhorias são bem-vindas.

## 📝 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.