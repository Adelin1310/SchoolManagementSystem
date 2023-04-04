import { Outlet } from "react-router-dom";
import Navbar from "./components/navbar/Navbar";
import Topbar from "./components/topbar/Topbar";
import './App.css'
import { useState } from "react";
import useLocalStorage from 'use-local-storage'

function App() {
  const [sideMenuOpened, setSideMenuOpened] = useState(true)
  const defaultDark = window.matchMedia('(prefers-color-scheme: dark)').matches;
  const [theme, setTheme] = useLocalStorage('theme', defaultDark ? 'dark' : 'light');

  const switchTheme = () =>{
    const newTheme = theme === 'light' ? 'dark' : 'light';
    setTheme(newTheme)
  }

  return (
    <div className="App" data-theme={theme}>
      <Navbar sideMenuState={sideMenuOpened} changeTheme={switchTheme} />
      <Topbar sideMenuState={sideMenuOpened} setSideMenuState={setSideMenuOpened} />
      <div className={sideMenuOpened ? "AppContainer" : "AppContainer full"}>
        <Outlet />
      </div>
    </div>
  );
}

export default App;
