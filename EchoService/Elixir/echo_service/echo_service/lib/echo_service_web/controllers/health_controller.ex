defmodule EchoServiceWeb.HealthController do
  use Phoenix.Controller, formats: [:html, :json]

  def livez(conn, _params) do
    send_resp(conn, 200, "Live")
  end

  def readyz(conn, _params) do
    send_resp(conn, 200, "Ready")
  end
end
