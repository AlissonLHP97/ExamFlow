const API_URL = "https://localhost:7113/api/solicitacaoexames";

// CARREGAR SOLICITAÇÕES
async function carregarSolicitacoes() {
  try {
    const response = await fetch(API_URL);

    if (!response.ok) {
      throw new Error("Erro ao buscar solicitações.");
    }

    const solicitacoes = await response.json();

    atualizarCards(solicitacoes);
    renderizarSolicitacoes(solicitacoes);
  } catch (erro) {
    console.error("Erro ao carregar solicitações:", erro);
  }
}

// ATUALIZAR CARDS
function atualizarCards(solicitacoes) {
  const novas = solicitacoes.filter(
    (solicitacao) => solicitacao.status === "Solicitado",
  ).length;

  const andamento = solicitacoes.filter(
    (solicitacao) => solicitacao.status === "EmAndamento",
  ).length;

  const concluidas = solicitacoes.filter(
    (solicitacao) => solicitacao.status === "LaudoDisponivel",
  ).length;

  document.getElementById("total-novas").textContent = novas;

  document.getElementById("total-andamento").textContent = andamento;

  document.getElementById("total-concluidas").textContent = concluidas;
}

// RENDERIZAR TABELA
function renderizarSolicitacoes(solicitacoes) {
  const tbody = document.getElementById("solicitacoes-laboratorio");

  tbody.innerHTML = "";

  solicitacoes.forEach((solicitacao) => {
    const linha = document.createElement("tr");

    linha.innerHTML = `
      <td>
        <strong>${solicitacao.pacienteNome}</strong>
      </td>

      <td>
        ${solicitacao.exames.length} exames
      </td>

      <td>
        ${solicitacao.usuarioNome}
      </td>

      <td>
        ${new Date(solicitacao.dataSolicitacao).toLocaleDateString("pt-BR")}
      </td>

      <td>
        <span class="status ${obterClasseStatus(solicitacao.status)}">
          ${formatarStatus(solicitacao.status)}
        </span>
      </td>

      <td>
        <button
          class="action-button"
          onclick="abrirSolicitacao(${solicitacao.id})">
          ${obterTextoBotao(solicitacao.status)}
        </button>
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
      return "Em andamento";

    case "LaudoDisponivel":
      return "Concluído";

    default:
      return status;
  }
}

function obterClasseStatus(status) {
  switch (status) {
    case "Solicitado":
      return "pending";

    case "EmAndamento":
      return "andamento";

    case "LaudoDisponivel":
      return "completed";

    default:
      return "";
  }
}

function obterTextoBotao(status) {
  switch (status) {
    case "Solicitado":
      return "Iniciar";

    case "EmAndamento":
      return "Continuar";

    case "LaudoDisponivel":
      return "Visualizar";

    default:
      return "Abrir";
  }
}

function abrirSolicitacao(id) {
  console.log("Solicitação selecionada:", id);
}

carregarSolicitacoes();
