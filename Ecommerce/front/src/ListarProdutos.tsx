import { useEffect } from "react";
//Componente
//1- O componente deve ser uma função
//2- Deve retornar apenas um elemento pai HTML
//3- Exportar o componente
//4- O nome da função precisa estar em PascalCase


function ListarProdutos(){

    //useEffect é método que permite executar algum código, no momento do carregamento do componente
    // Exercício é pegar os dados da requisição e mostrar no HTML dentro da lista utilizar Estado/Variável
    useEffect(() => {
       //Biblioteca AXIOS para requisições
        buscarProdutosAPI();
       
    }, []);

    async function buscarProdutosAPI(){
        try{
        
            const resposta = await fetch("http://localhost:5081/api/produto/listar")

            if(!resposta.ok){
                throw new Error("Requisição com problema: " + resposta.statusText);
            }

            const dados = await resposta.json();

            console.table(dados);
        } catch(error){
            console.log("Requisição com problema: " + error);
        };
        
    }

    return (
        <div id="listar_produtos">
            <h1>Listar Produtos</h1>
            <ul>
                <li></li>
                <li></li>
                <li></li>
                <li></li>
            </ul>
        </div>
    );
}

export default ListarProdutos;