const form = document.getElementById("login-form");

form.addEventListener("submit", async function (event) {
  event.preventDefault();

  const email = document.getElementById("email").value;
  const senha = document.getElementById("password").value;

  const response = await fetch("https://localhost:7113/api/usuario/login", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      email: email,
      senha: senha,
    }),
  });
  if (!response.ok) {
    alert("E-mail ou senha inválidos.");
    return;
  }

  const data = await response.json();

  localStorage.setItem("usuarioId", data.id);
  localStorage.setItem("usuarioNome", data.nome);
  localStorage.setItem("usuarioPerfil", data.perfil);

  switch (data.perfil) {
    case "Administrador":
      window.location.href = "admin.html";
      break;
    case "Laboratorio":
      window.location.href = "laboratorio.html";
      break;
    case "Medico":
      window.location.href = "medico.html";
      break;
    case "Paciente":
      window.location.href = "paciente.html";
    break;
    case "Recepcionista":
      window.location.href = "recepcionista.html";
      break;

    default:
      alert("Perfil de usuário não reconhecido.");
      break;
  }
});
