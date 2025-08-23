use leptos::prelude::*;

#[component]
pub fn Counter() -> impl IntoView {
    let (count, set_count) = signal(0);

    view! {

        <button on:click=move |_| *set_count.write() += 1>Up</button>
        <div>{count}</div>
        <button on:click=move |_| set_count.set(count.get() - 1)>Down</button>
    }
}