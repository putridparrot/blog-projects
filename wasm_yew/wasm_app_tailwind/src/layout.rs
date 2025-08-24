use yew::prelude::*;

#[function_component(Layout)]
pub fn counter() -> Html {
  html! {
<div class="min-h-screen w-screen flex flex-col">
  <nav class="bg-red-800 text-white px-6 py-4 flex justify-between items-center">
    <div class="text-base font-semibold">{ "My Application"  }</div>
    <ul class="flex space-x-6">
      <li><a href="#" class="hover:text-gray-300 text-base">{"Home"}</a></li>
      <li><a href="#" class="hover:text-gray-300 text-base">{"About"}</a></li>
      <li><a href="#" class="hover:text-gray-300 text-base">{"Services"}</a></li>
      <li><a href="/counter" class="hover:text-gray-300 text-base">{"Counter"}</a></li>
    </ul>
  </nav>

  <main class="flex-grow bg-gray-100 p-6">
    <p class="text-gray-700">{"This is where your content will go."}</p>
  </main>

  // <footer class="bg-gray-800 text-white text-center py-4">
  //   { "2025 My Application. All rights reserved." }
  // </footer>
</div>
    }
}