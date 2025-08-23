use yew::prelude::*;

#[function_component(Counter)]
pub fn counter() -> Html {
    let counter = use_state(|| 0);
    let on_add_click = {
        let c = counter.clone();
        move |_| { c.set(*c + 1); }
    };

    let on_subtract_click = {
        let c = counter.clone();
        move |_| { c.set(*c - 1); }
    };

    html! {
        <div>
            <button onclick={on_add_click}>{ "+1" }</button>
            <p>{ *counter }</p>
            <button onclick={on_subtract_click}>{ "-1" }</button>
        </div>
    }
}
