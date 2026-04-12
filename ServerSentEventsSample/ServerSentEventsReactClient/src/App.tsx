import { useEffect, useRef, useState } from 'react'
import './App.css'

type TickEvent = {
  id: number
  message: string
  sentAtUtc: string
}

const maxItems = 50

function App() {
  const [events, setEvents] = useState<TickEvent[]>([])
  const [isConnected, setIsConnected] = useState(false)
  const [status, setStatus] = useState('Disconnected')
  const eventSourceRef = useRef<EventSource | null>(null)

  useEffect(() => {
    return () => {
      eventSourceRef.current?.close()
      eventSourceRef.current = null
    }
  }, [])

  const connect = () => {
    if (eventSourceRef.current) {
      return
    }

    setStatus('Connecting...')

    const eventSource = new EventSource(import.meta.env.VITE_SSE_URL ?? '/events')
    eventSourceRef.current = eventSource

    eventSource.onopen = () => {
      setIsConnected(true)
      setStatus('Connected')
    }

    eventSource.addEventListener('tick', (event) => {
      const messageEvent = event as MessageEvent<string>

      try {
        const payload = JSON.parse(messageEvent.data) as TickEvent
        setEvents((previous) => [payload, ...previous].slice(0, maxItems))
      } catch {
        setStatus('Received malformed event payload')
      }
    })

    eventSource.onerror = () => {
      setStatus('Connection lost or closed by server')
      setIsConnected(false)
      eventSource.close()
      eventSourceRef.current = null
    }
  }

  const disconnect = () => {
    eventSourceRef.current?.close()
    eventSourceRef.current = null
    setIsConnected(false)
    setStatus('Disconnected')
  }

  const clear = () => setEvents([])

  return (
    <main className="app">
      <h1>Server Sent Events Demo</h1>
      <p className="subtitle">React + TypeScript client for the ServerSentEventsSample API</p>

      <div className="controls">
        <button onClick={connect} disabled={isConnected}>Connect</button>
        <button onClick={disconnect} disabled={!isConnected}>Disconnect</button>
        <button onClick={clear} disabled={events.length === 0}>Clear</button>
      </div>

      <p className="status">
        Status: <strong>{status}</strong>
      </p>

      <ul className="event-list">
        {events.length === 0 && <li className="empty">No events yet.</li>}
        {events.map((item) => (
          <li key={`${item.id}-${item.sentAtUtc}`}>
            <div className="row">
              <span className="id">#{item.id}</span>
              <span>{item.message}</span>
            </div>
            <time dateTime={item.sentAtUtc}>
              {new Date(item.sentAtUtc).toLocaleTimeString()}
            </time>
          </li>
        ))}
      </ul>
    </main>
  )
}

export default App
