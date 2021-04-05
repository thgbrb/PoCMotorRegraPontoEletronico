# PoC: Motor de Regra para Ponto Eletrônico
O objetivo dessa PoC é criar uma estrutura para validar as batidas de um ponto eletrônico. O desafio é que são várias regras que são aplicadas em uma coleção de batidas de um registro.

### Conceitos
Definições de conceitos das PoC.

#### Cálculos
Os cálculos são feitos com hora decimal.

#### Registro
Registro é uma coleção de batidas. Para um registro ser válido ele deverá ter um número par de batidas. Essa lógica é utilizada pois a regras são aplicadas nas comparações de pares de valores.
> Ex.: Intervalo da jornada, tempo máximo da jornada diária.

#### Batidas
Uma batida é uma struct que contém a hora, minuto e hora decimal. 

### Restrições
- O cálculo de jornada noturna ou jornadas que iniciam em um dia e finalizam e outro não está implementado. A PoC trabalha com o conceito de pares de registros (current e next) o que habilita a criação dessa validação.
- O motor não está considerando data para validar os registros, a fim de manter foco em validação de registros. A aplicação que utilizar o motor de regra deve controlar a ordem em que envia os registros para o motor.

### Padrões Utilizados
- Specification - Cada regra está descrita em uma espeficicação. Um exemplo de especificação é "A jornada de trabalho diária não deve ser superior a 9,5 horas.".
- Strategy - Uma estratégia é uma coleção de especificações. Um exemplo de estratégia é a validação de uma jornada de 40 horas semanais. Nessa estratégia deve ser aplicado uma coleção de especificações como por exemplo "A jornada de trabalho diária não deve ser superior a 9,5 horas." ou "O intervalo mínimo em uma jornada deve ser superior a 1 hora."
