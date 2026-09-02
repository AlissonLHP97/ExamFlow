const API_URL = "https://localhost:7113/api/solicitacaoexames";
const PACIENTES_API_URL = "https://localhost:7113/api/paciente";
const EXAMES_API_URL = "https://localhost:7113/api/exame";

// CARREGAR DASHBOARD
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
}

// RENDERIZAR TABELA
function renderizarSolicitacoes(solicitacoes) {
  const tbody = document.getElementById("solicitacoes-lista");

  tbody.innerHTML = "";

  solicitacoes.forEach((solicitacao) => {
    const linha = document.createElement("tr");

    linha.innerHTML = `
      <td>${solicitacao.pacienteNome}</td>

      <td>${solicitacao.exames.length} exames</td>

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
          class="details-button"
          onclick="verDetalhes(${solicitacao.id})">
          Ver detalhes
        </button>
      </td>
    `;

    tbody.appendChild(linha);
  });
}

// FORMATAR STATUS
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

// VER DETALHES

async function verDetalhes(id) {
  try {
    const response = await fetch(`${API_URL}/${id}`);

    if (!response.ok) {
      throw new Error("Erro ao buscar detalhes da solicitação.");
    }

    const solicitacao = await response.json();

    const detalhes = document.getElementById("detalhes-solicitacao");

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
        <strong>Data da solicitação:</strong>
        ${new Date(solicitacao.dataSolicitacao).toLocaleDateString("pt-BR")}
      </p>

      <p>
        <strong>Status:</strong>
        <span class="status ${obterClasseStatus(solicitacao.status)}">
          ${formatarStatus(solicitacao.status)}
        </span>
      </p>

      <hr>

      <h3>Exames</h3>

      ${solicitacao.exames
        .map(
          (exame) => `
            <div class="exame-detalhe">
              <strong>${exame.nome}</strong>

              <p>
                <strong>Resultado:</strong>
                ${exame.resultado ?? "Resultado ainda não disponível"}
              </p>

              ${
                exame.dataResultado
                  ? `
                    <p>
                      <strong>Data do resultado:</strong>
                      ${new Date(exame.dataResultado).toLocaleDateString(
                        "pt-BR",
                      )}
                    </p>
                  `
                  : ""
              }
            </div>
          `,
        )
        .join("")}
    `;

    const elementoModal = document.getElementById("modalDetalhes");

    const modal = bootstrap.Modal.getOrCreateInstance(elementoModal);

    modal.show();
  } catch (erro) {
    console.error("Erro ao carregar detalhes:", erro);
  }
}
// Carrega os pacientes cadastrados na API e preenche o campo de seleção em ordem alfabética.
async function carregarPacientes() {
  try {
    const response = await fetch(PACIENTES_API_URL);

    if (!response.ok) {
      throw new Error("Erro ao buscar pacientes.");
    }

    const pacientes = await response.json();

    const selectPaciente = document.getElementById("paciente");

    selectPaciente.innerHTML = `
      <option value="">
        Selecione um paciente
      </option>
    `;
    pacientes.sort((a, b) => a.nome.localeCompare(b.nome, "pt-BR"));

    pacientes.forEach((paciente) => {
      const option = document.createElement("option");

      option.value = paciente.id;
      option.textContent = paciente.nome;

      selectPaciente.appendChild(option);
    });
  } catch (erro) {
    console.error("Erro ao carregar pacientes:", erro);
  }
}
// Carrega os exames cadastrados na API e exibe as opções.
async function carregarExames() {
  try {
    const response = await fetch(EXAMES_API_URL);

    if (!response.ok) {
      throw new Error("Erro ao buscar exames.");
    }

    const exames = await response.json();

    const listaExames = document.getElementById("lista-exames");

    listaExames.innerHTML = "";

    exames.forEach((exame) => {
      const div = document.createElement("div");

      div.classList.add("form-check", "mb-2");

      div.innerHTML = `
        <input
          class="form-check-input exame-checkbox"
          type="checkbox"
          value="${exame.id}"
          id="exame-${exame.id}"
        >

        <label
          class="form-check-label ms-2"
          for="exame-${exame.id}">
          ${exame.nome}
        </label>
      `;

      listaExames.appendChild(div);
    });
  } catch (erro) {
    console.error("Erro ao carregar exames:", erro);
  }
}
//Cria uma nova solicitação.
async function criarSolicitacao() {
  try {
    const pacienteId = Number(document.getElementById("paciente").value);

    const usuarioId = Number(localStorage.getItem("usuarioId"));

    const examesSelecionados = document.querySelectorAll(
      ".exame-checkbox:checked",
    );

    const exameIds = Array.from(examesSelecionados).map((exame) =>
      Number(exame.value),
    );

    if (!pacienteId) {
      alert("Selecione um paciente.");
      return;
    }

    if (exameIds.length === 0) {
      alert("Selecione pelo menos um exame.");
      return;
    }

    const dados = {
      pacienteId,
      usuarioId,
      exameIds,
    };

    const response = await fetch(API_URL, {
      method: "POST",

      headers: {
        "Content-Type": "application/json",
      },

      body: JSON.stringify(dados),
    });

    if (!response.ok) {
      throw new Error("Erro ao criar solicitação.");
    }

    const elementoModal = document.getElementById("modalNovaSolicitacao");

    const modal = bootstrap.Modal.getOrCreateInstance(elementoModal);

    modal.hide();

    document.getElementById("paciente").value = "";

    document.querySelectorAll(".exame-checkbox").forEach((exame) => {
      exame.checked = false;
    });

    await carregarSolicitacoes();
    carregarSolicitacoes();
  } catch (erro) {
    console.error("Erro ao criar solicitação:", erro);
  }
}
document
  .getElementById("btn-criar-solicitacao")
  .addEventListener("click", criarSolicitacao);
// INICIAR DASHBOARD
carregarSolicitacoes();
carregarPacientes();
carregarExames();
