# ExamFlow

O **ExamFlow** é uma aplicação completa (Full-Stack) projetada para a gestão e realização de exames ou fluxos de avaliações. O projeto está estruturado de forma desacoplada, contendo um ecossistema de **Backend** robusto em C# e uma interface de **Frontend** para interação com o utilizador.

---

## 🚀 Arquitetura do Projeto

O repositório está dividido em duas componentes principais:

1. **Backend (`/Backend/ExamFlow.API`):** 
   * Desenvolvido em C# sobre a plataforma .NET
   * Arquitetura baseada em Web API Restful.
   * Integração com base de dados SQL Server e controlo de migrações automáticas através do EvolveDb.
2. **Frontend (`/Frontend`): 
   * Interface visual da aplicação (Single Page Application / Web App).
   * Desenvolvido sobre o ecossistema Node.js.

---

## 🛠️ Pré-requisitos

Antes de começares, garante que tens as seguintes ferramentas instaladas na tua máquina:
* [.NET SDK](https://dotnet.microsoft.com/) (Versão estável atualizada)
* [Node.js e NPM](https://nodejs.org/) (Para executar a interface visual)
* [Docker Desktop](https://www.docker.com/) (Recomendado para utilizadores de macOS/Linux executarem o SQL Server localmente) ou uma instância do SQL Server ativa.

---

## 🏁 Como Executar a Aplicação

### 1. Configuração da Base de Dados (SQL Server)
Caso estejas a utilizar o macOS ou não tenhas um SQL Server nativo, cria um contentor Docker com o comando:
```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=SuaSenhaForte123!" -p 1433:1433 --name sql_server -d mcr.microsoft.com/mssql/server:2022-latest
```
*Nota: Lembra-te de ajustar as credenciais de ligação no ficheiro `appsettings.json` ou `appsettings.Development.json` dentro da pasta da API antes de iniciar o backend.*

### 2. Iniciar o Backend (.NET C#)
Abre o teu terminal, navega até à pasta do microsserviço da API e executa o servidor:
```bash
# Entrar na pasta do projeto Backend
cd Backend/ExamFlow.API

# Restaurar as dependências do .NET
dotnet restore

# Executar a aplicação em modo de desenvolvimento
dotnet run
```
O servidor de dados e endpoints da API ficará disponível no endereço local indicado no teu terminal (geralmente `http://localhost:5000` ou similar).

### 3. Iniciar o Frontend (Interface Web)
Abra uma **nova janela** do terminal para manter o backend ativo em simultâneo e execute os seguintes comandos:
```bash
# Entrar na pasta do Frontend
cd Frontend

# Instalar os pacotes e dependências do Node.js
npm install

# Iniciar o servidor de desenvolvimento web
npm start
```
Após a compilação, o teu navegador irá abrir automaticamente a interface do ExamFlow.

---

## 🧪 Tecnologias Utilizadas

* **Linguagem Principal:** C# (C-Sharp)
* **Plataforma Core:** .NET Web API
* **Gestão de Base de Dados:** EvolveDb (Database Migration Tool)
* **Persistência / Client:** Microsoft.Data.SqlClient para SQL Server
* **Ambiente de Frontend:** Ecossistema Node.js / NPM

---
Este projeto foi clonado e adaptado a partir do repositório público [AlissonLHP97/ExamFlow](https://github.com/AlissonLHP97/ExamFlow.git).
