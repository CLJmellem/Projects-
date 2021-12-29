const display =
  document.querySelector(".display"); /*querySelector utiliza comandos css */

const keyNumbers = document.querySelectorAll("[id*=tecla]");
const operatorKeys = document.querySelectorAll("[id*=operador]");
const historico = document.querySelector(".historico");

let newNumber = true;
let operator;
let lastNumber;
let calculoHistorico;

const attDisplay = (text) => {
  if (newNumber === true) {
    display.textContent = text;
    newNumber = false;
  } else {
    display.textContent += text;
  }
};

const insertNumber = (event) => attDisplay(event.target.textContent);

keyNumbers.forEach(function (tecla) {
  tecla.addEventListener("click", insertNumber);
});

const selectOperator = (event) => {
  newNumber = true;
  operator = event.target.textContent;
  calculoHistorico = display.textContent + operator;
  lastNumber = display.textContent.replace(",", ".");
};

operatorKeys.forEach((operator) => {
  operator.addEventListener("click", selectOperator);
});

const calculator = () => {
  if (operator !== undefined) {
    calculoHistorico += display.textContent;
    const number = display.textContent.replace(",", ".");
    newNumber = true;
    let result = eval(`${lastNumber}${operator}${number}`);
    if (result.toString().includes(".")) {
      result = result.toFixed(1);
    }
    calculoHistorico += "=" + result.toString().replace(".", ",");
    attDisplay(result.toString().replace(".", ","));
    operator = undefined;

    inserirHistorico();
  }
};

const equalFunc = () => calculator();
document.querySelector("#igual").addEventListener("click", equalFunc);

const clearDisplay = () => (display.textContent = "");
document
  .querySelector("#limparDisplay")
  .addEventListener("click", clearDisplay);

const clearAll = () => {
  clearDisplay();
  operator = undefined;
  result = undefined;
  newNumber = true;
  lastNumber = undefined;
};
document.querySelector("#limparCalculo").addEventListener("click", clearAll);

const backspace = () => {
  display.textContent = display.textContent.slice(0, -1);
};
document.querySelector("#backspace").addEventListener("click", backspace);

const invertNumber = () => {
  newNumber = true;
  attDisplay((display.textContent *= -1));
};
document.querySelector("#inverter").addEventListener("click", invertNumber);

const decimal = () => {
  if (display.textContent.includes(",")) {
    newNumber = false;
  } else {
    if (display.textContent.length > 0) {
      attDisplay(",");
    } else {
      attDisplay("0,");
    }
  }
};
document.querySelector("#decimal").addEventListener("click", decimal);

const inserirHistorico = () => {
  const novoHistorico = document.createElement("p");
  novoHistorico.textContent = calculoHistorico;

  historico.appendChild(novoHistorico);
  
  novoHistorico = undefined;
};
