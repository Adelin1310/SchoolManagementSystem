import { Outlet } from "react-router-dom";
import Navbar from "./components/navbar/Navbar";
import Topbar from "./components/topbar/Topbar";
import './App.css'

function App() {
  return (
    <div className="App">
      <Navbar />
      <Topbar />
      <div className="AppContainer">
        <Outlet />
      </div>
    </div>
  );
}

export default App;
