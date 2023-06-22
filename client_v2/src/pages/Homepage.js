import React from 'react';
import './Styles/homepage.css';
import { Link } from 'react-router-dom';

const Homepage = () => {

    const title = 'QuickGrade'
    return (
        <div className="home-page">
            <header className="header">
                <div className="logo-container">
                    <div className='logo'>
                        {title}
                    </div>
                </div>
                <nav className="navbar">
                    <ul className="nav-list">
                        <li className="nav-item"><a href="#">Home</a></li>
                        <li className="nav-item"><a href="#">Login</a></li>
                        <li className="nav-item"><a href="#">Register</a></li>
                    </ul>
                </nav>
            </header>

            <main className="main">
                <section className="hero-section">
                    <h1 className="hero-title">Welcome to {title}</h1>
                    <p className="hero-subtitle">A simple and intuitive platform for managing grades and assignments.</p>
                    <div className="call-to-action">
                        <Link to="register" className="cta-btn cta-btn-primary">Request Access</Link>
                        <Link to="app/login" className="cta-btn cta-btn-secondary">Login</Link>
                    </div>
                </section>

                <section className="testimonials-section">
                    <h2 className="testimonials-title">What our users are saying</h2>
                    <div className="testimonials-container">
                        <div className="testimonial">
                            <p className="testimonial-text">"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sit amet leo vitae nulla iaculis sodales. Aliquam erat volutpat."</p>
                            <p className="testimonial-author">- John Doe</p>
                        </div>
                        <div className="testimonial">
                            <p className="testimonial-text">"Praesent vestibulum dignissim urna, ac dapibus leo interdum a. Sed nec justo enim. Curabitur egestas mi sit amet libero pharetra vel pretium urna feugiat."</p>
                            <p className="testimonial-author">- Jane Doe</p>
                        </div>
                        <div className="testimonial">
                            <p className="testimonial-text">"Integer ac aliquam dolor. Ut nec elit vitae elit posuere dignissim. Nunc dictum id nulla quis rhoncus. Praesent non ligula vitae erat gravida auctor vitae et urna."</p>
                            <p className="testimonial-author">- Bob Smith</p>
                        </div>
                        <div className="testimonial">
                            <p className="testimonial-text">"Donec in tellus vitae nunc interdum iaculis eget id justo. Praesent tempor sem in nulla mollis hendrerit. Sed sagittis nisl vel libero facilisis interdum."</p>
                            <p className="testimonial-author">- Sarah Johnson</p>
                        </div>
                    </div>
                </section>


                <section className="about-section">
                    <h2 className="about-title">About {title}</h2>
                    <p className="about-description">{title} is a platform designed to make managing grades and assignments simple and intuitive. Our system is used by students, teachers, parents, and administrators across the country.</p>
                    <a href="#" className="cta-btn cta-btn-primary">Learn More</a>
                </section>
            </main>

            <footer className="footer">
                <p className="footer-text">&copy; 2023 {title}. All rights reserved.</p>
            </footer>
        </div>
    );
};

export default Homepage;
