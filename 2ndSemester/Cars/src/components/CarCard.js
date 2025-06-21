import React from 'react';
import { Link } from 'react-router-dom';

const CarCard = ({ car }) => {
    return (
        <div className="car-card">
            <Link to={`/cars/${car.id}`} className="car-link">
                <img src={car.img} alt={car.name} className="car-image" />
                <div className="car-info">
                    <h3>{car.name}</h3>
                    <p className="price">{car.price}</p>
                    <div className="meta">
                        <span>{car.rate}</span>
                        <span className="recommend">{car.recommend}</span>
                    </div>
                </div>
            </Link>
        </div>
    );
};

export default CarCard;