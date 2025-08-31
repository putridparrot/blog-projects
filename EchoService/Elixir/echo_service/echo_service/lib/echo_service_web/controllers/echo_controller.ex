defmodule EchoServiceWeb.EchoController do
  use Phoenix.Controller, formats: [:html, :json]

  def index(conn, %{"text" => text}) do
    send_resp(conn, 200, "Elixir Echo: #{text}")
  end
end
