import { BaseQueryFn, FetchArgs, FetchBaseQueryError, createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

const dynamicBaseQuery: BaseQueryFn<string | FetchArgs, unknown, FetchBaseQueryError> = async (args, WebApi, extraOptions) => {
  const baseUrl = (WebApi.getState() as any).api.appSettings.contractsApiUrl;
  const rawBaseQuery = fetchBaseQuery({
    baseUrl,
    prepareHeaders: async (headers, { getState }) => {
      const token = (getState() as any).api.token;
      if (headers) {
        headers.set("Accept", "application/json");
        if(token) {
          headers.set("authorization", `Bearer ${token}`);
        }
      }

      return headers;
    },
  });
  return rawBaseQuery(args, WebApi, extraOptions);
};

export const contractsApi = createApi({
  reducerPath: "contractsApi",
  baseQuery: dynamicBaseQuery,
  tagTypes: [],
  endpoints: (builder) => ({
    getContract: builder.query<any, {contractId?: string, version?: string}>({
      query: (arg) => {
        const { contractId, version } = arg;        
        return {
          url: `api/GetContract?contractId=${contractId}&version=${version}`,
        }
      },
    }),
    getContractRevisions: builder.query({
      query: (contractId: string) => `api/GetContractRevisions?contractId=${contractId}`,
    }),
  }),
});
