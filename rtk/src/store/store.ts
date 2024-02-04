import { combineReducers, configureStore } from '@reduxjs/toolkit'
import counterReducer from './slices/counter.slice'
import { pokemonApi } from '../services/pokemon'
import queryParamsSlice from './slices/queryParams.slice'
import { contractsApi } from '../services/contracts'

const rootReducer = combineReducers({
    queryParamsSlice,
    counter: counterReducer,
    api: pokemonApi.reducer,
    contractsApi: contractsApi.reducer
  })
  
  export const setupStore = (preloadedState?: Partial<RootState>) => {
    return configureStore({
      reducer: rootReducer,
      middleware: (getDefaultMiddleware) =>
        // adding the api middleware enables caching, invalidation, polling and other features of `rtk-query`
        getDefaultMiddleware()
          .concat([contractsApi.middleware,  pokemonApi.middleware]),
      preloadedState,
    })
  }
  
  export type RootState = ReturnType<typeof rootReducer>
  export type AppStore = ReturnType<typeof setupStore>
  export type AppDispatch = AppStore['dispatch']