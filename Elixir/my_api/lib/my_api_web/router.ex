defmodule MyApiWeb.Router do
  use MyApiWeb, :router

  pipeline :api do
    plug :accepts, ["json"]
  end

  scope "/", MyApiWeb do
    pipe_through :api

    # this maps to the MathController and removes a bunch of auto-generator routes
    # resources "/api", MathController, except: [:new, :edit, :create, :delete, :update, :show]

    get "/add", MathController, :add
    get "/sub", MathController, :subtract
  end
end
