defmodule Simple.Messages do
  # def say_hello(), do: "Hello World"
  defp say_hello(name), do: "Hello #{name}"

  def say_hello_scooby(), do: say_hello("Scooby")
end
