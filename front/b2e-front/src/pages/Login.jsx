import { useState } from "react";
import axios from "axios";
import PageLayout from "../components/PageLayout";
import "../styles/Login.css";

export default function Login() {
  const [login, setLogin] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");

  const handleLogin = async () => {
    try {
      const response = await axios.post("https://localhost:7185/v1/users", {
        login,
        password,
      });
      if (response.data.success) {
        localStorage.setItem("token", "mock-token");
        window.location.href = "/produtos";
      }
    } catch (err) {
      setError("Usuário ou senha inválidos");
    }
  };

  return (
    <PageLayout>
      <div className="login-container">
        <div className="login-box">
          <h2 className="login-title">Login</h2>

          {error && <p className="login-error">{error}</p>}

          <form
            className="login-form"
            onSubmit={(e) => {
              e.preventDefault();
              handleLogin();
            }}
          >
            <input
              type="text"
              placeholder="Usuário"
              value={login}
              onChange={(e) => setLogin(e.target.value)}
              className="login-input"
            />
            <input
              type="password"
              placeholder="Senha"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              className="login-input"
            />
            <button type="submit" className="login-button">
              Entrar
            </button>
          </form>
        </div>
      </div>
    </PageLayout>
  );
}
