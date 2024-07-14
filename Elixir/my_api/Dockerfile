FROM elixir:latest

# ENV PHX_SERVER=true

# RUN mkdir /app
# COPY /_build/dev/ /app
# WORKDIR /app/rel/my_api/bin

# EXPOSE 4000

# CMD ["./my_api", "start"]

RUN mkdir /app
COPY . /app
WORKDIR /app

RUN mix local.hex --force
RUN mix do compile

EXPOSE 4000

CMD ["mix", "phx.server"]

# docker build -t pp/my-api:0.1.0 .
# docker run --rm --name my-api -p 4000:4000 -d pp/my-api:0.1.0