import web

urls = (
    '/hello/(.*)', 'hello',
    '/index/(.*)', 'index'
)

render = web.template.render('templates/')

# http://localhost:8080/index/putridparrot

class index:
    def GET(self, name):
        return render.index(name)

# http://localhost:8080/hello/putridparrot

class hello:
    def GET(self, name):
        if not name:
            name = 'World'
        return 'Hello, ' + name + '!'

if __name__ == "__main__":
    app = web.application(urls, globals())
    app.run()