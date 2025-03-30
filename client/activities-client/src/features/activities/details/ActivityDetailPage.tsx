import { Grid2, Typography } from "@mui/material";
import { useActivities } from "../../../lib/hooks/useActivities";
import { ActivityDetailsChat } from "./ActivityDetailsChat";
import { ActivityDetailsInfo } from "./ActivityDetailsInfo";
import { useParams } from "react-router";
import { ActivityDetailsHeader } from "./ActivityDetailsHeader";
import { ActivityDetailsSidebar } from "./ActivityDetailsSidebar";

export const ActivityDetailPage = () => {
  const { id } = useParams();
  const { activity, isLoadingActivity } = useActivities(id);
  if (isLoadingActivity) return <Typography>Loading...</Typography>;
  if (!activity) return <Typography>Activity not found.</Typography>;
  return (
    <Grid2 container spacing={3}>
      <Grid2 size={8}>
        <ActivityDetailsHeader />
        <ActivityDetailsInfo activity={activity} />
        <ActivityDetailsChat />
      </Grid2>
      <Grid2 size={4}>
        <ActivityDetailsSidebar />
      </Grid2>
    </Grid2>
  );
};
