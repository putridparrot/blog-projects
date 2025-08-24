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
            <button onclick={on_add_click}
                style="width: 100px;"
                class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">
                    { "+1" }</button>
            <p style="text-align: center">{ *counter }</p>
            <button onclick={on_subtract_click}
                style="width: 100px;"
                class="bg-emerald-500 hover:bg-emerald-700 text-white font-bold py-2 px-4 rounded">
                    { "-1" }</button>

// <div class="bg-white dark:bg-gray-800 rounded-lg px-6 py-8 ring shadow-xl ring-gray-900/5" style="width: 300px;">
//   <div>
//     <span class="inline-flex items-center justify-center rounded-md bg-indigo-500 p-2 shadow-lg">
//       <svg
//         class="h-6 w-6 text-white"
//         fill="none"
//         viewBox="0 0 24 24"
//         stroke="currentColor"
//         aria-hidden="true"
//       >
//         <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M11 5H6a2 2 0 00-2 2v11a2 2 0 002 2h11a2 2 0 002-2v-5m-1.414-9.414a2 2 0 112.828 2.828L11.828 15H9v-2.828l8.586-8.586z"></path>
//       </svg>
//     </span>
//   </div>
//   <h3 class="text-gray-900 dark:text-white mt-5 text-base font-medium tracking-tight ">{ "Writes upside-down" }</h3>
//   <p class="text-gray-500 dark:text-gray-400 mt-2 text-sm ">
//     { "The Zero Gravity Pen can be used to write in any orientation, including upside-down. It even works in outer space." }
//   </p>
// </div>
        </div>
    }
}
