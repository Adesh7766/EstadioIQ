import { useState } from "react";
import { Link } from "react-router-dom";

const Navbar = () => {
  const [isMenuOpen, setIsMenuOpen] = useState(false);

  return (
    <div className="navbar bg-base-100 shadow-md px-4">
      <div className="flex-1">
        <Link to="/" className="btn btn-ghost text-xl text-primary">
          EstadioIQ
        </Link>
      </div>
      <div className="flex-none">
        <ul className="menu menu-horizontal px-1">
          <li>
            <Link
              to="/login"
              className="btn btn-sm btn-outline btn-primary"
            >
              Sign in
            </Link>
          </li>
        </ul>
      </div>
    </div>
  );
};

export default Navbar;
