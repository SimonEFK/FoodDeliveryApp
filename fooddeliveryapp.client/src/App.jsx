import { useEffect, useState } from "react";
import Register from "./components/Register";
import Header from "./components/Header";

function App() {
  return (
    <>
      <Header></Header>
      <div className="container">
        <Register></Register>
      </div>
    </>
  );
}

export default App;
