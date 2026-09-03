const SOLICITACOES_API_URL = "https://localhost:7113/api/solicitacaoexames";

async function carregarLaudo() {
  const parametros = new URLSearchParams(window.location.search);
  const solicitacaoId = parametros.get("solicitacaoId");

  if (!solicitacaoId) {
    console.error("Solicitação não informada.");
    return;
  }

  try {
    const response = await fetch(`${SOLICITACOES_API_URL}/${solicitacaoId}`);

    if (!response.ok) {
      throw new Error("Erro ao buscar solicitação.");
    }

    const solicitacao = await response.json();

    preencherLaudo(solicitacao);
  } catch (erro) {
    console.error("Erro ao carregar laudo:", erro);
  }
}

function preencherLaudo(solicitacao) {
  // Cabeçalho
  document.getElementById("nome-paciente-laudo").textContent =
    solicitacao.pacienteNome;

  document.getElementById("inicial-paciente-laudo").textContent =
    solicitacao.pacienteNome.charAt(0).toUpperCase();

  // Informações
  document.getElementById("paciente-laudo").textContent =
    solicitacao.pacienteNome;

  document.getElementById("medico-laudo").textContent = solicitacao.usuarioNome;

  document.getElementById("data-exame").textContent = new Date(
    solicitacao.dataSolicitacao,
  ).toLocaleDateString("pt-BR");

  // Resultados dos exames
  const resultados = document.getElementById("resultados-laudo");

  resultados.innerHTML = solicitacao.exames
    .map(
      (exame) => `
        <div class="resultado-exame">
          <strong>${exame.nome}</strong>

          <p>
            ${exame.resultado ?? "Resultado não disponível."}
          </p>
        </div>
      `,
    )
    .join("");
}

carregarLaudo();
