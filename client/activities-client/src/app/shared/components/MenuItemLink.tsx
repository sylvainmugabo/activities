import { MenuItem } from "@mui/material";
import { yellow } from "@mui/material/colors";
import { ReactNode } from "react";
import { NavLink } from "react-router";

export const MenuItemLink = ({
  children,
  to,
}: {
  children: ReactNode;
  to: string;
}) => {
  return (
    <MenuItem
      component={NavLink}
      to={to}
      sx={{
        fontSize: "1.2rem",
        textTransform: "uppercase",
        fontWeight: "bold",
        color: "inherit",
        "&.active": {
          color: "yellow",
        },
      }}
    >
      {children}
    </MenuItem>
  );
};
