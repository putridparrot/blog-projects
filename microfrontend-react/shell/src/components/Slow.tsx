import { Card, CardContent, Typography } from "@mui/material";
import React from "react";

const drawerWidth = 240;
let fullfilled = false;
let promise: Promise<void> | null = null;

const useTimeout = (ms: number) => {
  if (!fullfilled) {
    throw (promise ||= new Promise((res) => {
      setTimeout(() => {
        fullfilled = true;

        //throw new Error("Something broke");

        res();
      }, ms);
    }));
  }
};

const Slow = () => {
  useTimeout(3000);
  return (
    <Card sx={{ minWidth: 275, boxShadow: 3 }} variant="elevation">
      <CardContent>
        <Typography variant="h5" component="div">
          Loaded Slow Component
        </Typography>
      </CardContent>
    </Card>
  );
};

export default Slow;
