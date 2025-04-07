import { useEffect, useState } from "react";
import axios from "axios";
import { FaTrash, FaFileExcel } from "react-icons/fa";
import * as XLSX from "xlsx";
import { useNavigate } from "react-router-dom";
import PageLayout from "../components/PageLayout";
import "../styles/ProductList.css";
import ConfirmModal from "../components/ConfirmModal";
import EditModal from "../components/EditModal";

export default function ProductList() {
  const [products, setProducts] = useState([]);
  const [sortAsc, setSortAsc] = useState(true);
  const [selectedProduct, setSelectedProduct] = useState(null);
  const [confirmDeleteId, setConfirmDeleteId] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    fetchProducts();
  }, []);

  const fetchProducts = async () => {
    const res = await axios.get("https://localhost:7185/v1/products/");
    setProducts(res.data);
  };

  const handleSort = () => {
    const sorted = [...products].sort((a, b) =>
      sortAsc ? a.name.localeCompare(b.name) : b.name.localeCompare(a.name)
    );
    setProducts(sorted);
    setSortAsc(!sortAsc);
  };

  const handleExportExcel = () => {
    const worksheet = XLSX.utils.json_to_sheet(products);
    const workbook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(workbook, worksheet, "Produtos");
    XLSX.writeFile(workbook, "produtos.xlsx");
  };

  const handleDelete = async (id) => {
    await axios.delete(`https://localhost:7185/v1/products/${id}`);
    setConfirmDeleteId(null);
    fetchProducts();
  };

  return (
    <PageLayout>
      <h1 className="title">Lista de Produtos</h1>

      <div className="toolbar">
        <button onClick={handleSort}>
          Ordenar por Nome ({sortAsc ? "A-Z" : "Z-A"})
        </button>
        <button onClick={handleExportExcel}>
          <FaFileExcel /> Exportar Excel
        </button>
        <button onClick={() => navigate("/produtos/novo")}>
          Novo Produto
        </button>
      </div>

      <table className="product-table">
        <thead>
          <tr>
            <th>Nome do Produto</th>
            <th>Valor (R$)</th>
            <th className="center">Ações</th>
          </tr>
        </thead>
        <tbody>
          {products.map((prod) => (
            <tr
              key={prod.id}
              onClick={() => setSelectedProduct(prod)}
              className="product-row"
            >
              <td>{prod.name}</td>
              <td>R$ {prod.price.toFixed(2)}</td>
              <td className="center">
                <button
                  onClick={(e) => {
                    e.stopPropagation();
                    setConfirmDeleteId(prod.id);
                  }}
                  className="delete-button"
                >
                  <FaTrash />
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      {selectedProduct && (
        <EditModal
          product={selectedProduct}
          onClose={() => setSelectedProduct(null)}
          onRefresh={fetchProducts}
        />
      )}

      {confirmDeleteId && (
        <ConfirmModal
          onConfirm={() => handleDelete(confirmDeleteId)}
          onCancel={() => setConfirmDeleteId(null)}
        />
      )}
    </PageLayout>
  );
}
