import React, { createContext, useContext, useState } from 'react';
import useLocalStorage from 'use-local-storage';

// Create the state context
const StateContext = createContext();

// Define the custom hook to access the state context values
const useStateContext = () => {
    const context = useContext(StateContext);
    if (!context) {
        throw new Error('useStateContext must be used within a StateContextProvider');
    }
    return context;
};

// Create the state provider component
const StateContextProvider = ({ children }) => {
    const [currentUser, setCurrentUser] = useState(null);
    const [sideMenuOpened, setSideMenuOpened] = useState(true)
    const defaultDark = window.matchMedia('(prefers-color-scheme: dark)').matches;
    const [theme, setTheme] = useLocalStorage('theme', defaultDark ? 'dark' : 'light');
    return (
        <StateContext.Provider value={{ currentUser, sideMenuOpened, theme, setCurrentUser, setSideMenuOpened, setTheme }}>
            {children}
        </StateContext.Provider>
    );
};

export { StateContext, StateContextProvider, useStateContext }; // export the context and custom hook
