#[macro_use] extern crate rocket;

use rocket::serde::{Serialize, json::Json};
use rocket_okapi::{openapi, openapi_get_routes};
use rocket_okapi::swagger_ui::{make_swagger_ui, SwaggerUIConfig};
use schemars::JsonSchema;

#[get("/")]
fn index() -> &'static str {
    "Hello, world!"
}

#[derive(Serialize, JsonSchema)]
struct EchoResponse {
    message: String,
}

#[openapi]
#[get("/echo?<text>")]
fn echo(text: &str) -> Json<EchoResponse> {
    Json(EchoResponse {
        message: format!("Echo: {}", text),
    })
}

#[launch]
fn rocket() -> _ {
    rocket::build()
        .mount("/", routes![index])
        .mount("/", openapi_get_routes![echo])
        .mount(
            "/swagger",
            make_swagger_ui(&SwaggerUIConfig {
                url: "/openapi.json".to_owned(),
                ..Default::default()
            })
        )
}
