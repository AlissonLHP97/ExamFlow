let pacientes = [];

async function carregarPacientes() {

    try {

        const response = await fetch(
            "https://localhost:7113/api/Paciente"
        );

        if (!response.ok) {
            throw new Error("Erro ao buscar pacientes.");
        }

        pacientes = await response.json();

        // Atualiza o total de pacientes
        const totalPacientes = document.getElementById("total-pacientes");

        if (totalPacientes) {
            totalPacientes.textContent = pacientes.length;
        }

        mostrarPacientes(pacientes);

    } catch (error) {

        console.error("Erro:", error);

        const lista = document.getElementById("lista-pacientes");

        lista.innerHTML = `
            <tr>
                <td colspan="4">
                    Não foi possível carregar os pacientes.
                </td>
            </tr>
        `;
    }
}


function mostrarPacientes(listaPacientes) {

    const lista = document.getElementById("lista-pacientes");

    lista.innerHTML = "";

    if (listaPacientes.length === 0) {

        lista.innerHTML = `
            <tr>
                <td colspan="4">
                    Nenhum paciente encontrado.
                </td>
            </tr>
        `;

        return;
    }

    listaPacientes.forEach(paciente => {

        const linha = document.createElement("tr");

        linha.innerHTML = `
            <td>
                <strong>${paciente.nome}</strong>
            </td>

            <td>
                ${paciente.cpf}
            </td>

            <td>
                ${formatarData(paciente.dataNascimento)}
            </td>

            <td>
                ${paciente.telefone}
            </td>
        `;

        lista.appendChild(linha);

    });
}


function formatarData(data) {

    if (!data) {
        return "";
    }

    return new Date(data).toLocaleDateString("pt-BR");
}


const campoBusca = document.getElementById("buscar-paciente");

if (campoBusca) {

    campoBusca.addEventListener("input", function () {

        const busca = campoBusca.value
            .toLowerCase()
            .trim();

        const pacientesFiltrados = pacientes.filter(paciente => {

            const nome = paciente.nome?.toLowerCase() || "";
            const cpf = paciente.cpf?.toLowerCase() || "";
            const telefone = paciente.telefone?.toLowerCase() || "";

            return (
                nome.includes(busca) ||
                cpf.includes(busca) ||
                telefone.includes(busca)
            );

        });

        mostrarPacientes(pacientesFiltrados);

    });

}


carregarPacientes();