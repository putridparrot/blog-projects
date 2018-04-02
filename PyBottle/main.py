from bottle import route, run, get, post, error, request

import jsonpickle

class Person:
    def __init__(self):
        self.firstName = "Eddie"
        self.lastName = "Van Halen"

# http://localhost:8080/putridparrot

@route('/<name>')
def index(name):
    return f"Hello {name}"

# http://localhost:8080/person

@get('/person')
def person():
    person = Person()
    return jsonpickle.encode(person, unpicklable=False)

@error(404)
def error404(error):
    return "Got a 404!"

run(host='localhost', port=8080)