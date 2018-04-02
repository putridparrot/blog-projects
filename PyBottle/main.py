from bottle import route, run

# pip install bottle

@route('/<name>')
def index(name):
    return f"Hello {name}"

run(host='localhost', port=8080)