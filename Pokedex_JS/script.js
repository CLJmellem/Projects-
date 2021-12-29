createPokemon = () => {

    var data;
    var names = [];
    var pokeData = new XMLHttpRequest();
    pokeData.open("GET", "./pokeData.txt", false);

    pokeData.onreadystatechange = () =>{
        if(pokeData.readyState === 4){
            if(pokeData.status === 200 || pokeData.status == 0){
                data = pokeData.response;    
            }
        }
    };
    pokeData.send(null);

    
    names = new String(data).split("\r\n");

    for(i = 0; i < 151; i++){
        let div = document.createElement("div");
        let img = document.createElement("img");
        img.src = "./IMG/"+(i+1)+".png";
        img.id = "img"+i;
        img.className = "pokemonIMG"
        div.className = "pokemon";
        div.id = i;
        div.textContent = (i+1)+"# "+ names[i];

        document.body.appendChild(div);
        document.getElementById(i).appendChild(img);
    }

};

removeButton = () =>{

    document.getElementById("container").remove();
}

document.getElementById("pokebola").addEventListener("click", createPokemon);
document.getElementById("pokebola").addEventListener("click", removeButton);
