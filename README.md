# 📦 Produto API

Uma API REST simples para gerenciar produtos, feita com **ASP.NET Core (.NET 9)** usando **Minimal API**. Este projeto demonstra as operações básicas de CRUD: criar, listar, atualizar e deletar produtos.

---

## 🚀 Tecnologias usadas

- [.NET 9 (Preview)](https://dotnet.microsoft.com/en-us/)
- C# 12
- Minimal API
- Swagger (documentação automática)

---

## 📦 Funcionalidades

- ✅ Criar produto (`POST /api/produtos`)
- 📄 Listar todos os produtos (`GET /api/produtos`)
- 🔍 Buscar produto por ID (`GET /api/produtos/{id}`)
- ✏️ Atualizar produto (`PUT /api/produtos/{id}`)
- ❌ Remover produto (`DELETE /api/produtos/{id}`)

---

## 🔧 Como executar

1. **Clone o repositório:**

```bash
git clone https://github.com/seu-usuario/produto-api.git
cd produto-api
```

- Rode o projeto:

```bash
dotnet run
```

- Acesse o Swagger:

Abra no navegador:
https://localhost:xxxx/swagger
(Substitua xxxx pela porta exibida no terminal)

## 🧪 Exemplos de requisições
✅ Criar um produto (POST /api/produtos)
```json

{
  "nome": "Camiseta",
  "preco": 49.90
}
```

- 📄 Exemplo de resposta (GET /api/produtos)
```json

[
  {
    "id": 1,
    "nome": "Camiseta",
    "preco": 49.9
  }
]
```



##⚠️ Validações
- O nome do produto não pode ser vazio

- O preço deve ser maior que zero

## 📌 Observações
- Os dados são armazenados em memória, ou seja, ao reiniciar a API, os dados são perdidos.

- Para persistência, recomenda-se usar um banco de dados com Entity Framework Core.

