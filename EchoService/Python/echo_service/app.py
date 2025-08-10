from flask import Flask, request

app = Flask(__name__)

@app.route('/echo')
def echo():
    text = request.args.get('text', '')
    return f"Python Echo: {text}", 200

@app.route('/livez')
def livez():
    return "OK", 200

@app.route('/readyz')
def readyz():
    return "Ready", 200

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=8080)