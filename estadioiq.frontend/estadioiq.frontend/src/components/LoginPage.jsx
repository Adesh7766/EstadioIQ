import { Link } from "react-router-dom";

const LoginPage = () => {
    const navigate = useNavigate();
    const [formData, setFormData] = useState({ email: "", password: "" });
    const [error, setError] = useState("");

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setError("");

        try {
            const response = await fetch("https://your-api-url.com/login", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(formData),
            });

            if (!response.ok) {
                const data = await response.json();
                throw new Error(data.message || "Login failed");
            }

            const data = await response.json();
            console.log("Login success:", data);

            // Redirect user somewhere after login
            navigate("/dashboard"); // or landing page
        } catch (err) {
            setError(err.message);
        }
    };

    return (
        <div className="min-h-screen flex items-center justify-center bg-green-50">
            <div className="bg-white p-12 rounded-2xl shadow-lg w-full max-w-md">
                <h2 className="text-3xl font-bold mb-8 text-center">Login</h2>
                {error && <p className="text-red-500 mb-4">{error}</p>}
                <form className="flex flex-col gap-4" onSubmit={handleSubmit}>
                    <input
                        type="email"
                        name="email"
                        placeholder="Email"
                        value={formData.email}
                        onChange={handleChange}
                        className="input input-bordered w-full"
                        required
                    />
                    <input
                        type="password"
                        name="password"
                        placeholder="Password"
                        value={formData.password}
                        onChange={handleChange}
                        className="input input-bordered w-full"
                        required
                    />
                    <button type="submit" className="btn btn-primary w-full">Sign In</button>
                </form>
                <p className="mt-6 text-center">
                    Don’t have an account?{" "}
                    <Link to="/signup" className="text-pink-500 font-bold">Get Started</Link>
                </p>
            </div>
        </div>
    );
};

export default LoginPage;
