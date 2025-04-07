
# Configuração do Banco de Dados - SQL Server via Docker

Este projeto utiliza uma instância do **SQL Server** executando em **Docker** para desenvolvimento e testes locais.

---

## 🐳 Subindo o SQL Server com Docker

Execute o comando abaixo para iniciar o container do SQL Server:

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=!@12QWqw" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:latest
```

- **Usuário:** `sa`
- **Senha:** `!@12QWqw`
- **Porta exposta:** `1433`

---

## 🗄 Criação do Banco de Dados

Após o container estar rodando, conecte-se ao SQL Server utilizando alguma ferramenta como:

- [Azure Data Studio](https://learn.microsoft.com/pt-br/sql/azure-data-studio/)
- [Beekeeper Studio](https://www.beekeeperstudio.io/)
- [DBeaver](https://dbeaver.io/)
- Ou via linha de comando com `sqlcmd`

Em seguida, crie o banco de dados com o seguinte comando:

```sql
CREATE DATABASE b2eDb;
```

---

## 🔌 Connection String

```json
"ConnectionStrings": {
  "ConnectionDb": "Server=sqlserver,1433;Database=b2eDb;User Id=sa;Password=!@12QWqw;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
}
```

---

## 🧼 Parar e remover o container (opcional)

Para parar e remover o container quando não for mais necessário:

```bash
docker stop sqlserver
docker rm sqlserver
```

---

## ✅ Dicas

- Verifique se a porta 1433 não está sendo usada por outro serviço.
- Caso tenha erro de conexão com `sqlserver`, troque para `localhost` no campo `Host`.

---
