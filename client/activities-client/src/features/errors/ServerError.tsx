import { Divider, Paper, Typography } from "@mui/material";
import { useLocation } from "react-router";

export const ServerError = () => {
  const { state } = useLocation();
  return (
    <Paper sx={{}}>
      {state.error ? (
        <>
          <Typography
            gutterBottom
            variant="h3"
            sx={{ px: 4, pt: 2 }}
            color="secondary"
          >
            {state.error.message || "There has been an error"}
          </Typography>
          <Divider />
          <Typography gutterBottom variant="body1" sx={{ px: 4 }}>
            {state.error.details || "Internal server error"}
          </Typography>
        </>
      ) : (
        <Typography variant="h5">Server error</Typography>
      )}
    </Paper>
  );
};
