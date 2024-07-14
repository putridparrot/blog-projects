import Config

# We don't run a server during test. If one is required,
# you can enable the server option below.
config :my_api, MyApiWeb.Endpoint,
  http: [ip: {127, 0, 0, 1}, port: 4002],
  secret_key_base: "2F0Lm32TJ8rCiuaRNr6Hd29TdqD614jCMo4TlkbkH3kLpGI7tjvoncJgn0+O+jex",
  server: false

# Print only warnings and errors during test
config :logger, level: :warning

# Initialize plugs at runtime for faster test compilation
config :phoenix, :plug_init_mode, :runtime
