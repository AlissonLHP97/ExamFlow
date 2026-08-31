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

  const data = await response.json();

  if (response.ok) {
    localStorage.setItem("usuarioId", data.id);
    localStorage.setItem("usuarioNome", data.nome);
    localStorage.setItem("usuarioPerfil", data.perfil);

    if (data.perfil === "Medico") {
      window.location.href = "medico.html";
    } else if (data.perfil === "Laboratorio") {
      window.location.href = "laboratorio.html";
    }
  }
  if (!response.ok) {
    alert("E-mail ou senha inválidos.");
    return;
  }
});
