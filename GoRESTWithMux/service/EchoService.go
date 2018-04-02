package service

import (
	"net/http"
	"github.com/gorilla/mux"
)

type IEchoService interface {
	Echo(string) string
}

type EchoService struct {

}

func (EchoService) Echo(value string) (string, error) {
	if value == "" {
		// create an error
		return "", nil
	}
	return value, nil
}

func (e EchoService) EchoHandler(w http.ResponseWriter, r *http.Request) {
	vars := mux.Vars(r)

	result, _ := e.Echo(vars["s"])

	w.WriteHeader(http.StatusOK)
	w.Write([]byte(result))
}

