import { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { v4 as uuidv4 } from "uuid";
import PageLayout from "../components/PageLayout";
import "../styles/ProductCreate.css";

export default function ProductCreate() {
  const [name, setName] = useState("");
  const [price, setPrice] = useState("");
  const navigate = useNavigate();

  const handleSave = async () => {
    if (!name || !price) {
      alert("Preencha todos os campos.");
      return;
    }

    const newProductId = uuidv4();

    await axios.post(`https://localhost:7185/v1/products/${newProductId}`, {
      name,
      price: parseFloat(price),
    });

    navigate("/produtos");
  };

  return (
    <PageLayout>
      <div className="product-container">
        <div className="product-box">
          <h2 className="product-title">Novo Produto</h2>

          <div className="product-form">
            <input
              type="text"
              placeholder="Nome do produto"
              value={name}
              onChange={(e) => setName(e.target.value)}
              className="product-input"
            />
            <input
              type="number"
              placeholder="Valor"
              value={price}
              onChange={(e) => setPrice(e.target.value)}
              className="product-input"
            />
            <div className="product-buttons">
              <button onClick={() => navigate("/produtos")} className="btn cancel">
                Fechar
              </button>
              <button onClick={handleSave} className="btn save">
                Salvar
              </button>
            </div>
          </div>
        </div>
      </div>
    </PageLayout>
  );
}
