defmodule HelloWorld.Application do
  # See https://hexdocs.pm/elixir/Application.html
  # for more information on OTP Applications
  @moduledoc false

  use Application

  @impl true
  def start(_type, _args) do
    children = [
      # Starts a worker by calling: HelloWorld.Worker.start_link(arg)
      # {HelloWorld.Worker, arg}
    ]

#    IO.puts Simple.Messages.say_hello_scooby()

#    IO.puts Simple.Messages.say_hello("Scooby")
#    anon = fn (name) -> "Hello #{name}" end
    #anon = &(name) "Hello #{name}"
    #IO.puts anon.("Scooby")
    anon = &("Hello #{&1}")
    IO.puts anon.("Scooby")

    # list
    list = [:one, 2, "Three"]
    Enum.each(list, &(IO.puts &1))

    # See https://hexdocs.pm/elixir/Supervisor.html
    # for other strategies and supported options
    opts = [strategy: :one_for_one, name: HelloWorld.Supervisor]
    Supervisor.start_link(children, opts)
  end
end
