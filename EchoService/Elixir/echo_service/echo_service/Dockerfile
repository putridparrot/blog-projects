FROM elixir:latest

RUN mkdir /app
COPY . /app
WORKDIR /app

RUN mix local.hex --force
RUN mix do compile

ENV PORT=8080
EXPOSE 8080

CMD ["mix", "phx.server"]
