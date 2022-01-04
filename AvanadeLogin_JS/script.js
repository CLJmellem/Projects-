const validaCPF = (cpf) => {

  var soma;
  var resto;
  soma = 0;
  if (cpf == "00000000000") return false;

  for (i = 1; i <= 9; i++) 
		soma = soma + parseInt(cpf.substring(i - 1, i)) * (11 - i);

  resto = (soma * 10) % 11;

  if ((resto == 10) || (resto == 11)) resto = 0;
  if (resto != parseInt(cpf.substring(9, 10))) return false;

  soma = 0;
  for (i = 1; i <= 10; i++) soma = soma + parseInt(cpf.substring(i - 1, i)) * (12 - i);
  resto = (soma * 10) % 11;

  if ((resto == 10) || (resto == 11)) resto = 0;
  if (resto != parseInt(cpf.substring(10, 11))) return false;
  return true;
};

const mascaraCpf = (cpf) => {
  return cpf
    ? cpf
        .replace(/\D/g, "")
        .replace(/(\d{3})(\d)/, "$1.$2")
        .replace(/(\d{3})(\d)/, "$1.$2")
        .replace(/(\d{3})(\d{1,2})/, "$1-$2")
        .replace(/(-\d{2})\d+?$/, "$1")
    : "";
};


const inputCPF = document.querySelector("#inputCPF");
const erroInput = document.querySelector(".erro-input");
const spinner = document.querySelector(".spinner-loading");

const forms = document.querySelector(".form-onboarding");

//quando submeter, apertar enter, nao deixa o navegador submeter para a action
forms.addEventListener("submit", (event) => {
  event.preventDefault();
});

const unmaskedCpf = (maskedCpf) =>{
  return maskedCpf.replace(/\D/g, "");
}
const handleCpfInput = (event) => {

  const unmaskCpf = unmaskedCpf(event.target.value);
  if(validaCPF(unmaskCpf)){
    erroInput.style.display = "none";
    inputCPF.style.borderBottom = "1px solid black";
    redirectAvanade();
  }
  else{
    erroInput.style.display = "block";
    inputCPF.style.borderBottom = "1px solid red";
  }

  const maskedCpf = mascaraCpf(event.target.value);
  event.target.value = maskedCpf;
}

const redirectAvanade = () => {
  spinner.style.display = "block";

  setTimeout(() => {
    spinner.style.display = "none";
    /*window.open("https://www.avanade.com/pt-br" , "_blank"); //outra pag */
    window.location.href = "https://www.avanade.com/pt-br"; //mesma pag 
  }, 2000); //espera 2 segundo e redireciona para o site  
}
inputCPF.addEventListener("input", handleCpfInput);
