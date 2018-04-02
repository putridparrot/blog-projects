package main

import (
	"../service"
	"github.com/gorilla/mux"
	"log"
	"net/http"
)

func main() {

	svc := service.EchoService{}

	router := mux.NewRouter()

	router.HandleFunc("/echo/{s}", svc.EchoHandler).Methods("GET")
	router.HandleFunc("/", WelcomeHandler).Methods("GET")

	log.Fatal(http.ListenAndServe(":8080", router))
}

func WelcomeHandler(w http.ResponseWriter, r *http.Request) {
	w.WriteHeader(http.StatusOK)
	w.Write([]byte("Welcome to the EchoService"))
}