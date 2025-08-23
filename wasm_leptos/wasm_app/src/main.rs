mod counter;
mod home;
mod app;

use leptos::mount::mount_to_body;
use leptos::view;
use crate::app::App;
use leptos_meta::*;

fn main() {
    mount_to_body(|| {
        provide_meta_context();
        view! {
            <Title text="Welcome to My App" />
            <Meta name="description" content="This is my app." />
            <App />
        }
    });
}