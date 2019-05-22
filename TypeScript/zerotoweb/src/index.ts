class App {
    getSalutation() {
        return "Hello World"
    } 
}

let app = new App();
document.body.innerHTML = app.getSalutation();