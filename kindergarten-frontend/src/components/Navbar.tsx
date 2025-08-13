import { useState } from "react";
import { Link, useLocation } from "react-router-dom";

const Navbar = () => {
  const [isOpen, setIsOpen] = useState(false);
  const location = useLocation();

  const navItems = [
    { label: "Dashboard", path: "/" },
    { label: "Users", path: "/users" },
    { label: "Login", path: "/login" },
    { label: "Logout", path: "/logout" },
  ];

  return (
    <nav className="w-full bg-gradient-to-r from-red-600 to-red-400 text-white px-4 py-3 shadow-lg fixed top-0 left-0 z-50">
      <div className="flex justify-between items-center max-w-7xl mx-auto">
        <div className="text-2xl font-extrabold tracking-wide drop-shadow-lg font-sans">
          <Link to="/" className="hover:text-yellow-200 transition-colors duration-200">
            Kindergarten <span className="text-yellow-200">App</span>
          </Link>
        </div>

        <button
          className="md:hidden"
          onClick={() => setIsOpen(!isOpen)}
          aria-label="Toggle navigation"
        >
          ☰
        </button>

        <ul className={`md:flex gap-6 ${isOpen ? "block mt-4" : "hidden md:flex md:mt-0"}`}>
          {navItems.map(({ label, path }) => (
            <li key={path}>
              <Link
                to={path}
                className={`hover:text-yellow-200 transition-colors duration-200 ${
                  location.pathname === path ? "underline text-yellow-200 font-bold" : ""
                }`}
              >
                {label}
              </Link>
            </li>
          ))}
        </ul>
      </div>
    </nav>
  );
};

export default Navbar;
