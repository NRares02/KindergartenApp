import { Link } from "react-router-dom";
import { FaUsers, FaChalkboardTeacher, FaLayerGroup, FaFileAlt, FaImages, FaComments, FaPoll } from "react-icons/fa";

const cards = [
  { title: "Utilizatori", path: "/users", icon: <FaUsers size={32} className="mx-auto mb-2 text-blue-500" /> },
  { title: "Clase", path: "/classes", icon: <FaChalkboardTeacher size={32} className="mx-auto mb-2 text-green-500" /> },
  { title: "Grupe", path: "/groups", icon: <FaLayerGroup size={32} className="mx-auto mb-2 text-purple-500" /> },
  { title: "Rapoarte", path: "/daily-reports", icon: <FaFileAlt size={32} className="mx-auto mb-2 text-yellow-500" /> },
  { title: "Galerie", path: "/media", icon: <FaImages size={32} className="mx-auto mb-2 text-pink-500" /> },
  { title: "Chat", path: "/chat", icon: <FaComments size={32} className="mx-auto mb-2 text-indigo-500" /> },
  { title: "Chestionare", path: "/surveys", icon: <FaPoll size={32} className="mx-auto mb-2 text-red-500" /> },
];

const Dashboard = () => (
  <div className="w-full min-h-screen pt-8 bg-gradient-to-br from-blue-50 to-white">
    <div className="mb-8 text-center">
      <h2 className="text-3xl font-bold text-blue-600 mb-2 drop-shadow">Bine ai venit la Dashboard!</h2>
      <p className="text-gray-600">Alege o secțiune pentru a începe.</p>
    </div>
    <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-8 w-full px-8">
      {cards.map((card) => (
        <Link
          key={card.title}
          to={card.path}
          className="bg-white shadow-xl rounded-2xl p-8 flex flex-col items-center hover:scale-105 hover:shadow-2xl transition-all duration-200 border border-blue-100 hover:border-blue-300"
        >
          {card.icon}
          <span className="text-lg font-semibold text-gray-800 mt-2">{card.title}</span>
        </Link>
      ))}
    </div>
  </div>
);

export default Dashboard;
