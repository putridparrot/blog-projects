use yew::prelude::*;
use yew_router::prelude::*;
use crate::counter::Counter;
use crate::layout::Layout;

#[derive(Clone, Routable, PartialEq)]
enum Route {
    #[at("/")]
    Home,
    #[at("/counter")]
    Counter,
    #[at("/layout")]
    Layout,
    #[not_found]
    #[at("/404")]
    NotFound,
}

fn switch(routes: Route) -> Html {
    match routes {
        Route::Home => html! { <h1>{ "Home" }</h1> },
        Route::Counter => { html! { <Counter /> }},
        Route::Layout => { html! { <Layout /> }},
        Route::NotFound => html! { <h1>{ "404" }</h1> },
    }
}

#[function_component(App)]
pub fn app() -> Html {
    html! {
        <BrowserRouter>
            <Switch<Route> render={switch} />
        </BrowserRouter>
    }
}
