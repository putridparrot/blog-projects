use leptos::prelude::*;
use leptos_router::{
    components::{Route, Router, Routes},
    StaticSegment,
};
use crate::counter::Counter;
use crate::home::Home;

#[component]
pub fn App() -> impl IntoView {
    view! {
        <Router>
            <Routes fallback=|| "Page not found.">
                <Route path=StaticSegment("") view=Home />
                <Route path=StaticSegment("counter") view=Counter />
            </Routes>
        </Router>
    }
}