import React, { useEffect, useState } from "react";
import Navbar from "./navbar/Navbar";
import Topbar from "./topbar/Topbar";
import { Outlet, useNavigate } from "react-router-dom";
import { useStateContext } from "../contexts/UserContext";
import { validateToken } from "../api/Auth";

const Wrapper = () => {
  const navigate = useNavigate();
  const {
    currentUser,
    sideMenuOpened,
    theme,
    setCurrentUser,
    setSideMenuOpened,
    setTheme,
  } = useStateContext();
  useEffect(() => {
    const checkTokenValidity = async () => {
      try {
        const res = await validateToken();
        if (!res.success) {
          setCurrentUser(null);
          navigate("/app/login");
        } else {
          setCurrentUser(res.data);
        }
      } catch (error) {
        setCurrentUser(null);
        navigate("/app/login");
      }
    };
    checkTokenValidity();
  }, []);

  return (
    <div className="App" data-theme={theme}>
      {currentUser !== null ? (
        <React.Fragment>
          <Navbar
            sideMenuState={sideMenuOpened}
            changeTheme={() => setTheme(theme === "light" ? "dark" : "light")}
            actualTheme={theme}
          />
          <Topbar
            sideMenuState={sideMenuOpened}
            setSideMenuState={setSideMenuOpened}
          />
          <div
            className={sideMenuOpened ? "AppContainer" : "AppContainer full"}
          >
            <Outlet />
          </div>
        </React.Fragment>
      ) : (
        <Outlet />
      )}
    </div>
  );
};

export default Wrapper;
