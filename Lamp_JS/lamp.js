function lamp() {
  var lampVerify = String(document.getElementById("lampada").src);
  
  if (lampVerify.includes("desligada"))
    document.getElementById("lampada").src = "./img/ligada.jpg";
  else 
    document.getElementById("lampada").src = "./img/desligada.jpg";
}

document.getElementById("botao").addEventListener("click", lamp);
