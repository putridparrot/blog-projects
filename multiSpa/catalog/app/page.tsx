import Image from 'next/image'

export default function Home() {
  return (
    <main className="flex min-h-screen flex-col items-center justify-between p-24">
      <nav>
        <a href='/'>Home</a> | <a href='/catalog'>Catalog</a>
      </nav>
      <h1>
        Catalog: Hello World
      </h1>
      <h2>
        List of products
      </h2>
    </main>
  )
}
