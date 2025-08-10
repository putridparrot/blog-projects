package main

import (
	"fmt"
	"net/http"
)

func livezHandler(w http.ResponseWriter, r *http.Request) {
	w.WriteHeader(http.StatusOK)
	w.Write([]byte("ok\n"))
}

func readyzHandler(w http.ResponseWriter, r *http.Request) {
	w.WriteHeader(http.StatusOK)
	w.Write([]byte("ok\n"))
}

func echoHandler(w http.ResponseWriter, r *http.Request) {
	text := r.URL.Query().Get("text")
	fmt.Fprintf(w, "Go Echo: %s\n", text)
}

func main() {
	http.HandleFunc("/echo", echoHandler)
	http.HandleFunc("/livez", livezHandler)
	http.HandleFunc("/readyz", readyzHandler)

	fmt.Println("Echo service running on port 8080...")
	err := http.ListenAndServe(":8080", nil)
	if err != nil {
		fmt.Println("Failed to start the service")
		return
	}
}
