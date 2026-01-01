FROM rust:1.89.0-slim AS builder

WORKDIR /app
COPY . .

RUN cargo build --release

FROM debian:bookworm-slim

RUN apt-get update && apt-get install -y ca-certificates && \
    rm -rf /var/lib/apt/lists/*

COPY --from=builder /app/target/release /usr/local/bin/crj

RUN chmod +x /usr/local/bin/crj

EXPOSE 8080

ENTRYPOINT ["/usr/local/bin/crj/crj"]