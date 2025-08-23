mod app;
mod counter;

use app::App;

fn main() {
    yew::Renderer::<App>::new().render();
}