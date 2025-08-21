import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { useState } from "react";

const SignupPage = () => {
    const navigate = useNavigate();
    const [formData, setFormData] = useState({ username: "", email: "", password: "", role: "" })
    const [error, setError] = useState("");

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setError("");
        try {
            const response = await fetch("https://localhost:7095/api/User/Register", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(formData),
            });

            if (!response.ok) {
                const data = await response.json();
                throw new Error(data.message || "Failed to create user");
            }

            // On success, redirect to login
            navigate("/login");
        } catch (err) {
            setError(err.message);
        }
    };


    return (
        <div className="min-h-screen flex items-center justify-center bg-green-50">
            <div className="bg-white p-12 rounded-2xl shadow-lg w-full max-w-md">
                <h2 className="text-3xl font-bold mb-8 text-center">Sign Up</h2>
                {error && <p className="text-red-500 mb-4">{error}</p>}
                <form className="flex flex-col gap-4" onSubmit={handleSubmit}>
                    <input
                        type="text"
                        name="name"
                        placeholder="Username"
                        value={formData.name}
                        onChange={handleChange}
                        className="input input-bordered w-full"
                        required
                    />
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
                    <button type="submit" className="btn btn-primary w-full">Sign Up</button>
                </form>
                <p className="mt-6 text-center">
                    Already have an account?{" "}
                    <Link to="/login" className="text-pink-500 font-bold">Login</Link>
                </p>
            </div>
        </div>
    );
};

export default SignupPage;
