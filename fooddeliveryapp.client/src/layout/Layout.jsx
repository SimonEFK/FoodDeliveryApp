import Footer from "./Footer";
import Header from "./Header";
import { Outlet } from "react-router-dom";
const Layout = () => {
  return (
    <>
      <Header></Header>
      <main>
        <div className="container">
          <Outlet></Outlet>
        </div>
      </main>
      <Footer></Footer>
    </>
  );
};
export default Layout;
