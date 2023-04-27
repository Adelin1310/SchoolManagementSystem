import React, { useEffect, useState } from "react";
import Navbar from "./navbar/Navbar";
import Topbar from "./topbar/Topbar";
import { Outlet } from "react-router-dom";
import { useStateContext } from "../contexts/UserContext";
import Login from "./pages/login/Login";
import { validateToken } from "../api/Auth";
import Modal from "./modal/Modal";
import SessionExpiredModal from "./modal/SessionExpiredModal/SessionExpiredModal";

const Wrapper = () => {
  const {
    currentUser,
    sideMenuOpened,
    theme,
    setCurrentUser,
    setSideMenuOpened,
    setTheme,
  } = useStateContext();
  const [isSessionValid, setIsSessionValid] = useState(currentUser !== null);
  setInterval(() => {
    const checkTokenValidity = async () => {
      try {
        const res = await validateToken();
        if (!res.success) {
          setCurrentUser(null);
        } else {
          setCurrentUser(res.data);
        }
      } catch (error) {
        setCurrentUser(null);
      }
    };
    checkTokenValidity();
    setIsSessionValid(currentUser !== null);
  }, 600000);

  return (
    <div className="App" data-theme={theme}>
      {currentUser !== null ? (
        <React.Fragment>
          <Modal
            initial={isSessionValid}
            isCloseable={false}
            component={<SessionExpiredModal />}
          />
          <Navbar
            sideMenuState={sideMenuOpened}
            changeTheme={() => setTheme(theme === "light" ? "dark" : "light")}
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
        <Login />
      )}
    </div>
  );
};

export default Wrapper;
