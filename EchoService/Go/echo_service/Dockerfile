# Dockerfile
FROM golang:1.24-alpine
WORKDIR /app
COPY . .
RUN go build -o echo_service .
CMD ["./echo_service"]