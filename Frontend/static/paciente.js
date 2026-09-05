const PACIENTE_API_URL = "http://localhost:8080/api/paciente";
const SOLICITACOES_API_URL = "http://localhost:8080/api/solicitacaoexames";

let pacienteLogado = null;
let solicitacoesPaciente = [];

async function carregarPacienteLogado() {
  const usuarioId = Number(localStorage.getItem("usuarioId"));
  const usuarioNome = localStorage.getItem("usuarioNome");

  if (!usuarioId) {
    console.error("Usuário não encontrado no localStorage.");
    return;
  }

  try {
    const response = await fetch(`${PACIENTE_API_URL}/usuario/${usuarioId}`);

    if (!response.ok) {
      throw new Error("Paciente não encontrado.");
    }

    pacienteLogado = await response.json();

    document.getElementById("nome-paciente").textContent = pacienteLogado.nome;

    document.getElementById("inicial-paciente").textContent =
      pacienteLogado.nome.charAt(0).toUpperCase();

    document.getElementById("boasvindas-paciente").textContent =
      pacienteLogado.nome;

    console.log("Paciente logado:", pacienteLogado);
  } catch (erro) {
    console.error("Erro ao carregar paciente:", erro);
  }
  await carregarSolicitacoesPaciente();
}
async function carregarSolicitacoesPaciente() {
  try {
    const response = await fetch(SOLICITACOES_API_URL);

    if (!response.ok) {
      throw new Error("Erro ao buscar solicitações.");
    }

    const solicitacoes = await response.json();

    solicitacoesPaciente = solicitacoes.filter(
      (solicitacao) => solicitacao.pacienteId === pacienteLogado.id,
    );

    atualizarCards(solicitacoesPaciente);
    renderizarSolicitacaoAtual(solicitacoesPaciente);
    renderizarHistorico(solicitacoesPaciente);

    console.log("Solicitações do paciente:", solicitacoesPaciente);
  } catch (erro) {
    console.error("Erro ao carregar solicitações do paciente:", erro);
  }
}
function atualizarCards(solicitacoes) {
  const totalSolicitacoes = solicitacoes.length;

  const andamento = solicitacoes.filter(
    (solicitacao) => solicitacao.status === "EmAndamento",
  ).length;

  const concluidos = solicitacoes.filter(
    (solicitacao) => solicitacao.status === "LaudoDisponivel",
  ).length;

  document.getElementById("todos-solicitados").textContent = totalSolicitacoes;

  document.getElementById("todos-andamento").textContent = andamento;

  document.getElementById("todos-concluido").textContent = concluidos;
}
function renderizarSolicitacoes(solicitacoes) {
  const tbody = document.getElementById("solicitacoes-paciente");

  tbody.innerHTML = "";

  solicitacoes.forEach((solicitacao) => {
    const linha = document.createElement("tr");

    const nomesExames = solicitacao.exames
      .map((exame) => exame.nome)
      .join(", ");

    linha.innerHTML = `
      <td>
        <strong>${nomesExames}</strong>
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
        ${
          solicitacao.status === "LaudoDisponivel"
            ? `
      <a
        href="laudo.html?solicitacaoId=${solicitacao.id}"
        class="action-button"
      >
        Ver laudo
      </a>
    `
            : `
      <span class="action-disabled">
        Indisponível
      </span>
    `
        }
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
function renderizarHistorico(solicitacoes) {
  const concluidas = solicitacoes.filter(
    (solicitacao) => solicitacao.status === "LaudoDisponivel",
  );

  renderizarSolicitacoes(concluidas);
}
function renderizarSolicitacaoAtual(solicitacoes) {
  const container = document.getElementById("conteudo-solicitacao-atual");

  const abertas = solicitacoes.filter(
    (solicitacao) =>
      solicitacao.status === "Solicitado" ||
      solicitacao.status === "EmAndamento",
  );

  if (abertas.length === 0) {
    container.innerHTML = `
      <p>Nenhum exame em andamento no momento.</p>
    `;

    return;
  }

  const solicitacaoAtual = abertas.sort(
    (a, b) => new Date(b.dataSolicitacao) - new Date(a.dataSolicitacao),
  )[0];

  const nomesExames = solicitacaoAtual.exames
    .map((exame) => exame.nome)
    .join(", ");

  container.innerHTML = `
    <div class="patient-exam-header">
      <div>
        <span class="exam-label">
          ${
            solicitacaoAtual.status === "Solicitado"
              ? "EXAME SOLICITADO"
              : "EXAME EM ANDAMENTO"
          }
        </span>

        <h2>${nomesExames}</h2>

        <p>
          Solicitado por ${solicitacaoAtual.usuarioNome}
        </p>
      </div>

      <span
        class="status ${obterClasseStatus(solicitacaoAtual.status)}"
      >
        ${formatarStatus(solicitacaoAtual.status)}
      </span>
    </div>
  `;
}
carregarPacienteLogado();
