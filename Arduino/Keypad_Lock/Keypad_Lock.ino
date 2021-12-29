
/*********************************************************************************

   Guia de conexão:
    
   Tinkercad project: https://www.tinkercad.com/things/9RrXxbXFMij
    
   Arduino:
   LINHA 1 TECLADO: Pino Digital 9
   LINHA 2 TECLADO: Pino Digital 8
   LINHA 3 TECLADO: Pino Digital 7
   LINHA 4 TECLADO: Pino Digital 6

   COLUNA 1 TECLADO: Pino Digital 5
   COLUNA 2 TECLADO: Pino Digital 4
   COLUNA 3 TECLADO: Pino Digital 3
   COLUNA 4 TECLADO: Pino Digital 2
   
   LED VERMELHO: Pino Digital 10
   LED VERDE: Pino Digital 11
   BUZZER: Pino Digital 13
   
  
   Este código utiliza a biblioteca Keypad
      
 ***************************************************************************** */

// Inclusão da biblioteca do módulo teclado
#include <Keypad.h>

/************************ DEFINIÇÃO DE SENHA ******************************* */

char* senha = "C#1109";  // defina a senha aqui, ela deve conter seis dígitos

/************************ CONFIGURAÇÕES TECLADO ******************************* */

const byte LINHAS = 4; // quantidade de linhas do teclado
const byte COLUNAS = 4; // quantidade de colunas do teclado

char digitos[LINHAS][COLUNAS] = {
{'1','2','3','A'},
{'4','5','6','B'},
{'7','8','9','C'},
{'*','0','#','D'}}; // todos os caracteres do teclado

byte pinosLinha[LINHAS] = { 9, 8, 7, 6 }; // pinos de conexão das linhas no arduino 
byte pinosColuna[COLUNAS] = { 5, 4, 3, 2 }; // pinos de conexão das colunas no arduino 

Keypad keypad = Keypad( makeKeymap(digitos), pinosLinha, pinosColuna, LINHAS, COLUNAS ); // objeto de leitura das teclas com os parâmetros lidos

/************************ VARIÁVEIS AUXILIARES ******************************* */

int position = 0;
int ledVermelho = 10;
int ledVerde = 11;
int buzzer = 13;
int tempoBuzz = 50;
int tempoAberto = 2000;

/***************************************************************************** */

void setup()
{ 
  
  estadoPorta(true); // diz se a porta está ou não trancada

  pinMode(ledVermelho,OUTPUT); 
  pinMode(ledVerde,OUTPUT);
  pinMode(buzzer,OUTPUT); // define os pinos de saída do arduino

}

void loop()
{
  
  char digito = keypad.getKey(); // faz a leitura das teclas
  digitalWrite(ledVermelho, HIGH);
  

  if (digito !=0)
  {
      digitalWrite(buzzer, HIGH);
      delay(tempoBuzz);
    digitalWrite(buzzer, LOW); // acionamento do buzzer ao apertar qualquer tecla
    
    if (digito == senha[position]) // verifica se o dígito apertado corresponde ao equivalente da senha
    {
      position ++;
    }
    else { // retorna a leitura para a primeira posição de leitura da senha quando o dígito apertado não corresponde ao correto 
    position = 0;
    }
    if (position == 6) // altera estado da porta  
    {
      estadoPorta(false);
    }
    delay(100);
  }
}

void estadoPorta(bool trancado)
{
  
  if (trancado == true) // trancamento da porta
  {
    digitalWrite(ledVermelho, HIGH);
    digitalWrite(ledVerde, LOW);
  }

  else // abertura da porta
  {
    digitalWrite(ledVermelho, LOW);
    digitalWrite(ledVerde, HIGH);
    digitalWrite(buzzer, HIGH);
    delay(tempoBuzz*10);
    digitalWrite(buzzer, LOW); // buzzer indica o acerto da senha 
    delay(tempoAberto);
    position = 0;
    estadoPorta(true); // tranca a porta novamente 
  }
}
