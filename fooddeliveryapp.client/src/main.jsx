import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.jsx";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import Layout from "./layout/Layout.jsx";
import RestaurantListing from "./pages/restaurantListing/RestaurantListing.jsx";
import OwnerPanel from "./pages/ownerPanel/OwnerPanel.jsx";
import Register from "./pages/register/Register.jsx";
import Login from "./pages/login/Login.jsx";

const router = createBrowserRouter([
  {
    path: "/",
    element: <Layout></Layout>,
    children: [
      {
        path: "/Register",
        element: <Register></Register>,

      },
      {
        path: "/Login",
        element: <Login></Login>,
      },
      {
        path: "/Restaurants",
        element: <RestaurantListing></RestaurantListing>,
      },
      {
        path: "/OwnerPanel",
        element: <OwnerPanel></OwnerPanel>
      }
    ],
  },
]);

ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <RouterProvider router={router}></RouterProvider>
  </React.StrictMode>
);
