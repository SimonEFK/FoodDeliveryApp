import './RestaurantCard.css'
const RestaurantCard = ({ restaurant }) => {
    return (
        <>
            <div className="overflow-hidden rounded position-relative" style={
                {
                    height: "250px"

                }}>
                <img src={restaurant.imageUrl} alt={restaurant.name} style={{
                    width: "100%",
                    height: "100%",
                    objectPosition: "center center",
                    objectFit: "cover"
                }} />
                <div className="sideBanner">
                    <p className="m-0 text-start">{restaurant.name}</p>
                </div>
            </div>
        </>
    );
};

export default RestaurantCard;
