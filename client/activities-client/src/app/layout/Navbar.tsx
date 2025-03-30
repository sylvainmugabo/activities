import { Group } from "@mui/icons-material";
import {
  AppBar,
  Box,
  Container,
  LinearProgress,
  MenuItem,
  Toolbar,
  Typography,
} from "@mui/material";
import { MenuItemLink } from "../shared/components/MenuItemLink";
import { useStore } from "../../lib/hooks/useStore";
import { Observer } from "mobx-react-lite";

export default function Navbar() {
  const { uiStore } = useStore();
  return (
    <>
      <Box sx={{ flexGrow: 1 }}>
        <AppBar
          position="static"
          sx={{
            backgroundImage:
              "linear-gradient(135deg, #182a73 0%, #218aae 69%, #20a7ac 89% )",
            position: "relative",
          }}
        >
          <Container maxWidth="xl">
            <Toolbar sx={{ display: "flex", justifyContent: "space-between" }}>
              <Box>
                <MenuItemLink to="/">
                  <Group fontSize="large" />
                  <Typography variant="h4" fontWeight="bold">
                    Reactivities
                  </Typography>
                </MenuItemLink>
              </Box>
              <Box sx={{ display: "flex" }}>
                <MenuItemLink to="/activities">Activities</MenuItemLink>
                <MenuItemLink to="/createActivity">
                  Create activity
                </MenuItemLink>
                <MenuItemLink to="/counter">Counter</MenuItemLink>
                <MenuItemLink to="/error">Error</MenuItemLink>
              </Box>

              <MenuItem>User Menu</MenuItem>
            </Toolbar>
          </Container>
          <Observer>
            {() =>
              uiStore.isLoading ? (
                <LinearProgress
                  color="secondary"
                  sx={{
                    position: "absolute",
                    bottom: 0,
                    left: 0,
                    right: 0,
                    height: 4,
                  }}
                />
              ) : null
            }
          </Observer>
        </AppBar>
      </Box>
    </>
  );
}
