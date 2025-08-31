defmodule EchoServiceWeb.Router do
  use EchoServiceWeb, :router

  pipeline :api do
    plug :accepts, ["json"]
  end

  scope "/", EchoServiceWeb do
    # pipe_through :api
    get "/echo", EchoController, :index
    get "/livez", HealthController, :livez
    get "/readyz", HealthController, :readyz
  end
end
