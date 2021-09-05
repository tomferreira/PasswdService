# PasswdService

Uma simples aplicação microsserviço serveless que implementa serviços relacionados à autenticação feito com Azure Functions.

## Implementação

A solução implementa a arquiteteura de microsseriço e REST, juntamente com Azure Funtions, o componente de computação sem servidor (serveless) da Azure Cloud, mas poderia ter sido usado qualquer outro componente do tipo, como o AWS Lambda.

Essa arquitetura foi escolhida porque permite a implementação de serviços fracamente acoplados, o que facilita a sua extensão futura. Além disso, essa arquitetura é extremamente escalável, leve, possui baixo custo de manutenção e um ótimo custo-benefício financeiro.

A solução é dividida em 3 componentes:

* O componente API contém a definição dos serviços, protocolos e a toda a infraestrutura relacionada, como a biblioteca Azure Functions SDK.
* O componente de domínio contém as definições das regras de negócio em si.
* O componente de teste contém as testes de unidade.

## API

Por enquanto foi implementado somente um único serviço.

### Checker: [POST] /api/Checker

Verifica se a senha é válida ou não. Caso não seja válida, retorna o motivo, por exemplo InvalidNoneDigit.

Para uma senha ser considerada válida, precisa ter 6 propriedades:

1. 9 ou mais caracteres;
2. Ao menos 1 dígito númerico;
3. Ao menos 1 letra maiúscula;
4. Ao menos 1 letra minúscula;
5. Ao menos 1 caracter especial;
6. Não possuir caracteres repetidos.

Atenção: Este serviço aceita somente requisições com método POST para evitar que a senha seja enviada na URL e evitar possível vazamento, uma vez que o navegador pode guardar em cache ou no histórico a URL das requisições GET contendo a senha em texto plano.

A ordem de verificação das propriedades da senha acima não é importante.

Naturalmente, uma letra minúscula é considerada um caracter diferente da sua versão maiúscula, da mesma forma é com as variações com acentos.

## Iniciando

Para debugar localmente, instale o Azure Functions Core Tools:
```sh
$ npm i -g azure-functions-core-tools@3 --unsafe-perm true
```

E execute:
```sh
$ cd PasswdService.Api && func host start
```

A aplicação ficará no ar no endereço http://localhost:7071/.

## Testes de unidade

Para executar os testes de unidades, execute o seguinte comando:
```sh
$ dotnet test
```