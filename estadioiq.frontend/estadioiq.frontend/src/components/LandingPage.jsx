import React from "react";
import { Link } from "react-router-dom";

const LandingPage = () => {
    return (
        <div className="min-h-screen bg-base-100 text-base-content">
            {/* Hero Section */}
            <section className="bg-pink-500 text-primary-content py-32">
                <div className="container mx-auto text-center px-4">
                    <h1 className="text-5xl font-bold mb-4">Welcome to EstadioIQ</h1>
                    <p className="text-xl mb-8">
                        Explore football clubs, players, and stats like never before.
                    </p>
                    <div className="flex justify-center gap-4">
                        <Link to="/signup" className="btn btn-primary px-6 py-3 text-lg">
                            Get Started
                        </Link>
                    </div>
                </div>
            </section>

            {/* Features Section */}
            <section className="py-20 bg-base-200 text-base-content">
                <div className="container mx-auto px-4">
                    <h2 className="text-4xl font-bold text-center mb-12">Features</h2>
                    <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
                        <div className="bg-blue-400 text-secondary-content rounded-2xl shadow-lg p-8 text-center hover:shadow-2xl transition">
                            <h3 className="text-2xl font-semibold mb-4">Player Stats</h3>
                            <p>
                                Get detailed player statistics including goals, assists,
                                appearances, and more.
                            </p>
                        </div>
                        <div className="bg-blue-400 text-secondary-content rounded-2xl shadow-lg p-8 text-center hover:shadow-2xl transition">
                            <h3 className="text-2xl font-semibold mb-4">Club Analysis</h3>
                            <p>
                                Explore clubs’ performance, win/loss ratios, formations, and
                                tactical stats.
                            </p>
                        </div>
                        <div className="bg-blue-400 text-secondary-content rounded-2xl shadow-lg p-8 text-center hover:shadow-2xl transition">
                            <h3 className="text-2xl font-semibold mb-4">Live Updates</h3>
                            <p>
                                Follow live scores, match events, and player performances in
                                real-time.
                            </p>
                        </div>
                    </div>
                </div>
            </section>

            {/* Call to Action */}
            <section className="bg-accent text-accent-content py-20">
                <div className="container mx-auto text-center px-4">
                    <h2 className="text-3xl md:text-4xl font-bold mb-6">
                        Ready to Explore Football Data?
                    </h2>
                    <p className="mb-8">
                        Join EstadioIQ today and get insights into your favorite clubs and
                        players.
                    </p>
                    <Link to="/signup" className="btn btn-secondary px-6 py-3 text-lg">
                        Sign Up Now
                    </Link>
                </div>
            </section>

            {/* Footer */}
            <footer className="bg-base-300 text-base-content py-6 mt-12">
                <div className="container mx-auto text-center">
                    <p>© 2025 EstadioIQ. All rights reserved.</p>
                </div>
            </footer>
        </div>
    );
};

export default LandingPage;
