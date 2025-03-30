import { Box, Container, CssBaseline } from "@mui/material";

import Navbar from "./Navbar";
import { Outlet, useLocation } from "react-router";
import { HomePage } from "../../features/activities/home/HomePage";

function App() {
  const location = useLocation();
  return (
    <Box sx={{ bgcolor: "#eeeeee", minHeight: "100vh" }}>
      <CssBaseline></CssBaseline>
      {location.pathname === "/" ? (
        <HomePage />
      ) : (
        <>
          <Navbar />
          <Container maxWidth="xl" sx={{ mt: 3 }}>
            <Outlet></Outlet>
          </Container>
        </>
      )}
    </Box>
  );
}

export default App;
