import { useState } from "react";
import axios from "axios";
import "../styles/EditModal.css";

export default function EditModal({ product, onClose, onRefresh }) {
  const [name, setName] = useState(product.name);
  const [price, setPrice] = useState(product.price);

  const handleSave = async () => {
    await axios.put(`https://localhost:7185/v1/products/${product.id}`, {
      name,
      price: parseFloat(price),
    });
    onClose();
    onRefresh();
  };

  return (
    <div className="modal-overlay">
      <div className="modal-container">
        <h2 className="modal-title">Editar Produto</h2>
        <input
          value={name}
          onChange={(e) => setName(e.target.value)}
          placeholder="Nome do produto"
          className="modal-input"
        />
        <input
          type="number"
          value={price}
          onChange={(e) => setPrice(e.target.value)}
          placeholder="Valor"
          className="modal-input"
        />
        <div className="modal-buttons">
          <button onClick={onClose} className="btn cancel-btn">
            Fechar
          </button>
          <button onClick={handleSave} className="btn save-btn">
            Salvar
          </button>
        </div>
      </div>
    </div>
  );
}
