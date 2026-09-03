const API_URL = "https://localhost:7113/api/solicitacaoexames";

let solicitacoesLaboratorio = [];

// CARREGAR USUÁRIO LOGADO
function carregarUsuarioLogado() {
  const nome = localStorage.getItem("usuarioNome");
  const perfil = localStorage.getItem("usuarioPerfil");

  if (!nome || !perfil) {
    return;
  }

  const nomeFormatado = nome.charAt(0).toUpperCase() + nome.slice(1);

  document.getElementById("nome-laboratorio").textContent = nomeFormatado;

  document.getElementById("inicial-laboratorio").textContent = nome
    .charAt(0)
    .toUpperCase();

  document.getElementById("perfil-laboratorio").textContent = perfil;
}

// CARREGAR SOLICITAÇÕES
async function carregarSolicitacoes() {
  try {
    const response = await fetch(API_URL);

    if (!response.ok) {
      throw new Error("Erro ao buscar solicitações.");
    }

    const solicitacoes = await response.json();

    solicitacoesLaboratorio = solicitacoes;

    atualizarCards(solicitacoesLaboratorio);
    renderizarSolicitacoes(solicitacoesLaboratorio);
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

  const hoje = new Date().toLocaleDateString("pt-BR");

  const concluidas = solicitacoes.filter((solicitacao) => {
    if (solicitacao.status !== "LaudoDisponivel") {
      return false;
    }

    const datasResultados = solicitacao.exames
      .filter((exame) => exame.dataResultado)
      .map((exame) => new Date(exame.dataResultado));

    if (datasResultados.length === 0) {
      return false;
    }

    const ultimaDataResultado = new Date(
      Math.max(...datasResultados.map((data) => data.getTime())),
    );

    return ultimaDataResultado.toLocaleDateString("pt-BR") === hoje;
  }).length;

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
          onclick="abrirSolicitacao(${solicitacao.id})"
        >
          ${obterTextoBotao(solicitacao.status)}
        </button>
      </td>
    `;

    tbody.appendChild(linha);
  });
}

// FILTRAR SOLICITAÇÕES
function filtrarSolicitacoes(status) {
  if (status === "Todos") {
    renderizarSolicitacoes(solicitacoesLaboratorio);
    return;
  }

  const solicitacoesFiltradas = solicitacoesLaboratorio.filter(
    (solicitacao) => solicitacao.status === status,
  );

  renderizarSolicitacoes(solicitacoesFiltradas);
}

// FORMATAR STATUS
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

// CLASSE CSS DO STATUS
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

// TEXTO DO BOTÃO
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

// ABRIR SOLICITAÇÃO
async function abrirSolicitacao(id) {
  try {
    const response = await fetch(`${API_URL}/${id}`);

    if (!response.ok) {
      throw new Error("Erro ao buscar solicitação.");
    }

    const solicitacao = await response.json();

    const detalhes = document.getElementById(
      "detalhes-solicitacao-laboratorio",
    );

    detalhes.innerHTML = `
      <p>
        <strong>Paciente:</strong>
        ${solicitacao.pacienteNome}
      </p>

      <p>
        <strong>Médico:</strong>
        ${solicitacao.usuarioNome}
      </p>

      <p>
        <strong>Data:</strong>
        ${new Date(solicitacao.dataSolicitacao).toLocaleDateString("pt-BR")}
      </p>

      <p>
        <strong>Status:</strong>
        ${formatarStatus(solicitacao.status)}
      </p>

      <hr>

      <h3 class="fs-6">
        Exames solicitados
      </h3>

      ${solicitacao.exames
        .map(
          (exame) => `
            <div class="mb-4">
              <strong>${exame.nome}</strong>

              ${
                exame.resultado
                  ? `
                    <p class="mt-2 mb-0">
                      ${exame.resultado}
                    </p>
                  `
                  : `
                    <textarea
                      class="form-control mt-2"
                      id="resultado-${exame.id}"
                      rows="3"
                      placeholder="Digite o resultado do exame"
                    ></textarea>

                    <button
                      class="btn btn-primary mt-2"
                      onclick="salvarResultado(
                        ${solicitacao.id},
                        ${exame.id}
                      )"
                    >
                      Salvar resultado
                    </button>
                  `
              }
            </div>
          `,
        )
        .join("")}
    `;

    const elementoModal = document.getElementById("modalSolicitacao");

    const modal = bootstrap.Modal.getOrCreateInstance(elementoModal);

    modal.show();
  } catch (erro) {
    console.error("Erro ao abrir solicitação:", erro);
  }
}

// SALVAR RESULTADO
async function salvarResultado(solicitacaoId, exameId) {
  const campoResultado = document.getElementById(`resultado-${exameId}`);

  const resultado = campoResultado.value.trim();

  if (!resultado) {
    alert("Informe o resultado do exame.");
    return;
  }

  try {
    const response = await fetch(
      `${API_URL}/${solicitacaoId}/exames/${exameId}/resultado`,
      {
        method: "PUT",

        headers: {
          "Content-Type": "application/json",
        },

        body: JSON.stringify({
          resultado: resultado,
        }),
      },
    );

    if (!response.ok) {
      throw new Error("Erro ao salvar resultado.");
    }

    await abrirSolicitacao(solicitacaoId);

    await carregarSolicitacoes();
  } catch (erro) {
    console.error("Erro ao salvar resultado:", erro);
  }
}

// FILTRO
document.getElementById("filtro-status").addEventListener("change", (event) => {
  filtrarSolicitacoes(event.target.value);
});

// INICIALIZAR PÁGINA
carregarUsuarioLogado();
carregarSolicitacoes();
