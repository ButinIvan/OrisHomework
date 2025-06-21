import React, { useState, useEffect } from 'react';
import { useParams, Link } from 'react-router-dom';

const CarDetailPage = () => {
    const { id } = useParams();
    const [car, setCar] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        fetch(`/api/cars/${id}`)
            .then(res => {
                if (!res.ok) throw new Error('Car not found');
                return res.json();
            })
            .then(data => {
                setCar(data);
                setLoading(false);
            })
            .catch(err => {
                setError(err.message);
                setLoading(false);
            });
    }, [id]);

    if (loading) return <p>Loading...</p>;
    if (error) return <p>Error: {error}</p>;
    if (!car) return <p>Car not found</p>;

    return (
        <div className="container">
            <aside className="sidebar">
                <h1 className="logo">caradver</h1>
                <nav>
                    <ul>
                        <li><Link to="/">Dashboard</Link></li>
                        <li><Link to="/cars">Assets</Link></li>
                        <li><a href="#">Booking</a></li>
                        <li><a href="#">Sell Cars</a></li>
                        <li><a href="#">Services</a></li>
                    </ul>
                </nav>
                <div className="bottom-links">
                    <a href="#">Settings</a>
                    <a href="#" className="logout">Log out</a>
                </div>
            </aside>
            <main className="content">
                <div className="car-detail">
                    <div className="car-detail-image">
                        <img src={car.img} alt={car.name} />
                    </div>
                    <div className="car-detail-info">
                        <h1>{car.name}</h1>
                        <p className="price">{car.price}$</p>
                        <p className="description">{car.description}</p>
                        <div className="meta-info">
                            <p>Hourly rate: {car.rate}</p>
                            <p>Recommendation: {car.recommend}</p>
                            <p>Owner: {car.owner}</p>
                            <p>Contact: {car.contact}</p>
                        </div>
                    </div>
                </div>
            </main>
        </div>
    );
};

export default CarDetailPage;
