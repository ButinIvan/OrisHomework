import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import CarList from "../components/CarList";

const HomePage = () => {
    const [searchTerm, setSearchTerm] = useState("");
    const navigate = useNavigate(); 

    return (
        <div className="container">
            <aside className="sidebar">
                <h1 className="logo">caradver</h1>
                <nav>
                    <ul>
                        <li className="mainPage"><a href="/">Dashboard</a></li>
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
                        <a href="#"><img src="signs/message.png" alt="Notifications" className="icon" /></a>
                        <a href="#"><img src="signs/user.jpg" alt="User" className="user-photo" /></a>
                    </div>
                </header>
                
                <section className="brands">
                    <div className="brand" onClick={() => navigate("/brand/Lamborghini")}>
                        <img src="brands/lambo.png" alt="Lamborghini"/>
                        <p>Lamborghini</p>
                    </div>
                    <div className="brand" onClick={() => navigate("/brand/Rolls-Royce")}>
                        <img src="brands/rr.png" alt="Rolls-Royce"/>
                        <p>Rolls-Royce</p>
                    </div>
                    <div className="brand"><img src="brands/bmw.png" alt="BMW"/><p>BMW</p></div>
                    <div className="brand"><img src="brands/mers.png" alt="Mercedes"/><p>Mercedes-Benz</p></div>
                </section>

                <CarList searchTerm={searchTerm}/>
            </main>
        </div>
    );
};

export default HomePage;


