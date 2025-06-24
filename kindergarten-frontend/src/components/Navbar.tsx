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
    <nav className="bg-blue-600 text-white px-4 py-3 shadow-md">
      <div className="flex justify-between items-center max-w-7xl mx-auto">
        <div className="text-xl font-bold">
          <Link to="/">Kindergarten App</Link>
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
                className={`hover:text-yellow-300 ${
                  location.pathname === path ? "underline text-yellow-300" : ""
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
