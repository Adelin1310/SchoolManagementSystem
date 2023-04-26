import './App.css'
import { StateContextProvider } from "./contexts/UserContext";
import Wrapper from './components/wrapper';

function App() {
  return (
    <StateContextProvider>
      <Wrapper/>
    </StateContextProvider>
  );
}

export default App;
