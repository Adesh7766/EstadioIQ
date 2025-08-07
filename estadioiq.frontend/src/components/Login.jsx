import React, {useState} from "react";
import axios from "axios";
import { useNavigate } from "reac-router-dom";

const Login = () => {
    const [email1, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');
    const navigate = useNavigate('');

    const handleSubmit = async (e) => {
        e.preventDefaults();
        try{
            const response = await axios.post("endpoint", {
                email, password}
            );

            localStorage.setItem('token', response.data.token)

            navigate("/dashboard");
        }
        catch(error){
            setError(error.response?.data?.message || "Login failed");
        }
    } 

    return (
        <div className="login-container">
            <h2>Login</h2>
            {error && <div className="error">{error}</div>}
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Email:</label>
                    <input type="email" value={password} onChange={(e) => setPassword(e.target.value)}  required/>
                </div>
                <button type="submit">Login</button>
            </form>
        </div>
    );
} ;

export default Login