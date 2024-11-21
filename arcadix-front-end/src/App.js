import logo from './logo.svg';
import './App.css';
import {BrowserRouter,Route,Routes} from "react-router-dom";
import Home from './Components/Home';

function App() {
  return (
    <div className='App'>
      <BrowserRouter>
      {/* <Navbar/> */}
      <Routes>
        <Route path="/" element = {<Home/>}></Route>
      </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
