import Image from 'next/image'

export default function Home() {
  return (
    <main className="flex min-h-screen flex-col items-center justify-between p-24">
      <nav>
        <a href='/'>Home</a> | <a href='/catalog'>Catalog</a>
      </nav>
      <h1>
        Home: Hello World
      </h1>
      <h2>
        Welcome to the store
      </h2>
    </main>
  )
}
