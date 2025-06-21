import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import HomePage from "./pages/HomePage";
import BrandCarsPage from "./pages/BrandCarsPage";
import CarsPage from "./pages/CarsPage";
import CarDetailPage from "./pages/CarDetailPage";

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<HomePage />} />
                <Route path="/cars" element={<CarsPage />} />
                <Route path="/brand/:brand" element={<BrandCarsPage />} />
                <Route path="/car/:id" element={<CarDetailPage />} />
            </Routes>
        </Router>
    );
}

export default App;
