defmodule MyApiWeb.MathController do
  #use MyApiWeb, :controller
  use Phoenix.Controller, formats: [:html, :json]

  # def index(conn, _params) do
  #  json(conn, "{name: Scooby}")
  # end

  # http://localhost:4000/add?a=10&b=5
  def add(conn, %{"a" => a, "b" => b}) do
    text(conn, String.to_integer(a) + String.to_integer(b))
  end

  # http://localhost:4000/subtract?a=10&b=5
  def subtract(conn, %{"a" => a, "b" => b}) do
    text(conn, String.to_integer(a) - String.to_integer(b))
   end

 end
