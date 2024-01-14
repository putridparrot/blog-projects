import { Card, CardContent, Typography } from "@mui/material";
import React from "react";

const drawerWidth = 240;

export const About = () => (
  <Card sx={{ minWidth: 275, boxShadow: 3 }} variant="elevation">
  <CardContent>
    <Typography variant="h5" component="div">
      Micro frontend app using React
    </Typography>
    <Typography sx={{ fontSize: 14, mb: 1.5 }} color="text.secondary" variant="body2">
      <p>
      This uses npx create-mf-app to generate module federation components
      </p>
    </Typography>    
</CardContent>
</Card>
);
