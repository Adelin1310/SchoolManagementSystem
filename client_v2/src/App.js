import './App.css'
import Wrapper from "./components/wrapper";
import { StateContextProvider } from "./contexts/UserContext";

function App() {
  return (
    <StateContextProvider>
      <Wrapper/>
    </StateContextProvider>
  );
}

export default App;
