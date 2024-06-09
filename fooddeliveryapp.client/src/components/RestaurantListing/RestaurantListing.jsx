import { useState, useEffect } from "react";
import "./RestaurantListing.css"



const RestaurantListing = () => {

  const [restaurants, setRestaurants] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState();
  useEffect(() => {
    async function fetchRestaurants() {
      setLoading(true);
      try {
        const response = await fetch("https://localhost:44341/api/restaurants");
        const restaurantsJson = await response.json();
        setRestaurants(restaurantsJson);
      } catch (error) {
        setError(error);
      }

      setLoading(false);
    };
    fetchRestaurants();
  }, []);


  if (loading) {
    return <span>Loading...</span>
  }
  if (error) {
    return <span className="text-danger">Unexpected server error please try again.</span>
  }

  return (
    <>
      <div className="row">
        {restaurants.map((x) => (
          <div className="col-12 col-lg-6 col-xl-8 mb-3" key={x.id}>
            <div className="overflow-hidden rounded position-relative" style={
              {
                height: "250px"

              }}>
              <img src={x.imageUrl} alt={x.name} style={{
                width: "100%",
                height: "100%",
                objectPosition: "center center",
                objectFit: "cover"
              }} />
              <div className="test">
                <p className="m-0 text-start">{x.name}</p>
              </div>
            </div>
          </div>
        ))}

      </div>
    </>
  );
};

export default RestaurantListing;
