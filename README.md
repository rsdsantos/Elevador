# Elevador
O programa representa um software de elevador de forma bastante simplificada. Os andares do elevador são representados por um array que controla as viagens do usuário.

## State Pattern
Para controlar as viagens foi implementado o padrão de projeto [State](https://pt.wikipedia.org/wiki/State), que é utilizado quando o comportamento de um objeto muda. Para este programa foram implementados os seguintes estados: Subindo, Descendo e Parado. 

Cada estado tem a responsabilidade de posicionar o usuário no Controle (array de andares) conforme a decisão de subir ou descer.

##Informações gerais
* O uso do padrão State pode ser considerado over pela simplicidade do programa, mas a intenção é mostrar os ganhos de isolamento e extensibilidade com OO. A não utilização do padrão poderia ferir o principio [Open/Closed](https://en.wikipedia.org/wiki/Open%E2%80%93closed_principle);
* O projeto está no framework .NET Core 2.1;
