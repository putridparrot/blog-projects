use axum::{
    routing::get,
    extract::Query,
    http::StatusCode,
    response::IntoResponse,
    Router,
};
use tokio::net::TcpListener;
use axum::serve;
use std::net::SocketAddr;
use serde::Deserialize;

#[derive(Deserialize)]
struct EchoParams {
    text: Option<String>,
}

async fn echo(Query(params): Query<EchoParams>) -> String {
    format!("Rust Echo: {}", params.text.unwrap_or_default())
}

async fn livez() -> impl IntoResponse {
    (StatusCode::OK, "OK")
}

async fn readyz() -> impl IntoResponse {
    (StatusCode::OK, "Ready")
}

#[tokio::main]
async fn main() {
    let app = Router::new()
        .route("/echo", get(echo))
        .route("/livez", get(livez))
        .route("/readyz", get(readyz));

    let addr = SocketAddr::from(([0, 0, 0, 0], 8080));
    println!("Running on http://{}", addr);

    let listener = TcpListener::bind(addr).await.unwrap();
    serve(listener, app).await.unwrap();

}
