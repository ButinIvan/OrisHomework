import React, { useState } from "react";
import CarList from "../components/CarList";

const CarsPage = () => {
    const [searchTerm, setSearchTerm] = useState("");

    return (
        <div className="container">
            <aside className="sidebar">
                <h1 className="logo">caradver</h1>
                <nav>
                    <ul>
                        <li className="active"><a href="/">Dashboard</a></li>
                        <li><a href="/cars">Assets</a></li>
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
                <header className="top-bar">
                    <input
                        type="text"
                        placeholder="Search or type"
                        className="search"
                        value={searchTerm}
                        onChange={(e) => setSearchTerm(e.target.value)}
                    />
                    <div className="user-info">
                        <a href=""><img src="signs/message.png" alt="Notifications" className="icon" /> </a>
                        <a href=""><img src="signs/user.jpg" alt="User" className="user-photo" /></a>
                    </div>
                </header>
                <CarList searchTerm={searchTerm} />
            </main>
        </div>
    );
};

export default CarsPage;