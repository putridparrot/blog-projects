import { PayloadAction, createSlice } from "@reduxjs/toolkit";

export interface IQueryParams {
  gitUser?: string;
  repoName?: string;
}

const initialState: IQueryParams = {
  gitUser: "",
  repoName: "",
}

const queryParamsSlice = createSlice({
  name: "queryParams",
  initialState: initialState,
  reducers: {
    setQueryParams: (_, action: PayloadAction<IQueryParams>) => 
      action.payload,
  },
});

export const { setQueryParams } = queryParamsSlice.actions;

export default queryParamsSlice.reducer;
