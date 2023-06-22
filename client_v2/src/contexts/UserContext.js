import React, { createContext, useContext, useState } from 'react';
import useLocalStorage from 'use-local-storage';


const StateContext = createContext();


const useStateContext = () => {
    const context = useContext(StateContext);
    if (!context) {
        throw new Error('useStateContext must be used within a StateContextProvider');
    }
    return context;
};

const StateContextProvider = ({ children }) => {
    const [module, setModule] = useState(null);
    const [activeTab, setActiveTab] = useState(null);
    const [currentUser, setCurrentUser] = useState(null);
    const [sideMenuOpened, setSideMenuOpened] = useState(true)
    const defaultDark = window.matchMedia('(prefers-color-scheme: dark)').matches;
    const [theme, setTheme] = useLocalStorage('theme', defaultDark ? 'dark' : 'light');
    return (
        <StateContext.Provider value={{ module, currentUser, sideMenuOpened, theme, activeTab, setActiveTab, setModule, setCurrentUser, setSideMenuOpened, setTheme }}>
            {children}
        </StateContext.Provider>
    );
};

export { StateContext, StateContextProvider, useStateContext };
