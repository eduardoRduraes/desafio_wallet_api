# Wallet API

Bem-vindo à **Wallet API**, um projeto desenvolvido para o desafio técnico de Backend da WL Consultings. Este repositório contém uma API para gerenciar carteiras digitais e transações financeiras.

---

## 🚀 Funcionalidades

- **Autenticação JWT**
  - Login e registro de novos usuários.
- **Gerenciamento de Carteiras**
  - Consulta de saldo.
  - Adição de saldo.
- **Transferências**
  - Transferências entre carteiras de diferentes usuários.
  - Listagem de transferências com suporte a filtros por período.
- **Documentação**
  - API documentada automaticamente com Swagger.

---

## 🎯 Tecnologias Utilizadas

- **C#** com **.NET 9.0**
- **PostgreSQL** como banco de dados relacional
- **JWT** para autenticação
- **Swagger** para documentação da API
- **Docker** e **Docker Compose** para containerização

---

## 🛠️ Pré-requisitos

Antes de começar, você precisará ter as seguintes ferramentas instaladas:

- [.NET SDK 9.0](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Docker](https://www.docker.com/) e [Docker Compose](https://docs.docker.com/compose/) (opcional)
- [PostgreSQL](https://www.postgresql.org/) (se não for usar Docker)

---

## 🚀 Como Executar o Projeto

### **1. Configuração com Docker (Recomendado)**

> Certifique-se de que o Docker está instalado e em execução.

1. Clone este repositório:
   ```bash
   git clone https://github.com/eduardoRduraes/desafio_wallet_api.git
   cd desafio_wallet_api
   ```

2. Construa e inicie os containers:
   ```bash
   docker-compose up --build
   ```

3. Acesse a API em: [http://localhost:8080](http://localhost:8080)

4. Documentação Swagger: [http://localhost:8080/swagger](http://localhost:8080/swagger)

---

### **2. Configuração Manual (Sem Docker)**

Caso prefira executar o projeto sem Docker, siga os passos abaixo:

1. Clone este repositório:
   ```bash
   git clone https://github.com/eduardoRduraes/desafio_wallet_api.git
   cd desafio_wallet_api
   ```

2. Configure o banco de dados PostgreSQL:
   - Crie um banco chamado `wallet_db`.
   - Configure as credenciais:
     - **Usuário**: `root`
     - **Senha**: `root`

3. Atualize a string de conexão no arquivo `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Database=wallet_db;Username=root;Password=root"
   }
   ```

4. Restaure as dependências:
   ```bash
   dotnet restore
   ```

5. Aplique as migrations:
   ```bash
   dotnet ef database update
   ```

6. Execute o projeto:
   ```bash
   dotnet run
   ```

7. Acesse a API em: [http://localhost:5189](http://localhost:5189)

8. Documentação Swagger: [http://localhost:5189/swagger](http://localhost:5189/swagger)

---

## 🧪 Testando a API

1. Utilize a interface do Swagger para explorar os endpoints.
2. Ferramentas como [Postman](https://www.postman.com/) ou `curl` também podem ser usadas para realizar testes manuais.

---

## ✨ Scripts de Demonstração

Para popular o banco de dados com dados fictícios, utilize o script incluído no projeto. Ele cria usuários, carteiras e transações para demonstração.

```bash
dotnet run seed
```

---

## 🏗 Estrutura do Projeto

- **Controllers**: Contêm a lógica de roteamento da API.
- **Services**: Implementam a lógica de negócios.
- **Data**: Configuração do banco de dados e migrations.
- **Models**: Definições das entidades `User`, `Wallet` e `Transaction`.
- **Migrations**: Scripts para criação e atualização do banco de dados.

---

## 🎁 Funcionalidades Bônus

Além dos requisitos básicos do desafio, este projeto inclui:

- **Docker**: Para fácil configuração e execução.
- **Testes Unitários**: Feitos com `xUnit` e `Moq`.
- **Linter**: Garantia de código limpo e organizado.

---

## 📝 Licença

Este projeto está sob a licença MIT.
