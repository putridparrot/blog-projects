mod app;
mod counter;
mod layout;

use app::App;

fn main() {
    yew::Renderer::<App>::new().render();
}