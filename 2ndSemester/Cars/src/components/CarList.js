import React, { useEffect, useState } from 'react';

const CarList = ({ searchTerm }) => {
    const [cars, setCars] = useState([]);

    useEffect(() => {
        fetch('http://localhost:3000/api/cars') // проверь тут URL
            .then(res => res.json())
            .then(data => setCars(data))
            .catch(console.error);
    }, []);

    // фильтрация по searchTerm, если нужно
    const filteredCars = cars.filter(car => car.name.toLowerCase().includes(searchTerm.toLowerCase()));

    return (
        <div className="car-list">
            {filteredCars.map(car => (
                <div key={car.id}>{car.name}</div>
            ))}
        </div>
    );
};

export default CarList;
