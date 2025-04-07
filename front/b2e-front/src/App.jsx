import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Login from "./pages/Login";
import ProductList from "./pages/ProductList";
import ProductCreate from "./pages/ProductCreate";

export default function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/produtos" element={<ProductList />} />
        <Route path="/produtos/novo" element={<ProductCreate />} />
      </Routes>
    </Router>
  );
}
