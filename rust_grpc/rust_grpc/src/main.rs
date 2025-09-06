mod generated;

use tokio::spawn;
use tokio::time::{sleep, Duration};
use tonic::{Request, Response, Status};
use tonic::transport::Server;
use crate::generated::hello::greeter_client::GreeterClient;
use crate::generated::hello::greeter_server::{Greeter, GreeterServer};
use crate::generated::hello::{HelloReply, HelloRequest};

#[tokio::main]
async fn main() -> Result<(), Box<dyn std::error::Error>> {
    spawn(async {
        grpc_server().await.unwrap();
    });

    sleep(Duration::from_millis(500)).await;

    grpc_client().await?;
    
    Ok(())
}

async fn grpc_server() -> Result<(), Box<dyn std::error::Error>> {
    let addr = "[::1]:50051".parse()?;
    let greeter = GreeterService::default();

    println!("Server listening on {}", addr);

    Server::builder()
        .add_service(GreeterServer::new(greeter))
        .serve(addr)
        .await?;

    Ok(())
}

async fn grpc_client() -> Result<(), Box<dyn std::error::Error>> {

    let mut client = GreeterClient::connect("http://[::1]:50051").await?;

    let request = Request::new(HelloRequest {
        name: "PutridParrot".into(),
    });
    let response = client.say_hello(request).await?;

    println!("Response is {:?}", response.into_inner().message);
    Ok(())
}

#[derive(Default)]
pub struct GreeterService {}

#[tonic::async_trait]
impl Greeter for GreeterService {
    async fn say_hello(
        &self,
        request: Request<HelloRequest>,
    ) -> Result<Response<HelloReply>, Status> {
        let name = request.into_inner().name;
        let reply = HelloReply {
            message: format!("Hello, {}!", name),
        };
        Ok(Response::new(reply))
    }
}
