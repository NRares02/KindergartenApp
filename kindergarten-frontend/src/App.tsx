import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Navbar from "./components/Navbar";
import Dashboard from "./pages/Dashboard";
import Users from "./pages/Users";
import Login from "./pages/Login";
import Logout from "./pages/Logout";

function App() {
  return (
    <Router>
      <Navbar />
      {/* Remove p-4 and add pt-20 for navbar offset */}
      <div className="pt-20 min-h-screen bg-gradient-to-br from-blue-50 to-white">
        <Routes>
          <Route path="/" element={<Dashboard />} />
          <Route path="/dashboard" element={<Dashboard />} />
          <Route path="/users" element={<Users />} />
          <Route path="/login" element={<Login />} />
          <Route path="/logout" element={<Logout />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
