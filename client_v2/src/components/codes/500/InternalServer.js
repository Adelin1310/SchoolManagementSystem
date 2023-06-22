import React from 'react'
import './InternalServer.css'
const InternalServer = () => {
    return (
        <div className="error-container">
            <h1 className="error-title">500 Internal Server Error</h1>
            <p className="error-message">Oops! Something went wrong.</p>
            <p className="error-description">We apologize for the inconvenience.</p>
            <button className="error-button" onClick={() => window.location.reload()}>
                Reload Page
            </button>
        </div>
    );
}

export default InternalServer