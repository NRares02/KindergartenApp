import { Link } from "react-router-dom";

const Dashboard = () => {
  const cards = [
    { title: "Utilizatori", path: "/users" },
    { title: "Clase", path: "/classes" },
    { title: "Grupe", path: "/groups" },
    { title: "Rapoarte", path: "/daily-reports" },
    { title: "Galerie", path: "/media" },
    { title: "Chat", path: "/chat" },
    { title: "Chestionare", path: "/surveys" },
  ];

  return (
    <div className="p-6">
      <h2 className="text-2xl font-bold mb-6 text-center text-blue-600">Dashboard</h2>
      <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-6">
        {cards.map((card) => (
          <Link
            key={card.title}
            to={card.path}
            className="bg-white shadow-md rounded-lg p-6 text-center hover:bg-blue-100 transition"
          >
            <span className="text-lg font-semibold text-blue-700">{card.title}</span>
          </Link>
        ))}
      </div>
    </div>
  );
};

export default Dashboard;
