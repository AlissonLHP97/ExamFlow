async function carregarSolicitacoes()
{
    const response = await fetch("https://localhost:7113/api/solicitacaoexames");

    const solicitacoes = await response.json();

    console.log(solicitacoes);
}

carregarSolicitacoes();