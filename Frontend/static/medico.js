async function carregarSolicitacoes() {
  const response = await fetch("https://localhost:7113/api/solicitacaoexames");

  const solicitacoes = await response.json();

  const totalSolicitacoes = solicitacoes.length;

  const totalAndamento = solicitacoes.filter(
    (solicitacao) => solicitacao.status === "EmAndamento",
  ).length;

  const totalConcluidos = solicitacoes.filter(
    (solicitacao) => solicitacao.status === "LaudoDisponivel",
  ).length;

  document.getElementById("total-solicitacoes").textContent = totalSolicitacoes;

  document.getElementById("total-andamento").textContent = totalAndamento;

  document.getElementById("total-concluidos").textContent = totalConcluidos;

  const tbody = document.getElementById("solicitacoes-lista");

tbody.innerHTML = "";

solicitacoes.forEach((solicitacao) => {
  const linha = document.createElement("tr");

  linha.innerHTML = `
    <td>${solicitacao.pacienteNome}</td>
    <td>${solicitacao.exames.length} exames</td>
    <td>${new Date(solicitacao.dataSolicitacao).toLocaleDateString("pt-BR")}</td>
    <td>
      <span class="status ${obterClasseStatus(solicitacao.status)}">
        ${formatarStatus(solicitacao.status)}
      </span>
    </td>
  `;

  tbody.appendChild(linha);
  });
}
function formatarStatus(status) {
  switch (status) {
    case "Solicitado":
      return "Solicitado";
    case "EmAndamento":
      return "Em Andamento";
    case "LaudoDisponivel":
      return "Laudo disponível";
    default:
      return status;
  }
}
function obterClasseStatus(status) {
  switch (status) {
    case "Solicitado":
      return "pending";

    case "EmAndamento":
      return "progress";

    case "LaudoDisponivel":
      return "completed";

    default:
      return "";
  }
}

carregarSolicitacoes();
