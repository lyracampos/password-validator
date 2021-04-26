# password-validator

## introdução
API desenvolvida para verificar se uma senha atende à um conjunto de regras específicas.

## pré requisitos
.net 5.0

## técnologias
<br />framework .net 5.0
<br />language c# 8.0

## como utilizar
**opção 1**
abrir cmd, ir no diretório da aplicação e rodar os comandos abaixo:

```Bash
cd PasswordValidator.Api
dotnet run
```

**opção 2**
abrir a aplicação no visual studio ou vscode e rodar a aplicação

**testando**
<br />abrir o navegador e acessar
<br />https://localhost:5001/swagger/index.html
<br />ou
<br />http://localhost:5000/swagger/index.html

## como rodar testes unitários e integrados
abrir cmd, ir no diretório da aplicação e rodar os comandos abaixo:
```Bash
cd PasswordValidator.Tests
dotnet test
```


## Solução abordada para o desafio
Optei por abstrair o comportamento das validações em uma classe abstrata (ValidatePassword) com métodos e propriedades para tal. As classes (Specifications) que herdam da classe abstrata ficam responsáveis por cada regra específica do conjunto de validações. Assim temos classes responsáveis por cada verificação e podemos compor elas de acordo com a necessidade.

Os testes unitários foram feitos para cada regra e o teste integrado para a o endpoint da API.

### Outra solução possível
O mesmo problema poderia ser feito atraves de partial class. Fico à disposição para implantar.
