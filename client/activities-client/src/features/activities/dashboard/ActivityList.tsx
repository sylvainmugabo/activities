import { Box, Typography } from "@mui/material";
import { ActivityCard } from "./ActivityCard";
import { useActivities } from "../../../lib/hooks/useActivities";

export const ActivityList = () => {
  const { activities, isPending } = useActivities();
  if (!activities || isPending) return <Typography>Loading...</Typography>;
  const displayActivityList = activities.map((activity) => {
    return <ActivityCard activity={activity} key={activity.id} />;
  });
  return (
    <Box sx={{ display: "flex", flexDirection: "column", gap: 3 }}>
      {displayActivityList}
    </Box>
  );
};
