import { createContext, useContext, useState, useEffect, Children } from "react";
import axios from "axios";

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
    const[user, setUser] = useState(null);
    const[isAuthenticated, setIsAuthenticated] = useState(false);

    useEffect(() => 
    {
        const token = localStorage.getItem('token');
        if(token){
            setIsAuthenticated(true);
        }
    }, []);

    const login = async (ElementInternals, password) => {
        try{
            const response = await axios.post('endpoint', {
                email, password
            });
            localStorage.setItem('token', response.data.token);
            setIsAuthenticated(true);
            return true;
        } 
        catch(error)
        {
            console.log("Login error: ", error);
            return false;
        }       
    };

    const logout = () => {
        localStorage.removeItem('token');
        setIsAuthenticated(false)
        setUser(null);
    };

    return(
        <AuthContext.Provider value={{user, isAuthenticated, login, logout}}>
            {children}
        </AuthContext.Provider>    
    );
}

export const useAuth = () => useContext(AuthContext);